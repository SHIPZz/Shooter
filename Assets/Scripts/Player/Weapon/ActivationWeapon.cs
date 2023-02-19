using Cinemachine;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ActivationWeapon : MonoBehaviour
{
    private const string FireOne = "Fire1";
    private const string IsHolstered = "IsHolstered";

    [SerializeField] private Transform _crossHairTarget;
    [SerializeField] private Rig _handIk;
    [SerializeField] private Transform _weaponParent;
    [SerializeField] private Transform _weaponLeftGrip;
    [SerializeField] private Transform _weaponRightGrip;
    [SerializeField] private Animator _rigController;
    [SerializeField] private CinemachineFreeLook _playerCamera;
    [SerializeField] private AmmoWidget _ammoWidget;

    private RaycastWeapon _weapon;

    private void Start()
    {
        RaycastWeapon existingWeapon = GetComponentInChildren<RaycastWeapon>();

        if (existingWeapon)
        {
            EquipWeapon(existingWeapon);
        }
    }

    private void Update()
    {
        bool isHolstered = _rigController.GetBool(IsHolstered);

        if (_weapon)
        {
            if (Input.GetButtonDown(FireOne) && isHolstered == false)
                _weapon.StartFire();
            else if (Input.GetButtonUp(FireOne))
                _weapon.StopFire();

            _weapon.UpdateBullets(Time.deltaTime);

            if (_weapon.IsFired)
                _weapon.UpdateFire(Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.X))
            {
                _rigController.SetBool(IsHolstered, !isHolstered);
            }
        }
    }

    public RaycastWeapon GetActiveWeapon() => GetWeapon(ref _weapon);

    public void EquipWeapon(RaycastWeapon weapon)
    {
        float weaponPositionX = -0.41f;
        float weaponPositionY = 0.032f;
        float weaponPositionZ = 0.468f;

        if (_weapon)
            Destroy(_weapon.gameObject);

        _weapon = weapon;
        _weapon.SetRaycastDestination(_crossHairTarget);
        _weapon.Recoil.SetPlayerCamera(_playerCamera);
        _weapon.transform.parent = _weaponParent;
        _weapon.transform.localPosition = new Vector3(weaponPositionX, weaponPositionY, weaponPositionZ);
        _weapon.transform.localRotation = Quaternion.identity;

        _rigController.Play("equip_" + _weapon.Name);
        _ammoWidget.Refresh(weapon.AmmoCount);
    }

    public RaycastWeapon GetWeapon(ref RaycastWeapon weapon) => weapon;
}