using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterState 
{
    void Enter(CharacterController characterController);

    void Update();

    void Exit();
}
