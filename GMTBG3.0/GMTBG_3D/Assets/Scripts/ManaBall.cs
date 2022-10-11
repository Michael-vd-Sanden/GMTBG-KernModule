using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DestructableWall")
        {
            DestructableWall wall = other.GetComponentInParent<DestructableWall>();
            if(wall != null)
            {
                wall.destroyWall();
            }
        }
    }
}
