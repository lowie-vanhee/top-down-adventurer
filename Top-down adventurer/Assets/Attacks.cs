using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{

    public GameObject bullet;

    //Input
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        //Hold down? Slower shooting
    }

    void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
