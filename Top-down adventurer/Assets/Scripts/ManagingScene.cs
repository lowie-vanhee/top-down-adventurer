using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagingScene : MonoBehaviour
{
    public void backToMenu()
    {
        //save progress?
        SceneManager.LoadScene("MainMenu");
    }

    public void playGame()
    {
        SceneManager.LoadScene("Main");
    }
}