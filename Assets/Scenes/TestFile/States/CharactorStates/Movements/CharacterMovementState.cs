using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementState : ICharacterState
{
    protected CharacterController _characterController;
    protected IWeaponAnimationStrategy _aniStrategy;
    public virtual void Enter(CharacterController characterController)
    {
        _characterController = characterController;
    }

    public virtual void Exit()
    {
        _characterController = null;
        _aniStrategy = null;
    }

    public virtual void Update()
    {
    }

    public CharacterMovementState(IWeaponAnimationStrategy iWeaponAnimationStrategy)
    {
        _aniStrategy = iWeaponAnimationStrategy;
    }
}
