// COMP30019 Graphics and Interaction
// Project 2
// Author: traillj

using UnityEngine;
using UnityEngine.UI;

public class FoodTriggerScript : MonoBehaviour
{
    private Text scoreDisplay;
    private SnakeScript snakeScript;
    private GameObject foodSparkle;
    private AccelerometerScript accelerometerScript;

    private int score;
    private float age;

    void Awake()
    {
        GameObject snake = GameObject.Find("Snake");
        snakeScript = snake.GetComponent<SnakeScript>();

        GameObject scoreObject = GameObject.Find("Score");
        scoreDisplay = scoreObject.GetComponent<Text>();

        foodSparkle = GameObject.Find("FoodSparkle");

        GameObject gameController = GameObject.Find("GameController");
        accelerometerScript = gameController.GetComponent<AccelerometerScript>();

        score = 0;
        age = 0;
        MoveFood();
    }

    void Update()
    {
        age += Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (age < 0.2)
        {
            // Cube adjacent to the head also triggers this event,
            // so prevents doubling the score.
            // Food may have spawned on the snake, hiding the food,
            // meaning the food will become visible and edible when
            // the snake moves off the food.
            age = 0;
            return;
        }

        age = 0;
        score++;
        scoreDisplay.text = score.ToString();

        snakeScript.Grow();
        MoveFood();
    }

    public void MoveFood()
    {
        float xPos = 2 * Random.Range(0, 37) + 1.5f;
        int zPos = 0;
        if (accelerometerScript.IsTiltedDown())
        {
            // Move food to the top half of the field
            zPos = 2 * Random.Range(12, 24) + 1;
            accelerometerScript.SetTiltedDown(false);
        }
        else if (accelerometerScript.IsTiltedUp())
        {
            // Move food to the bottom half of the field
            zPos = 2 * Random.Range(0, 12) + 1;
            accelerometerScript.SetTiltedUp(false);
        }
        else
        {
            // Move food to either half of the field
            zPos = 2 * Random.Range(0, 24) + 1;
        }

        transform.position = new Vector3(xPos, 0.5f, zPos);
        foodSparkle.transform.position = transform.position;
    }
}
