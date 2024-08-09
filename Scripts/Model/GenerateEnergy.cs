using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateEnergy : MonoBehaviour
{
    [SerializeField] private float _maxTimeToGenerateEnergy;
    private float _currentTimeToGenerateEnergy;
    private ClickData _clickData;
    [SerializeField] private Image _energyBar;
    [Space]
    [SerializeField] private ClickBaseModel _baseModel;

    private void Start()
    {
        _clickData = _baseModel.GetClickData();
        UpdateEnergyBar();
    }

    private void FixedUpdate()
    {
        _currentTimeToGenerateEnergy += Time.fixedDeltaTime;
        Debug.Log(_currentTimeToGenerateEnergy);
        if (_currentTimeToGenerateEnergy >= _maxTimeToGenerateEnergy)
        {
            _clickData.AddEnergy();
            UpdateEnergyBar();
            _currentTimeToGenerateEnergy = 0;
        }
    }

    public void UpdateEnergyBar()
    {
        _energyBar.fillAmount = (float)_clickData.GetCurrentEnergy() / (float)_clickData.GetStartEnergy();
    }
}
