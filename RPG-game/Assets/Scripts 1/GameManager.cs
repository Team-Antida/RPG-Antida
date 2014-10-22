using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	//Reference to COntroller2D script
	public Controller2D controller2D;
	//Players life
	public Texture playersHealthTexture;
	//Control screen position of texture
	public float screenPositionX;
	public float screenPositionY;

	//Controls icon size on screen
	public float iconSizeX = 25;
	public float iconSizeY = 25;
	//Starting lifes
	public int playersHealth = 3;
	// Use this for initialization

	public int currentEXP = 0;
	int maxEXP = 50;
	int level = 1;
	
	bool playerStats;
	public GUIText statsDisplay;

	void Update()
	{
		if (currentEXP >= maxEXP) 
		{
			LevelUp();
		}
		
		if (Input.GetKeyDown(KeyCode.C)) 
		{
			playerStats = !playerStats;
		}
		
		if(playerStats)
		{
			statsDisplay.text = "Level " + level + ":  XP " + currentEXP + " / " + maxEXP;		
		}
		else
		{
			statsDisplay.text = "";
		}
	}
	
	void LevelUp()
	{
		currentEXP = 0;
		maxEXP = maxEXP + 50;
		level++;
		
		//Add Stats When Leveling
		playersHealth++;
	}

	void OnGUI()
	{
		//Controls players healths texture
		for (int h = 0; h < playersHealth; h++) 
		{
			GUI.DrawTexture(new Rect(screenPositionX+(h*iconSizeX),screenPositionY,iconSizeX,iconSizeY),playersHealthTexture,ScaleMode.ScaleToFit,true,0);

		}
	}
	void PlayerDamage(int damage)
	{
		if (playersHealth > 0)
		{
			playersHealth -= damage;
		}
		if (playersHealth <= 0)
		{
			playersHealth = 0;
			RestartScene();
		}
	}
	void RestartScene()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
}
