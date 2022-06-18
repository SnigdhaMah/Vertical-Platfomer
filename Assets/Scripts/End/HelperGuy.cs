using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelperGuy : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().name.Equals("Tutorial"))
            {
                SceneManager.LoadScene("Level 1");
            }
            else if (SceneManager.GetActiveScene().name.Equals("Level 1"))
            {
                SceneManager.LoadScene("End");
            }
        }
    }

}
