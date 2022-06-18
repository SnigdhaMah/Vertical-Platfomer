using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public HealthBar instance;

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    void Start()
    {
        if (instance == null)
        {
            instance = this;

        }
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        //one is the right, 0 is left
        fill.color = gradient.Evaluate(1f);

    }
    public void setHealth(int health)
    {
        slider.value = health;
        //normalized value is between 0 and 1
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
