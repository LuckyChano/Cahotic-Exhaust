using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicGas : MonoBehaviour
{
    [SerializeField]
    float _damage;
    [SerializeField]private Collider _gasZone;
    bool canTrigger = true;
    private void OnTriggerStay(Collider _gasZone)
    {
        var affectGas = _gasZone.gameObject.GetComponent<IAffectGas>();

        if (affectGas != null && canTrigger)
        {
            StartCoroutine(DeadGasDamage(affectGas));
        }
    }

    IEnumerator DeadGasDamage(IAffectGas damagable)
    {
        damagable.EnterGas(_damage);
        canTrigger = false;
        yield return new WaitForSeconds(1f);
        canTrigger = true;
    }
}
