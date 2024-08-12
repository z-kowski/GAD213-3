using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject canvasMain;
    public GameObject canvasGame; 

    private void Awake()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
    }

    public void LoadGame()
    {
        canvasMain.SetActive(false);

        SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);

        canvasGame.SetActive(true);

    }

    public void BackToMain()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
