using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatObserver 
{
    //Stat�� ��ȭ�� �� ȣ��Ǵ� �޼ҵ�
    //����Ϸ��� Ŭ�������� IStatPublisher�� ��ӹް� �� Ŭ������ �ش��ϴ� Stat�� Obseervers�� ����ؾ���
    public void WhenStatChanged((float,string) data);  
}
