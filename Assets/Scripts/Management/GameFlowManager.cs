using System;
using TMPro;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    public static GameFlowManager Instance { get; private set; }
    public GameObject gameOverWinUI;
    public GameObject gameUI;
    public GameObject gameMenu;
    public TextMeshProUGUI text;
    public ScoreManager scoreManager;

    private void Awake()
    {
        Instance = this;
    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ResumeGame()
    {
        gameMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void WinGame(float time)
    {
        gameOverWinUI.SetActive(true);
        text.text = "Hacking was successful!";
        gameUI.SetActive(false);

        Score score = new Score();

        score.completionData = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
        score.completionTime = time;

        scoreManager.AddResult(score);

    }
    public void GameOver()
    {
        gameOverWinUI.SetActive(true);
        text.text = "Hacking was not successful!";
        gameUI.SetActive(false);  
    }


}
