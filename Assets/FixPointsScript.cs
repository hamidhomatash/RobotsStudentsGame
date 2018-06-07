using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPointsScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject TheEnd;
    public Gravity gravity;
    public bool IsFixed = true;

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
       if (collider.gameObject.tag == "Player")
       {
           StartCoroutine(Stop());
           IsFixed = false;
        }
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(1f);
        TheEnd.GetComponent<BoxCollider2D>().enabled = false;
    }
}
