using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SkillFactory
{
    /// <summary>
    /// �� ��ų�� �´� ��ų���� �����ؼ� ��ȯ  
    /// </summary>
    /// <param name="_aniStrategy"></param>
    /// <param name="skillNames">��ų �̸����� ��� ����Ʈ</param>
    /// <returns></returns>
    public static List<(ActionState, IPlayerState)> CreateStates(this PlayerFSM<ActionState> fsm, List<string> skillNames)
    {
        List<(ActionState, IPlayerState)> states = new List<(ActionState, IPlayerState)>();
        foreach (var skillName in skillNames)
        {
            switch (skillName)
            {
                case "MovementSkills":
                    states.Add(new(ActionState.MovementSkills, new MovementSkillsState()));
                    break;
            }
        }
        return states;
    }
}
