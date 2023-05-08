using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MapSelection"); // Replace "GameScene" with the name of your actual game scene
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}