using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Projectile : Skill
{
    public float projectileVelocity = 5f;
    public float projectileDamage = 1f;
    public float projectileDestroyInTime = 1f;
    public float projectileCooldown = 0.25f;


    public override void Use(Entity owner, ref PlayerBrain.PlayerInput input)
    {
        Hitbox.Create(owner, (owner.transform.position + owner.transform.forward * 0.5f + Vector3.up * 0.5f), owner.transform.forward * projectileVelocity, projectileDamage, projectileDestroyInTime);
        owner.AttackCooldown = projectileCooldown;
    }
}
