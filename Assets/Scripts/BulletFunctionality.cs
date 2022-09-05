using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFunctionality : MonoBehaviour
{   // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
    public float bulletSpeed = 7;

    // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
    public Rigidbody2D bulletRigidbody2D;

    // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
    public GameObject explosionReference;

    public Transform bulletTransform;

    // Start is called before the first frame update
    void Start()
    {
        // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
        // Enables the bullets to continuously travel to the right at the defined speed 
        bulletRigidbody2D.velocity = transform.right * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Upon the bullet reaching the other side of the screen, said bullet is destroyed
        if (bulletTransform.position.x >= 9.41)
        {
            // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
            Destroy(gameObject);
        }
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
            // Spawns an explosion which indicates that the enemy has been hit by a bullet
            Instantiate(explosionReference, bulletTransform.position, Quaternion.identity);

            // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
            Destroy(gameObject);
        }

        if (detectCollision.gameObject.name == "Snail Enemy(Clone)")
        {
            // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
            // Spawns an explosion which indicates that the enemy has been hit by a bullet
            Instantiate(explosionReference, bulletTransform.position, Quaternion.identity);

            // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
            Destroy(gameObject);
        }

        if (detectCollision.gameObject.name == "Snake Enemy(Clone)")
        {
            // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
            // Spawns an explosion which indicates that the enemy has been hit by a bullet
            Instantiate(explosionReference, bulletTransform.position, Quaternion.identity);

            // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
            Destroy(gameObject);
        }
    }
}
