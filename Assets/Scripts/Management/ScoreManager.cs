using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public ScoreDatabaseSO scoreDatabaseSO;
    private string savePath;

    private void Awake()
    {
        savePath = Application.persistentDataPath + "/score.json"; 
    }

    private class ResultListWrapper
    {
        public List<Score> results;
    }

    public void AddResult(Score score)
    { 
        scoreDatabaseSO.results.Add(score);
    }

    private void OnApplicationQuit()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        ResultListWrapper wrapper = new ResultListWrapper { results = scoreDatabaseSO.results};
        string json = JsonUtility.ToJson(wrapper, true);
        File.WriteAllText(savePath, json);
    }

    public void LoadScore()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            var wrapper = JsonUtility.FromJson<ResultListWrapper>(json);
            scoreDatabaseSO.results = wrapper.results ?? new List<Score>();
        }
        else
        {
            scoreDatabaseSO.results.Clear();
        }
    }

}
