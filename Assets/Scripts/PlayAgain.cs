using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    public void Again()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
