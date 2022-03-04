using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody rb;
    public float heightToLook = 1f;

    bool isActive = true;

    Vector3 movement;

    public EscapeMenu escapemenu;
    public GameObject optionsmenu;
    public GameObject escmenu;
    public SetUI setui;

    //Input
    void Update()
    {
        if(isActive)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.z = Input.GetAxisRaw("Vertical");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.tag == "Ground")
                    transform.LookAt(new Vector3(hit.point.x, heightToLook, hit.point.z));
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
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void SetActive(bool boolean)
    {
        isActive = boolean;
    }
}
