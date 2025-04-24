using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasingRandomStatEvery20Seconds : MonoBehaviour, IPassive
{
    //20�� ���� ���� ���� ����

    Coroutine RandomStat;

    public void ApplyPassive(PlayerController playerController)
    {
        if (RandomStat == null)
        {
            RandomStat = StartCoroutine(HelthRegen(playerController));
        }
    }

    IEnumerator HelthRegen(PlayerController playerController)
    {
        while (true)
        {
            int rand = Random.Range(0, 3);
            switch (rand) {
                case 0:
                    //�ִ� ü�� ����, ü�� 5 ȸ��
                    playerController.AddStatDecorate(StatType.MaxHp, 5);
                    playerController.CurrentHp += 5;
                    break;
                case 1:
                    //�̵� �ӵ� ����
                    playerController.AddStatDecorate(StatType.MoveSpeed, 0.5f);
                    break;
                case 2:
                    //���� ���� ����
                    playerController.AddStatDecorate(StatType.JumpPower, 0.5f);
                    break;
                case 3:
                    //���� ����
                    playerController.AddStatDecorate(StatType.Defence, 0.5f);
                    break;
            }    
            yield return new WaitForSeconds(20f);
            switch (rand)
            {
                case 0:
                    //�ִ� ü�� ����
                    playerController.RemoveStatDecorate(StatType.MaxHp);
                    break;
                case 1:
                    playerController.RemoveStatDecorate(StatType.MoveSpeed);
                    break;
                case 2:
                    playerController.RemoveStatDecorate(StatType.JumpPower);
                    break;
                case 3:
                    playerController.RemoveStatDecorate(StatType.Defence);
                    break;
            }
        }
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
