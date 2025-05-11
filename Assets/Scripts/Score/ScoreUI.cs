using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public Transform contentParent;
    public GameObject scoreTextPrefab;
    public ScoreDatabaseSO scoreDatabaseSO;
    private int number;

    private void OnEnable()
    {
        UpdateUI();
        number = 0;
    }

    public void UpdateUI()
    {
        foreach (Transform child in contentParent)
            Destroy(child.gameObject);

        List<Score> entries = scoreDatabaseSO.results;

        foreach (var entry in entries)
        {
            GameObject obj = Instantiate(scoreTextPrefab, contentParent);
            TextMeshProUGUI text = obj.GetComponentInChildren<TextMeshProUGUI>();
            number++;

            if (text != null)
                text.text = $"{number}.   Time in game: {entry.completionTime} sec. | Data: {entry.completionData}";
        }
    }

}
