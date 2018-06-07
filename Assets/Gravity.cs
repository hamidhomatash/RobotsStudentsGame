using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    public MovementScript movementScript;

    void Start()
    {
        Physics2D.gravity = new Vector3(0f, -25f, 0f);
    }

    public void OnTriggerStay2D(Collider2D collider)
    {
        if (movementScript.gravityEnabled == true)
        {
            if (collider.gameObject.tag == "MagnetRoof")
            {
                Physics2D.gravity = new Vector3(0f, 30f, 0f);
                //movementScript.normal = true;
                //movementScript.wall = false;
            }
            if (collider.gameObject.tag == "MagnetWallR")
            {
                Physics2D.gravity = new Vector3(80f, 0f, 0f);
                //movementScript.wall = true;
                //movementScript.normal = false;
            }
         
            if (collider.gameObject.tag == "MagnetWallL")
            {
                Physics2D.gravity = new Vector3(-80f, 0f, 0f);
                //movementScript.normal = true;
                //movementScript.wall = true;
            }

            if (collider.gameObject.tag == "MagnetPushLow")
            {
                Physics2D.gravity = new Vector3(0f, 40f, 0f);
                //movementScript.normal = true;
                //movementScript.wall = false;
            }

            if (collider.gameObject.tag == "MagnetPushRight")
            {
                Physics2D.gravity = new Vector3(40f, 0f, 0f);
                //movementScript.normal = true;
                //movementScript.wall = false;
            }

            if (collider.gameObject.tag == "MagnetPushLeft")
            {
                Physics2D.gravity = new Vector3(-40f, 0f, 0f);
                //movementScript.normal = true;
                //movementScript.wall = false;
            }

            if (collider.gameObject.tag == "MagnetPushLeftDia")
            {
                Physics2D.gravity = new Vector3(-40f, 40f, 0f);
                //movementScript.normal = true;
                //movementScript.wall = false;
            }

            if (collider.gameObject.tag == "MagnetPushRightDia")
            {
                Physics2D.gravity = new Vector3(40f, 40f, 0f);
                //movementScript.normal = true;
                //movementScript.wall = false;
            }

        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "MagnetRoof")
        {
            Physics2D.gravity = new Vector3(0f, -25f, 0f);
            movementScript.gravityEnabled = false;
            movementScript.gravity.enabled = false;
        }
        if (collider.gameObject.tag == "MagnetWallR")
        {
            Physics2D.gravity = new Vector3(0f, -25f, 0f);
            movementScript.gravityEnabled = false;
            movementScript.gravity.enabled = false;
        }
        if (collider.gameObject.tag == "MagnetWallL")
        {
            Physics2D.gravity = new Vector3(0f, -25f, 0f);
            movementScript.gravityEnabled = false;
            movementScript.gravity.enabled = false;
        }

        if (collider.gameObject.tag == "MagnetPushLow")
        {
            Physics2D.gravity = new Vector3(0f, -25f, 0f);
            movementScript.gravityEnabled = false;
            movementScript.gravity.enabled = false;
        }

        if (collider.gameObject.tag == "MagnetPushRight")
        {
            Physics2D.gravity = new Vector3(0f, -25f, 0f);
            movementScript.gravityEnabled = false;
            movementScript.gravity.enabled = false;
        }

        if (collider.gameObject.tag == "MagnetPushLeft")
        {
            Physics2D.gravity = new Vector3(0f, -25f, 0f);
            movementScript.gravityEnabled = false;
            movementScript.gravity.enabled = false;
        }

        if (collider.gameObject.tag == "MagnetPushLeftDia")
        {
            Physics2D.gravity = new Vector3(0f, -25f, 0f);
            movementScript.gravityEnabled = false;
            movementScript.gravity.enabled = false;
        }

        if (collider.gameObject.tag == "MagnetPushRightDia")
        {
            Physics2D.gravity = new Vector3(0f, -25f, 0f);
            movementScript.gravityEnabled = false;
            movementScript.gravity.enabled = false;
        }
    }

    //private void OnTriggerEnter2D(Collider2D collider)
    //{
    //    if (collider.gameObject.tag == "GravDis")
    //    {
    //        movementScript.gravityEnabled = false;
    //        movementScript.gravity.enabled = false;
    //    }
    //}
}