using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    Final Harvest
    Franz Cadiente 301098663
    Sydney Huang 301068497
    Kautuk Udavant 301072587

    Date last modified: 03/08/21
 */
public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuCanvas;
    public GameObject thePlayer;

    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
        if (isPaused)
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
            thePlayer.GetComponent<PlayerBehaviour>().enabled = false;
            Cursor.lockState = CursorLockMode.None;

        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
            thePlayer.GetComponent<PlayerBehaviour>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void Resume()
    {
        isPaused = false;
    }
    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }
}
