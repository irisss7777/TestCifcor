using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentTextOnAnimationObject : MonoBehaviour
{
    [SerializeField] Text _myText;

    public Text GetText()
    {
        return _myText;
    }
}
