using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public GameObject raceFinishedPanel;
    public AudioSource carAudioSource;
    private bool raceFinished = false;

    private void Start()
    {
        EnablePause();
    }

    public void FinishRace()
    {
        if (!raceFinished)
        {
            raceFinished = true;
            Debug.Log("Race Finished!");
            carAudioSource.Stop();
            pauseButton.SetActive(false);
            raceFinishedPanel.SetActive(true);
            Time.timeScale = 0;
            PauseMenuController pauseMenuController = pauseMenu.GetComponent<PauseMenuController>();
            if (pauseMenuController != null)
            {
                pauseMenuController.Pause();
            }
        }
    }

    public void LoadNextMap()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void EnablePause()
    {
        if (pauseButton != null)
        {
            pauseButton.SetActive(true);
        }
    }
}