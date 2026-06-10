using UnityEngine;
using Zenject;

public class PlayerShooter : ITickable
{
    readonly Bullet.Pool _bulletPool;
    readonly ISoundPlayer _soundPlayer;
    readonly PlayerView _player;
    public PlayerShooter(Bullet.Pool bulletPool, ISoundPlayer soundPlayer, PlayerView player)
    {
        _bulletPool = bulletPool;
        _soundPlayer = soundPlayer;
        _player = player;
    }

    public void Tick()
    {
        if (Input.GetMouseButtonDown(0)) Shoot();
    }

    void Shoot()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 spawnPos = _player.FirePointPosition;
        Vector3 direction = (mousePos - spawnPos).normalized;
        _bulletPool.Spawn(spawnPos, direction);
        _soundPlayer.PlayShootSound();
    }
}