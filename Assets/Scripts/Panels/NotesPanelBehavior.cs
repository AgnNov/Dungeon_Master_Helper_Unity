using Panels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotesPanelBehavior : MonoBehaviour
{
    [SerializeField]
    private Button _addNotesButton;
    [SerializeField]
    private Button _saveButton;
    [SerializeField]
    private GameObject _panelManager;

    private PanelManager _panelBehavior;

    void Start()
    {
        _panelBehavior = _panelManager.GetComponent<PanelManager>();

        _saveButton.onClick.AddListener(() => _panelBehavior.ClosePanel(this.gameObject));
    }
}
