using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPassive 
{
    //�ʿ��� �͸� �޾ƿ��������� �ʹ� ���ų�
    // ref�� ������� ���ϴ� ��찡 ����Ƿ� playerController�� ������ �Ѱ��ش�
    /// <summary>
    ///  �нú긦 �����ϱ� ���� �޼ҵ�
    ///  �нú� ������ �����ȴ�
    /// </summary>
    /// <param name="playerController">playerController</param>
    public void ApplyPassive(PlayerController playerController);
}
