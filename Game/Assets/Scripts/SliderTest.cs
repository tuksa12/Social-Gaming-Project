using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTest : MonoBehaviour
{
    public Slider slider;

    public void Damage()
    {
        slider.value -= 0.1f;
    }

    public void Heal()
    {
        slider.value += 0.2f;
    }
}
