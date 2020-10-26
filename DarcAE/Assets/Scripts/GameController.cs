using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public Text scoreText;

    public GameObject gameOver;
    public GameObject nextLvl;

    //para outro script poder acessar essa classe
    public static GameController instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        //ToString tranforma o valor em text
        scoreText.text = totalScore.ToString();
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void RestartGamer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLvl()
    {
        nextLvl.SetActive(true);
    }
}
