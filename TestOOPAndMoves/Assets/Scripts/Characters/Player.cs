using UnityEngine;
using System.Collections;

public class Player : ScriptableObject, IHumanoid 
{
	public string Name { get; set; }

	public Player(string name)
	{ 
		this.Name = name;
	}	
}
