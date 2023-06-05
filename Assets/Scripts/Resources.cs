using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Resources : MonoBehaviour
{
    public Text MyscoreText;
    private int ScoreNum;

    void Start()
    {
        ScoreNum = 0;
        MyscoreText.text = "Energy: " + ScoreNum.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MyCoin"))
        {
            ScoreNum++;
            Destroy(other.gameObject);
            MyscoreText.text = "Energy: " + ScoreNum;
        }

    }
}
