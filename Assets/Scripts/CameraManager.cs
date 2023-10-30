using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    private Camera _camera;
    public Plane[] _cameraPlanes;

    private void Start()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);


        _camera = Camera.main;
        _cameraPlanes = GeometryUtility.CalculateFrustumPlanes(_camera);
    }

}

