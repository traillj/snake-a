// COMP30019 Graphics and Interaction
// Project 2
// Author: traillj

using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public SnakeScript snakeScript;

    void Update()
    {
        if (Input.touchCount <= 0)
        {
            // Not touching screen
            return;
        }

        Touch touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began)
        {
            // Only respond at the beginning of a touch
            return;
        }

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

        // Determine if left or right side of the screen
        // was touched
        Vector3 touchPos = touch.position;

        if (touchPos.x < Screen.width / 2)
        {
            // Move left from snake's perspective (clockwise),
            // opposite direction of the same axis compared to
            // moving right
            newDirection *= -1;
        }

        snakeScript.SetNextStepDirection(newDirection);
    }
}
