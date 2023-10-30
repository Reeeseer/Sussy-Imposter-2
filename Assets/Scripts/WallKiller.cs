using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallKiller : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Wall wall = other.GetComponentInParent<Wall>();
        if(wall != null)
        {
            Destroy(wall.gameObject);
        }
    }
}
