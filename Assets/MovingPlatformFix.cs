using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformFix : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
	{
		collider.transform.parent = gameObject.transform;
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		collider.transform.parent = null;
	}
}
