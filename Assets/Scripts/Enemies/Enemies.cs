using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public PlayerHealth health;

    void Start()
    {
        health = GameObject.Find("PlayerHealth").GetComponent<PlayerHealth>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            health.TakeDamage(2);
        }
    }
}
