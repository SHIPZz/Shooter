using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class WeaponAnimationEvent : MonoBehaviour
{
    public UnityEvent<string> AnimationPlayed;  

    public void OnAnimationEvent(string eventName)
    {
        AnimationPlayed?.Invoke(eventName);
    } 
}
