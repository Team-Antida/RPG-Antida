using UnityEngine;
using System.Collections;

public class HellBoar : Enemy
{

    // Fields:
    public static readonly int HellBoarHealth = 3;

    // Use this for initialization
    void Start()
    {

    }

    void Awake()
    {
        InitEnemy();
        this.EnemyHealth = HellBoar.HellBoarHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}