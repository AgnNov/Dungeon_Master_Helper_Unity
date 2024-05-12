using System.Collections;
using System.Collections.Generic;
using Managers;
using Spawners;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Panels
{
    public class CreaturePanelBehavior : MonoBehaviour
    {
        [SerializeField]
        private Button _addCreatureButton;
        [SerializeField]
        private Button _confirmButton;
        [SerializeField]
        private Button _cancelButton;

        [SerializeField]
        private TMP_Text _dropdownChosenOptionTxt;

        [SerializeField]
        private TMP_InputField _creatureNameInput;

        [SerializeField]
        private GameObject _panelManagerGO;
        [SerializeField]
        private GameObject _inputsManagerGO;
        [SerializeField]
        private GameObject _spawnManagerGO;

        private PanelManager _panelManager;
        private InputsManager _inputsManager;
        private CreatureSpawner _creatureSpawner;

        public string creatureName;

        void Start()
        {
            _panelManager = _panelManagerGO.GetComponent<PanelManager>();
            _inputsManager = _inputsManagerGO.GetComponent<InputsManager>();
            _creatureSpawner = _spawnManagerGO.GetComponent<CreatureSpawner>();


            _confirmButton.onClick.AddListener(() => _inputsManager.ResetInputText(_creatureNameInput));
            _confirmButton.onClick.AddListener(() => _creatureSpawner.SpawnCreature(GetChosenCreatureType()));
            _confirmButton.onClick.AddListener(() => _panelManager.ClosePanel(gameObject));

            _cancelButton.onClick.AddListener(() => _inputsManager.ResetInputText(_creatureNameInput));
            _cancelButton.onClick.AddListener(() => _panelManager.ClosePanel(gameObject));
        }

        void Update()
        {
            bool interactibilityCondition = _creatureNameInput.text != "";
            _panelManager.ManageButtonInteractibility(interactibilityCondition,
                                                      _confirmButton);
            creatureName = _creatureNameInput.text;

        }


        private string GetChosenCreatureType()
        {
            return _dropdownChosenOptionTxt.text;
        }
    }
}