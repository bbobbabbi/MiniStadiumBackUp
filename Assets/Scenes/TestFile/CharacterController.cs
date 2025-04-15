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
    private FSM<ActionState> _actionFSM;
    private FSM<PostureState> _PostureFSM;
    private FSM<MovementState> _MovementFSM;
    [SerializeField]
    private string defaultState;

    [Header("Weapon")]
    Weapon _weapon;

    private void Awake()
    {
        _weapon = GetComponent<Weapon>();
        _actionFSM = new FSM<ActionState>(StateType.Action, _weapon, defaultState);
        _PostureFSM = new FSM<PostureState>(StateType.Posture, _weapon, defaultState);
        _MovementFSM = new FSM<MovementState>(StateType.Move, _weapon, defaultState);
    }

    void Start()
    {
        _actionFSM.Run(this);
        _PostureFSM.Run(this);
        _MovementFSM.Run(this);

        _actionFSM.ChangeState("Attack",this);
    }

    void Update()
    {
        Debug.Log("Update");
    }
}
