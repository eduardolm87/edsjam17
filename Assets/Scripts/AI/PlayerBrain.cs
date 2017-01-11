using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrain : Brain
{

	public class PlayerInput
	{
		public float Y = 0;
		public float X = 0;
		public bool Fire1Down = false;
		public bool Fire1Pressed = false;
		public bool Fire1Up = false;
		public bool Fire2Down = false;
		public bool Fire2Pressed = false;
		public bool Fire2Up = false;
		public bool Fire3Down = false;
		public bool Fire3Pressed = false;
		public bool Fire3Up = false;
		public bool JumpDown = false;
		public bool JumpPressed = false;
		public bool JumpUp = false;

		public string ToString()
		{
			string str = "";
			str += "X:" + X.ToString() + " ";
			str += "Y:" + Y.ToString() + " ";
			str += "Fire1Down:" + Fire1Down.ToString() + " ";
			str += "Fire1Pressed:" + Fire1Pressed.ToString() + " ";
			str += "Fire1Up:" + Fire1Up.ToString() + " ";
			str += "Fire2Down:" + Fire2Down.ToString() + " ";
			str += "Fire2Pressed:" + Fire2Pressed.ToString() + " ";
			str += "Fire2Up:" + Fire2Up.ToString() + " ";
			str += "Fire3Down:" + Fire3Down.ToString() + " ";
			str += "Fire3Pressed:" + Fire3Pressed.ToString() + " ";
			str += "JumpUp:" + Fire3Up.ToString() + " ";
			str += "JumpDown:" + JumpDown.ToString() + " ";
			str += "JumpPressed:" + JumpPressed.ToString() + " ";
			str += "JumpUp:" + JumpUp.ToString() + " ";

			return str;
		}
	}


	[HideInInspector]
	public PlayerInput playerInput = new PlayerInput();

	public override void Tick()
	{
		playerInput = GetPlayerInput(playerInput);

		//GameManager.Instance.ConsoleText.text = playerInput.ToString();
	}


	public PlayerInput GetPlayerInput(PlayerInput oldPlayerInput)
	{
		PlayerInput newInput = new PlayerInput();

		newInput.X = Input.GetAxis("Horizontal");
		newInput.Y = Input.GetAxis("Vertical");
		newInput.Fire1Pressed = Input.GetAxis("Fire1") > 0;
		newInput.Fire2Pressed = Input.GetAxis("Fire2") > 0;
		newInput.Fire3Pressed = Input.GetAxis("Fire3") > 0;
		newInput.JumpPressed = Input.GetAxis("Jump") > 0;

		newInput.Fire1Down = (newInput.Fire1Pressed && !oldPlayerInput.Fire1Pressed);
		newInput.Fire1Up = (!newInput.Fire1Pressed && oldPlayerInput.Fire1Pressed);
		newInput.Fire2Down = (newInput.Fire2Pressed && !oldPlayerInput.Fire2Pressed);
		newInput.Fire2Up = (!newInput.Fire2Pressed && oldPlayerInput.Fire2Pressed);
		newInput.Fire3Down = (newInput.Fire3Pressed && !oldPlayerInput.Fire3Pressed);
		newInput.Fire3Up = (!newInput.Fire3Pressed && oldPlayerInput.Fire3Pressed);
		newInput.JumpDown = (newInput.JumpPressed && !oldPlayerInput.JumpPressed);
		newInput.JumpUp = (!newInput.JumpPressed && oldPlayerInput.JumpPressed);



		return newInput;
	}
}
