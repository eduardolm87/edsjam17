using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class GameConsole : MonoBehaviour 
{
	public static GameConsole Instance = null;
	void Awake()
	{
		Instance = this;
	}



	public Text Text;


	public void AddLine(string Line)
	{
		Text.text += Line;
		Text.text += "\n";
	}

	public void Clear()
	{
		Text.text = "";
	}
}
