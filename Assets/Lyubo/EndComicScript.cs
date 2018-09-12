using UnityEngine;
using UnityEngine.SceneManagement;

public class EndComicScript : MonoBehaviour
{
	public bool loadNextScene = false;
	
	// Update is called once per frame
	private void Update ()
    {
        if (loadNextScene || Input.GetKeyDown(KeyCode.Space))
        {
			SceneManager.LoadScene("LevelSelection");
		}
	}
}
