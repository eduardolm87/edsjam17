using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
	public CapsuleCollider collider;
	public Rigidbody rigidbody;
	public Brain brain;
	public Locomotor locomotor;
	public Stats stats = new Stats();

	[System.Serializable]
	public class Stats
	{
		public int HPMax = 10;
		public int HP = 10;

		public int Speed = 1;

		public void Reset()
		{
			HP = HPMax;
		}
	}


	void Awake()
	{
		brain.entity = this;
		locomotor.entity = this;
	}


	void Update()
	{
		if (!brain)
			return;

		brain.Tick();
	}
}
