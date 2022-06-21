using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{
    [SerializeField] private UIManaBar mana;

    private Vector3 direction;

    bool hasMoved;
    float horizontal;
    float vertical;

    public Tilemap floorTiles;
    public Tile greenTile;
    public Tile purpleTile;

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            RemovepurpleTiles();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            mana.PlusMana();
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
        if (horizontal < 0)
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
            Vector3Int currentPlayerTile = floorTiles.WorldToCell(transform.position);
            if (floorTiles.GetTile(currentPlayerTile) != purpleTile && floorTiles.GetTile(currentPlayerTile) != greenTile)
            { transform.position -= direction; }

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
            Vector3Int currentPlayerTile = floorTiles.WorldToCell(transform.position);
            if (floorTiles.GetTile(currentPlayerTile) != purpleTile && floorTiles.GetTile(currentPlayerTile) != greenTile)
            { transform.position -= direction; }
        }
    }

    public void RemovepurpleTiles()
    {
        Vector3Int currentPlayerTile = floorTiles.WorldToCell(transform.position);

        if (floorTiles.GetTile(currentPlayerTile) == purpleTile)
        { floorTiles.SetTile(currentPlayerTile, greenTile); }

        mana.MinusMana();
    }

    public void SetPlayersBack()
    {
        direction = new Vector3(-1, 0, 0);

        transform.position += direction;
    }

}
