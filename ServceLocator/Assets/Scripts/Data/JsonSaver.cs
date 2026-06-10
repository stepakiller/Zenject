using UnityEngine;
using System.IO;
public class JsonSaver : ISaver
{
    readonly Score _score;
    public JsonSaver(Score score) => _score = score;
    public void SaveScore(string path)
    {
        if (string.IsNullOrEmpty(path)) path = Application.persistentDataPath + "/score.json";
        string json = JsonUtility.ToJson(_score);
        File.WriteAllText(path, json);
        Debug.Log($"Сохранено в {path}");
    }
}