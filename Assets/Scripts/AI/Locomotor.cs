using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotor : MonoBehaviour 
{
	[HideInInspector]
	public Entity entity;


	public void Walk(Vector3 Direction)
	{
		Vector3 movement = Direction.normalized * entity.stats.Speed;

		entity.rigidbody.velocity = movement;
	}

}
