// COMP30019 Graphics and Interaction
// Project 2
// Author: traillj

using UnityEngine;

public class ShakeScreen : MonoBehaviour
{
    public float shakeTime;

    private SnakeScript snakeScript;
    private int angle;
    private Vector3 originalPosition;

    void Awake()
    {
        GameObject snake = GameObject.Find("Snake");
        snakeScript = snake.GetComponent<SnakeScript>();
        angle = 0;
        originalPosition = transform.position;
    }

    void Update()
    {
        if (snakeScript.HasCollided() == true && shakeTime > 0)
        {
            transform.Translate(Vector3.right * Mathf.Sin(angle));
            angle++;
            shakeTime -= Time.deltaTime;
        }
        else if (shakeTime < 0)
        {
            transform.position = originalPosition;
        }
    }
}
