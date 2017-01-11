using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

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




	public Text ConsoleText;

	
	public void AddConsoleLine(string str)
	{
		ConsoleText.text += "\n" + str;

		int LinesNumber = ConsoleText.text.Count(n => n == '\n');
		while(LinesNumber>5)
		{
			DeleteOldestConsoleLine();
		}
	}

	public void DeleteOldestConsoleLine()
	{
		int firstCR = ConsoleText.text.IndexOf('\n');
		if (firstCR < 0)
			return;
		ConsoleText.text.Remove(0, firstCR);
	}

	
}
