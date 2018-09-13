using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class OutroController : MonoBehaviour
{
	private void Start()
	{
		StartCoroutine(NextScene());
	}

	private IEnumerator NextScene()
	{
		yield return new WaitForSeconds(6.0f);
		SceneManager.LoadScene("LevelSelection");
	}
}
