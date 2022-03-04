using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUI : MonoBehaviour
{

    public RectTransform healthbar;
    public RectTransform staminabar;
    void Start()
    {
        //check if health bars need to be on top
        switch(SettingsMenu.barsPos)
        {
            case 0:
                healthbar.anchoredPosition = new Vector3(-285, -65, 0);
                staminabar.anchoredPosition = new Vector3(285, -65, 0);
                break;
            case 1:
                healthbar.anchoredPosition = new Vector3(-650, -913.44f, 0);
                staminabar.anchoredPosition = new Vector3(650, -913.44f, 0);
                break;
            case 2:
                healthbar.anchoredPosition = new Vector3(-650, -913.44f, 0);
                staminabar.anchoredPosition = new Vector3(-650, -830, 0);
                break;
        }
    }
}
