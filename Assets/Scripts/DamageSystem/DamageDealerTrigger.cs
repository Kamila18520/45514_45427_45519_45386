using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealerTrigger : MonoBehaviour
{
    [SerializeField] float damagePerSecond;

    private void onTriggerStay(Collider other)
    {
        var damagable = other.GetComponentInParent<IDamagable>();
        if (ReferenceEquals(damagable, null))
            return;
        
        damagable.AddDamage(damagePerSecond * Time.fixedDeltaTime);
        


    }

}
