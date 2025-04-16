using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : CharacterActionState
{
    private static int aniName;

    public AttackState(IWeaponAnimationStrategy iWeaponAnimationStrategy) : base(iWeaponAnimationStrategy)
    {
        aniName = Animator.StringToHash(_aniStrategy.GetAnimationName("Attack"));
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