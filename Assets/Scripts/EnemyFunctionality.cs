using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFunctionality : MonoBehaviour
{
    public float enemyMovementSpeed;

    public int enemyHealth;

    // public AudioClip enemyHitSound;

    // public AudioClip enemyDeathSound;

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
}
