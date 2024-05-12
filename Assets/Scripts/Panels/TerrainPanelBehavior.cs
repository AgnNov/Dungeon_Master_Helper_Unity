using System.Collections;
using System.Collections.Generic;
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
        private GameObject _panelManager;
        [SerializeField]
        private GameObject _inputsManager;
        [SerializeField]
        private GameObject _spawnManager;

        private PanelManager _panelBehavior;
        private InputsManager _inputsBehavior;
        private TerrainSpawner _terrainBehavior;

        private void Start()
        {
            _panelBehavior = _panelManager.GetComponent<PanelManager>();
            _inputsBehavior = _inputsManager.GetComponent<InputsManager>();
            _terrainBehavior = _spawnManager.GetComponent<TerrainSpawner>();


            _confirmButton.onClick.AddListener(() => _terrainBehavior.InstantiateTerrain());
            _confirmButton.onClick.AddListener(() => _inputsBehavior.ResetInputText(_heightInputValue));
            _confirmButton.onClick.AddListener(() => _inputsBehavior.ResetInputText(_widthInputValue));
            _confirmButton.onClick.AddListener(() => _panelBehavior.ClosePanel(this.gameObject));

            _cancelButton.onClick.AddListener(() => _inputsBehavior.ResetInputText(_heightInputValue));
            _cancelButton.onClick.AddListener(() => _inputsBehavior.ResetInputText(_widthInputValue));
            _cancelButton.onClick.AddListener(() => _panelBehavior.ClosePanel(this.gameObject));

        }

        private void Update()
        {
            ManageConfirmButton();
        }

        private void ManageConfirmButton()
        {
            if (_heightInputValue.text != "" && _widthInputValue.text != "")
            {
                _confirmButton.interactable = true;
            }
            else
            {
                _confirmButton.interactable = false;
            }
        }
    }
}