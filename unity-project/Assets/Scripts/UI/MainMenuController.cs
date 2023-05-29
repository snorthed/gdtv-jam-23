using Management;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void StartGameClick()
    {
        LevelLoader.GoToMainGame();
    }

    public void ExitGame()
    {
        LevelLoader.ExitGame();
    }

}
