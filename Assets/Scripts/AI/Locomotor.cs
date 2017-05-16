using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotor : MonoBehaviour
{
    [HideInInspector]
    public Entity entity;


    public void Walk(Vector3 Direction, float speedModifier = 1)
    {
        Vector3 movement = Direction.normalized * entity.stats.Speed * speedModifier;

        entity.rigidbody.velocity = movement;
    }


    public void Look(Vector3 Direction)
    {
        entity.transform.rotation = Quaternion.LookRotation(Direction, Vector3.up);
    }
}
