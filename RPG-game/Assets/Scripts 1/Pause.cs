using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
	
	/*void Start()
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
    }*/

	private bool paused = false;

	void Update () {
		if(Input.GetKeyUp(KeyCode.P))
		{
			paused = !paused;
		}
		
		if(paused)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
	}
}