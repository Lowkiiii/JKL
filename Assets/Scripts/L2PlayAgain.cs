using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L2PlayAgain : MonoBehaviour
{
    public void pAgain()
    {
        SceneManager.LoadScene("Level2");
    }
    public void tBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
