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
    private TMP_Text _resultText;

    private Button _diceButton;

    private void Start()
    {
        _diceButton = gameObject.GetComponent<Button>();
        _diceButton.onClick.AddListener(() => RollTheDice());
    }

    public void RollTheDice()
    {

        int rolledValue = Random.Range(1, _diceValue + 1);

        _resultText.SetText($"D{_diceValue} roll: {rolledValue}");
    }
}
