using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int curHealth;
    public static int maxHealth = 100;
    public static int attack = 5;
    //[SerializeField] private HealthBar healthBar;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.position = spawnPoint.position;
        curHealth = maxHealth;
        //healthBar.alterMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Hurt(10);
        }
        DeathCheck();
    }

    //reduces current health
    private void Hurt(int hurtAmount)
    {
        curHealth -= hurtAmount;
        //healthBar.alterHealth(curHealth);
    }

    private void DeathCheck()
    {
        if(rb.position.y < - 20)
        {
            curHealth = 0;
        }
        if(curHealth == 0)
        {
            curHealth = maxHealth;
            //healthBar.alterHealth(curHealth);
            rb.velocity = new Vector2(rb.velocity.x * 0f, rb.velocity.y * 0f);
            rb.position = spawnPoint.position;
        }
    }
}
