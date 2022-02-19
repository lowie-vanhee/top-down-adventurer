using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    CharacterMovement cm;
    Attacks att;
    public GameObject character;

    public void SetActive(bool boolean)
    {
        gameObject.SetActive(boolean);
        if (boolean)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
        cm.SetActive(true);
        att.SetActive(true);
    }

    public bool IsActive()
    {
        return gameObject.activeSelf && Time.timeScale == 0;
    }

    private void Start()
    {
        cm = character.GetComponent<CharacterMovement>();
        att = character.GetComponent<Attacks>();
        SetActive(false);
    }
}
