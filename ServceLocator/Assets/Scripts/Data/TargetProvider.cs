using UnityEngine;

public class TargetProvider : MonoBehaviour, ITargetProvider
{
    public Vector3 Position => transform.position;
    public bool IsActive => gameObject.activeInHierarchy;
}