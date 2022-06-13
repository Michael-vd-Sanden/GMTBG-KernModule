using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightScript : MonoBehaviour
{
    public int speed = 10;
    public GameObject successBar;

    private Rigidbody2D rb;
    public bool isActive = true;

    [SerializeField] private GameObject attackScreen;
    [SerializeField] GetMonster getMonster;
    [SerializeField] LoadScenes scenes;

    private MonsterScript monster;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            isActive = false;
            CheckIfWon();
        }
        if(getMonster.checkIfActive())
        {
            Debug.Log("You won bitch");
            scenes.loadMainScene();
        }
    }

    public void CheckIfWon()
    {
        Vector2 position = rb.position;
        float successbar = successBar.transform.localScale.x;
        float bound1 = successbar / 2;
        float bound2 = bound1 * -1;
        if (position.x < bound1 && position.x > bound2)
        {
            Debug.Log("WON");
            monster = getMonster.getActiveMonster();
            monster.ChangeHealth(10);
        }
        attackScreen.SetActive(false);
    }


    private void FixedUpdate()
    {
        if(!isActive)
        { return; }

        Vector2 position = rb.position;

        if (position.x > 0.86f || position.x < -0.86f)
        {
            speed = speed * -1;
        }
        position.x += speed * Time.deltaTime;

        rb.MovePosition(position);
    }
}
