using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    [SerializeField] private RaycastWeapon _weapon;

    private void OnTriggerEnter(Collider other)
    {
        ActivationWeapon activeWeapon = other.gameObject.GetComponent<ActivationWeapon>();

        if (activeWeapon)
        {
           _weapon = activeWeapon.GetWeapon(_weapon);
            activeWeapon.EquipWeapon(_weapon);
        }

        Destroy(gameObject);
    }
}