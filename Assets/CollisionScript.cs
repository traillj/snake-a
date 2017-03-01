// COMP30019 Graphics and Interaction
// Project 2
// Author: traillj

using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    private SnakeScript snakeScript;

    private GameObject restartButton;
    private GameObject menuButton;

    void Awake()
    {
        GameObject snake = GameObject.Find("Snake");
        snakeScript = snake.GetComponent<SnakeScript>();

        restartButton = GameObject.Find("RestartButton");
        restartButton.SetActive(false);

        menuButton = GameObject.Find("MenuButton");
        menuButton.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SnakeBody" || other.tag == "Boundary")
        {
            snakeScript.SetCollided(true);
            restartButton.SetActive(true);
            menuButton.SetActive(true);
        }
    }
}
