using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class MainScreenView : MonoBehaviour
{
    [SerializeField] Button _openButton;
    public void SubscribeOpen(UnityAction action) => _openButton.onClick.AddListener(action);
    public void UnsubscribeOpen(UnityAction action) => _openButton.onClick.RemoveListener(action);
    public void SetInteractable(bool state) => _openButton.interactable = state;
}