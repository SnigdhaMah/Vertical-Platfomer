using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;

    public KeyScript key;

    public void Update()
    {

        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                //if this is the current tutorial step, show the popup
                popUps[i].SetActive(true);
            }
            else
            {
                //hide all other popups
                popUps[i].SetActive(false);
            }
        }


        if (popUpIndex == 0)
        {
            //tutorial start -> left and right arrow instructions

            //wait till player hits left or right keys
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1)
        {
            //jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2)
        {
            //shoot
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 3)
        {
            //pause
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 4)
        {
            //press 1
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 5)
        {
            //press 2
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 6)
        {
            //press 3
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 7)
        {
            //press 4
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 8)
        {
            //right click
            if (Input.GetMouseButton(1))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 9)
        {
            //left click
            if (Input.GetMouseButton(0))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 10)
        {
            //key
            if (key.hit == true)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 11)
        {
            //helper guy
            //if helper guy is hit level 1 starts
        }

    }
}
