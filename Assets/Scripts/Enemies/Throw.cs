using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public Animator animator;
    public bool throwLeft;
    public float speed = 10f;
    private Rigidbody2D rigid;
    private Vector2 boundaries;

    public GameObject rock;
    public Throw instance;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;

        }

        //if the enemy needs to be set to the left
        if (throwLeft == true)
        {
            //turn player to left
            transform.eulerAngles = new Vector3(0, -180, 0);
        } else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        InvokeRepeating("throwRock", 1f, 2f);

    }

    public void throwRock ()
    {
        //when want to throw, make an object to throw
        GameObject r = Instantiate(rock) as GameObject;
        r.transform.position = enemy.transform.position;

    }
}
