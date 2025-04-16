using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : CharacterActionState
{
    private static int aniName;
    public DeadState(IWeaponAnimationStrategy iWeaponAnimationStrategy) : base(iWeaponAnimationStrategy)
    {
        aniName = Animator.StringToHash(_aniStrategy.GetAnimationName("Dead"));
    }
    public override void Enter(CharacterController characterController)
    {
        characterController.Animator.Play(aniName);
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