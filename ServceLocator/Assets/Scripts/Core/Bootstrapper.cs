using UnityEngine;
public class Bootstrapper : MonoBehaviour
{
    [SerializeField] MainScreenView _mainScreenView;
    [SerializeField] PanelView _panelView;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _openClip;
    [SerializeField] AudioClip _closeClip;
    [SerializeField] bool _useJsonSaver = false;
    ServiceLocator _locator;
    UISwitcher _uiSwitcher;
    void Awake()
    {
        var score = new Score();
        _locator = new ServiceLocator();
        _locator.RegisterService<IFadeService>(new FadeService());
        _locator.RegisterService<ISoundPlayer>(new SoundPlayer(_audioSource, _openClip, _closeClip));
        ISaver saver = _useJsonSaver ? new JsonSaver(score) : new PlayerPrefsSaver(score);
        _locator.RegisterService<ISaver>(saver);
        _uiSwitcher = new UISwitcher();
        var mainState = new MainScreenState(_mainScreenView, _uiSwitcher);
        var panelState = new PanelState(_panelView, _uiSwitcher, _locator, score);
        _uiSwitcher.AddState(mainState);
        _uiSwitcher.AddState(panelState);
        _panelView.PanelImage.gameObject.SetActive(false);
        _uiSwitcher.SwitchState<MainScreenState>();
    }
}