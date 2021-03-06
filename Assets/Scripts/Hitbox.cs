﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
	public Rigidbody rigidbody;
	[HideInInspector]
	public Entity owner;
	[HideInInspector]
	public float damage = 0;


	public string[] AffectToGroups = new string[] { "ENEMY" };

	public enum Properties
	{
		DestroyWhenHit = 1,
		VisibleHitbox = 2}

	;



	public static Hitbox Create(Entity Owner, Vector3 Position, Vector3 Velocity, float Damage, float TimeToDestroy, List<Properties> Props)
	{
		GameObject newHitboxGO = GameObject.Instantiate(GameManager.Instance.HitboxPrefab.gameObject, Position, Quaternion.identity) as GameObject;
		Hitbox newHitbox = newHitboxGO.GetComponent<Hitbox>();

		newHitbox.owner = Owner;
		newHitbox.damage = Damage;

		if (!Props.Contains(Properties.VisibleHitbox) && !GameManager.Instance.Cheats.SeeHitbox)
		{
			MeshRenderer renderer = newHitboxGO.GetComponent<MeshRenderer>();
			if (renderer != null)
			{
				renderer.enabled = false;
			}
		}

		if (Velocity.sqrMagnitude > 0)
		{
			newHitbox.rigidbody.velocity = Velocity;
		}

		if (TimeToDestroy > 0)
		{
			newHitbox.DestroyAfterTime(TimeToDestroy);
		}

		return newHitbox;
	}


	public void DestroyAfterTime(float TimeToDestroy)
	{
		Invoke("Expire", TimeToDestroy);
	}

	void Expire()
	{
		Destroy(gameObject);
	}

}
