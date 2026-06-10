using UnityEngine;

public class DestructibleObstacle : MonoBehaviour
{
    [SerializeField] GameObject _idleModel;
    [SerializeField] GameObject _brokenModel;
    [SerializeField] Collider2D _collider;

    public void DestroyObstacle()
    {
        _idleModel.SetActive(false);
        _brokenModel.SetActive(true);
        _collider.enabled = false;
    }
}
