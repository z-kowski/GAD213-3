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
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        //Debug.Log("timescale reset to 1");
    }
}
