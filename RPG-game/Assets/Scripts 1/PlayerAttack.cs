using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public Rigidbody bulletPrefab;

	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.F)) 
		{
			BulletAttack();
		}
	}

	void BulletAttack()
	{
		Rigidbody bPrefab = Instantiate (bulletPrefab, transform.position, Quaternion.identity) as Rigidbody;
		bPrefab.rigidbody.AddForce (Vector3.right * 500);
	}
}
