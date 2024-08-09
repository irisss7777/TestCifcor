using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class MyMoneyView : MonoBehaviour
{
    [SerializeField] private Text _myMoneyText;

    public void UpdateMoney(int currentMoney)
    {
        StringBuilder newText = new StringBuilder("" + currentMoney);
        _myMoneyText.text = newText.ToString();
    }
}
