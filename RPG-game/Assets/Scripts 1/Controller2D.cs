﻿using UnityEngine;
using System.Collections;

public class Controller2D : MonoBehaviour {
	//reference to craracter controller

	CharacterController characterController;
	private Animator animator;
	//Controls gravity
	public float gravity = 1;

	//Walkspeed
	public float walkSpeed = 5;
	public float jumpHeight = 10;

	//Controlling our movement directions
	Vector3 moveDirection = Vector3.zero;
	float horizontal = 0;

	//Shows that we have taken damage
	float takenDamage = 0.2f;
	//player attack
	public Rigidbody bulletPrefab;
	
	float attackRate = 0.5f;
	float coolDown;

	bool lookRight = true;
	// Use this for initialization
	void Start ()
	{
		characterController = GetComponent<CharacterController> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Controls player movement
		characterController.Move (moveDirection * Time.deltaTime);
		horizontal = Input.GetAxisRaw ("Horizontal");

		//Playing animation
		animator.SetFloat ("Speed",Mathf.Abs( horizontal));
		//Controls players gravity
		moveDirection.y -= gravity * Time.deltaTime;

		if (horizontal > 0.01f) 
		{
			lookRight = true;
			moveDirection.x = horizontal*walkSpeed;
			transform.rotation = Quaternion.Euler(transform.rotation.x,0,transform.rotation.z);
		}
		//Moves player left		
		if (horizontal< 0.01f) 
		{
			lookRight = false;
			moveDirection.x = horizontal*walkSpeed;
			transform.rotation = Quaternion.Euler(transform.rotation.x,180,transform.rotation.z);
		} 


		if (horizontal == 0)  
		{
			moveDirection.x = horizontal;
			transform.rotation = Quaternion.Euler(transform.rotation.x,0,transform.rotation.z);
			lookRight = true;
		}


		//Controls jumping
		if (characterController.isGrounded)
		{
			animator.SetBool("Jump",false);
			if (Input.GetKeyDown(KeyCode.Space)) 
			{
				animator.SetBool("Jump",true);
				moveDirection.y = jumpHeight;
			}
		}
		//Controls player attack
		if (Time.time >= coolDown)
		{
			if (Input.GetKeyDown (KeyCode.F)) {
				BulletAttack ();
			}
		}
	}
	void BulletAttack()
	{
		if (lookRight)
		{
			Rigidbody bPrefab = Instantiate (bulletPrefab, transform.position, Quaternion.identity) as Rigidbody;
			bPrefab.rigidbody.AddForce (Vector3.right * 500);
			coolDown = Time.time + attackRate;
		} 
		else 
		{
			Rigidbody bPrefab = Instantiate (bulletPrefab, transform.position, Quaternion.identity) as Rigidbody;
			bPrefab.rigidbody.AddForce (-Vector3.right * 500);
			coolDown = Time.time + attackRate;
		}
	}

	public IEnumerator TakenDamage()
	{
		renderer.enabled = false;
		yield return new WaitForSeconds (takenDamage);
		renderer.enabled = true;
		yield return new WaitForSeconds (takenDamage);
		renderer.enabled = false;
		yield return new WaitForSeconds (takenDamage);
		renderer.enabled = true;
		yield return new WaitForSeconds (takenDamage);
		renderer.enabled = false;
		yield return new WaitForSeconds (takenDamage);
		renderer.enabled = true;
		yield return new WaitForSeconds (takenDamage);
	}
}