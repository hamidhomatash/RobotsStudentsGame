using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class LevelSelectScript : MonoBehaviour
{

    int index = 0;
    public int totalLevels = 3;
    public float xOffset = 100f;




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (index < totalLevels - 1)
            {
                index++;
                Vector2 position = transform.position;
                position.x += xOffset;
                transform.position = position;
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (index > 0)
            {
                index--;
                Vector2 position = transform.position;
                position.x -= xOffset;
                transform.position = position;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (index == 0)
            {
                SceneManager.LoadScene("Lolz");
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (index == 1)
            {
                SceneManager.LoadScene("MediumDifficultyLevel");
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (index == 2)
            {
                SceneManager.LoadScene("Level1");
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (index == 3)
            {
                SceneManager.LoadScene("Level 4");
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (index == 4)
            {
                SceneManager.LoadScene("Level 5 - With Background");
            }
        }
    }
}
