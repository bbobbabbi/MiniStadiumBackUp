using System;
using System.Collections.Generic;

public class Stat : IStatPublisher
{
    private readonly float baseValue;
    private List<Func<float, float>> modifiers;
    private float value;
    private List<IStatObserver> observers;
    private float passResult;
    public float BaseValue => baseValue;
    public float Value
    {
        get
        {
            float result = baseValue;
            foreach (var modifier in modifiers)
            {
                result = modifier(result);
            }
           
            value = result;
            if (value != passResult)
            {
                NotifyObservers(value);
                passResult = value;
            }
            return value;
        }
    }

    /// <summary>
    /// ������
    /// </summary>
    /// <param name="baseValue"> PlayerController�� fixed�������� �⺻���� �Ҵ� </param>
    public Stat(float baseValue)
    {
        this.baseValue = baseValue;
        this.modifiers = new List<Func<float, float>>();
        this.value = baseValue;
        this.observers = new List<IStatObserver>();
    }

    /// <summary>
    /// ���ڷ���Ʈ �߰� �޼ҵ�
    /// </summary>
    /// <param name="Decorate">���ڷ���Ʈ �� func ������ ����</param>
    public void AddDecorate(Func<float, float> Decorate)
    {
        modifiers.Add(Decorate);
    }

    /// <summary>
    /// �ε��� ��° ���� ���� 
    /// </summary>
    public void RemoveModifiers() {
        if (modifiers.Count > 0)
        {
            modifiers.RemoveAt(modifiers.Count - 1);
        }
    }

    /// <summary>
    /// ���� ��� ����
    /// </summary>
    public void RemoveAllModifiers()
    {
        modifiers.Clear();
    }

    public void AddObserver(IStatObserver observer)
    {
        if (observers == null) {
            observers = new List<IStatObserver>();
        }
        observers.Add(observer);
    }

    public void RemoveObserver(IStatObserver observer)
    {
        observers.Clear();
    }

    public void NotifyObservers(float value)
    {
        if (observers == null) return;
        foreach (IStatObserver observer in observers)
        {
            observer.WhenStatChanged(value);
        }
    }
}
