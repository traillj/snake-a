// COMP30019 Graphics and Interaction
// Project 2
// Author: traillj

using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEventsScript : MonoBehaviour
{

    public void ReloadGame()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void LoadMainMenu()
    {
        GameObject mainMenuController = GameObject.Find("MainMenuController");
        Destroy(mainMenuController);
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
