using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPostureState : ICharacterState
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

    public CharacterPostureState(IWeaponAnimationStrategy iWeaponAnimationStrategy)
    {
        _aniStrategy = iWeaponAnimationStrategy;
    }
}
