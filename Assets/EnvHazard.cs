using System.Collections;
using UnityEngine;

public class EnvHazard : MonoBehaviour
{
    public GameObject Elec;
    public FixPointsScript fps;
     
	// Use this for initialization
	void Start ()
    {
		if (Elec != null)
		{
			StartCoroutine(Test());
		}
	}

    void Update()
    {
        if (Elec != null && fps != null && fps.IsFixed)
        {
            StopCoroutine(Test());
			fps = null;

		}
    }

    IEnumerator Test()
    {
        while (enabled)
        {
            Elec.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            Elec.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }

        while (!enabled)
        {
            Elec.SetActive(false);
        }
    }
}
