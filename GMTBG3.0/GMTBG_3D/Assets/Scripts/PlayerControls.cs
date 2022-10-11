using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private GUIStyle guiStyle = new GUIStyle();

    public int playerSize;
    public int playerAttack;

    public GameObject manaBall;
    public Transform launchPoint;
    public float launchVelocity = 700f;

    private void Start()
    {
        playerSize = 1;
        playerAttack = 5;
    }

    private void Update()
    {
        CheckSize();
        if(Input.GetKeyDown(KeyCode.E))
        {
            playerSize++;
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject magicBall = Instantiate(manaBall, launchPoint.position, launchPoint.rotation);
            magicBall.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, launchVelocity));
        }
    }

    private void CheckSize()
    {
        switch (playerSize)
        {
            case 1: 
                gameObject.transform.localScale = new Vector3(1, 1, 1);
                break;
            case 2: 
                gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                break;
            case 3:
                gameObject.transform.localScale = new Vector3(2, 2, 2);
                break;
            case 4:
                gameObject.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
                break;
            case 5:
                gameObject.transform.localScale = new Vector3(3, 3, 3);
                break;
            case 6:
                gameObject.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
                break;
            case 7:
                gameObject.transform.localScale = new Vector3(4, 4, 4);
                break;
            case 8:
                gameObject.transform.localScale = new Vector3(4.5f, 4.5f, 4.5f);
                break;
        }
    }

    private void OnGUI()
    {
        guiStyle.fontSize = 30;
        GUI.Label(new Rect(10, 10, 400, 200), "LV: " + playerSize.ToString(), guiStyle);
        GUI.Label(new Rect(10, 40, 400, 200), "Attack score: " + playerAttack.ToString(), guiStyle);
    }
}
