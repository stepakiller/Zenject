using UnityEngine;

public interface ITargetProvider
{
    Vector3 Position { get; }
    bool IsActive { get; }
}