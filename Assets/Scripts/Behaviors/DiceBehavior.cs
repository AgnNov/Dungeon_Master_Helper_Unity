using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiceBehavior : MonoBehaviour
{
    [SerializeField]
    private int _diceValue;
    [SerializeField]
    private GameObject _result;

    private TMP_Text _resultText;

    private void Start()
    {
        _resultText = _result.GetComponent<TMP_Text>();
    }

    public void RollTheDice()
    {

        int rolledValue = Random.Range(1, _diceValue + 1);
        Debug.Log("You rolled " + rolledValue  + "!");

        _resultText.SetText($"D{_diceValue} roll: {rolledValue}");
        _result.SetActive(true);
    }


}
