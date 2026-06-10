using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] Bullet _bulletPrefab;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _shootSound, _hitSound;
    [SerializeField] TargetProvider _targetProvider;
    [SerializeField] PlayerView _playerView;

    public override void InstallBindings()
    {
        Container.Bind<UISwitcher>().AsSingle();
        Container.Bind<MainScreenState>().AsSingle();
        Container.Bind<PanelState>().AsSingle();

        Container.Bind<PlayerView>().FromInstance(_playerView).AsSingle();
        Container.Bind<ITargetProvider>().FromInstance(_targetProvider).AsSingle();

        Container.Bind<IFadeService>().To<FadeService>().AsSingle();
        Container.Bind<Score>().AsSingle();
        Container.Bind<ISaver>().To<JsonSaver>().AsSingle();
        
        Container.Bind<ISoundPlayer>()
                .FromMethod(context => new SoundPlayer(_audioSource, _shootSound, _hitSound))
                .AsSingle();

        Container.BindMemoryPool<Bullet, Bullet.Pool>()
                 .WithInitialSize(20)
                 .FromComponentInNewPrefab(_bulletPrefab)
                 .UnderTransformGroup("BulletsPool");

        Container.BindInterfacesAndSelfTo<PlayerShooter>().AsSingle().NonLazy();
    }
}