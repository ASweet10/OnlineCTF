using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    [Header("Ability Controls")]
    [SerializeField] private KeyCode abilityOneKey = KeyCode.Alpha1;
    [SerializeField] private KeyCode abilityTwoKey = KeyCode.Alpha2;
    [SerializeField] private KeyCode abilityThreeKey = KeyCode.Alpha3;
    [SerializeField] private KeyCode ultimateKey = KeyCode.Alpha4;
    [SerializeField] private KeyCode machineGunKey = KeyCode.Space;


    [Header("Objects")]
    [SerializeField] private GameObject homingMissile;
    [SerializeField] private GameObject machineGunBullet;
    [SerializeField] private Transform missileSpawnPointOne;
    [SerializeField] private Transform missileSpawnPointTwo;

    [Header("Parameters")]
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float missileSpeed;

    private GameObject target = null;
    private bool canUseAbilities = true;
    private bool abilityOneReady = true;
    private bool abilityTwoReady = true;
    private bool abilityThreeReady = true;
    private bool machineGunReady = true;
    private bool ultimateReady = true;

    private void Update() {
        if(canUseAbilities)
        {
            HandleWeaponInput();
        }
    }

    private void HandleWeaponInput() {
        if(Input.GetKeyDown(abilityOneKey)) {
            if(abilityOneReady) {
                UseAbilityOne();
            } else {
                Debug.Log("ABILITY 1 ON CD");
            }
        }

        if(Input.GetKeyDown(abilityTwoKey)) {
            if(abilityTwoReady) {
                UseAbilityTwo();
            } else {
                Debug.Log("ABILITY 2 ON CD");
            }
        }

        if(Input.GetKeyDown(abilityThreeKey)) {
            if(abilityThreeReady) {
                UseAbilityThree();
            } else {
                Debug.Log("ABILITY 3 ON CD");
            }
        }

        if(Input.GetKeyDown(ultimateKey)) {
            if(ultimateReady) {
                UseUltimate();
            } else {
                Debug.Log("ABILITY 4 ON CD");
            }
        }
            
        if(Input.GetKey(machineGunKey))
        {
            UseTheMachineGun();
        }
    }

    //Maybe make this into one large UseAbility function
    // Might make it easier to slot in abilities from each individual character then
    private void UseAbilityOne() {
        //If statement for each character?
        // Or
        // Each character has ability script with functions for all abilities
        // -Use ability 1, then check which ability to use based on car this script attached to
        // -
        GameObject rocketOne = Instantiate(homingMissile, missileSpawnPointOne.position, missileSpawnPointOne.rotation * Quaternion.Euler(30, 0, 15));
        GameObject rocketTwo = Instantiate(homingMissile, missileSpawnPointTwo.position, missileSpawnPointTwo.rotation * Quaternion.Euler(30, 0, 15));
        
        target = FindClosestTarget();
        rocketOne.transform.LookAt(target.transform);
        StartCoroutine(SendHoming(rocketOne, target));
        rocketTwo.transform.LookAt(target.transform);
        StartCoroutine(SendHoming(rocketTwo, target));

        Debug.Log("firezemissiles");
        StartCoroutine(WaitForAbilityCooldown(1, 3));
    }
        private void UseAbilityTwo() {
        Debug.Log("FIRE ABILITY 2");
        StartCoroutine(WaitForAbilityCooldown(2, 8));
    }
        private void UseAbilityThree() {
        Debug.Log("FIRE ABILITY 3");
        StartCoroutine(WaitForAbilityCooldown(3, 5));
    }
        private void UseUltimate() {
        Debug.Log("FIRE ULTIMATE");
        StartCoroutine(WaitForAbilityCooldown(4, 25));
    }

    private void UseTheMachineGun() {
        GameObject bullet = Instantiate(machineGunBullet, missileSpawnPointOne.position, missileSpawnPointOne.rotation);
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
        GameObject bulletTwo = Instantiate(machineGunBullet, missileSpawnPointTwo.position, missileSpawnPointTwo.rotation);
        Rigidbody bulletRBTwo = bulletTwo.GetComponent<Rigidbody>();
        bulletRB.AddForce(transform.forward * bulletSpeed);
        bulletRBTwo.AddForce(transform.forward * bulletSpeed);
        StartCoroutine(WaitForAbilityCooldown(5, 1f));
    }

    public void ToggleWeapons(bool canUseAbilities) {
        if(canUseAbilities) {
            canUseAbilities = true;
        } else {
            canUseAbilities = false;
        }
    }

    private IEnumerator WaitForAbilityCooldown(int abilityNum, float duration) {
        switch(abilityNum) {
            case 1:
                abilityOneReady = false;
                yield return new WaitForSeconds(duration);
                abilityOneReady = true;
                yield break;
            case 2:
                abilityTwoReady = false;
                yield return new WaitForSeconds(duration);
                abilityTwoReady = true;
                yield break;
            case 3:
                abilityThreeReady = false;
                yield return new WaitForSeconds(duration);
                abilityThreeReady = true;
                yield break;
            case 4:
                ultimateReady = false;
                yield return new WaitForSeconds(duration);
                ultimateReady = true;
                yield break;
            case 5:
                machineGunReady = false;
                yield return new WaitForSeconds(duration);
                machineGunReady = true;
                yield break;
            default:
                yield break;
        }
    }

    private IEnumerator SendHoming(GameObject rocket, GameObject target) {
        while(Vector3.Distance(target.transform.position, rocket.transform.position) > 0.3f) {
            rocket.transform.position += (target.transform.position - rocket.transform.position).normalized * missileSpeed * Time.deltaTime;
            rocket.transform.LookAt(target.transform);
            yield return null;
        }
        Destroy(rocket);
    }

    private GameObject FindClosestTarget() {
        GameObject target = null;
       float current = Mathf.Infinity;
       float dist = 0f;
       while(dist < current) {
        //Run through all enemy vehicles within radius or FOV cone
        //If Vector3.Distance(target.transform.position - gameObject.transform.position)
        // is less than the current distance, that target is the new target
        current = dist;
       }

       return target;
    }
}