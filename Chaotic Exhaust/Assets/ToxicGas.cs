using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ToxicGas : MonoBehaviour
{
    [SerializeField]
    float _damage = 5;
    //[SerializeField]private Collider _gasZone;
    bool canTrigger = true;

    private void OnTriggerStay(Collider other)
    {
        var damagable = other.gameObject.GetComponent<IAffectGas>();

        if (damagable != null && canTrigger)
            StartCoroutine(DeadGasDamage(damagable));
    }

    IEnumerator DeadGasDamage(IAffectGas damagable)
    {
        if (damagable != null)
        {
            damagable.EnterGas(_damage);
            canTrigger = false;
            yield return new WaitForSeconds(2f);
            canTrigger = true;
        }
    }
}
