using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
public class PanelView : MonoBehaviour
{
    [SerializeField] Button _closeButton;
    [SerializeField] Button _collectButton;
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] Image _panelImage;

    public Image PanelImage => _panelImage;
    public void SubscribeClose(UnityAction action) => _closeButton.onClick.AddListener(action);
    public void UnsubscribeClose(UnityAction action) => _closeButton.onClick.RemoveListener(action);
    public void SubscribeCollect(UnityAction action) => _collectButton.onClick.AddListener(action);
    public void UnsubscribeCollect(UnityAction action) => _collectButton.onClick.RemoveListener(action);
    public void UpdateScoreText(int score) => _scoreText.text = $"Счет: {score}";
}
