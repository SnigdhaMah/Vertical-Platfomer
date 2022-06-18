using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rigid;
    private Vector2 boundaries;

    public PlayerController player;

    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();

        //set the velocity to the speed 
        rigid.velocity = transform.right * speed;

        //stored the measurements of the camera view.
        //x,y store negative and half the screen units
        boundaries = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    // Update is called once per frame
    void Update()
    {
        //if outside of bounds of the screen on the right
        if (transform.position.x > boundaries.x * 10)
        {
            Destroy(this.gameObject);

        }
        else if (transform.position.x < boundaries.x * -10)
        {
            Destroy(this.gameObject);

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            //destroy enemy once hit
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}