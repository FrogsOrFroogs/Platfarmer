using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float SmoothSpeed = 0.1f;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    private Vector3 velocity = Vector3.zero;
    void Update()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, SmoothSpeed);
        transform.position = smoothedPosition;
    }
}
