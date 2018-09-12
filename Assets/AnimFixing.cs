using System.Collections;
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

    public IEnumerator PlayAnimation()
    {
        yield return new WaitForSeconds(2f);

		Animator anim = GetComponent<Animator>();
		anim.SetInteger("Stages", 1);

		yield return new WaitForSeconds(0.5f);
		anim.SetInteger("Stages", 2);

		EnableFan(fan99, false);
		EnableFan(fan98, false);
		EnableFan(fan97, false);
		EnableFan(fan96, false);
		EnableFan(fan1, false);
		EnableFan(fan2, false);
		EnableFan(fan3, false);
		EnableFan(fan4, false);
		EnableFan(fan5, false);
		EnableFan(fan6, false);
		EnableFan(fan7, false);
		EnableFan(fan8, false);
		EnableFan(fan9, false);

		EnableFan(fan10, true);
		EnableFan(fan11, true);
		EnableFan(fan12, true);
		EnableFan(fan13, true);
		EnableFan(fan14, true);
		EnableFan(fan15, true);
		EnableFan(fan16, true);
		EnableFan(fan17, true);
		EnableFan(fan18, true);
		EnableFan(fan19, true);
		EnableFan(fan20, true);
		EnableFan(fan21, true);
		EnableFan(fan22, true);
		EnableFan(fan23, true);
		EnableFan(fan24, true);

		//yield return new WaitForSeconds(0.5f);

		//Animator animator = GetComponent<Animator>();
		//if (animator != null)
		//{
		//	if (animator.GetCurrentAnimatorStateInfo(0).IsName("level2fixed"))
		//	{

		//	}
		//	anim.SetInteger("Stages", 2);
		//	//animator.Play("level2fixed");
		//}


	}

	private void EnableFan(GameObject fan, bool hasSpriteRenderer)
	{
		if(fan == null)
		{
			return;
		}

		fan.gameObject.GetComponent<Animator>().enabled = true;

		if(hasSpriteRenderer)
		{
			fan.gameObject.GetComponent<SpriteRenderer>().enabled = true;
		}
	}
}


