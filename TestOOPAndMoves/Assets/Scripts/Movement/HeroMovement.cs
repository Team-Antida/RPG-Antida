using UnityEngine;
using System.Collections;

public class HeroMovement : MonoBehaviour 
{
	public const float moveSpeed = 0.2f;
	public const float rotationSpeed = 0.2f;
	
	public void PlayerMove (float move, float rotation)
	{
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			Vector2 position = this.transform.position;
			position.x--;
			this.transform.position = position;
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			Vector2 position = this.transform.position;
			position.x++;
			this.transform.position = position;
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			Vector2 position = this.transform.position;
			position.y++;
			this.transform.position = position;
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			Vector2 position = this.transform.position;
			position.y--;
			this.transform.position = position;
		}
	}
	
	void Start()
	{
		Hero hero = ScriptableObject.CreateInstance("Hero") as Hero;
		hero.Name = "hero";
		Debug.Log (hero.Name);
	}
	
	// Update is called once per frame
	void Update () 
	{
		PlayerMove (moveSpeed, rotationSpeed);
	}
}
