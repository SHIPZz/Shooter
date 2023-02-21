using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    void LateUpdate()
    {
        transform.LookAt(_camera.transform);
    }
}
