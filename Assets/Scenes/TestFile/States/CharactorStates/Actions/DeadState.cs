using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : CharacterActionState
{
    public DeadState(IWeaponAnimationStrategy iWeaponAnimationStrategy) : base(iWeaponAnimationStrategy)
    {

    }
    public override void Enter(CharacterController characterController)
    {
        base.Enter(characterController);
        Debug.Log("Enter Dead State");
    }
    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exit Dead State");
    }
    public override void Update()
    {
        base.Update();
        Debug.Log("Update Dead State");
    }
}