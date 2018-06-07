using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms2 : MonoBehaviour {


    bool movingRight;
    bool movingLeft;

    [SerializeField]
    protected Vector3 stopVectorRight;

    [SerializeField]
    protected Vector3 stopVectorLeft;

    // Use this for initialization
    void Start()
    {
        movingRight = true;

    }

    /// <summary>
    /// Conall Wrote this
    /// </summary>
    void Update()
    {
        if (movingRight)
        {

            transform.position += Vector3.right * Time.deltaTime * 4;
            //print(gameObject.name + " transform x: " + transform.position.x + " stop x: " + stopVectorRight.x);
            if (transform.position.x >= stopVectorRight.x)
            {
                movingRight = false;
                movingLeft = true;
            }
        }

        if (movingLeft)
        {
            transform.position += Vector3.left * Time.deltaTime * 4;
            if (transform.position.x <= stopVectorLeft.x)
            {

                movingLeft = false;
                movingRight = true;
            }
        }
    }


}
