using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	public Transform origin;
	public Transform destination;
	public float speed = 10f;
	private bool _switching;
	private Transform _myTransform;
	// Use this for initialization
	void Start () 
	{
		_myTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (_myTransform.position == origin.position) 
		{
			_switching = true;
		}
		if (_myTransform.position == destination.position) 
		{
			_switching = false;
		}
		if (_switching == true) 
		{
			_myTransform.position = Vector3.MoveTowards(_myTransform.position,destination.position,speed*Time.deltaTime);
		}
		if (_switching == false) 
		{
			_myTransform.position = Vector3.MoveTowards(_myTransform.position,origin.position,speed*Time.deltaTime);
		}
		
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "Player")
		{
			Debug.Log ("col");
			col.transform.parent = transform;
		}
	}
	
	void OnCollisionExit2D(Collision2D col)
	{
		col.transform.parent = null;
	}
}
