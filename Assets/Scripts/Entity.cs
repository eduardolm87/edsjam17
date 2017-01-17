using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Entity : MonoBehaviour
{
    public CapsuleCollider collider;
    public Rigidbody rigidbody;
    public Brain brain;
    public Locomotor locomotor;
    public Stats stats = new Stats();
    public string[] HurtGroups = new string[] { "PLAYER" };

    //states and flags
    [HideInInspector]
    public float AttackCooldown = 0;
    [HideInInspector]
    public float StunCooldown = 0;


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
        Cooldowns();

        if (!brain)
            return;

        brain.Tick();
    }

    void Cooldowns()
    {
        ReduceCooldownToZero(ref AttackCooldown);
        ReduceCooldownToZero(ref StunCooldown);
    }

    void ReduceCooldownToZero(ref float Variable)
    {
        if (Variable > 0)
        {
            Variable -= Time.deltaTime;
            if (Variable < 0)
                Variable = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Hitbox hitbox = other.GetComponent<Hitbox>();
        if (hitbox != null)
        {
            if (hitbox.owner != this)
            {
                if (hitbox.AffectToGroups.ToList().Intersect(HurtGroups).ToList().Count() > 0)
                {
                    OnHitboxHit(hitbox);
                }
            }
        }
    }


    void OnHitboxHit(Hitbox hitbox)
    {
        Debug.Log("HITBOX hit!");

        //Damage formula
        stats.HP -= Mathf.RoundToInt(hitbox.damage);

        //FX
        GameManager.Instance.FXManager.Create("Toon Bzz 02 PS", transform.position, 1);

        //Sound


    }


}
