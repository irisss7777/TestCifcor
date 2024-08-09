using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBaseModel : MonoBehaviour
{
    [SerializeField] private ClickData _clickData;
    [SerializeField] private OnClickView _clickView;
    [SerializeField] private GenerateEnergy _generateEnergy;
    [SerializeField] private MyMoneyView _moneyView;
    private int _currentMoney;
    private float _timeToAutoCollector;
    private float _maxTimeToAutoCollector;

    private void Awake()
    {
        _maxTimeToAutoCollector = _clickData.GetMaxTimeAutoCollector();
        _clickData.SetStartEnergy();
    }

    private void FixedUpdate()
    {
        _timeToAutoCollector += Time.fixedDeltaTime;
        if(_timeToAutoCollector >= _maxTimeToAutoCollector)
        {
            _timeToAutoCollector = 0;

        }
    }

    public ClickData GetClickData()
    {
        return _clickData;
    }

    public void AddBonusMoneyOnClick(int bonusValue)
    {
        _clickData.AddBonusOnClick(bonusValue);
    }

    public void TryAddMoney()
    {
        if (_clickData.GetEnergy())
        {
            _currentMoney += _clickData.GetClickData();
            _clickData.SubstractEnergy();
            _generateEnergy.UpdateEnergyBar();
            _clickView.OnClick(_clickData.GetClickData());
            _moneyView.UpdateMoney(_currentMoney);
        }
    }

    public void AutoCollectorAddMoney()
    {
        _currentMoney += _clickData.GetAutoCollectorValue();
        _clickView.OnAutoCollection(_clickData.GetAutoCollectorValue());
        _moneyView.UpdateMoney(_currentMoney);
    }
}
