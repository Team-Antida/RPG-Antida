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
