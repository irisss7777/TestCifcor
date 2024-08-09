using UnityEngine;

[CreateAssetMenu(fileName = "DefaultClickData", menuName = "MyClickData", order = 51)]
public class ClickData : ScriptableObject
{
    [Header("Energy")]
    [SerializeField] private int _baseEnergy;
    [SerializeField] private int _energyCostOnClick;
    [SerializeField] private int _energyAddValue;
    private int _bonusEnergy;
    private int _currentEnergy;
    [Space]
    [Header("Click")]
    [SerializeField] private int _baseMoneyOnClick;
    [SerializeField] private int _bonusMoneyOnClick;
    [Space]
    [Header("Auto collector")]
    [SerializeField] private int _baseAutoCollectorValue;
    [SerializeField] private float _timeToNewAutoCollect;
    private int _bonusAutoCollectorValue;

    public void SetStartEnergy()
    {
        //бонусную энергию можно будет увеличивать, а также подгружать на старте из базы данных
        _currentEnergy = _baseEnergy + _bonusEnergy;
    }

    public int GetClickData()
    {
        int currentClickData = (_baseMoneyOnClick * _bonusMoneyOnClick) +
        (int)Mathf.Round((_baseAutoCollectorValue + _bonusAutoCollectorValue) / 10);
        return currentClickData;
    }

    public void AddBonusOnClick(int bonus)
    {
        _bonusMoneyOnClick += bonus;
    }

    public int GetAutoCollectorValue()
    {
        return _baseAutoCollectorValue + _bonusAutoCollectorValue;
    }

    public float GetMaxTimeAutoCollector()
    {
        return _timeToNewAutoCollect;
    }

    public bool GetEnergy()
    {
        bool noneEnergy = true;
        if (_currentEnergy - _energyCostOnClick >= 0)
        {
            noneEnergy = true;
        }
        else
        {
            noneEnergy = false;
        }
        Debug.Log(_currentEnergy);
        return noneEnergy;
    }

    public int GetStartEnergy()
    {
        return _baseEnergy + _bonusEnergy;
    }

    public int GetCurrentEnergy()
    {
        return _currentEnergy;
    }

    public void SubstractEnergy()
    {
        if (_currentEnergy - _energyCostOnClick >= 0)
        {
            _currentEnergy -= _energyCostOnClick;
        }
    }

    public void AddEnergy()
    {
        if (_currentEnergy < GetStartEnergy())
        {
            _currentEnergy += _energyAddValue;
        }
    }
}
