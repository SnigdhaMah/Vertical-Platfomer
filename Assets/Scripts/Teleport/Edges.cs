using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edges : MonoBehaviour
{
    public Transform leftEdge;
    public Transform rightEdge;

    public Edges instance;

    public void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
