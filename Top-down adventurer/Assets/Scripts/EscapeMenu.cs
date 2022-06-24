using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenu : MonoBehaviour
{
    CharacterMovement cm;
    Attacks att;
    public GameObject character;
    public GameObject Escapemenu;
    public GameObject optionsmenu;

    public void SetActive(bool boolean)
    {
        Escapemenu.SetActive(boolean);
        if (boolean)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
        cm.SetActive(!boolean);
        att.SetActive(!boolean);
    }

    public bool IsActive()
    {
        return Escapemenu.activeSelf && Time.timeScale == 0;
    }

    private void Start()
    {
        cm = character.GetComponent<CharacterMovement>();
        att = character.GetComponent<Attacks>();
        optionsmenu.SetActive(false);
        SetActive(false);
    }
}
