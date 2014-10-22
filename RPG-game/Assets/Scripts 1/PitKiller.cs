using UnityEngine;
using System.Collections;

public class PitKiller : MonoBehaviour
{
    public GameManager gameManager;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Enemy")
        {
            gameManager.RestartScene();
        }
    }
}
