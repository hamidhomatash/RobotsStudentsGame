using UnityEngine;

public class Singleton : MonoBehaviour
{
	public int currentLevelIndex = 5;
	public int completedLevels = 5;

	public static Singleton Instance
	{
		get
		{
			if(instance == null)
			{
				GameObject gameObject = new GameObject("Singleton");
				instance = gameObject.AddComponent<Singleton>();
				DontDestroyOnLoad(gameObject);
			}
			return instance;
		}
	}

	private static Singleton instance = null;
}
