using UnityEngine;
using System.Collections;

public class Orc : Enemy {

	// Fields:
	public static readonly int OrcHealth = 4;
	
	// Use this for initialization
	void Start()
	{
		
	}
	
	void Awake()
	{
		InitEnemy();
		this.EnemyHealth = Orc.OrcHealth;
	}
	
	// Update is called once per frame
	void Update()
	{
		Move();
	}
}
