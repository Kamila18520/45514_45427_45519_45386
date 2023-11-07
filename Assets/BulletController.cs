using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float velocity;
    [SerializeField] new Rigidbody rigidbody;
    public float damage;
    // Start is called before the first frame update

    private void Awake()
    {
        rigidbody.velocity = transform.forward* velocity;
        Destroy(gameObject, 5f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        var damagables = collision.collider.GetComponentsInParent<IDamagable>();
        if (damagables.Length == 0)
            return;
        foreach (var damagable in damagables)
        {
           
            damagable.AddDamage(damage);
            
            
        }
        

    }

}
