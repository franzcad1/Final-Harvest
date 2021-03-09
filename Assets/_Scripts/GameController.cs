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
public class GameController : MonoBehaviour
{
    public GameObject player;


    public void SavePlayer()
    {
        var playerScript = FindObjectOfType<PlayerBehaviour>();
        SaveSystem.SavePlayer(playerScript);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        player = GameObject.FindGameObjectWithTag("Player");

        player.transform.position = position;
        PauseMenu.isPaused = false;

    }
}
