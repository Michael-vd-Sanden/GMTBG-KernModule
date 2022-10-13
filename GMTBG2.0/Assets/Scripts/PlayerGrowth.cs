using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrowth : MonoBehaviour
{
    //health and growth is stored here
    public float health;
    public float maxHealth = 10f;
    private int timesDied = 0;
    private bool isInvincible;
    private float invincibleTimer;
    public float timeInvincible = 2f;

    private PlayerController controller;
    private FightingControlls fight;
    private CameraController mainCam;
    [SerializeField] private SceneSelect scenes;

    [SerializeField] private GameObject life1;
    [SerializeField] private GameObject life2;
    [SerializeField] private GameObject life3;
    [SerializeField] private GameObject life4;
    [SerializeField] private GameObject life5;

    private void Start()
    {
        controller = FindObjectOfType<PlayerController>();
        fight = FindObjectOfType<FightingControlls>();
        mainCam = FindObjectOfType<CameraController>();
        health = maxHealth;
    }

    private void Update()
    {
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            { isInvincible = false; }
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            health++;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            health--;
        }
        SizeCheck();
    }

    public void SizeCheck()
    {
        switch (health)
        {
            case 1:
                controller.jumpForce = 3f;
                controller.walkingSpeed = 100f;
                fight.attackDamage = 1f;
                gameObject.transform.localScale = new Vector3(0.5f, 0.5f);
                mainCam.hp1();
                SetAllLivesToNull();
                life1.SetActive(true);
                break;
            case 2:
                controller.jumpForce = 6f;
                controller.walkingSpeed = 200f;
                fight.attackDamage = 2f;
                gameObject.transform.localScale = new Vector3(1.4f, 1.4f);
                mainCam.hp2();
                SetAllLivesToNull();
                life1.SetActive(true);
                life2.SetActive(true);
                break;
            case 3:
                controller.jumpForce = 9f;
                controller.walkingSpeed = 300f;
                fight.attackDamage = 3f;
                gameObject.transform.localScale = new Vector3(2.6f, 2.6f);
                mainCam.hp3();
                SetAllLivesToNull();
                life1.SetActive(true);
                life2.SetActive(true);
                life3.SetActive(true);
                break;
            case 4:
                controller.jumpForce = 12f;
                controller.walkingSpeed = 400f;
                fight.attackDamage = 4f;
                gameObject.transform.localScale = new Vector3(3.8f, 3.8f);
                mainCam.hp4();
                SetAllLivesToNull();
                life1.SetActive(true);
                life2.SetActive(true);
                life3.SetActive(true);
                life4.SetActive(true);
                break;
            case 5:
                controller.jumpForce = 15f;
                controller.walkingSpeed = 500f;
                fight.attackDamage = 5f;
                gameObject.transform.localScale = new Vector3(5f, 5f);
                mainCam.hp5();
                life1.SetActive(true);
                life2.SetActive(true);
                life3.SetActive(true);
                life4.SetActive(true);
                life5.SetActive(true);
                break;
        }
    }

    private void SetAllLivesToNull()
    {
        life1.SetActive(false);
        life2.SetActive(false);
        life3.SetActive(false);
        life4.SetActive(false);
        life5.SetActive(false);
    }

    public void changeHealth(float hp)
    {
        if (hp < 0)
        {
            if (isInvincible)
            {
                return;
            }
            controller.playerAnimator.SetTrigger("hit");
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        health = Mathf.Clamp(health + hp, 0, maxHealth);
        float percentage = (hp / maxHealth);
        Vector3 tempPercentage = new Vector3(percentage, 0);
        controller.healthMask.transform.position += tempPercentage;

        Debug.Log(health);
        if (health <= 0) //death
        {
            StartCoroutine(DeathBehaviour());
        }
    }

    private IEnumerator DeathBehaviour()
    {
        Time.timeScale = 0;
        controller.DeathScreen.SetActive(true);
        fight.enabled = false;

        yield return new WaitForSecondsRealtime(2f);

        controller.DeathScreen.SetActive(false);
        fight.enabled = true;
        Time.timeScale = 1;

        scenes.loadEndScene();
        yield break;
    }
}