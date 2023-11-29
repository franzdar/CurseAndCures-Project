using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;
using UnityEditor;

public class MenusNavigation : MonoBehaviour
{
    [Header("Game Manager")]
    public GameManager gameManager;

    [Header("Game Screens")]
    [SerializeField] private GameObject HomeScreen;
    [SerializeField] private GameObject MenuScreen;
    [SerializeField] private GameObject LoadScreen;
    [SerializeField] private GameObject PauseScreen;
    [SerializeField] private GameObject DeathScreen;

    [Header("Game Menu Conditions")]
    [SerializeField] private bool noSavedFiles; //checks if the player already played the game or has no save files
    //[SerializeField] private bool isPlaying;

    [SerializeField] private bool isMainMenuOpen; // checks if the main menu is open
    [SerializeField] private bool isChapterSelectOpen; // checks if chapter select is open 

    // Start is called before the first frame update
    void Start()
    {
        noSavedFiles = true; // Update this with PlayerPrefs

        isMainMenuOpen = false;
        isChapterSelectOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
        {
            if(!isMainMenuOpen && !isChapterSelectOpen && !gameManager.isPlaying)
            {
                if (noSavedFiles)
                {
                    StartGame();

                    Debug.Log("Playing");
                    gameManager.isPlaying = true;
                }
                else
                {
                    HomeScreen.GetComponent<CanvasGroup>().alpha = 0f;
                    HomeScreen.SetActive(false);
                    OpenMainMenu();
                }
            }
        }

        if (gameManager.isPlaying && Input.GetKeyUp(KeyCode.Escape))
        {
            if (isMainMenuOpen)
            {
                Resume();
            }
            else
            {
                PauseGame();
            }
        }

        // Show or Hide Death Screen
        if(gameManager.isPlayerDead)
        {
            StartCoroutine(FadeIn(DeathScreen, 2f));

            if (Input.anyKey)
            {
                gameManager.Spawn();

                StartCoroutine(FadeOut(DeathScreen, 2f));
                gameManager.isPlayerDead = false;
            }
        }
    }

    public IEnumerator FadeOut(GameObject menu, float fadeTime)
    {
        // fade from opaque to transparent
        while (menu.GetComponent<CanvasGroup>().alpha > 0)
        {
            menu.GetComponent<CanvasGroup>().alpha -= 1 * Time.deltaTime / fadeTime;
            yield return null;
        }
        menu.GetComponent<CanvasGroup>().alpha = 0f;
        menu.SetActive(false);
        Debug.Log("Faded Out");
    }

    public IEnumerator FadeIn(GameObject menu, float fadeTime)
    {
        menu.SetActive(true);

        // fade from transparent to opaque
        /*while (menu.GetComponent<CanvasGroup>().alpha < 1)
        {   
            menu.GetComponent<CanvasGroup>().alpha += 1 * Time.deltaTime / fadeTime;
        }*/
        menu.GetComponent<CanvasGroup>().alpha = 1f;
        yield return null;

        Debug.Log("Faded In");
    }

    // HOME SCREEN MENUS
    public void StartGame()
    {
        //MenuScreen.GetComponent<CanvasGroup>().alpha = 0f;
        StartCoroutine(FadeOut(HomeScreen, 2f));
    }

    public void OpenMainMenu()
    {
        MenuScreen.SetActive(true);
        MenuScreen.GetComponent<CanvasGroup>().alpha = 1f;

        isMainMenuOpen = true;
        Debug.Log("OpenMenu");
    }

    public void ResumeGame()
    {
        // Go back to previous checkpoint and load
        gameManager.isPaused = false;

        MenuScreen.GetComponent<CanvasGroup>().alpha = 0f;
        MenuScreen.SetActive(false);

        isMainMenuOpen = false;
    }
    public void StartNewGame()
    {
        // Delete Saved Files and Start Game
        gameManager.isPaused = false;

        MenuScreen.GetComponent<CanvasGroup>().alpha = 0f;
        MenuScreen.SetActive(false);
    }

    public void LoadChapter()
    {
        // Open Chapter Selection Screen

        MenuScreen.GetComponent<CanvasGroup>().alpha = 0f;
        MenuScreen.SetActive(false);

        LoadScreen.SetActive(true);
        LoadScreen.GetComponent<CanvasGroup>().alpha = 1f;

        isChapterSelectOpen = true;
    }

    public void ReturnToMain()
    {
        // Close Chapter Selection Screen
        MenuScreen.SetActive(true);
        MenuScreen.GetComponent<CanvasGroup>().alpha = 1f;

        LoadScreen.GetComponent<CanvasGroup>().alpha = 0f;
        LoadScreen.SetActive(false);

        isChapterSelectOpen = false;
    }
 
    public void Settings()
    {
        // Open Settings
    }

    public void ExitGame()
    {
        Application.Quit();
    }



    // PAUSE MENUS
    public void PauseGame()
    {
        gameManager.isPaused = true;

        PauseScreen.SetActive(true);
        PauseScreen.GetComponent<CanvasGroup>().alpha = 1f;
    }
    public void Resume()
    {
        gameManager.isPaused = false;

        PauseScreen.GetComponent<CanvasGroup>().alpha = 0f;
        PauseScreen.SetActive(false);
    }
    public void Restart()
    {
        // Restart Game to Checkpoint
        gameManager.isPaused = false;
        gameManager.Spawn();

        PauseScreen.GetComponent<CanvasGroup>().alpha = 0f;
        PauseScreen.SetActive(false);
    }

    public void ExitToMainMenu()
    {
        PauseScreen.GetComponent<CanvasGroup>().alpha = 0f;
        PauseScreen.SetActive(false);

        OpenMainMenu();
    }
}
