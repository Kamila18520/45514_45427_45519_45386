using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    [SerializeField] Transform bulletPrefab;
    [SerializeField] Transform bulletSpawnTransform;
    [SerializeField] float weaponCooldown;

    [Header("Bullet")]
    [SerializeField] private float bulletVelocity;
    [SerializeField] private float weaponDamage;

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {      
            bulletPrefab.GetComponent<BulletController>().velocity= bulletVelocity;
            bulletPrefab.GetComponent<BulletController>().damage = weaponDamage;
             Instantiate(bulletPrefab, bulletSpawnTransform.position, bulletSpawnTransform.rotation);


        }
        
    }

}
