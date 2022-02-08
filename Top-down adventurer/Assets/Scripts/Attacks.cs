using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{

    public GameObject bullet;

    bool isUsingHeal = false;
    public GameObject aNotifier;

    public GameObject special;
    bool isUsingSpecial = false;
    public GameObject eNotifier;

    public CharacterHealthAndStamina has;

    int healcost;
    int specialcost;

    //Input
    void Update()
    {
        if(Input.GetButtonDown("Ability1"))
        {
            //check if player has 50 stamina and doesnt have full health
            if (has.getStamina() >= healcost && has.currentHealth < has.maxHealth)
            {
                if(isUsingSpecial)
                {
                    isUsingSpecial = false;
                    eNotifier.SetActive(false);
                }


                if (isUsingHeal)
                {
                    isUsingHeal = false;
                    aNotifier.SetActive(false);
                }
                else
                {
                    isUsingHeal = true;
                    aNotifier.SetActive(true);
                }
            }
            else
                Debug.Log("stamina too low for heal");
        }

        if (Input.GetButtonDown("Ability2"))
        {
            //check if player has 100 stamina
            if (has.getStamina() == specialcost)
            {
                if (isUsingHeal)
                {
                    isUsingHeal = false;
                    aNotifier.SetActive(false);
                }


                if (isUsingSpecial)
                {
                    isUsingSpecial = false;
                    eNotifier.SetActive(false);
                }
                else
                {
                    isUsingSpecial = true;
                    eNotifier.SetActive(true);
                }
            }
            else
                Debug.Log("stamina too low for special");
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if(!isUsingSpecial && !isUsingHeal)
                Shoot();
            else if(!isUsingSpecial && isUsingHeal)
            {
                has.removeStamina(healcost);
                isUsingHeal = false;
                aNotifier.SetActive(false);
                StartCoroutine(Heal());
            }
            else if(isUsingSpecial && !isUsingHeal)
            {
                ShootSpecial();
                has.removeStamina(specialcost);
                isUsingSpecial = false;
                eNotifier.SetActive(false);
            }

        }

        //Hold down? Slower shooting
    }

    void ShootSpecial()
    {
        Instantiate(special, transform.position, transform.rotation);
    }
    void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }

    private void Start()
    {
        eNotifier.SetActive(false);
        aNotifier.SetActive(false);

        healcost = has.getMaxStamina() / 2;
        specialcost = has.getMaxStamina();
    }

    IEnumerator Heal()
    {
        for (int j = 0; j < 2; j++)
        {
            for (int i = 0; i < 20; i++)
            {
                has.addHealth(1);
                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForSecondsRealtime(1);
        }

        for (int i = 0; i < 20; i++)
        {
            has.addHealth(1);
            yield return new WaitForEndOfFrame();
        }
    }
}
