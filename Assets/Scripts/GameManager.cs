using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance = null;

	void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
		}

		Instance = this;

		DontDestroyOnLoad(transform.root.gameObject);
	}




	
}
