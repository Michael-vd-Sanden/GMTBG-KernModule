using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableWall : MonoBehaviour
{
    public GameObject destroyedWall;
    public GameObject completeWall;

    public void destroyWall()
    {
        Instantiate(destroyedWall, transform.position, transform.rotation);
        Destroy(completeWall);
    }
}
