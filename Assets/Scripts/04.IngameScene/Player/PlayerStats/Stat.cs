using System;
using System.Collections.Generic;

public class Stat : IStatPublisher
{
    private readonly float baseValue;
    private List<Func<float, float>> modifiers;
    private string name;
    private float value;
    private List<IStatObserver> observers;
    private (float,string) data;
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
            return result;
        }
    }

    /// <summary>
    /// ������
    /// </summary>
    /// <param name="baseValue"> PlayerController�� fixed�������� �⺻���� �Ҵ� </param>
    /// <param name="statName">�񱳸� ���� Stat�� �̸��� ����</param>
    public Stat(float baseValue, string statName)
    {
        this.baseValue = baseValue;
        this.modifiers = new List<Func<float, float>>();
        this.value = baseValue;
        this.observers = new List<IStatObserver>();
        name = statName;
    }

    /// <summary>
    /// ���ڷ���Ʈ �߰� �޼ҵ�
    /// </summary>
    /// <param name="Decorate">���ڷ���Ʈ �� func ������ ����</param>
    public void AddDecorate(Func<float, float> Decorate)
    {
        modifiers.Add(Decorate);
        checkValueChanged();
    }

    /// <summary>
    /// �ε��� ��° ���� ���� 
    /// </summary>
    public void RemoveModifiers() {
        if (modifiers.Count > 0)
        {
            modifiers.RemoveAt(modifiers.Count - 1);
            checkValueChanged();
        }
    }

    /// <summary>
    /// ���� ��� ����
    /// </summary>
    public void RemoveAllModifiers()
    {
        modifiers.Clear();
        checkValueChanged();
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

    public void NotifyObservers((float,string) value)
    {
        if (observers == null) return;
        foreach (IStatObserver observer in observers)
        {
            observer.WhenStatChanged(value);
        }
    }

    private void checkValueChanged() {
        float curr = Value;
        if (passResult != curr)
        {
            NotifyObservers(new(curr, name));
            passResult = curr;
        }
    }
}
