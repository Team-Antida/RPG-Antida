using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public GameManager gameManager;

    // Constants:
    public static readonly int DefaultDamage = 1;

    int damageValue = Enemy.DefaultDamage;

    //enemy start and end pos
    private float startPos;
    private float endPos;

    //units enemy moves right
    private int unitsMove = 5;

    //enemy's movement speed
    private int moveSpeed = 5;

    //enemy moving right or left
    protected bool moveRight;

    //Enemy's health
    private int enemyHealth = 3;

    public int EnemyHealth
    {
        protected set
        {
            this.enemyHealth = value;
        }

        get
        {
            return this.enemyHealth;
        }
    }

    void Awake()
    {
        InitEnemy();
    }

    protected virtual void InitEnemy()
    {
        moveRight = true;
        startPos = transform.position.x;
        endPos = startPos + unitsMove;
    }

    void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        if (moveRight)
        {
            rigidbody.position += Vector3.right * moveSpeed * Time.deltaTime;
            rigidbody.transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
        }
        if (rigidbody.position.x >= endPos)
        {
            moveRight = false;
        }
        if (!moveRight)
        {
            rigidbody.transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
            rigidbody.position -= Vector3.right * moveSpeed * Time.deltaTime;
        }
        if (rigidbody.position.x <= startPos)
        {
            moveRight = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.SendMessage("PlayerDamage", damageValue, SendMessageOptions.DontRequireReceiver);
            col.gameObject.SendMessage("TakenDamage", SendMessageOptions.DontRequireReceiver);
        }
    }

    //enemy taking damage
	void EnemyDamaged(int damage)
    {
        if (enemyHealth > 0)
        {
            enemyHealth -= damage;
        }
        if (enemyHealth <= 0)
        {
            enemyHealth = 0;
            Destroy(gameObject);
      //      gameManager.currentEXP += 10;
        }
    }
}
