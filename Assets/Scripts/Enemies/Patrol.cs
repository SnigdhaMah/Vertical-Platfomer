using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool moveRight;
    public Transform GroundDetector;

    // Update is called once per frame
    void Update()
    {
        //move enemy right
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        //check the area right in front of the player
        RaycastHit2D groundCheck = Physics2D.Raycast(GroundDetector.position, Vector2.down, distance);

        //if didn't hit anything aka not on ground anymore
        if (groundCheck.collider == false)
        {
            //if moving right
            if (moveRight == true)
            {
                //rotates the object to look left
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveRight = false;
            }
            else
            {
                //if no more ground but moving left, go right
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveRight = true;
            }
        }
    }
}
