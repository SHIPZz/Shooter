using System.Collections;
using UnityEngine;

public class RealodingWeapon : MonoBehaviour
{
    private const string CommandDetachMagazine = "detach_magazine";
    private const string CommandDropMagazine = "drop_magazine";
    private const string CommandRefillMagazine = "refill_magazine";
    private const string CommandfAttachMagazine = "attach_magazine";
    private const float Delay = 1f;

    [SerializeField] private Animator _rigController;
    [SerializeField] private ActivationWeapon _activeWeapon;
    [SerializeField] private Transform _leftHand;
    [SerializeField] private WeaponAnimationEvent _animationEvents;
    [SerializeField] private AmmoWidget _ammoWidget;

    private GameObject _magazineHand;
    private bool _isReloading;
    private int _isReloaded = Animator.StringToHash("IsReloaded");

    private void Start()
    {
        _animationEvents.AnimationPlayed.AddListener(OnAnimationEvent);
    }

    private void Update()
    {
        if (_isReloading)
            return;

        RaycastWeapon weapon = _activeWeapon.GetActiveWeapon();

        if (weapon == null)
            return;

        if (weapon.AmmoCount <= 0 && Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(EndReloadCoroutine(Delay));
            _isReloading = true;
            _rigController.SetTrigger(_isReloaded);
            return;
        }

        if (weapon.IsFired)
            _ammoWidget.Refresh(weapon.AmmoCount);
    }

    public void OnAnimationEvent(string eventName)
    {
        switch (eventName)
        {
            case CommandDetachMagazine:
                DetachMagazine();
                break;

            case CommandDropMagazine:
                DropMagazine();
                break;

            case CommandRefillMagazine:
                RefillMagazine();
                break;

            case CommandfAttachMagazine:
                AttachMagazine();
                break;
        }
    }

    private void AttachMagazine()
    {
        RaycastWeapon weapon = _activeWeapon.GetActiveWeapon();

        _magazineHand.transform.SetParent(weapon.transform);
        _magazineHand.transform.localPosition = weapon.Magazine.transform.localPosition;
        _magazineHand.transform.localRotation = weapon.Magazine.transform.localRotation;

        GameObject oldMagazine = weapon.Magazine;
        weapon.SetMagazinePosition(_magazineHand);

        Destroy(oldMagazine);

        weapon.SetAmmoCount(weapon.ClipSize);

        _ammoWidget.Refresh(weapon.AmmoCount);
    }

    private void RefillMagazine()
    {
        _magazineHand.SetActive(true);
    }

    private void DropMagazine()
    {
        GameObject droppedMagazine = Instantiate(_magazineHand, _magazineHand.transform.position, _magazineHand.transform.rotation);
        droppedMagazine.AddComponent<Rigidbody>();
        droppedMagazine.AddComponent<BoxCollider>();
        _magazineHand.SetActive(false);
        float delay = 5f;

        Destroy(droppedMagazine, delay);
    }

    private void DetachMagazine()
    {
        RaycastWeapon weapon = _activeWeapon.GetActiveWeapon();

        _magazineHand = Instantiate(weapon.Magazine, _leftHand, true);

        weapon.Magazine.SetActive(false);
    }

    private IEnumerator EndReloadCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        _isReloading = false;
    }
}