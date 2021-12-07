using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement3D : MonoBehaviour
{
    private bool wKeyPressed;
    private bool aKeyPressed;
    private bool sKeyPressed;
    private bool dKeyPressed;
    private bool spaceKeyPressed;
    private bool shiftKeyPressed;

    Transform t;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.2f;
        t = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Checks for key down
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            wKeyPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            aKeyPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            sKeyPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            dKeyPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceKeyPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            shiftKeyPressed = true;
        }

        // Checks for key up
        if (Input.GetKeyUp(KeyCode.W))
        {
            wKeyPressed = false;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            aKeyPressed = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            sKeyPressed =false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            dKeyPressed = false;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            spaceKeyPressed = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            shiftKeyPressed = false;
        }

    }

    // Called once every fixed frame
    private void FixedUpdate()
    {   
        // Checks to see if key is pressed
        if (wKeyPressed)
        {
            t.position = new Vector3(t.position.x, t.position.y, t.position.z + speed);
        }

        if (aKeyPressed)
        {
            t.position = new Vector3(t.position.x - speed, t.position.y, t.position.z);
        }

        if (sKeyPressed)
        {
            t.position = new Vector3(t.position.x, t.position.y, t.position.z - speed);
        }

        if (dKeyPressed)
        {
            t.position = new Vector3(t.position.x + speed, t.position.y, t.position.z);
        }

        if (spaceKeyPressed)
        {
            t.position = new Vector3(t.position.x, t.position.y + speed, t.position.z);
        }

        if (shiftKeyPressed)
        {
            t.position = new Vector3(t.position.x, t.position.y - speed, t.position.z);
        }
    }
}
