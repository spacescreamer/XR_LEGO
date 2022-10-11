using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event System.Action OnReachedEndOfLevel;
    bool disabled;

    void Start()
    {
        Guard.OnGuardHasSpottedPlayer += Disable;
    }


    void OnTriggerEnter(Collider hitCollider)
    {
        if (hitCollider.tag == "Finish")
        {
            Disable();
            if (OnReachedEndOfLevel !=null)
            {
                OnReachedEndOfLevel();
            }
        }
    }

    void Disable()
    {
        disabled = true;
    }


    void OnDestroy()
    {
        Guard.OnGuardHasSpottedPlayer -= Disable;
    }
}
