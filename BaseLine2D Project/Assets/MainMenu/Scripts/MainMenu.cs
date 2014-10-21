// Main Menu
// Attached to Main Camera

using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Texture backgroundTexture;

	public float guiPlacementY1;
	public float guiPlacementY2;


	public float guiPlacementX1;
	public float guiPlacementX2;


	void OnGUI()
	{
		//Display our Background Texture
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);

		//Display our Buttons (With GUI OutLine)
		//Play Game Button
		if (GUI.Button (new Rect (
							Screen.width * guiPlacementX1,
							Screen.height * guiPlacementY1,
							Screen.width * .5f,
							Screen.height * .1f), "Play Game")){

			Application.LoadLevel("Scene1");
		}

		//Options Game Button
		if (GUI.Button (new Rect (
			Screen.width * guiPlacementX2,
			Screen.height * guiPlacementY2,
			Screen.width * .5f,
			Screen.height * .1f), "Options")){

			print("Options");
		}
	}
}
