using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void setStamina(int stamina)
    {
        slider.value = stamina;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void setMaxStamina(int stamina)
    {
        slider.maxValue = stamina;
        slider.value = 0;

        fill.color = gradient.Evaluate(0f);
    }
}
