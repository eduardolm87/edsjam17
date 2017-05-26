using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotor : MonoBehaviour
{
	[HideInInspector]
	public Entity entity;


	[HideInInspector]
	public Animator animator;


	const float transitionWalkToIdle = 1f;
	bool previousmoving = false;

	[HideInInspector]
	public bool IsMoving = false;

	const float ForceMultiplier = 7f;

	float distToGround = 0;


	void Awake()
	{
		FindAnimator();
		animator.SetTrigger("Idle");
	}

	void Start()
	{
		distToGround = entity.collider.bounds.extents.y;
	}

	void FindAnimator()
	{
		animator = GetComponentInChildren<Animator>();
		if (animator == null)
		{
			Debug.LogError("Entity " + name + " does not have an animator");
		}
	}


	public void Walk(Vector3 Direction, float speedModifier = 1)
	{
		Vector3 movement = Direction.normalized * entity.stats.Speed * speedModifier;
	
		//entity.rigidbody.velocity = movement;

		entity.rigidbody.AddForce(movement * ForceMultiplier);

	}


	public void Look(Vector3 Direction)
	{
		entity.transform.rotation = Quaternion.LookRotation(Direction, Vector3.up);
	}

	void Update()
	{
		AnimationUpdate();
	}


	void AnimationUpdate()
	{
		if (entity.brain.IsBusy)
			return;

		IsMoving = (entity.rigidbody.velocity.magnitude > transitionWalkToIdle);

		if (IsMoving && !previousmoving)
		{
			//Start walking
			animator.SetTrigger("Walk");
		}
		else if (!IsMoving && previousmoving)
		{
			//Stopping
			StopMoving();
		}

		previousmoving = IsMoving;
	}

	public void StopMoving()
	{
		entity.rigidbody.velocity = Vector3.zero;
		animator.SetTrigger("Idle");
		IsMoving = false;
		previousmoving = false;
	}

	public bool IsGrounded()
	{
		bool r = Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.2f);

		if (!r)
			r = Physics.Raycast(transform.position + (transform.forward * 0.2f), -Vector3.up, distToGround + 0.2f);

		if (!r)
			r = Physics.Raycast(transform.position - (transform.forward * 0.2f), -Vector3.up, distToGround + 0.2f);

		return r;
	}

}
