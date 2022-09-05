using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFunctionality : MonoBehaviour
{
    public float enemyMovementSpeed;

    int enemyMovementSpeedModifier = 1;

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
        transform.Translate(Vector2.left * enemyMovementSpeed * enemyMovementSpeedModifier * Time.deltaTime);

        // Upon the enemy reaching the other side of the screen, said enemy is destroyed and the player loses a life
        if (enemyTransform.position.x <= -8.80)
        {
            // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
            Destroy(gameObject);

            GameController gc = GameObject.FindObjectOfType<GameController>();

            gc.DecreasePlayerLives();
        }
    }

    // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
    // Defines the consequences of a bullet hitting an enemy
    void OnTriggerEnter2D(Collider2D detectCollision)
    {
        // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
        Debug.Log(detectCollision.name);

        // Upon an enemy being hit by a bullet, their health decreases by 1 and a sound and an animation play
        if (detectCollision.gameObject.name == "Bullet(Clone)")
        {
            // Referenced: "MELEE COMBAT in Unity" by Brackeys
            enemyAnimator.SetTrigger("EnemyHasBeenHit");

            enemyHealth--;

            AudioSource.PlayClipAtPoint(enemyHitSound, enemyTransform.position);

            // Referenced: "Coroutines with IEnumerator & WaitForSeconds - Unity - C# Scripting Tutorial" by Learn Everything Fast
            StartCoroutine(StopEnemyMovement());   
        }

        // Upon the enemy's health reaching 0, a sound plays, the enemy vanishes, and the player's score increases
        if (enemyHealth == 0)
        {
            AudioSource.PlayClipAtPoint(enemyDeathSound, enemyTransform.position);

            // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
            Destroy(gameObject);

            GameController gc = GameObject.FindObjectOfType<GameController>();

            gc.IncreasePlayerScore();
        }
    }

    // Upon the enemy colliding with the Main Character, said enemy is destroyed and the player loses a life
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

    // Referenced: "Coroutines with IEnumerator & WaitForSeconds - Unity - C# Scripting Tutorial" by Learn Everything Fast
    // Upon the enemy being hit by a bullet, said enemy ceases moving for a brief period
    IEnumerator StopEnemyMovement()
    {
        enemyMovementSpeedModifier = 0;

        // Referenced: "Coroutines with IEnumerator & WaitForSeconds - Unity - C# Scripting Tutorial" by Learn Everything Fast
        yield return new WaitForSeconds(0.25f);

        enemyMovementSpeedModifier = 1;
    }
}
