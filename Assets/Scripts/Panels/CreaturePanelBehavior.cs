using System.Collections;
using System.Collections.Generic;
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
        private GameObject _panelManager;
        [SerializeField]
        private GameObject _inputsManager;
        [SerializeField]
        private GameObject _spawnManager;

        private PanelManager _panelBehavior;
        private InputsManager _inputsBehavior;
        private CreatureSpawner _creatureSpawner;

        public string creatureName;

        void Start()
        {
            _panelBehavior = _panelManager.GetComponent<PanelManager>();
            _inputsBehavior = _inputsManager.GetComponent<InputsManager>();
            _creatureSpawner = _spawnManager.GetComponent<CreatureSpawner>();


            _confirmButton.onClick.AddListener(() => _inputsBehavior.ResetInputText(_creatureNameInput));
            _confirmButton.onClick.AddListener(() => _creatureSpawner.SpawnCreature(GetChosenCreatureType()));
            _confirmButton.onClick.AddListener(() => _panelBehavior.ClosePanel(this.gameObject));

            _cancelButton.onClick.AddListener(() => _inputsBehavior.ResetInputText(_creatureNameInput));
            _cancelButton.onClick.AddListener(() => _panelBehavior.ClosePanel(this.gameObject));
        }

        void Update()
        {
            ManageConfirmButton();
        }

        private void ManageConfirmButton()
        {
            if (_creatureNameInput.text != "")
            {
                _confirmButton.interactable = true;
                creatureName = _creatureNameInput.text;
            }
            else
            {
                _confirmButton.interactable = false;
            }
        }

        private string GetChosenCreatureType()
        {
            Debug.Log(_dropdownChosenOptionTxt.text);
            return _dropdownChosenOptionTxt.text;
        }
    }
}