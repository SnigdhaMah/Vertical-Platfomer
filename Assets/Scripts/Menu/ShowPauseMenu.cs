using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPauseMenu : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            this.GetComponent<RectTransform>().gameObject.SetActive(true);
        } else
        {
            this.GetComponent<RectTransform>().gameObject.SetActive(false);

        }
    }
}
