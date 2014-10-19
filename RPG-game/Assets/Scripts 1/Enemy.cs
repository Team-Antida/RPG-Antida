using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameManager gameManager;
	int damageValue = 1;
	//enemy start and end pos
	float startPos;
	float endPos;
	//units enemy moves right
	public int unitsMove = 5;
	//enemy's movement speed
	public int moveSpeed = 5;
	//enemy moving right or left
	bool moveRight = true;

	void Awake()
	{
		startPos = transform.position.x;
		endPos = startPos + unitsMove;
	}

	void Update()
	{
		if (moveRight) 
		{
			rigidbody.position += Vector3.right *moveSpeed*Time.deltaTime;
		}
		if (rigidbody.position.x >= endPos) 
		{
			moveRight = false;
		}
		if (!moveRight) 
		{
			rigidbody.position -= Vector3.right *moveSpeed*Time.deltaTime;
		}
		if (rigidbody.position.x <= startPos) 
		{
			moveRight = true;
		}
	}
	
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player") 
		{
			gameManager.SendMessage("PlayerDamage",damageValue,SendMessageOptions.DontRequireReceiver);
			gameManager.controller2D.SendMessage("TakenDamage",SendMessageOptions.DontRequireReceiver);
		}
	}
}
