using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public GameObject enemy;
    public GameManager gameManager;
	Vector3 spawnPosition;
	public float timer= 0.0f;
	
	void spawnEnemy ()
    {
		spawnPosition = new Vector3(0,0,0);
		Instantiate(enemy,spawnPosition,Quaternion.identity);
	}
	
	void  Update ()
    {
		timer += Time.deltaTime;
		if(timer > 10)
        {
			spawnEnemy();
			timer = 0.0f;
		}
	}
}

