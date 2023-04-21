using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelectionController : MonoBehaviour
{
    private BackgroundMusicController backgroundMusicController;

    void Start()
    {
        backgroundMusicController = FindObjectOfType<BackgroundMusicController>();
    }

    public void LoadMap1()
    {
        backgroundMusicController.StopBackgroundMusic();
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadMap2()
    {
        backgroundMusicController.StopBackgroundMusic();
        SceneManager.LoadScene("SampleScene");
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}