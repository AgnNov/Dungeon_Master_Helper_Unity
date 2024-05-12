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
        private Button _clearDrawingsButton;
        [SerializeField]
        private Button _drawButton;


        [SerializeField]
        private GameObject _terrainPanel;
        [SerializeField]
        private GameObject _creaturePanel;
        [SerializeField]
        private GameObject _rollboxPanel;
        [SerializeField]
        private GameObject _panelManagerGO;
        [SerializeField]
        private GameObject _drawingManagerGO;
        [SerializeField]
        private GameObject _drawingsContainer;


        private PanelManager _panelManager;
        private DrawingManager _drawingManager;
        private TMP_Text _drawButtonText;

        void Start()
        {
            _panelManager = _panelManagerGO.GetComponent<PanelManager>();
            _drawingManager = _drawingManagerGO.GetComponent<DrawingManager>();

            _addTerrainButton.onClick.AddListener(() => _panelManager.OpenPanel(_terrainPanel));
            _addCreatureButton.onClick.AddListener(() => _panelManager.OpenPanel(_creaturePanel));
            _rollTheDiceButton.onClick.AddListener(() => _panelManager.OpenPanel(_rollboxPanel));
            _clearDrawingsButton.onClick.AddListener(() => ClearDrawings());
            _drawButton.onClick.AddListener(() => _drawingManager.ChangeActiveness());
            _drawButton.onClick.AddListener(() => ChangeDrawBtnText());
        }

        private void ChangeDrawBtnText()
        {
            _drawButtonText = _drawButton.GetComponentInChildren<TMP_Text>();

            if (_drawingManager.isActive)
            {
                _drawButtonText.SetText("STOP DRAWING");
            }
            else
            {
                _drawButtonText.SetText("START DRAWING");
            }
        }

        private void ClearDrawings()
        {
            for (var i = _drawingsContainer.transform.childCount - 1; i >= 0; i--)
            {
                Destroy(_drawingsContainer.transform.GetChild(i).gameObject);
            }
        }
    }
}
