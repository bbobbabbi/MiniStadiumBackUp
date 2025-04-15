using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActionState : ICharacterState
{
    protected CharacterController _characterController;
    protected IWeaponAnimationStrategy _aniStrategy;
    public virtual void Enter(CharacterController characterController)
    {
        _characterController = characterController;
    }

    public virtual void Exit()
    {
    }

    public virtual void Update()
    {
    }

    public CharacterActionState(IWeaponAnimationStrategy iWeaponAnimationStrategy) {
        _aniStrategy = iWeaponAnimationStrategy;
    }
}
