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
            str += "X:" + string.Format("{0:00}", X) + " ";
            str += "Y:" + string.Format("{0:00}", Y) + " ";
            str += "F1Down:" + Fire1Down.ToString() + " ";
            str += "F1Pressed:" + Fire1Pressed.ToString() + " ";
            str += "F1Up:" + Fire1Up.ToString() + " ";
            str += "F2Down:" + Fire2Down.ToString() + " ";
            str += "F2Pressed:" + Fire2Pressed.ToString() + " ";
            str += "F2Up:" + Fire2Up.ToString() + " ";
            str += "F3Down:" + Fire3Down.ToString() + " ";
            str += "F3Pressed:" + Fire3Pressed.ToString() + " ";
            str += "JMPUp:" + Fire3Up.ToString() + " ";
            str += "JMPDown:" + JumpDown.ToString() + " ";
            str += "JMPPressed:" + JumpPressed.ToString() + " ";
            str += "JMPUp:" + JumpUp.ToString() + " ";

            return str;
        }
    }


    [HideInInspector]
    public PlayerInput playerInput = new PlayerInput();

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




    public override void Tick()
    {
        playerInput = GetPlayerInput(playerInput);
        //GameManager.Instance.ConsoleText.text = playerInput.ToString();

        if (entity.StunCooldown > 0)
            return;

        MovePlayer(ref playerInput);

        if (entity.AttackCooldown == 0)
        {
            FirePlayer(ref playerInput);
        }
    }

    void MovePlayer(ref PlayerInput input)
    {
        Vector3 move = Vector3.zero;
        if (input.Y > 0)
        {
            move = transform.forward;
        }
        else if (input.Y < 0)
        {
            move = -transform.forward;
        }
        if (input.X > 0)
        {
            move += transform.right;
        }
        else if (input.X < 0)
        {
            move += -transform.right;
        }

        if (move.sqrMagnitude != 0)
            entity.locomotor.Walk(move);
    }

    void FirePlayer(ref PlayerInput input)
    {
        float projectileVelocity = 5f;
        float projectileDamage = 1f;
        float projectileDestroyInTime = 2f;
        float projectileCooldown = 1f;

        if (input.Fire1Down)
        {
            Hitbox.Create(entity, (transform.position + transform.forward * 0.5f), transform.forward * projectileVelocity, projectileDamage, projectileDestroyInTime);
            entity.AttackCooldown = projectileCooldown;
        }
    }
}
