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
public class MenuController : MonoBehaviour
{
    public PlayerBehaviour player;
    public PauseMenu LoadPlayer;
    public SceneDataSO sceneData;

    private void Start()
    {
        LoadPlayer = FindObjectOfType<PauseMenu>();
        player = FindObjectOfType<PlayerBehaviour>();

    }
    public void OnLoadButtonPressed()
    {
        SceneManager.LoadScene("Game play");
        //LoadPlayer.OnLoadButtonPressed();

        player.controller.enabled = false;
        player.transform.position = sceneData.playerPosition;
        player.controller.enabled = true;

        player.health = sceneData.playerHealth;
        player.healthBar.SetHealth(sceneData.playerHealth);
    }

    public void PlayGame ()
    {
        SceneManager.LoadScene("Game play");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
