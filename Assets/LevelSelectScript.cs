using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class LevelSelectScript : MonoBehaviour
{
	public const int totalLevels = 5;

	private int levelIndex = 0;
    
	[SerializeField]
	private float endTime = 3.0f;

	[SerializeField]
	private float[] armPositionsX;

	[SerializeField]
	private Rigidbody2D playerRobot;

	[SerializeField]
	private GameObject controlsPanel;

	[SerializeField]
	private GameObject robotsToFixTextGameObject;


	/// <summary>This is a magic number taken from moving the arm off screen in the inspector</summary>
	private float offscreenX = 1325.0f;

	private Vector3 startPosition;
	private Vector3 endPosition;
	private bool allowSelection = false;
	private float currentTime;

	private bool isFirstFrame = true;

	private void Start()
	{
		levelIndex = Singleton.Instance.currentLevelIndex;
		if (levelIndex >= totalLevels)
		{
			levelIndex = totalLevels - 1;
		}

		startPosition = transform.position;
		startPosition.x = armPositionsX[levelIndex];

		allowSelection = Singleton.Instance.completedLevels >= totalLevels;
		if(!allowSelection)
		{
			endPosition = startPosition;
			
			if(levelIndex - 1 < 0)
			{
				startPosition.x = offscreenX;
			}
			else
			{
				startPosition.x = armPositionsX[levelIndex - 1];
			}
		}

		transform.position = startPosition;

		// Show controls panel if allowed to select
		controlsPanel.SetActive(allowSelection);

		// Hide robots to fix text if all have been fixed
		robotsToFixTextGameObject.SetActive(!allowSelection);
	}
	
	// Update is called once per frame
	void Update()
	{
		// Skip first frame to avoid large delta time
		if(isFirstFrame)
		{
			isFirstFrame = false;
			return;
		}

		if (allowSelection)
		{
			if (Input.GetKeyDown(KeyCode.D) ||
				Input.GetKeyDown(KeyCode.RightArrow) ||
				Input.GetKeyDown(KeyCode.Keypad6))
			{
				if (levelIndex < totalLevels - 1)
				{
					levelIndex++;
					Vector2 position = transform.position;
					position.x = armPositionsX[levelIndex];
					transform.position = position;
				}
			}

			if (Input.GetKeyDown(KeyCode.A) ||
				Input.GetKeyDown(KeyCode.LeftArrow) ||
				Input.GetKeyDown(KeyCode.Keypad4))
			{
				if (levelIndex > 0)
				{
					levelIndex--;
					Vector2 position = transform.position;
					position.x = armPositionsX[levelIndex];
					transform.position = position;
				}
			}

			if (Input.GetKeyDown(KeyCode.Space) ||
				Input.GetKeyDown(KeyCode.Return) ||
				Input.GetKeyDown(KeyCode.Keypad0) ||
				Input.GetKeyDown(KeyCode.Keypad5) || 
				Input.GetKeyDown(KeyCode.KeypadEnter))
			{
				LoadLevel(levelIndex);
			}
		}
		else
		{
			if (currentTime < endTime)
			{
				currentTime += Time.deltaTime;
				transform.position = Vector3.Lerp(startPosition, endPosition, currentTime / endTime);

				if (currentTime >= endTime)
				{
					currentTime = endTime;
					transform.position = endPosition;

					GetComponent<Animator>().SetInteger("State", 1);
					playerRobot.simulated = true;
				}
			}
			else
			{
				if (playerRobot.simulated)
				{
					Vector3 localPosition = playerRobot.transform.localPosition;
					if (localPosition.y <= -5.0f)
					{
						playerRobot.simulated = false;

						localPosition.y = -5.0f;
						playerRobot.transform.localPosition = localPosition;
						LoadLevel(Singleton.Instance.completedLevels);
					}
				}
			}
		}
	}

	static public void LoadLevel(int levelIndex)
	{
		if (levelIndex < 0)
		{
			levelIndex = 0;
		}
		else if (levelIndex >= totalLevels)
		{
			levelIndex = totalLevels - 1;
		}

		Singleton.Instance.currentLevelIndex = levelIndex;
		switch (levelIndex)
		{
			case 0:
				SceneManager.LoadScene("Lolz");
				break;

			case 1:
				SceneManager.LoadScene("MediumDifficultyLevel");
				break;

			case 2:
				SceneManager.LoadScene("Level1");
				break;

			case 3:
				SceneManager.LoadScene("Level 4");
				break;

			case 4:
				SceneManager.LoadScene("Level 5 - With Background");
				break;
		}
	}
}
