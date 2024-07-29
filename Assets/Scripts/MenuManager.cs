using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Main Menus")]

    [Tooltip("A main/title menu")]
    public GameObject mainMenu;

    [Tooltip("A specific level selection menu")]
    public GameObject levelSelectMenu;

    [Tooltip("A load game menu")]
    public GameObject loadGameMenu;

    [Tooltip("A difficulty selection menu")]
    public GameObject difficultySelectMenu;

    [Tooltip("An options menu")]
    public GameObject optionsMenu;

    [Tooltip("An options submenu for sound/audio")]
    public GameObject optionsSound;

    [Tooltip("An options submenu for graphics")]
    public GameObject optionsGFX;

    [Tooltip("An options submenu for accessibility options")]
    public GameObject optionsAccess;

    [Tooltip("A quit menu")]
    public GameObject quitMenu;

    [Header("In-Game Menus")]

    [Tooltip("A canvas containing all ingame UI")]
    public GameObject canvasGame;

    [Tooltip("An in-game HUD")]
    public GameObject gameHUD;

    [Tooltip("An in-game pause menu")]
    public GameObject gamePauseMenu;

    [Header("Loading Screen")]

    [Tooltip("A loading screen")]
    public GameObject loadingScreenMenu;
    public Slider slider;

    private void Awake()
    {
        MainMenu();
    }

    private void Update()
    {
        if (mainMenu.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                QuitMenu();
            }
        }

        else if (!mainMenu.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenu();
        }

        if (gameHUD.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseMenu();
            }
        }

        else if (gamePauseMenu.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ResumeGame();
            }
        }
    }

    public void MainMenu()
    {
        levelSelectMenu.SetActive(false);
        loadGameMenu.SetActive(false);
        difficultySelectMenu.SetActive(false);
        optionsSound.SetActive(false);
        optionsMenu.SetActive(false);
        quitMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void LevelSelectMenu()
    {
        mainMenu.SetActive(false);
        levelSelectMenu.SetActive(true);
    }

    public void LoadGameMenu()
    {
        mainMenu.SetActive(false);
        loadGameMenu.SetActive(true);
    }

    public void DifficultySelectMenu()
    {
        mainMenu.SetActive(false);

        if (levelSelectMenu)
        {
            levelSelectMenu.SetActive(false);
        }

        difficultySelectMenu.SetActive(true);
    }

    public void OptionsMenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void OptionsSound()
    {
        if (optionsMenu.activeInHierarchy)
        {
            //make sure to disable all other options submenus
            
            //optionsGraphics.SetActive(false);
            //optionsAccessibility.SetActive(false);
            optionsSound.SetActive(true);
        }
    }

    public void QuitMenu()
    {
        mainMenu.SetActive(false);
        quitMenu.SetActive(true);
    }

    public void QuitGame()
    {
        if (EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }

    public void PauseMenu()
    {
        gameHUD.SetActive(false);
        
        gamePauseMenu.SetActive(true);
        Time.timeScale = 0f;
        //Debug.Log("time set to " + Time.timeScale);
    }

    public void ResumeGame()
    {
        gamePauseMenu.SetActive(false);
        gameHUD.SetActive(true);
        Time.timeScale = 1f;
        //Debug.Log("time set to " + Time.timeScale);
    }
}
