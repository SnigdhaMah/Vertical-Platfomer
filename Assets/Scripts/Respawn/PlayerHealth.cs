using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public PlayerHealth instance;

    public int maxHealth = 6;
    public int currentHealth;
    public HealthBar healthBar;

    public RespawnController resp;

    public Animator animator;


    //int count;
    //bool returnedtoCheckPoint;
    //bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        currentHealth = maxHealth;

        //access the health bar
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        healthBar.SetMaxHealth(maxHealth);

        //access the respawner
        resp = GameObject.FindGameObjectWithTag("RespawnController").GetComponent<RespawnController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            //GAME OVER

            //idk why its not showing up when respawning fix this
            resp.Respawn();

        }

    }

    public void TakeDamage(int damage)
    {       
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);

        StartCoroutine("AnimationCoroutine");

    }

    public void Restore ()
    {
        currentHealth = maxHealth;
        healthBar.setHealth(currentHealth);

    }

    public IEnumerator AnimationCoroutine ()
    {
        //animator.SetBool("isHurt", true);

        yield return new WaitForSeconds(3f);

        animator.SetBool("isHurt", false);
    }
}
