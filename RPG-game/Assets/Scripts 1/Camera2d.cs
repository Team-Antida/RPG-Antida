using UnityEngine;
using System.Collections;

public class Camera2d : MonoBehaviour {

	public Transform player;
	public float smoothRate = 0.5f;

	private Transform thisTransform;
	private Vector2 velocity;

	// Use this for initialization
	void Start () {
		thisTransform = transform;
		velocity = new Vector2 (0.5f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 newPosition2D = Vector2.zero;
		newPosition2D.x = Mathf.SmoothDamp (thisTransform.position.x, player.position.x,ref velocity.x,smoothRate);
		newPosition2D.y = Mathf.SmoothDamp (thisTransform.position.y, player.position.y,ref velocity.y,smoothRate);

		Vector3 newPos = new Vector3 (newPosition2D.x, newPosition2D.y, transform.position.z);
		transform.position = Vector3.Slerp(transform.position,newPos,Time.time);
	}
}
