using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreDatabaseSO", menuName = "Scriptable Objects/ScoreDatabaseSO")]
public class ScoreDatabaseSO : ScriptableObject
{
    public List<Score> results = new List<Score>();
}
