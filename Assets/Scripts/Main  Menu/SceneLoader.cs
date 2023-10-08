using UnityEngine;
using UnityEngine.SceneManagement;

//A simplified class responsible for loading/unloading scenes
//Usually would include a loading screen with a fade in/out effect while loading/unloading async
public class SceneLoader : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);//Normally I'd create a dedicated intializtion scene that never gets unloaded

    }
    private void OnEnable()
    {
        SimplifiedEventManager.GameplayRequested.AddListener(LoadGameplay);
        SimplifiedEventManager.MainMenuRequested.AddListener(LoadMainMenu);

    }
    private void OnDisable()
    {
        SimplifiedEventManager.GameplayRequested.RemoveListener(LoadGameplay);
        SimplifiedEventManager.MainMenuRequested.RemoveListener(LoadMainMenu);
    }
    private void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    private void LoadGameplay()
    {
        SceneManager.LoadScene(1);
    }
}
