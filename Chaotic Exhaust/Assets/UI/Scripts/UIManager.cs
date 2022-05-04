using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private int _mainScene;
    [SerializeField] private int _survivalScene;
    [SerializeField] private int _mainMenuScene;
    
    // Interfaces
    [SerializeField] private GameObject _optionsMenu;
    [SerializeField] private GameObject _levelSelection;
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
        SceneManager.LoadScene(sceneBuildIndex: _mainScene);
        Time.timeScale = 1;
    }
    
    public void LoadSurvivalScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: _survivalScene);
    }
    
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: _mainMenuScene);
        Time.timeScale = 1;
    }

    public void ShowMainOptions()
    {
        _optionsMenu.SetActive(true);
        _mainMenu.SetActive(false);
    }
    
    public void ShowLevelSelectionMenu()
    {
        _mainMenu.SetActive(false);
        _levelSelection.SetActive(true);
    }
    
    public void ShowMainMenu()
    {
        _mainMenu.SetActive(true);
        _optionsMenu.SetActive(false);
        _credits.SetActive(false);
        _levelSelection.SetActive(false);
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
