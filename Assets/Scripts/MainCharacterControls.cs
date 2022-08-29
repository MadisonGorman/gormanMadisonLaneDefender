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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// Update is called once per frame; Enables the main character to move (up, down)
    /// </summary>
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
    }
}
