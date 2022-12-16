using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject explosionPrefab;

    [SerializeField] private float missileSpeed = 45f;

    private Transform target;

    private void Awake() {
        if(rb == null) {
            rb = gameObject.GetComponent<Rigidbody>();
        }
    }

    private void FixedUpdate()
    {
        //rb.velocity = transform.up * missileSpeed * Time.deltaTime;
        rb.AddForce(-transform.up * missileSpeed);
    }

    private void OnCollisionEnter(Collision other) {
        //Instantiate explosion at collision point
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        //
        //Damage, score, physics calculations, etc. here
        //

        Destroy(gameObject);
    }
}
