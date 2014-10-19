using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		//doesnt work???
		if (other.gameObject.tag == "Enemy") 
		{
			Destroy(gameObject);
			Destroy(other.gameObject);
		}
	}
}
