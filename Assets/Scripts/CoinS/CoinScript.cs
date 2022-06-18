using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    //when triggered by player
    void OnTriggerEnter2D(Collider2D other)
    {
        //only destroy if player hits the coin
        if (other.CompareTag("Player"))
        {
            //destroy the object this script is attached to 
            Destroy(gameObject);
            //call the changescore method in the score script
            Score.instance.ChangeScore();
        }
    }
}
