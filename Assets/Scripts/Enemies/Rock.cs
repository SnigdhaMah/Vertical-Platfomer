using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rigid;
    private Vector2 boundaries;
    
    public Throw enemy;

    public PlayerHealth health;

    public Teleport teleport;

    public Camera seeOptions;

    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();

        health = GameObject.Find("PlayerHealth").GetComponent<PlayerHealth>();

        if (GameObject.FindGameObjectWithTag("Player") != null) 
        {
            teleport = GameObject.FindGameObjectWithTag("Player").GetComponent<Teleport>();
        }

        //if the enemy plans to throw left
        if (enemy.throwLeft == true)
        {
            speed = (-speed);
        }

        //set the velocity to the speed (this one goes right
        rigid.velocity = new Vector2(speed, 0);

        Camera rendering = teleport.CameraType();

        boundaries = rendering.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height, rendering.transform.position.z));


    }

    // Update is called once per frame
    void Update()
    {
        //if outside of bounds of the screen on the right
        if (transform.position.x > boundaries.x * 10)
        {
            Destroy(this.gameObject);

        } else if (transform.position.x < boundaries.x * -10)
        {
            Destroy(this.gameObject);

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            health.TakeDamage(1);
            Destroy(this.gameObject);
        }
    }
}
