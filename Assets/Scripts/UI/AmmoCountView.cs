using TMPro;
using UnityEngine;

public class AmmoCountView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ammoText;

    public void Refresh(int ammoCount) => _ammoText.text = ammoCount.ToString();
}
