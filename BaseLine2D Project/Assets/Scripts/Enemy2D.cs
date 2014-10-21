using UnityEngine;
using System.Collections;

public class Enemy2D : MonoBehaviour {

	//Reference to our GameManager script
	public GameManager gameManager;

	//Enemies Start/End Positions
	float startingPos;
	float endPos;

	//Units Enemy Moves Right
	public int unitsToMove = 5;

	//Enemies Movement Speed
	public int moveSpeed = 2;

	//Enemy moving Right/Left
	bool moveRight = true;

	//Enemy Health
	int enemyHealth = 1;

	//Types of Enemy
	public bool basicEnemy;
	public bool advancedEnemy;

	void Awake() {

		startingPos = transform.position.x;
		endPos = startingPos + unitsToMove;

		if (basicEnemy) 
		{
			enemyHealth = 3;
		}

		if (advancedEnemy) 
		{
			enemyHealth = 6;
		}

	}

	void Update() {

		if (moveRight) {
			rigidbody.position += Vector3.right * moveSpeed * Time.deltaTime;
		}

		if (!moveRight) {
			rigidbody.position -= Vector3.right * moveSpeed * Time.deltaTime;
		}

		if (rigidbody.position.x >= endPos) {
			moveRight = false;
		}

		if (rigidbody.position.x <= startingPos) {
			moveRight = true;
		}
	}

	//Enemy Damage Value
	int damageValue = 1;

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			gameManager.SendMessage("PlayerDamage",damageValue, SendMessageOptions.DontRequireReceiver);
			gameManager.controller2D.SendMessage("TakenDamage",SendMessageOptions.DontRequireReceiver);
		}
	}

	//Enemy Taking Damage
	void EnemyDamaged(int damage)
	{
		if(enemyHealth > 0)
		{
			enemyHealth -= damage;
		}

		if(enemyHealth <= 0)
		{
			enemyHealth = 0;
			Destroy(gameObject);
			gameManager.currentEXP += 10; 
		}
	}
}
	