using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SplineManager : MonoBehaviour
{
    public static SplineManager instance;

    public List<SplineContainer> Splines = new List<SplineContainer>();

    private void Awake()
    {
        if(instance == null) 
            instance = this;
    }

    public void AddSpline(SplineContainer spline)
    {
        Splines.Add(spline);
    }

}
