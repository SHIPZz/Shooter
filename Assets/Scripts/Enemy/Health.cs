using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public int Wellness { get; private set; }

    public event Action<int> OnWellnessChanged;
    public event Action<int> OnWellnessZeroReached;

    public void Decrease(int damage)
    {
        Wellness = Mathf.Clamp(Wellness - damage, 0, Wellness);

        if (Wellness == 0)
        {
            OnWellnessZeroReached?.Invoke(Wellness);
        }

        OnWellnessChanged?.Invoke(Wellness);
    }
}