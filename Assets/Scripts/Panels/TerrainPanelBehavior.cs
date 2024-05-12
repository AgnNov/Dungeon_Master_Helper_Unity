using System.Collections;
using System.Collections.Generic;
using Managers;
using Spawners;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Panels
{
    public class TerrainPanelBehavior : MonoBehaviour
    {
        [SerializeField]
        private Button _addTerrainButton;
        [SerializeField]
        private Button _confirmButton;
        [SerializeField]
        private Button _cancelButton;

        [SerializeField]
        private TMP_InputField _heightInputValue;
        [SerializeField]
        private TMP_InputField _widthInputValue;

        [SerializeField]
        private GameObject _panelManagerGO;
        [SerializeField]
        private GameObject _inputsManagerGO;
        [SerializeField]
        private GameObject _spawnManagerGO;

        private PanelManager _panelManager;
        private InputsManager _inputsManager;
        private TerrainSpawner _terrainSpawner;

        private void Start()
        {
            _panelManager = _panelManagerGO.GetComponent<PanelManager>();
            _inputsManager = _inputsManagerGO.GetComponent<InputsManager>();
            _terrainSpawner = _spawnManagerGO.GetComponent<TerrainSpawner>();


            _confirmButton.onClick.AddListener(() => _terrainSpawner.InstantiateTerrain());
            _confirmButton.onClick.AddListener(() => _inputsManager.ResetInputText(_heightInputValue));
            _confirmButton.onClick.AddListener(() => _inputsManager.ResetInputText(_widthInputValue));
            _confirmButton.onClick.AddListener(() => _panelManager.ClosePanel(gameObject));

            _cancelButton.onClick.AddListener(() => _inputsManager.ResetInputText(_heightInputValue));
            _cancelButton.onClick.AddListener(() => _inputsManager.ResetInputText(_widthInputValue));
            _cancelButton.onClick.AddListener(() => _panelManager.ClosePanel(gameObject));

        }

        private void Update()
        {
            bool interactibilityCondition = _heightInputValue.text != "" && _widthInputValue.text != "";
            _panelManager.ManageButtonInteractibility(interactibilityCondition,
                                                      _confirmButton);

        }

    }
}