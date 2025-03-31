using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class SoftRemoveScript : SampleSript
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float scale = 5f;

    [SerializeField]
    private float duration = 3f;

    [ContextMenu("Activate")]
    public override void Use()
    {
        StartCoroutine(ResizeAndDestroy(target.localScale / scale));
    }

    public IEnumerator ResizeAndDestroy(Vector3 endSize)
    {
        float timer = 0;
        Vector3 startSize = target.localScale;

        Transform[] children = new Transform[target.childCount];
        for (int i = 0; i < target.childCount; i++)
        {
            children[i] = target.GetChild(i);
        }

        while (timer < duration)
        {
            timer += Time.deltaTime;

            foreach (Transform child in children)
            {
                if (child != null)
                    child.localScale = Vector3.Lerp(startSize, endSize, timer / duration);
            }

            yield return null;
        }

        foreach (Transform child in children)
        {
            if (child != null) Destroy(child.gameObject);
        }
    }
}
