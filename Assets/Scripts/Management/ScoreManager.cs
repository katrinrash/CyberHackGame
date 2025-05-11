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

    private void OnApplicationQuit()
    {
        SaveScore();
    }

    public void AddResult(Score score)
    { 
        scoreDatabaseSO.results.Add(score);
    }

    public void SaveScore()
    {
        ResultListWrapper wrapper = new ResultListWrapper { results = scoreDatabaseSO.results};
        string json = JsonUtility.ToJson(wrapper, true);
        File.WriteAllText(savePath, json);
    }

    public void LoadScore()
    {

        if (File.Exists(savePath) && !PlayerPrefs.HasKey("FirstLaunchDone"))
        {
            string json = File.ReadAllText(savePath);
            var wrapper = JsonUtility.FromJson<ResultListWrapper>(json);
            scoreDatabaseSO.results = wrapper.results ?? new List<Score>();
            PlayerPrefs.SetInt("FirstLaunchDone", 1);
            PlayerPrefs.Save();
        }

    }

}
