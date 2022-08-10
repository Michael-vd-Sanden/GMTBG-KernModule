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

    public void zoomOut()
    {
        cam.orthographicSize += 0.2f;
    }    
}
