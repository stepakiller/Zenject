using UnityEngine;
public class SoundPlayer : ISoundPlayer
{
    readonly AudioSource _audioSource;
    readonly AudioClip _shootClip;
    readonly AudioClip _hitClip;
    public SoundPlayer(AudioSource audioSource, AudioClip shootClip, AudioClip hitClip)
    {
        _audioSource = audioSource;
        _shootClip = shootClip;
        _hitClip = hitClip;
    }
    public void PlayShootSound() => _audioSource.PlayOneShot(_shootClip);
    public void PlayHitSound() => _audioSource.PlayOneShot(_hitClip);
}