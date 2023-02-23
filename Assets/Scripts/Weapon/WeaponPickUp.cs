using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    [SerializeField] private RaycastWeapon _weapon;

    private void OnTriggerEnter(Collider other)
    {
        ActivationWeapon activeWeapon = other.gameObject.GetComponent<ActivationWeapon>();

        if (activeWeapon)
        {
            activeWeapon.EquipWeapon(_weapon);
        }

        Destroy(gameObject);
    }
}