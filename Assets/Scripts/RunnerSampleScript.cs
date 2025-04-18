using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerSampleScript : MonoBehaviour
{
    [SerializeField]
    private List<SampleSript> Scipts;

    [ContextMenu("Activate scripts")]
    public void UseScripts()
    {
        foreach (SampleSript s in Scipts)
        {
            s.Use();
        }
    }
}
