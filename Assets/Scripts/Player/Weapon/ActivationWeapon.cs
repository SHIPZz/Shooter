using UnityEngine;
using UnityEditor.Animations;

public class ActivationWeapon : MonoBehaviour
{
    private const string FireOne = "Fire1";
    private const int LayerIndex = 1;

    [SerializeField] private Transform _crossHairTarget;
    [SerializeField] private UnityEngine.Animations.Rigging.Rig _handIk;
    [SerializeField] private Transform _weaponParent;
    [SerializeField] private Transform _weaponLeftGrip;
    [SerializeField] private Transform _weaponRightGrip;

    private RaycastWeapon _weapon;
    private Animator _animator;
    private AnimatorOverrideController _overrideAnimatorController;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _overrideAnimatorController = _animator.runtimeAnimatorController as AnimatorOverrideController;
        RaycastWeapon existingWeapon = GetComponentInChildren<RaycastWeapon>();

        if (existingWeapon)
        {
            EquipWeapon(existingWeapon);
        }
    }

    private void Update()
    {
        if (_weapon)
        {
            if (Input.GetButtonDown(FireOne))
                _weapon.StartFire();
            else if (Input.GetButtonUp(FireOne))
                _weapon.StopFire();

            _weapon.UpdateBullets(Time.deltaTime);

            if (_weapon._IsFired)
                _weapon.UpdateFire(Time.deltaTime);
        }
        else
        {
            _handIk.weight = 0.0f;
            _animator.SetLayerWeight(LayerIndex, 0.0f);
        }
    }


    public void EquipWeapon(RaycastWeapon weapon)
    {
        float weaponPositionX = -0.357f;
        float weaponPositionY = -0.078f;
        float weaponPositionZ = 0.378f;
        float invokeTime = 0.001f;
        float MaxlayerWeight = 1.0f;

        if(_weapon)
            Destroy(_weapon.gameObject);

        _weapon = weapon;
        _weapon.SetRaycastDestination(_crossHairTarget);
        _weapon.transform.parent = _weaponParent;
        _weapon.transform.localPosition = new Vector3(weaponPositionX, weaponPositionY, weaponPositionZ);
        _weapon.transform.localRotation = Quaternion.identity;
        _handIk.weight = 1.0f;

        _animator.SetLayerWeight(LayerIndex, MaxlayerWeight);

        Invoke(nameof(SetAnimationDelay), invokeTime);
    }

    private void SetAnimationDelay()
    {
        _overrideAnimatorController["empty_animation"] = _weapon.WeaponAnimation;
    }

    [ContextMenu("Save weapon pose")]
    private void SaveWeaponPose()
    {
        GameObjectRecorder recorder = new GameObjectRecorder(gameObject);
        recorder.BindComponentsOfType<Transform>(_weaponParent.gameObject, false);
        recorder.BindComponentsOfType<Transform>(_weaponLeftGrip.gameObject, false);
        recorder.BindComponentsOfType<Transform>(_weaponRightGrip.gameObject, false);
        recorder.TakeSnapshot(0.0f);
        recorder.SaveToClip(_weapon.WeaponAnimation);
        UnityEditor.AssetDatabase.SaveAssets();
    }
}