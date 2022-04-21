using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private int sceneIndex;
        
    public void LoadMainScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: sceneIndex);
    }
}
