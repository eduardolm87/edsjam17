using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotor : MonoBehaviour
{
    [HideInInspector]
    public Entity entity;


    [HideInInspector]
    public Animator animator;

    void Awake()
    {
        FindAnimator();
        animator.SetTrigger("Idle");
    }

    void FindAnimator()
    {
        animator = GetComponentInChildren<Animator>();
        if (animator == null)
        { Debug.LogError("Entity " + name + " does not have an animator"); }
    }


    public void Walk(Vector3 Direction, float speedModifier = 1)
    {
        Vector3 movement = Direction.normalized * entity.stats.Speed * speedModifier;

        entity.rigidbody.velocity = movement;
    }


    public void Look(Vector3 Direction)
    {
        entity.transform.rotation = Quaternion.LookRotation(Direction, Vector3.up);
    }

    void Update()
    {
        AnimationUpdate();
    }


    const float transitionWalkToIdle = 1f;
    bool previousmoving = false;


    [HideInInspector]
    public bool IsMoving = false;



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
}
