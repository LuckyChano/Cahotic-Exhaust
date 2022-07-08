using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicGas : MonoBehaviour
{
    [SerializeField]
    float _damage;
    [SerializeField]private Collider _gasZone;
    private void OnTriggerStay(Collider _gasZone)
    {
        var affectGas = _gasZone.gameObject.GetComponent<IAffectGas>();

        if (affectGas != null)
            affectGas.EnterGas(_damage);
    }
}
