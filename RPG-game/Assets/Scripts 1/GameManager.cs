using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	//Reference to COntroller2D script
	public Controller2D controller2D;
	//Players life
	public Texture playersHealthTexture;
	public Texture heartTexture;
	public Texture shootTexture;
	//Control screen position of texture
	public float screenPositionX;
	public float screenPositionY;

	//Controls icon size on screen
	public float iconSizeX = 25;
	public float iconSizeY = 25;
	//Starting lifes
	public float timer= 0.0f;
	// Use this for initialization

	public int currentEXP = 0;
	int maxEXP = 150;
	int level = 1;

	bool playerStats;
	public GUIText statsDisplay;
	//Inventory store
	private int displayInventory ;
	private const int inventoryWindowId = 1;
	private Rect inventoryWindowRect = new Rect(680,10,80,200);
	
	void Start()
	{
		StartCoroutine(InventoryCoroutine()); 
	}
	//Inventory controls
	IEnumerator InventoryCoroutine() {
		
		while (true)
		{
			if (Input.GetKeyDown(KeyCode.I))
			{
				if (displayInventory == 0)
				{
					displayInventory = 1;
					Time.timeScale = 0;
				} else {
					displayInventory = 0;
					Time.timeScale = 1;
				}
				
			}    
			yield return null;    
		}
	}

	void Update()
	{
		timer += Time.deltaTime;
		if (timer > 5) {
			currentEXP += 10;
			timer = 0;
				}
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

        if (controller2D.playersHealth <= 0)
        {
            controller2D.playersHealth = 0;
            RestartScene();
        }
	}
	
	void LevelUp()
	{
		currentEXP = 0;
		maxEXP = maxEXP + 50;
		level++;
		
		//Add Stats When Leveling
		controller2D.playersHealth++;
	}

	void OnGUI()
	{
		//Controls players healths texture
		for (int h = 0; h < controller2D.playersHealth; h++) 
		{
			GUI.DrawTexture(new Rect(screenPositionX+(h*iconSizeX),screenPositionY,iconSizeX,iconSizeY),playersHealthTexture,ScaleMode.ScaleToFit,true,0);
		}
		//controls inventory - when to show
		if (displayInventory == 1) {
			inventoryWindowRect = GUI.Window(inventoryWindowId,inventoryWindowRect,InventoryWindow,"Inventory");
		}

		if(GUI.Button(new Rect(0, 30, 110, 20), "Restart")){
			RestartScene();
		}
	}



	public void RestartScene()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
	public void InventoryWindow(int id)
	{
		if (GUI.Button (new Rect (20, 40, 40, 50),heartTexture)&& currentEXP >=50)
		{
			controller2D.playersHealth++;
			currentEXP -=50;
		}
		if (GUI.Button (new Rect (20, 120, 40, 50),shootTexture) && currentEXP >=50)
		{
			controller2D.bulletForce +=10;
			currentEXP-=50;
		}
		GUI.DragWindow ();
	}
}
