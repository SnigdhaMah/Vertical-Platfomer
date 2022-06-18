using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnController : MonoBehaviour
{
    public RespawnController instance;
    public float respawnDelay;
    public PlayerController player;
    public PlayerHealth health;


    public GameMaster gm;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    public void Respawn ()
    {
         StartCoroutine("RespawnCoroutine");
    }


    //delay respawn
    public IEnumerator RespawnCoroutine()
    {
        //make player inactive 
        player.gameObject.SetActive(false);

        //wait for x amount of seconds
        yield return new WaitForSeconds(respawnDelay);

        //move to checkpoint and reload scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //give player access again
        player.gameObject.SetActive(true);

    }
}

