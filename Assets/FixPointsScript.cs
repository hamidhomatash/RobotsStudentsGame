using UnityEngine;

public class FixPointsScript : MonoBehaviour
{
    public bool IsFixed = false;

	private void Start()
	{
		IsFixed = false;
	}

	public void SetFixed()
    {
		IsFixed = true;
		GetComponent<BoxCollider2D>().enabled = false;
	}
}
