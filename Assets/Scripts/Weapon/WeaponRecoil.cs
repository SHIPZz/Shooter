using Cinemachine;
using UnityEngine;

public class WeaponRecoil : MonoBehaviour
{
    private const int DecreaseReturn = 1000;

    [SerializeField] private float _verticalRecoil;

    private readonly float _duration = 0.1f;

    private CinemachineFreeLook _playerCamera;
    private float _time;

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
    }

    public void SetPlayerCamera(CinemachineFreeLook playerCamera)
    {
        _playerCamera = playerCamera;
    }
}