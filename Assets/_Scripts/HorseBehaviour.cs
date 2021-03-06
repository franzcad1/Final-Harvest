using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HorseBehaviour : MonoBehaviour
{
    public GameObject player;
    private bool isWinnable = false;
    public Text winnableText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isWinnable)
        {
            winnableText.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("Game Over");
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else
        {
            winnableText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.transform.gameObject;
            isWinnable = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isWinnable = false;
        }
    }
}
