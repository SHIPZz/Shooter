using UnityEngine;

public class Health : MonoBehaviour
{
    private const int MaxHealth = 5000;
    private const int MinHealth = 0;

    [field: SerializeField] public int Wellness { get; private set; }

    public void Decrease(int damage)
    {
        Wellness = Mathf.Clamp(Wellness - damage, MinHealth, MaxHealth);
    }


}
