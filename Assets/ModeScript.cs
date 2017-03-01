// COMP30019 Graphics and Interaction
// Project 2
// Author: traillj

using UnityEngine;
using UnityEngine.UI;

public class ModeScript : MonoBehaviour
{
    void Start()
    {
        GameObject mainMenuController = GameObject.Find("MainMenuController");
        MainMenuControllerScript mainMenuControllerScript =
            mainMenuController.GetComponent<MainMenuControllerScript>();
        string mode = mainMenuControllerScript.mode;

        GameObject modeObject = GameObject.Find("Mode");
        Text modeDisplay = modeObject.GetComponent<Text>();
        modeDisplay.text += mode;

        if (mode.Equals("Fast"))
        {
            GameObject snake = GameObject.Find("Snake");
            SnakeScript snakeScript = snake.GetComponent<SnakeScript>();

            // Make snake move twice as fast
            snakeScript.stepTime /= 2;

            IncreaseBlurSpeed();
        }
    }

    private void IncreaseBlurSpeed()
    {
        GameObject floor = GameObject.Find("Floor");
        FloorScript floorScript = floor.GetComponent<FloorScript>();
        floorScript.blurSpeed *= 10;
    }
}
