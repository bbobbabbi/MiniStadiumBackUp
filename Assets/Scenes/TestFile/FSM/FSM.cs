using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;

public enum StateType { 
    Action,
    Posture,
    Move
}

public static class StateFactory
{    
    public static List<(T, ICharacterState)> CreateStates<T>(this FSM<T> fsm, IWeaponAnimationStrategy _aniStrategy) where T : Enum
    {
        if (typeof(T) == typeof(ActionState))
        {
            var list = (fsm as FSM<ActionState>).CreateStates(_aniStrategy);
            return list.Select(tuple => ((T)(object)tuple.Item1, tuple.Item2)).ToList();
        }
        else if (typeof(T) == typeof(MovementState))
        {
            var list = (fsm as FSM<MovementState>).CreateStates(_aniStrategy);
            return list.Select(tuple => ((T)(object)tuple.Item1, tuple.Item2)).ToList();
        }
        else if (typeof(T) == typeof(PostureState)) {

            var list = (fsm as FSM<PostureState>).CreateStates(_aniStrategy);
            return list.Select(tuple => ((T)(object)tuple.Item1, tuple.Item2)).ToList();
        }
        return null;
    }

    public static List<(ActionState, ICharacterState)> CreateStates(this FSM<ActionState> fsm, IWeaponAnimationStrategy _aniStrategy) => new()
    {
        (ActionState.Idle, new ActionIdleState(_aniStrategy)),
        (ActionState.Attack, new AttackState(_aniStrategy)),
        (ActionState.Hit, new HitState(_aniStrategy)),
        (ActionState.Dead, new DeadState(_aniStrategy)),
        (ActionState.MovementSkills, new MovementSkillsState(_aniStrategy)),
        (ActionState.WeaponSkills, new WeaponSkillsState(_aniStrategy))
    };

    public static List<(MovementState, ICharacterState)> CreateStates(this FSM<MovementState> fsm, IWeaponAnimationStrategy _aniStrategy) => new()
    {
        (MovementState.Walk, new WalkState(_aniStrategy)),
        (MovementState.Jump, new JumpState(_aniStrategy)),
        (MovementState.Idle, new MovementIdleState(_aniStrategy))
    }; 
    public static List<(PostureState, ICharacterState)> CreateStates(this FSM<PostureState> fsm, IWeaponAnimationStrategy _aniStrategy) => new()
    {
        (PostureState.Idle, new PostureIdleState(_aniStrategy)),
        (PostureState.Crouch, new CrouchState(_aniStrategy))
    };
}

/// <summary>
/// FSM은 상태머신을 구현하기 위한 클래스입니다.
/// </summary>
/// <typeparam name="T">character의 state를 각각 나눠둔 enum을 받음</typeparam>
public class FSM<T> where T : Enum
{
    private string _defaultState;
    private ICharacterState _currentState;
    private Dictionary<Enum, ICharacterState> _states = new();
    private StateType _stateType;
    private Weapon _weapon;
    private CharactorAnimationStrategyFactory _charactorAnimationStrategyFactory;
    private IWeaponAnimationStrategy _aniStrategy;


    /// <summary>
    /// FSM의 생성자입니다.
    /// </summary>
    /// <param name="value"></param>
    public FSM(StateType value, Weapon weapon, string defaultState)
    {
        _defaultState = defaultState;
        _stateType = value;
        _weapon = weapon;
        _charactorAnimationStrategyFactory = new CharactorAnimationStrategyFactory();
        _aniStrategy = _charactorAnimationStrategyFactory.CreateStrategy(weapon);
    }  

    public void Run(CharacterController characterController) 
    {
        List<(T, ICharacterState)> list = this.CreateStates(_aniStrategy);
        foreach (var state in list)
        {
            AddState(state.Item1, state.Item2);
        }

       ChangeState(_defaultState, characterController);
    }

    public void AddState(T stateType, ICharacterState state)
    {
        if (_states.ContainsKey(stateType))
        {
            Debug.LogError($"State {stateType} already exists.");
            return;
        }
        _states.Add(stateType, state);
    }

    public void ChangeState(string stateName, CharacterController characterController) {
        T stateType = (T)(object)Enum.Parse(typeof(T), stateName);
        _currentState?.Exit();
        if (!_states.TryGetValue(stateType, out _currentState)) return;
        _currentState?.Enter(characterController);
    }

    /// <summary>
    /// 무기 변경시 새 전략으로 바꾸기위해 호출해줘야 함
    /// </summary>
    public void ChangeWeapon(Weapon weapon, CharacterController characterController) {
        _weapon = weapon;
        _states.Clear();
        _states = null;
        _aniStrategy = _charactorAnimationStrategyFactory.CreateStrategy(_weapon);
        ChangeState(_defaultState, characterController);
    }
   
}
