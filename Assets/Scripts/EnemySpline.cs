using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class EnemySpline : MonoBehaviour
{
    void Start()
    {
        SplineManager.instance.AddSpline(GetComponent<SplineContainer>());
    }

}
