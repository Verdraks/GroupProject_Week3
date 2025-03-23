using UnityEngine;
using UnityEngine.SceneManagement;
public class UI_MainMenuButton : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string levelToLoad;

    public void PlayButton()
    {
        SceneManager.LoadScene(levelToLoad);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}