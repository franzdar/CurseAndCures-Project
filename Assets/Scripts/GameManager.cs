using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;
    public Transform playerPos;
    public PlayerMovement playerMovement;
    //private Vector2 playerPosition;


    [Header("Checkppints")]
    public Transform checkpoint1;
    public Transform checkpoint2;
    public Transform checkpoint3;
    public Transform checkpoint4;

    public GameObject playerLantern;
    public GameObject playerFlower;

    [Header("Game Conditions")]
    public bool isPlaying;
    public bool isPaused;
    public bool isPlayerDead;

    public bool isLanternObtained;
    public bool isFlowerObtained;
    public bool isGameFinished;

    [Header("End Game")]
    public GameObject removableTerrain;




    // Start is called before the first frame update
    void Start()
    {
        isPlaying = false;

        //RESET PREFS
        PlayerPrefs.SetInt("Checkpoint", 1);

        Debug.Log(PlayerPrefs.GetInt("Checkpoint"));

        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        // Pause and Disable player movement
        if (!isPaused)
        {
            Time.timeScale = 1.0f;
            playerMovement.enabled = true;
        }

        // Resume and Enable player movement
        if(isPaused)
        {
            Time.timeScale = 0f;
            playerMovement.enabled = false;
        }

        // Player is Dead
        if(isPlayerDead)
        {
            Time.timeScale = 0f;
            playerMovement.enabled = false;
        }

        // Player resurrected
        if (!isPlayerDead)
        {
            Time.timeScale = 1.0f;
            playerMovement.enabled = true;
        }


        if (isLanternObtained)
        {
            playerLantern.SetActive(true);
        }

        if (isFlowerObtained)
        {
            playerFlower.SetActive(true);

            removableTerrain.SetActive(false);
        }

        // Animation

        
    }

    public void Spawn()
    {

        switch (PlayerPrefs.GetInt("Checkpoint"))
        {
            case 1:
                Debug.Log("Check");
                playerPos.position = checkpoint1.position;
                break;
            case 2:
                Debug.Log("Check");
                playerPos.position = checkpoint2.position;
                break;
            case 3:
                Debug.Log("Check");
                player.transform.position = checkpoint3.position;
                break;
            case 4:
                Debug.Log("Check");
                player.transform.position = checkpoint4.position;
                break;
            default:
                break;
        }
    }
}
