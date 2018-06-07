using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimFixing : MonoBehaviour
{
    public GameObject fan99;
    public GameObject fan98;
    public GameObject fan97;
    public GameObject fan96;
    public GameObject fan1;
    public GameObject fan2;
    public GameObject fan3;
    public GameObject fan4;
    public GameObject fan5;
    public GameObject fan6;
    public GameObject fan7;
    public GameObject fan8;
    public GameObject fan9;
    public GameObject fan10;
    public GameObject fan11;
    public GameObject fan12;
    public GameObject fan13;
    public GameObject fan14;
    public GameObject fan15;
    public GameObject fan16;
    public GameObject fan17;
    public GameObject fan18;
    public GameObject fan19;
    public GameObject fan20;
    public GameObject fan21;
    public GameObject fan22;
    public GameObject fan23;
    public GameObject fan24;


    Animator anims;
    Animator anim;
    GameObject stuff;

    // Use this for initialization
    void Start()
    {
        anim = this.GetComponent<Animator>();
      
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        { 
            StartCoroutine(Whatever());
         }
    }

    IEnumerator Whatever()
    {
        yield return new WaitForSeconds(2f);
        anim.SetInteger("Stages", 1);
        yield return new WaitForSeconds(0.5f);
        anim.SetInteger("Stages", 2);
        fan99.gameObject.GetComponent<Animator>().enabled = true;
        fan98.gameObject.GetComponent<Animator>().enabled = true;
        fan97.gameObject.GetComponent<Animator>().enabled = true;
        fan96.gameObject.GetComponent<Animator>().enabled = true;
        fan1.gameObject.GetComponent<Animator>().enabled = true;
        fan2.gameObject.GetComponent<Animator>().enabled = true;
        fan3.gameObject.GetComponent<Animator>().enabled = true;
        fan4.gameObject.GetComponent<Animator>().enabled = true;
        fan5.gameObject.GetComponent<Animator>().enabled = true;
        fan6.gameObject.GetComponent<Animator>().enabled = true;
        fan7.gameObject.GetComponent<Animator>().enabled = true;
        fan8.gameObject.GetComponent<Animator>().enabled = true;
        fan9.gameObject.GetComponent<Animator>().enabled = true;
        fan10.gameObject.GetComponent<Animator>().enabled = true;
        fan10.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        fan11.gameObject.GetComponent<Animator>().enabled = true;
        fan11.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        fan12.gameObject.GetComponent<Animator>().enabled = true;
        fan12.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        fan13.gameObject.GetComponent<Animator>().enabled = true;
        fan13.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        fan14.gameObject.GetComponent<Animator>().enabled = true;
        fan14.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        fan15.gameObject.GetComponent<Animator>().enabled = true;
        fan15.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        fan16.gameObject.GetComponent<Animator>().enabled = true;
        fan16.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        fan17.gameObject.GetComponent<Animator>().enabled = true;
        fan17.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        fan18.gameObject.GetComponent<Animator>().enabled = true;
        fan18.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        fan19.gameObject.GetComponent<Animator>().enabled = true;
        fan19.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        fan20.gameObject.GetComponent<Animator>().enabled = true;
        fan20.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        fan21.gameObject.GetComponent<Animator>().enabled = true;
        fan21.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        fan22.gameObject.GetComponent<Animator>().enabled = true;
        fan22.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        fan23.gameObject.GetComponent<Animator>().enabled = true;
        fan23.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        fan24.gameObject.GetComponent<Animator>().enabled = true;
        fan24.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    
}


