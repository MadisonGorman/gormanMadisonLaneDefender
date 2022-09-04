using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFunctionality : MonoBehaviour
{
    // NOTE: Need to have Enemy Hit Animations Transition Back to the Movement Animations
    public float enemyMovementSpeed;

    public int enemyHealth;

    public Transform enemyTransform;

    public AudioClip enemyHitSound;

    public AudioClip enemyDeathSound;

    // Referenced: "2D Animation in Unity (Tutorial)" by Brackeys
    public Animator enemyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Referenced: answers.unity.com/questions/690884/how-to-move-an-object-along-x-axis-between-two-poi.html, "How to move an object along x-axis between two points?", Answer provided by robertbu, April 20, 2014 at 11:25PM
        // Results in the enemies continuously moving to the left at a distinct speed upon being spawned
        transform.Translate(Vector2.left * enemyMovementSpeed * Time.deltaTime);
    }

    // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
    // Defines the consequences of a bullet hitting an enemy
    void OnTriggerEnter2D(Collider2D detectCollision)
    {
        // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
        Debug.Log(detectCollision.name);

        // Upon an enemy being hit by a bullet, their health decreases by 1 and a sound plays
        if (detectCollision.gameObject.name == "Bullet(Clone)")
        {
            // Referenced: "2D Animation in Unity (Tutorial)" by Brackeys
            enemyAnimator.SetBool("EnemyHasBeenHit", true);

            enemyHealth--;

            AudioSource.PlayClipAtPoint(enemyHitSound, enemyTransform.position);
        }

        // Upon the enemy's health reaching 0, a sound plays and the enemy vanishes
        if (enemyHealth == 0)
        {
            AudioSource.PlayClipAtPoint(enemyDeathSound, enemyTransform.position);

            // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
            Destroy(gameObject);

            GameController gc = GameObject.FindObjectOfType<GameController>();

            gc.IncreasePlayerScore();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Main Character")
        {
            // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
            Destroy(gameObject);

            GameController gc = GameObject.FindObjectOfType<GameController>();

            gc.DecreasePlayerLives();
        }
    }
}
