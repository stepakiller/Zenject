using UnityEngine;
public class PlayerPrefsSaver : ISaver
{
    readonly Score _score;
    const string SCORE_KEY = "SavedScore";
    public PlayerPrefsSaver(Score score) => _score = score;
    public void SaveScore(string path = null)
    {
        PlayerPrefs.SetInt(SCORE_KEY, _score.Value);
        PlayerPrefs.Save();
        Debug.Log($"Счет сохранен: {_score.Value}");
    }
}