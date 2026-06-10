public class PanelState : IUIState
{
    readonly PanelView _view;
    readonly UISwitcher _switcher;
    readonly IServiceLocator _locator;
    readonly Score _score;
    public PanelState(PanelView view, UISwitcher switcher, IServiceLocator locator, Score score)
    {
        _view = view;
        _switcher = switcher;
        _locator = locator;
        _score = score;
    }
    public void Enter()
    {
        _locator.GetService<IFadeService>().FadeIn(_view.PanelImage, 0.5f);
        _view.UpdateScoreText(_score.Value);
        _view.SubscribeClose(OnCloseClicked);
        _view.SubscribeCollect(OnCollectClicked);
    }
    public void Exit()
    {
        _locator.GetService<IFadeService>().FadeOut(_view.PanelImage, 0.5f);
        _locator.GetService<ISaver>().SaveScore();
        _view.UnsubscribeClose(OnCloseClicked);
        _view.UnsubscribeCollect(OnCollectClicked);
    }
    void OnCollectClicked()
    {
        _score.AddPoint();
        _view.UpdateScoreText(_score.Value);
    }
    void OnCloseClicked() => _switcher.SwitchState<MainScreenState>();
}
