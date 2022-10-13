using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesScript : MonoBehaviour
{
    private PlayerGrowth player;

    private void Start()
    {
        player = FindObjectOfType<PlayerGrowth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (collision != null)
            {
                player.changeHealth(-1f);
            }
        }

    }
}
