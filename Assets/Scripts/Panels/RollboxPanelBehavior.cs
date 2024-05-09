using Panels;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RollboxBehavior : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _resultText;

    [SerializeField]
    private Button _rollTheDiceButton;
    [SerializeField]
    private Button _cancelButton;
    [SerializeField]
    private GameObject _panelManager;

    private PanelManager _panelBehavior;

    private void Start()
    {
        _panelBehavior = _panelManager.GetComponent<PanelManager>();

        _cancelButton.onClick.AddListener(() => _panelBehavior.ClosePanel(this.gameObject));
        _cancelButton.onClick.AddListener(ResetResultText);
    }

    public void ResetResultText()
    {
        _resultText.SetText("");
    }
}
