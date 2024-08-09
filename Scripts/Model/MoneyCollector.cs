using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollector : MonoBehaviour
{
    [SerializeField] ClickBaseModel _baseModel;
    private ClickData _clickData;
    private float _maxTimeToCollection;
    private float _currentTimeToCollection;

    private void Start()
    {
        _clickData = _baseModel.GetClickData();
        _maxTimeToCollection = _clickData.GetMaxTimeAutoCollector();
    }

    private void FixedUpdate()
    {
        _currentTimeToCollection += Time.fixedDeltaTime;
        if(_currentTimeToCollection >= _maxTimeToCollection)
        {
            _baseModel.AutoCollectorAddMoney();
            _currentTimeToCollection = 0;
        }
    }
}
