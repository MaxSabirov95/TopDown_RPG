using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerXPBar : MonoBehaviour
{
    public Slider sliderXP;

    public void SetXP(int XP)
    {
        sliderXP.value = XP;
    }
}
