using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	//Reference to our GameManager script
	public GameManager gameManager;
	
	//Enemies Start/End Positions
	float startingPos;
	float endPos;
	
	//Units Enemy Moves Right
	public int unitsToMove = 4;
	
	//Enemies Movement Speed
	public int moveSpeed = 2;
	
	//Enemy moving Right/Left
	bool moveRight = true;

	
	void Awake() 
	{
		startingPos = transform.position.y;
		endPos = startingPos + unitsToMove;
	}
	
	void Update() {
		
		if (moveRight) {
			transform.position += Vector3.up * moveSpeed * Time.deltaTime;
		}
		
		if (!moveRight) {
			transform.position -= Vector3.up * moveSpeed * Time.deltaTime;
		}
		
		if (transform.position.y >= endPos) {
			moveRight = false;
		} 
		
		if (transform.position.y <= startingPos) {
			moveRight = true;
		}
	}
}
