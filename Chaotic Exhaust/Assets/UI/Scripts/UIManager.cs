using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private int _sceneIndex;
    
    // Interfaces
    [SerializeField] private GameObject _optionsMenu;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _credits;

    private void Awake()
    {
        _optionsMenu.SetActive(false);
        _mainMenu.SetActive(true);
        _credits.SetActive(false);
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: _sceneIndex);
    }
    
    public void ShowMainOptions()
    {
        _optionsMenu.SetActive(true);
        _mainMenu.SetActive(false);
    }
    
    public void ShowMainMenu()
    {
        _mainMenu.SetActive(true);
        _optionsMenu.SetActive(false);
        _credits.SetActive(false);
    }

    public void ShowCredits()
    {
        _credits.SetActive(true);
        _mainMenu.SetActive(false);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
