// COMP30019 Graphics and Interaction
// Project 2
// Author: traillj

using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public SnakeScript snakeScript;
    public Camera mainCamera;
    public ButtonEventsScript buttonEventsScript;
    public AccelerometerScript accelerometerScript;

    void Update()
    {
        if (snakeScript.HasCollided() == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                // Restart
                buttonEventsScript.ReloadGame();
            }
            else if (Input.GetKeyDown(KeyCode.M))
            {
                // Return to menu
                buttonEventsScript.LoadMainMenu();
            }
        }

        // Change the snake's movement direction
        bool pressedRight;
        if (Input.GetKeyDown(KeyCode.L))
        {
            pressedRight = true;
            ChangeSnakeDirection(pressedRight);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            pressedRight = false;
            ChangeSnakeDirection(pressedRight);
        }

        // Set whether the food will next appear in the top or bottom half
        if (Input.GetKeyDown(KeyCode.W) && !accelerometerScript.IsTiltedDown())
        {
            // Top half
            accelerometerScript.SetTiltedDown(true);
        }
        else if (Input.GetKeyDown(KeyCode.D) && !accelerometerScript.IsTiltedUp())
        {
            // Bottom half
            accelerometerScript.SetTiltedUp(true);
        }
    }

    private void ChangeSnakeDirection(bool pressedRight)
    {
        Vector3 currentDirection = snakeScript.GetDirection();
        Vector3 newDirection;

        // Assume pressed right,
        // move right from snake's perspective (clockwise)
        if (currentDirection.Equals(Vector3.forward))
        {
            newDirection = Vector3.right;
        }
        else if (currentDirection.Equals(Vector3.right))
        {
            newDirection = Vector3.back;
        }
        else if (currentDirection.Equals(Vector3.back))
        {
            newDirection = Vector3.left;
        }
        else
        {
            // currentDirection is left
            newDirection = Vector3.forward;
        }

        if (!pressedRight)
        {
            // Move left from snake's perspective (clockwise),
            // opposite direction of the same axis compared to
            // moving right
            newDirection *= -1;
        }

        snakeScript.SetNextStepDirection(newDirection);
    }
}
