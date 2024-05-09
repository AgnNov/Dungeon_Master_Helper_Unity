using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        private Button _addObjectButton;


        [SerializeField]
        private GameObject _terrainPanel;
        [SerializeField]
        private GameObject _creaturePanel;
        [SerializeField]
        private GameObject _rollboxPanel;
        [SerializeField]
        private GameObject _notesPanel;
        [SerializeField]
        private GameObject _objectsPanel;


        [SerializeField]
        private GameObject _panelManager;
        
        private PanelManager _panelBehavior;

        void Start()
        {
            _panelBehavior = _panelManager.GetComponent<PanelManager>();

            _addTerrainButton.onClick.AddListener(() => _panelBehavior.OpenPanel(_terrainPanel));
            _addCreatureButton.onClick.AddListener(() => _panelBehavior.OpenPanel(_creaturePanel));
            _rollTheDiceButton.onClick.AddListener(() => _panelBehavior.OpenPanel(_rollboxPanel));
            _addNotesButton.onClick.AddListener(() => _panelBehavior.OpenPanel(_notesPanel));
            _addNotesButton.onClick.AddListener(() => _panelBehavior.OpenPanel(_notesPanel));
            _addObjectButton.onClick.AddListener(() => _panelBehavior.OpenPanel(_objectsPanel));
        }
    }
}
