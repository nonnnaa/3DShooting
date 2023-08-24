using UnityEngine;
using UnityEngine.SceneManagement;
public class Game : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    public void startGame()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
