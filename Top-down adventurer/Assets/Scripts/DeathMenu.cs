using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    CharacterMovement cm;
    Attacks att;
    public GameObject character;
    public GameObject Deathmenu;

    public void SetActive(bool boolean)
    {
        Deathmenu.SetActive(boolean);
        if (boolean)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
        cm.SetActive(!boolean);
        att.SetActive(!boolean);
    }

    public bool IsActive()
    {
        return Deathmenu.activeSelf && Time.timeScale == 0;
    }

    private void Start()
    {
        cm = character.GetComponent<CharacterMovement>();
        att = character.GetComponent<Attacks>();
        SetActive(false);
    }
}
