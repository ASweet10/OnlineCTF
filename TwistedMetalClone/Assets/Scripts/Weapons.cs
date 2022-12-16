using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [Header("Weapon Controls")]
    [SerializeField] private KeyCode weaponOneKey = KeyCode.Alpha1;
    [SerializeField] private KeyCode weaponTwoKey = KeyCode.Alpha2;
    [SerializeField] private KeyCode machineGunKey = KeyCode.Space;


    [SerializeField] private GameObject homingMissile;
    [SerializeField] private GameObject machineGunBullet;
    [SerializeField] private Transform missileSpawnPointOne;
    [SerializeField] private Transform missileSpawnPointTwo;



    private bool canUseWeapons = true;
    private bool slotOneFull = false;
    private bool slotTwoFull = false;

    private void Awake()
    {

    }

    private void Update()
    {
        if(canUseWeapons)
        {
            HandleWeaponInput();
        }
    }

    private void HandleWeaponInput()
    {
        // Player has weapon?
        //if(slotOneFull)
        //{
            if(Input.GetKeyDown(weaponOneKey))
            {
                FireMissile();
            }
            
            if(Input.GetKey(machineGunKey))
            {
                UseTheMachineGun();
            }
        //}
    }

    private void FireMissile()
    {
        Instantiate(homingMissile, missileSpawnPointOne.position, missileSpawnPointOne.rotation * Quaternion.Euler(30, 0, 15));
        Instantiate(homingMissile, missileSpawnPointTwo.position, missileSpawnPointTwo.rotation * Quaternion.Euler(30, 0, 15));
        Debug.Log("firezemissiles");
    }

    private void UseTheMachineGun()
    {
        GameObject bullet = Instantiate(machineGunBullet, missileSpawnPointOne.position, missileSpawnPointOne.rotation);
    }

    public void ToggleWeapons(bool canUseWeapons)
    {
        if(canUseWeapons) {
            canUseWeapons = true;
        } else {
            canUseWeapons = false;
        }
    }
}