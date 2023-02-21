using TMPro;
using UnityEngine;

public class AmmoWidget : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ammoText;

    public void Refresh(int ammoCount) => _ammoText.text = ammoCount.ToString();
}
