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

    private void Awake()
    {
        _clickData.SetStartEnergy();
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
