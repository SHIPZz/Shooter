using UnityEngine;

public class LookingAtCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void LateUpdate()
    {
        transform.LookAt(_camera.transform);
    }
}