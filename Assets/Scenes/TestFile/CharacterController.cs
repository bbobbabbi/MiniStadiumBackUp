using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionState { 
    Idle,
    Attack,
    Hit,
    Dead,
    MovementSkills,
    WeaponSkills,
    None
}

public enum PostureState { 
    Idle,
    Crouch,
    None
}

public enum MovementState
{
    Idle,
    Walk,
    Jump,
    None
}

public class CharacterController : MonoBehaviour
{
    [Header("FSM")]
    private CharacterFSM<ActionState> _actionFSM;
    private CharacterFSM<PostureState> _PostureFSM;
    private CharacterFSM<MovementState> _MovementFSM;
    [SerializeField]
    private string defaultState;

    [Header("Weapon")]
    Weapon _weapon;


    private Animator _animator;
    public Animator Animator { get => _animator;}

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _weapon = GetComponent<Weapon>();
        _actionFSM = new CharacterFSM<ActionState>(StateType.Action, _weapon, defaultState);
        _PostureFSM = new CharacterFSM<PostureState>(StateType.Posture, _weapon, defaultState);
        _MovementFSM = new CharacterFSM<MovementState>(StateType.Move, _weapon, defaultState);
    }

    void Start()
    {
        _actionFSM.Run(this);
        _PostureFSM.Run(this);
        _MovementFSM.Run(this);

        _actionFSM.ChangeState("Attack",this);
        _PostureFSM.ChangeState("Crouch", this);
    }

    void Update()
    {
        Debug.Log("Update");
    }
}
