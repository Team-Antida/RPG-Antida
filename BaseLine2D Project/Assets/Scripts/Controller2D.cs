using UnityEngine;
using System.Collections;

public class Controller2D : MonoBehaviour {

	//Reference to my Charachter controller 
	CharacterController characterController;

	//Controls graviry
	public float gravity = 10;
	public float walkSpeed = 5;
	public float jumpHeight = 5;

	//Shows that we have taken damage

	float takenDamage = 0.2f;


	//Controlling our  Player's movement directions
	Vector3 moveDirection = Vector3.zero;
	float horizontal = 0;

	//**Player Attack Vars**//
	public Rigidbody bulletPrefab;
	float attackRate = .5f;
	float coolDown;
	bool lookRight = true;

	// Use this for initialization
	void Start () 
	{
		characterController = GetComponent<CharacterController>();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Controls Character Controller
		characterController.Move (moveDirection * Time.deltaTime);
		horizontal = Input.GetAxis ("Horizontal");	

		// Controls player's gravity
		moveDirection.y -= gravity * Time.deltaTime;

		//Player Stands Still 
		if (horizontal == 0) 
		{
			moveDirection.x = horizontal;
		} 
		//Moves player right
		if (horizontal > .01f)  
		{
			lookRight = true;
			moveDirection.x = horizontal * walkSpeed;
		}	
		//Moves	 player left
		if (horizontal < -.01f) 
		{
			lookRight = false;
			moveDirection.x = horizontal * walkSpeed;
		}
		//Controls Jumping
		if (characterController.isGrounded) 
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				moveDirection.y = jumpHeight;
			}
		}
		//Controls Player Attack
		if(Time.time >= coolDown)
		{
			if (Input.GetKeyDown (KeyCode.F))
			{
				BulletAttack();
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
		yield return new WaitForSeconds(takenDamage);	
		renderer.enabled = true;
		yield return new WaitForSeconds(takenDamage);	
		renderer.enabled = false;
		yield return new WaitForSeconds(takenDamage);	
		renderer.enabled = true;
		yield return new WaitForSeconds(takenDamage);	
		renderer.enabled = false;
		yield return new WaitForSeconds(takenDamage);
		renderer.enabled = true;
		yield return new WaitForSeconds(takenDamage);	
	}
}
