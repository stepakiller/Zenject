public class MainScreenState : IUIState
{
    readonly MainScreenView _view;
    readonly UISwitcher _switcher;
    public MainScreenState(MainScreenView view, UISwitcher switcher)
    {
        _view = view;
        _switcher = switcher;
    }
    public void Enter()
    {
        _view.SetInteractable(true);
        _view.SubscribeOpen(OnOpenClicked);
    }
    public void Exit()
    {
        _view.SetInteractable(false);
        _view.UnsubscribeOpen(OnOpenClicked);
    }
    void OnOpenClicked() => _switcher.SwitchState<PanelState>();
}