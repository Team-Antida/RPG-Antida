﻿using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	int damageValue = 1;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy") 
		{
			Destroy(gameObject);
			other.gameObject.SendMessage("EnemyDamaged",damageValue,SendMessageOptions.DontRequireReceiver);
		}

		if (other.gameObject.tag == "Wall") 
		{
			Destroy(gameObject);	
		}
	}

	void FixedUpdate()
	{
		Destroy (gameObject, 1.25f);
	}
}