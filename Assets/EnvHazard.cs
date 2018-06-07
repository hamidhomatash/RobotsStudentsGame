using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvHazard : MonoBehaviour {

    bool turnOn = false;
    public GameObject Elec;
    public FixPointsScript fps;
     
	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Test());
	}

    void Update()
    {
        if (fps.IsFixed == false)
        {
            StopCoroutine(Test());
            
        }
    }

    IEnumerator Test()
    {
        while (enabled)
        {
            Elec.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            print(Time.time);
            Elec.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }

        while (!enabled)
        {
            Elec.SetActive(false);
        }
    }
}
