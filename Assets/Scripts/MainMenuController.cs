using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameManager gm;
    public void StartGame()
    {
        gm.StartGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
