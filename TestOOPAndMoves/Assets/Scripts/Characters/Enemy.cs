using UnityEngine;
using System.Collections;

public class Enemy : ScriptableObject, IHumanoid 
{
	public string Name { get; set; }

	public Enemy(string name)
	{
		this.Name = name;
	}
}
