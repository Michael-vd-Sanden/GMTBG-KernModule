using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MovementController : MonoBehaviour
{
    private Vector3 direction;

    bool hasMoved;
    float horizontal;
    float vertical;

    public Tilemap purpleTiles;

    public int cureRange = 1;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            RemovepurpleTiles();
        }
        Move();
    }

    public void Move()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (horizontal == 0)
        {
            hasMoved = false;
        }
        else if (horizontal != 0 && !hasMoved)
        {
            hasMoved = true;
            GetMovementDirection();
        }
    }

    public void GetMovementDirection()
    {
        if(horizontal < 0)
        {
            if (vertical > 0)
            {
                direction = new Vector3(-0.5f, 0.75f);
            }
            else if (vertical < 0)
            {
                direction = new Vector3(-0.5f, -0.75f);
            }
            else
            {
                direction = new Vector3(-1, 0, 0);
            }
            transform.position += direction;
        }
        else if (horizontal > 0)
        {
            if (vertical > 0)
            {
                direction = new Vector3(0.5f, 0.75f);
            }
            else if (vertical < 0)
            {
                direction = new Vector3(0.5f, -0.75f);
            }
            else
            {
                direction = new Vector3(1, 0, 0);
            }
            transform.position += direction;
        }
    }

    public void RemovepurpleTiles()
    {
        Vector3Int currentPlayerTile = purpleTiles.WorldToCell(transform.position);

        for(int x = -cureRange; x <= cureRange; x++)
        {
            for(int y = -cureRange; y <= cureRange; y++)
            {
                purpleTiles.SetTile(currentPlayerTile + new Vector3Int(x, y, 0), null);
            }
        }
    }

}
