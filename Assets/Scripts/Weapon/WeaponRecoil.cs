using Cinemachine;
using UnityEngine;

public class WeaponRecoil : MonoBehaviour
{
    private const int DecreaseReturn = 1000;

    [SerializeField] private float _verticalRecoil;
    [SerializeField] private float _duration;

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