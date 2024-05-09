using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Panels
{
    public class DMActionsBehavior : MonoBehaviour
    {
        [SerializeField]
        private Button _addTerrainButton;
        [SerializeField]
        private Button _addCreatureButton;
        [SerializeField]
        private Button _rollTheDiceButton;
        [SerializeField]
        private Button _addNotesButton;
        [SerializeField]
        private Button _drawButton;


        [SerializeField]
        private GameObject _terrainPanel;
        [SerializeField]
        private GameObject _creaturePanel;
        [SerializeField]
        private GameObject _rollboxPanel;
        [SerializeField]
        private GameObject _notesPanel;

        [SerializeField]
        private GameObject _panelManager;
        [SerializeField]
        private GameObject _drawingManager;


        private PanelManager _panelBehavior;
        private DrawingManager _drawingBehavior;
        private TMP_Text _drawButtonText;

        void Start()
        {
            _panelBehavior = _panelManager.GetComponent<PanelManager>();
            _drawingBehavior = _drawingManager.GetComponent<DrawingManager>();

            _addTerrainButton.onClick.AddListener(() => _panelBehavior.OpenPanel(_terrainPanel));
            _addCreatureButton.onClick.AddListener(() => _panelBehavior.OpenPanel(_creaturePanel));
            _rollTheDiceButton.onClick.AddListener(() => _panelBehavior.OpenPanel(_rollboxPanel));
            _addNotesButton.onClick.AddListener(() => _panelBehavior.OpenPanel(_notesPanel));
            _addNotesButton.onClick.AddListener(() => _panelBehavior.OpenPanel(_notesPanel));
            _drawButton.onClick.AddListener(() => _drawingBehavior.ChangeVisibility());
            _drawButton.onClick.AddListener(() => ChangeDrawBtnText());
        }

        private void ChangeDrawBtnText()
        {
            _drawButtonText = _drawButton.GetComponentInChildren<TMP_Text>();

            if (_drawingBehavior.isActive)
            {
                _drawButtonText.SetText("STOP DRAWING");
            }
            else
            {
                _drawButtonText.SetText("DRAW");
            }
        }
    }
}
