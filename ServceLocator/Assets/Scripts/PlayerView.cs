using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    public Vector3 FirePointPosition => _firePoint.position; 
}
