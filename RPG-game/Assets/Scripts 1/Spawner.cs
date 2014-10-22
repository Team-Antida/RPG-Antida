using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public GameObject enemy;
	Vector3 spawnPosition;
	public float timer= 0.0f;
	
	void  spawn_cube (){
		spawnPosition = new Vector3(0,0,0);
		Instantiate(enemy,spawnPosition,Quaternion.identity);
	}
	
	void  Update (){
		timer += Time.deltaTime;
		if(timer > 10){
			spawn_cube();
			timer = 0.0f;
		}
	}
}

