using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionIdleState : CharacterActionState
{
    public ActionIdleState(IWeaponAnimationStrategy iWeaponAnimationStrategy) : base(iWeaponAnimationStrategy)
    {

    }
    public override void Enter(CharacterController characterController)
    {
        base.Enter(characterController);
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
    }
}