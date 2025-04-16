using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : CharacterActionState
{
    private static int aniName;
    public HitState(IWeaponAnimationStrategy iWeaponAnimationStrategy) : base(iWeaponAnimationStrategy)
    {
        aniName = Animator.StringToHash(_aniStrategy.GetAnimationName("Hit"));
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