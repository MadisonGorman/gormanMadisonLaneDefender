using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NOTE: Need to ensure that the bullet is destroyed upon leaving the screen
public class BulletFunctionality : MonoBehaviour
{   // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
    public float bulletSpeed = 7;

    // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
    public Rigidbody2D bulletRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
        // Enables the bullets to continuously travel to the right at the defined speed 
        bulletRigidbody2D.velocity = transform.right * bulletSpeed;
    } 

    // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
    // Upon the bullet hitting an enemy, said bullet is destroyed
    void OnTriggerEnter2D(Collider2D detectCollision)
    {
        // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
        Debug.Log(detectCollision.name);

        if(detectCollision.gameObject.name == "Blue Slime Enemy(Clone)")
        {
            // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
            Destroy(gameObject);
        }

        if (detectCollision.gameObject.name == "Snail Enemy(Clone)")
        {
            // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
            Destroy(gameObject);
        }

        if (detectCollision.gameObject.name == "Snake Enemy(Clone)")
        {
            // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
            Destroy(gameObject);
        }
    }
}
