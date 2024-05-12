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

    private Button _diceButton;
    private TMP_Text _resultText;

    private void Start()
    {
        _resultText = _result.GetComponent<TMP_Text>();
        _diceButton = gameObject.GetComponent<Button>();

        _diceButton.onClick.AddListener(() => RollTheDice());
    }

    public void RollTheDice()
    {

        int rolledValue = Random.Range(1, _diceValue + 1);

        _resultText.SetText($"D{_diceValue} roll: {rolledValue}");
        _result.SetActive(true);
    }


}
