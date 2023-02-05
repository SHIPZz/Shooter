using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
   [SerializeField] private Animator _animator;


    void Update()
    {
        var input = Event.current;

        switch(input.keyCode)
        {
            case KeyCode.Space:
                _animator.Play("Jump");
                break;


        }
    }
}
