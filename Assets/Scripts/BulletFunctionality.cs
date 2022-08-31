using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFunctionality : MonoBehaviour
{   // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
    public float speed = 5;

    // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
    public Rigidbody2D bulletRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
        bulletRigidbody2D.velocity = transform.right * speed;
    } 

    // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
    void OnTriggerEnter2D(Collider2D detectCollision)
    {
        // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
        Debug.Log(detectCollision.name);

        // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
        //Destroy(gameObject);

        // NOTE: Need to ensure that the bullet is destroyed upon hitting an enemy or leaving the screen
    }
}
