using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public int Wellness { get; private set; }

    public void Decrease(int damage)
    {
        Wellness = Mathf.Clamp(Wellness - damage, 0, 100);
    }


}
