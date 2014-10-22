using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	int damageValue = 1;
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy") 
		{
			Destroy(gameObject);
			other.gameObject.SendMessage("EnemyDamaged",damageValue,SendMessageOptions.DontRequireReceiver);
		}
	}

	//destroying bullet after 1.25 seconds
	void FixedUpdate()
	{
		Destroy (gameObject, 1.25f);
	}
}
