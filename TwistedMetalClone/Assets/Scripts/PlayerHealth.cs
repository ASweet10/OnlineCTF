using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private float maxShield = 100f;
    [SerializeField] private float maxHealth = 100f;
    private float currentShield;
    private float currentHealth;

    private void Start()
    {
        ResetStats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ResetStats()
    {
        currentHealth = maxHealth;
        currentShield = maxShield;
    }

    public void TakeDamage(int damageVal)
    {
        currentHealth -= damageVal;
        if(currentHealth <= 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
