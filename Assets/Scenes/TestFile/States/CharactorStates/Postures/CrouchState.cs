using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchState : CharacterPostureState
{
    private static int aniName;

    public CrouchState(IWeaponAnimationStrategy iWeaponAnimationStrategy) : base(iWeaponAnimationStrategy)
    {

        aniName = Animator.StringToHash(_aniStrategy.GetAnimationName("Crouch"));

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