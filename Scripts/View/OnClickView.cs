using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class OnClickView : MonoBehaviour
{
    List<Animator> _myAnims = new List<Animator>(5);
    List<Text> _myText = new List<Text>(5);
    List<Animator> _myAnims1 = new List<Animator>(5);
    List<Text> _myText1 = new List<Text>(5);
    [SerializeField] private Transform _onClickAnimParent;
    [SerializeField] private Transform _onAutoCollectionAnimParent;
    [SerializeField] private GameObject _onClickAnimPrefab;
    [SerializeField] private Animator _characterAnimator;
    private const int _maxCountOfObjectPull = 5;
    private int _currentInObjectPull;

    public void OnClick(int value)
    {
        if (_myAnims.Count < _maxCountOfObjectPull)
        {
            GameObject onClickObj = Instantiate(_onClickAnimPrefab, _onClickAnimParent.transform.position, Quaternion.identity);
            onClickObj.transform.SetParent(_onClickAnimParent);
            onClickObj.transform.localScale = new Vector3(1, 1, 1);
            StringBuilder newText = new StringBuilder("+ " + value);
            Text currentText = onClickObj.GetComponent<CurrentTextOnAnimationObject>().GetText();
            currentText.text = newText.ToString();
            _myAnims.Add(onClickObj.GetComponent<Animator>());
            _myText.Add(currentText);
        }
        else
        {
            StringBuilder newText = new StringBuilder("+ " + value);
            _myText[_currentInObjectPull].text = newText.ToString();
            _myAnims[_currentInObjectPull].SetTrigger("OnClick");
            if (_currentInObjectPull < _maxCountOfObjectPull - 1)
            {
                _currentInObjectPull += 1;
            }
            else
            {
                _currentInObjectPull = 0;
            }
        }
        _characterAnimator.SetTrigger("Hit");
    }

    public void OnAutoCollection(int value)
    {
        if (_myAnims1.Count < _maxCountOfObjectPull)
        {
            GameObject onClickObj = Instantiate(_onClickAnimPrefab, _onAutoCollectionAnimParent.transform.position, Quaternion.identity);
            onClickObj.transform.SetParent(_onAutoCollectionAnimParent);
            onClickObj.transform.localScale = new Vector3(1, 1, 1);
            StringBuilder newText = new StringBuilder("+ " + value);
            Text currentText = onClickObj.GetComponent<CurrentTextOnAnimationObject>().GetText();
            currentText.text = newText.ToString();
            _myAnims1.Add(onClickObj.GetComponent<Animator>());
            _myText1.Add(currentText);
        }
        else
        {
            StringBuilder newText = new StringBuilder("+ " + value);
            _myText1[_currentInObjectPull].text = newText.ToString();
            _myAnims1[_currentInObjectPull].SetTrigger("OnClick");
            if (_currentInObjectPull < _maxCountOfObjectPull - 1)
            {
                _currentInObjectPull += 1;
            }
            else
            {
                _currentInObjectPull = 0;
            }
        }
    }
}
