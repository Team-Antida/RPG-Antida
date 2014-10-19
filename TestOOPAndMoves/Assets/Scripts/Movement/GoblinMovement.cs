using UnityEngine;
using System.Collections;

public class GoblinMovement : MonoBehaviour 
{
	public Transform target;
	public const float speed = 2f;
	public const float minDistance = 0.5f;
	
	public void EnemyMove (Transform targ, float currentSpeed, float distance)
	{
		float range = Vector2.Distance (transform.position, targ.position);
		if (range > distance) {
			Debug.Log (range);
			transform.position = Vector2.MoveTowards (transform.position, targ.position, currentSpeed * Time.deltaTime);
		}
	}
	
	void Start()
	{
		Goblin goblin = ScriptableObject.CreateInstance ("Goblin") as Goblin;
		goblin.Name = "goblin";
	}
	
	void Update ()
	{
		EnemyMove (target, speed, minDistance);
	}
}
