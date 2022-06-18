using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberOfRocks : MonoBehaviour
{
    public NumberOfRocks instance;

    public GameObject rock1, rock2, rock3;

    public int test = 3;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        rock1.gameObject.SetActive(true);
        rock2.gameObject.SetActive(true);
        rock3.gameObject.SetActive(true);

    }

    //change the amount of rocks shown on the UI
    public void changeDisplay (int rocks)
    {
        if (rocks == 3)
        {
            rock1.gameObject.SetActive(true);
            rock2.gameObject.SetActive(true);
            rock3.gameObject.SetActive(true);
        }
        else if (rocks == 2)
        {
            rock1.gameObject.SetActive(true);
            rock2.gameObject.SetActive(true);
            rock3.gameObject.SetActive(false);
        }
        else if (rocks == 1)
        {
            rock1.gameObject.SetActive(true);
            rock2.gameObject.SetActive(false);
            rock3.gameObject.SetActive(false);

        }
        else if (rocks == 0)
        {
            rock1.gameObject.SetActive(false);
            rock2.gameObject.SetActive(false);
            rock3.gameObject.SetActive(false);
        }
    }
}
