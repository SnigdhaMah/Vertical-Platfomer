using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public bool facingRight;
    public Portal connection;
    public PlayerController player;
    public bool recentlyTeleported;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //gets where on the portal the player hit
            var direction = transform.InverseTransformPoint(other.transform.position);

            //the player hit the right side of the portal 
            if (direction.x > 0f && connection.recentlyTeleported == false)
            {
                //the mouth is on the right
                if (facingRight)
                {
                    //if the player is trying to enter the open mouth of the portal, move it to the other portal
                    player.transform.position = connection.transform.position;

                    recentlyTeleported = true;
                    connection.recentlyTeleported = true;

                    Debug.Log(recentlyTeleported + " and " + connection.recentlyTeleported);

                    //    (  <- O
                    //    (( O ->

                }
            }

            //the player hit the left side of the portal
            else if (direction.x < 0f && connection.recentlyTeleported == false)
            {
                //the mouth is on the left
                if (!facingRight)
                {
                    //if the player is trying to enter the open mouth of the portal, move it to the other portal
                    player.transform.position = connection.transform.position;

                    recentlyTeleported = true;
                    connection.recentlyTeleported = true;

                }
            }

            StartCoroutine("resetCoroutine");
        }

    }

    public IEnumerator resetCoroutine ()
    {
        //if go left and connection is facing right        or if go right and connection is facing left
        if (player.movement < 0 && connection.facingRight || player.movement > 0 && !connection.facingRight)
        {
            //switch the direction
            player.movement = -(player.movement);
            Debug.Log(player.movement);
        }

        yield return new WaitForSeconds(.5f);

        recentlyTeleported = false;
        connection.recentlyTeleported = false;

        //switch it back
        player.movement = -(player.movement);

    }
}

