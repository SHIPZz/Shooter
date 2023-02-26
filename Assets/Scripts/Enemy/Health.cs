using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public int Value { get; private set; }

    public event Action<int> ValueChanged;
    public event Action<int> ValueZeroReached;

    private void Start()
    {
        ValueChanged?.Invoke(Value);
    }

    public void Decrease(int damage)
    {
        Value = Mathf.Clamp(Value - damage, 0, Value);

        if (Value == 0)
        {
            ValueZeroReached?.Invoke(Value);
        }

        ValueChanged?.Invoke(Value);
    }
}