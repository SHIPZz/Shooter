using UnityEngine;

public class CharacterAiming : MonoBehaviour
{
    private const string FireOne = "Fire1";
    private const float TurnSpeed = 15;

    [SerializeField] private Camera _mainCamera;

    private RaycastWeapon _weapon;

    private void Start()
    {
        _mainCamera = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _weapon = GetComponentInChildren<RaycastWeapon>();
    }

    private void FixedUpdate()
    {
        float yawCamera = _mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), TurnSpeed * Time.fixedDeltaTime);
    }

    private void Update()
    {
        if (_weapon != null)
        {
            if (Input.GetButtonDown(FireOne))
            {
                _weapon.StartFire();
            }
            else if (Input.GetButtonUp(FireOne))
            {
                _weapon.StopFire();
            }

            _weapon.UpdateBullets(Time.deltaTime);

            if (_weapon.IsFired)
                _weapon.UpdateFire(Time.deltaTime);
        }
    }
}