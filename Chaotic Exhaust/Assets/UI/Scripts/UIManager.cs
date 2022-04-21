using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private int _sceneIndex;
    [SerializeField]
    private GameObject _optionsMenu;
    [SerializeField]
    private GameObject _mainMenu;

    private void Awake()
    {
        _optionsMenu.SetActive(false);
        _mainMenu.SetActive(true);
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

    public void CloseGame()
    {
        Application.Quit();
    }
}
