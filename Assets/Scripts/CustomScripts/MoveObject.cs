using UnityEngine;
using System.Collections;

public class MoveObject : SampleSript
{
    [Header("Penis")]
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private float moveSpeed = 1f;

    private bool isMoving = false;

    [ContextMenu("Rabotai")]
    public override void Use()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveToTarget());
        }
    }

    private IEnumerator MoveToTarget()
    {
        isMoving = true;
        Vector3 startPosition = transform.position;
        float distance = Vector3.Distance(startPosition, targetPosition);
        float duration = distance / moveSpeed;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        isMoving = false;
    }
}
