using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PassiveFactory : MonoBehaviour
{
    //�ۼ��� �Ϸ�� �нú�Ŭ������ �̰��� �߰������־�� ��
    public void CreatePassive(PlayerController target,List<string> passiveNames) {
        foreach (string passiveName in passiveNames) {
            switch (passiveName) {
                case "HpRegenerationPassive":
                    target.PassiveList.Add(target.AddComponent<HpRegenerationPassive>());
                break;
                case "IncreasingRandomStatEvery20Seconds":
                    target.PassiveList.Add(target.AddComponent<IncreasingRandomStatEvery20Seconds>());
                break;
            }
        }
    }
}
