using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{

    public GameObject bullet;
    public GameObject special;
    bool isUsingSpecial = false;
    public GameObject eNotifier;

    //Input
    void Update()
    {
        if(Input.GetButtonDown("Ability2"))
        {
            //check if it has ability
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

        if(Input.GetButtonDown("Fire1"))
        {
            if(!isUsingSpecial)
                Shoot();
            else
            {
                ShootSpecial();
                //set special bar to 0
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
    }
}
