using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Camera cam;
    public float cameraPlusX = 5f;
    public float cameraPlusY = 2f;

    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x + cameraPlusX, player.transform.position.y + cameraPlusY, transform.position.z);
    }

    public void hp1()
    {
        //cam.orthographicSize = 5f;
        //cameraPlusX = 2f;
        //cameraPlusY = 0.5f;
    }

    public void hp2()
    {
        //cam.orthographicSize = 5f;
        //cameraPlusX = 3.2f;
        //cameraPlusY = 0.8f;
    }
    public void hp3()
    {
        //cam.orthographicSize = 5f;
        //cameraPlusX = 4.8f;
        //cameraPlusY = 0.85f;
    }
    public void hp4()
    {
        //cam.orthographicSize = 6f;
        //cameraPlusX = 6.4f;
        //cameraPlusY = 0.9f;
    }
    public void hp5()
    {
        //cam.orthographicSize = 7.5f;
        //cameraPlusX = 8f;
        //cameraPlusY = 1f;
    }
}
