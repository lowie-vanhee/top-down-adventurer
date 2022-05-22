using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float backwardsSpeed = 4f;
    public Rigidbody rb;
    public float heightToLook = 1f;

    bool isActive = true;

    Vector3 movement;

    public EscapeMenu escapemenu;
    public GameObject optionsmenu;
    public GameObject escmenu;
    public SetUI setui;

    public Animator anim;

    //Input
    void Update()
    {
        if(isActive)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.z = Input.GetAxisRaw("Vertical");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Vector3 lookAt = new Vector3(0,0,0);
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.tag == "Ground")
                {
                    lookAt = new Vector3(hit.point.x, heightToLook, hit.point.z);
                    transform.LookAt(lookAt);
                }
            }

            /// if the angle between the movement vector and the lookAt vector is in between 90 degrees and 270 => backwards walking
            if(Vector3.Angle(movement, lookAt) > 90 && Vector3.Angle(movement, lookAt) < 270)
            {
                anim.SetBool("isWalkingForwards", false);
                anim.SetBool("isWalkingBackwards", true);
            }
            else
            {
                anim.SetBool("isWalkingBackwards", false);
                anim.SetBool("isWalkingForwards", true);
            }
            
            if (movement.x == 0 && movement.z == 0)
            {
                anim.SetBool("isWalkingBackwards", false);
                anim.SetBool("isWalkingForwards", false);
            }
        }

        if (Input.GetButtonDown("Cancel"))
        {
            if (!escapemenu.IsActive() && !optionsmenu.activeSelf)
                escapemenu.SetActive(true);
            else if (escapemenu.IsActive() && !optionsmenu.activeSelf)
                escapemenu.SetActive(false);
            else if (!escapemenu.IsActive() && optionsmenu.activeSelf)
            {
                optionsmenu.SetActive(false);
                escmenu.SetActive(true);
                setui.CheckBarPositions();
            }
        }
    }

    //Move
    void FixedUpdate()
    {
        if(anim.GetBool("isWalkingForwards"))
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        else if(anim.GetBool("isWalkingBackwards"))
            rb.MovePosition(rb.position + movement * backwardsSpeed * Time.fixedDeltaTime);
    }

    public void SetActive(bool boolean)
    {
        isActive = boolean;
    }
}
