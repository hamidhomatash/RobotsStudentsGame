using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformVertical : MonoBehaviour {
    bool movingUp;
    bool movingDown;

    [SerializeField]
    protected Vector3 stopVectorUp;

    [SerializeField]
    protected Vector3 stopVectorDown;

    // Use this for initialization
    void Start()
    {
        movingUp = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (movingUp)
        {

            transform.position += Vector3.up * Time.deltaTime * 2;
            //print(gameObject.name + " transform x: " + transform.position.x + " stop x: " + stopVectorRight.x);
            if (transform.position.y >= stopVectorUp.y)
            {
                movingUp = false;
                movingDown = true;
            }
        }

        if (movingDown)
        {
            transform.position += Vector3.down * Time.deltaTime * 2;
            if (transform.position.y <= stopVectorDown.y)
            {

                movingDown = false;
                movingUp = true;
            }
        }
    }
}
