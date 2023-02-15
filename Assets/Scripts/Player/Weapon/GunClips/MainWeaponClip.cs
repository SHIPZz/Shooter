using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWeaponClip : MonoBehaviour
{
    private readonly int _bulletsCount = 30;
    private List<int> _bullets = new();

    void Start()
    {
        for (int i = 0; i < _bullets.Count; i++)
        {
            _bullets.Add(_bulletsCount);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
