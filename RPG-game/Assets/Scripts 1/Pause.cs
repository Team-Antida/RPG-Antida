using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
	
	void Start()
	{
		StartCoroutine(PauseCoroutine());  
	}
	
	IEnumerator PauseCoroutine() {
		
		while (true)
		{
			if (Input.GetKeyDown(KeyCode.P))
			{
				if (Time.timeScale == 0)
				{
					Time.timeScale = 1;
				} else {
					Time.timeScale = 0;
				}
				
			}    
			yield return null;    
		}
    }

	/*public bool paused;
	void OnGUI() {
		if (paused) 
		{
			GUI.Label (new Rect (100, 100, 50, 50), "Game paused");
		}
		
	}
	void OnApplicationPause(bool pauseStatus) {
		paused = pauseStatus;
	}*/
}