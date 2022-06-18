using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//used to reload the scenes
using UnityEngine.SceneManagement;

public class PlayerPosition : MonoBehaviour
{
    private GameMaster gm;
    public float respawnDelay;


    // Start is called before the first frame update
    void Start()
    {
        //Respawn();
        //reference the gameobject instance
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

        //there are actually checkpoints saved and the coordinate is not just the default( (0,-7) which is below the start)
        if (gm.lastCheckpoint.x != 0 && gm.lastCheckpoint.y != -7)
        {
            //start the level at last checkpoint
            transform.position = gm.lastCheckpoint;
        }

        //if there are no checkpoints saved, go to the beginning
    }

    void setPosition ()
    {
        //reference the gameobject instance
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

        //there are actually checkpoints saved and the coordinate is not just the default( (0,-7) which is below the start)
        if (gm.lastCheckpoint.x != 0 && gm.lastCheckpoint.y != -7)
        {
            //start the level at last checkpoint
            transform.position = gm.lastCheckpoint;
        }

        //if there are no checkpoints saved, go to the beginning
    }

    //delay respawn
    /*public IEnumerator Respawn () 
    {
        //make player inactive 
        gameObject.SetActive(false);

        //wait for x amount of seconds
        yield return new WaitForSeconds(respawnDelay);

        //move to checkpoint
        setPosition();

        //give player access again
        gameObject.SetActive(true);
    }*/

}
