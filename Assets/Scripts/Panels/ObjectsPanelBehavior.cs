using Panel;
using Panels;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ObjectsPanelBehavior : MonoBehaviour
{
    [SerializeField]
    private Button _cancelButton;

    [SerializeField]
    private Transform _items;
    [SerializeField]
    private GameObject _panelManager;
    [SerializeField]
    private GameObject _itemPrefab;

    private PanelManager _panelBehavior;
    private 

    void Start()
    {
        _panelBehavior = _panelManager.GetComponent<PanelManager>();

        _cancelButton.onClick.AddListener(() => _panelBehavior.ClosePanel(this.gameObject));
    }
}


