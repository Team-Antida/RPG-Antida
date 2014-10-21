using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//reference to my Controller2D Script
	public Controller2D controller2D;

	//Players Life
	public Texture playersHealthTexture;

	//Controls Screen Position of Texture
	public float screenPositionX;
	public float screenPositionY;

	//Controls Icon size of Screen
	public int iconSizeX = 25;
	public int iconSizeY = 25;

	//Starting Life
	public int playerHealth = 3;

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

		//if (Input.GetKeyDown(KeyCode.E))
		//{
		//	currentEXP += 10; 
		//}

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
		playerHealth++;
	}

	void OnGUI(){
		//Controls Player's Health Textures
		for (int h = 0; h < playerHealth; h++) {
			GUI.DrawTexture(new Rect
			                (screenPositionX + (h * iconSizeX), screenPositionY, iconSizeX, iconSizeY), 
			                playersHealthTexture, 
			                ScaleMode.ScaleToFit,
			                true,
			                0);
		}
	}

	void PlayerDamage(int damage){

		if (playerHealth > 0) {
			playerHealth -= damage;
		}

		if (playerHealth <= 0) {
			playerHealth = 0;
			RestartScene();
		}
	}

	void RestartScene(){
		Application.LoadLevel(Application.loadedLevel);
	}
}
