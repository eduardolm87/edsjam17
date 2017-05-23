using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Projectile : Skill
{
    public float projectileVelocity = 5f;
    public float projectileDamage = 1f;
    public float projectileDestroyInTime = 1f;
    public float projectileCooldown = 0.25f;
    public string ExecuteAnimation = "";
    public float DelayAnimation = 0;




    public override void Use(Entity owner, PlayerBrain.PlayerInput input)
    {
        owner.StartCoroutine(UseCoroutine(owner, input));
    }

    IEnumerator UseCoroutine(Entity owner, PlayerBrain.PlayerInput input)
    {
        if (ExecuteAnimation.Length > 0)
        {
            owner.locomotor.StopMoving();
            owner.brain.IsBusy = true;
            owner.locomotor.animator.SetTrigger(ExecuteAnimation);

            while (owner.rigidbody.velocity.sqrMagnitude > 0)
                yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(DelayAnimation);

        CreateHitbox(owner, input);

        yield return new WaitForSeconds(0.25f);
        owner.brain.IsBusy = false;
    }

    void CreateHitbox(Entity owner, PlayerBrain.PlayerInput input)
    {
        Hitbox.Create(owner, owner.front.position, owner.transform.forward * projectileVelocity, projectileDamage, projectileDestroyInTime);
        owner.AttackCooldown = projectileCooldown;
    }
}
