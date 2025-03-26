using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : SampleSript
{
    [SerializeField]
    private Vector3 rotationAxis;

    [SerializeField]
    [Range(0,360)]
    private float rotationAngle = 90f;

    [SerializeField]
    private float rotationSpeed = 10f;

    [SerializeField]
    private Transform target;

    [ContextMenu("erect")]
    public override void Use()
    {
        StartCoroutine(RotateAroundAxis());
    }

        IEnumerator RotateAroundAxis()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(rotationAxis * rotationAngle); 

        float elapsedTime = 0f;
        float totalDuration = rotationAngle / rotationSpeed; 

        while (elapsedTime < totalDuration)
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime / totalDuration);
            
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endRotation;
    }
}
