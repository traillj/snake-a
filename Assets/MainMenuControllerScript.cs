// COMP30019 Graphics and Interaction
// Project 2
// Author: traillj

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControllerScript : MonoBehaviour
{
    public string mode;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void LoadNormalMode()
    {
        mode = "Normal";
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void LoadFastMode()
    {
        mode = "Fast";
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void LoadInstructions()
    {
        SceneManager.LoadScene("InstructionsScene", LoadSceneMode.Single);
    }
}
