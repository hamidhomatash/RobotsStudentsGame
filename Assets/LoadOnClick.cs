using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadOnClick : MonoBehaviour {

    

	// Use this for initialization
	void Start ()
    {   
     
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("LevelSelection");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
        
        }

	}

    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
    }
}
