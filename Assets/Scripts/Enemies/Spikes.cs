using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public Animator animator;
    public PlayerHealth health;

    void Start()
    {
        health = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if the player hits the spikes
        if (other.CompareTag("Player"))
        {
            animator.SetBool("isHurt", true);
            health.TakeDamage(1);
        }
    }
}
