using UnityEngine;

public class CrossHairTarget : MonoBehaviour
{
    private Camera _mainCamera;
    private Ray _ray;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        _ray.origin = _mainCamera.transform.position;
        _ray.direction = _mainCamera.transform.forward;

        Physics.Raycast(_ray, out RaycastHit hitInfo);
        transform.position = hitInfo.point;
    }
}