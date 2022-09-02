using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreBoard;
    [SerializeField] TMP_Text gameOver;

    private int score = 0;
    private int cubeNumber = 1;

    void Start()
    {
        gameOver.enabled = false;
    }

    public int getCubeNumber()
    {
        return cubeNumber;
    }
    public int getScore()
    {
        return score;
    }

    public void IncreaseScore()
    {
        score++;
        scoreBoard.text = score.ToString();
    }
    public void IncreaseCubeNumber()
    {
        cubeNumber++;
    }

    public void GameOver()
    {
        gameOver.enabled = true;
        Invoke("LoadScene" , 3f);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
