using UnityEngine;
using System.Collections;

public class PitKiller : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            gameManager.SendMessage("PlayerDamage", 9999, SendMessageOptions.DontRequireReceiver);
            gameManager.controller2D.SendMessage("TakenDamage", SendMessageOptions.DontRequireReceiver);
        }
    }
}
