using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider sliderHP;

    public void SetMaxHealth(int health)
    {
        sliderHP.maxValue = health;
        sliderHP.value = health;
    }

    public void SetHealth(int health)
    {
        sliderHP.value = health;
    }
}
