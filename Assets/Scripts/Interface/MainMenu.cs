using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	public void StartGame()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Main", UnityEngine.SceneManagement.LoadSceneMode.Single);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
