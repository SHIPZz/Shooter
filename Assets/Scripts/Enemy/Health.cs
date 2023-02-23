using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public int Wellness { get; private set; }

    public event Action<int> WellnessChanged;
    public event Action<int> WellnessZeroReached;

    private void Start()
    {
        WellnessChanged?.Invoke(Wellness);
    }

    public void Decrease(int damage)
    {
        Wellness = Mathf.Clamp(Wellness - damage, 0, Wellness);

        if (Wellness == 0)
        {
            WellnessZeroReached?.Invoke(Wellness);
        }

        WellnessChanged?.Invoke(Wellness);
    }
}