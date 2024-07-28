using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Menu Screens")]

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

    [Header("Game Mode Screen(s)")]

    [Tooltip("An in-game HUD")]
    public GameObject inGameScreen;

    //[Header("Loading Screen")]

    //public GameObject loadingScreenMenu;
    //public Slider slider;

    private void Awake()
    {
        MainMenu();
    }

    private void Update()
    {
        if (mainMenu.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape))
        {
            mainMenu.SetActive(false);
            quitMenu.SetActive(true);
        }
        if (!mainMenu.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenu();
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
        if (optionsMenu)
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

    //load a specific saved game from a save file
    //public void LoadFromSave()
    //save slot 1
    //save slot 2
    //save slot 3

    //public void LoadingScreen()
    //{
    //    difficultySelectMenu.SetActive(false);
    //    loadingScreenMenu.SetActive(true);
    //}
}
