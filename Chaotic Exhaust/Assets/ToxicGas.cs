using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicGas : MonoBehaviour
{
    [SerializeField]
    float _damage;
    private void OnTriggerStay(Collider other)
    {
        var affectGas = other.gameObject.GetComponent<IAffectGas>();

        if (affectGas != null)
            affectGas.EnterGas(_damage);
    }
}
