using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Offset between camera and target
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;
    [SerializeField] private float translationSpeed;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private float smoothTime = 0.3f;
    private void FixedUpdate()
    {
        HandleTranslation();
        HandleRotation();
    }

    private void HandleTranslation()
    {
        var targetPosition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, translationSpeed * Time.deltaTime);
        //transform.position = Vector3.SmoothDamp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
    }
    private void HandleRotation()
    {
        var direction = target.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
