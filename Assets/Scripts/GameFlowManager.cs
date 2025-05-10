using TMPro;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    public static GameFlowManager Instance { get; private set; }
    public GameObject gameOverWinUI;
    public GameObject gameUI;
    public GameObject gameMenu;
    public TextMeshProUGUI text;

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

    public void WinGame()
    {
        gameOverWinUI.SetActive(true);
        text.text = "Hacking was successful!";
        gameUI.SetActive(false);

    }
    public void GameOver()
    {
        gameOverWinUI.SetActive(true);
        text.text = "Hacking was not successful!";
        gameUI.SetActive(false);  
    }


}
