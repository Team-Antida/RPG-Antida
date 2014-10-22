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

	//Enemy's health
	int enemyHealth = 1;

	//types of enemies
	public bool basicEnemy;
	public bool advancedEnemy;

	void Awake()
	{
		startPos = transform.position.x;
		endPos = startPos + unitsMove;
		if (basicEnemy) 
		{
			enemyHealth = 3;
		}
		if (advancedEnemy)
		{
			enemyHealth = 6;
		}
	}

	void Update()
	{
		if (moveRight) 
		{
			rigidbody.position += Vector3.right *moveSpeed*Time.deltaTime;
			rigidbody.transform.rotation = Quaternion.Euler(transform.rotation.x,0,transform.rotation.z);
		}
		if (rigidbody.position.x >= endPos) 
		{
			moveRight = false;
		}
		if (!moveRight) 
		{
			rigidbody.transform.rotation = Quaternion.Euler(transform.rotation.x,180,transform.rotation.z);
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
	//enemy taking damage
	void EnemyDamaged(int damage)
	{
		if (enemyHealth > 0) 
		{
			enemyHealth -= damage;
		}
		if (enemyHealth <= 0)
		{
			enemyHealth = 0;
			Destroy(gameObject);
			gameManager.currentEXP += 10; 
		}
	}
}
