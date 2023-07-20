using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        ScoreScript.scoreValue = 0;
        FinalScoreScript.scoreValue = 0;
        TimeScript.time = 0;
        FinalTimeScript.time = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
