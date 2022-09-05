using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFunctionality : MonoBehaviour
{
    // Permits the explosion to be removed from the game following the termination of its animation
    public void DestroyExplosion()
    {
        // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
        Destroy(gameObject);
    }
}
