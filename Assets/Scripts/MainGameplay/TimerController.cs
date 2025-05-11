using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public float TimeLeft { get; set; }
    public float TimePassed { get; set; }
    public bool isTimerRunning { get; private set;}

    public TextMeshProUGUI timerText;
    private void Start()
    {
        StartTimer(30f);
    }
    public void StartTimer(float duration)
    {
        TimeLeft = duration;
        TimePassed = 0f;
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    void Update()
    {
        if (!isTimerRunning)
            return;

        TimeLeft -= Time.deltaTime;
        TimePassed += Time.deltaTime;
        timerText.text = "Time Left: " + Mathf.CeilToInt(TimeLeft).ToString() + " sec.";

        if (TimeLeft <= 0)
        {
            isTimerRunning = false;
            GameFlowManager.Instance.GameOver();
        }

    }
}
