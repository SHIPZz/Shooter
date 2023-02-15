using Cinemachine;
using UnityEngine;

public class WeaponRecoil : MonoBehaviour
{
    private const int DecreaseReturn = 1000;

    [SerializeField] private float _verticalRecoil;
    [SerializeField] private float _duration;

    private CinemachineFreeLook _playerCamera;
    private CinemachineImpulseSource _cameraShake;
    private float _time;

    private void Awake()
    {
        _cameraShake = GetComponent<CinemachineImpulseSource>();
    }

    private void Update()
    {
        if (_time > 0)
        {
            _playerCamera.m_YAxis.Value -= ((_verticalRecoil / DecreaseReturn) * Time.deltaTime) / _duration;
            _time -= Time.deltaTime;
        }
    }

    public void GenerateRecoil()
    {
        _time = _duration;

        _cameraShake.GenerateImpulse(Camera.main.transform.forward);
    }

    public void SetPlayerCamera(CinemachineFreeLook playerCamera)
    {
        _playerCamera = playerCamera;
    }
}
