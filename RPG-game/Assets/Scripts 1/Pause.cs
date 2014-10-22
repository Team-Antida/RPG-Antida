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
}