using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChangeSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;
    private int howManyWeapons;
    public int currentWeapon;
    
    void Start()
    {
        currentWeapon = 0;
        howManyWeapons = weapons.Length;
        weapons[currentWeapon].SetActive(true);
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Bron zmieniona");
            weapons[currentWeapon].SetActive(false);
            if(currentWeapon == weapons.Length-1)
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon = currentWeapon+1;
            }
            weapons[currentWeapon].SetActive(true);

        }
        
    }
}
