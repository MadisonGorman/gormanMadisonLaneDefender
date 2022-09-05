using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterControls : MonoBehaviour
{
    public float movementSpeed = 5;

    public KeyCode moveUpFirstOption = KeyCode.UpArrow;
    public KeyCode moveDownFirstOption = KeyCode.DownArrow;

    public KeyCode moveUpSecondOption = KeyCode.W;
    public KeyCode moveDownSecondOption = KeyCode.S;

    public KeyCode shootBullet = KeyCode.Space;

    // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
    public GameObject bulletReference;
    public GameObject explosionReference;
    public Transform bulletSpawnLocation;

    // Referenced: "Coroutines with IEnumerator & WaitForSeconds - Unity - C# Scripting Tutorial" by Learn Everything Fast
    bool playerCanShootBullets = true;

    public AudioClip bulletShotSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame; Enables the main character to move (up, down)
    void Update()
    {
        float yMovement = Input.GetAxis("Vertical");

        Vector3 newPosition = transform.position;

        // Upon pressing the Up Arrow or W key, the main character moves up at the defined movement speed
        if (Input.GetKey(moveUpFirstOption) || Input.GetKey(moveUpSecondOption))
        {
            newPosition.y += yMovement * Time.deltaTime * movementSpeed;

            // Restricts the main character's movement to the defined vertical range
            newPosition.y = Mathf.Clamp(newPosition.y, -3.48f, 1.56f);

            transform.position = newPosition;
        }

        // Upon pressing the Down Arrow or S key, the main character moves down at the defined movement speed
        if (Input.GetKey(moveDownFirstOption) || Input.GetKey(moveDownSecondOption))
        {
            newPosition.y += yMovement * Time.deltaTime * movementSpeed;

            // Restricts the main character's movement to the defined vertical range
            newPosition.y = Mathf.Clamp(newPosition.y, -3.48f, 1.56f);

            transform.position = newPosition;
        }

        // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
        // When the spacebar is pressed or held down, bullets are shot, with a delay between each
        if (Input.GetKey(shootBullet))
        {
            // Referenced: "Coroutines with IEnumerator & WaitForSeconds - Unity - C# Scripting Tutorial" by Learn Everything Fast
            if (playerCanShootBullets)
            {
                StartCoroutine(SpawnBullet());
            }
        }
    }

    // Referenced: "Coroutines with IEnumerator & WaitForSeconds - Unity - C# Scripting Tutorial" by Learn Everything Fast
    // Spawns a bullet, ensuring that players are prevented from shooting further for a brief period, a sound accompanies each bullet 
    IEnumerator SpawnBullet()
    {
        AudioSource.PlayClipAtPoint(bulletShotSound, bulletSpawnLocation.position);

        // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
        // Spawns an explosion which conceals the spawning of the bullet
        Instantiate(explosionReference, bulletSpawnLocation.position, Quaternion.identity);

        // Referenced: "2D Shooting in Unity (Tutorial)" by Brackeys
        Instantiate(bulletReference, bulletSpawnLocation.position, Quaternion.identity);

        // Referenced: "Coroutines with IEnumerator & WaitForSeconds - Unity - C# Scripting Tutorial" by Learn Everything Fast
        playerCanShootBullets = false;

        // Referenced: "Coroutines with IEnumerator & WaitForSeconds - Unity - C# Scripting Tutorial" by Learn Everything Fast
        yield return new WaitForSeconds(0.50f);

        // Referenced: "Coroutines with IEnumerator & WaitForSeconds - Unity - C# Scripting Tutorial" by Learn Everything Fast
        playerCanShootBullets = true;
    }
}
