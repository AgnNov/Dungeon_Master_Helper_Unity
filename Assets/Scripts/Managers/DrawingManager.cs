using Managers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class DrawingManager : MonoBehaviour
{
    private GameObject _drawing;
    private LineRenderer _line;
    private Vector3 _previousPosition;


    [SerializeField]
    private Material _lineMaterial;
    [SerializeField]
    private GameObject _drawingsContainer;
    [SerializeField]
    private GameObject _panelManagerGO;

    private PanelManager _panelManger;

    private float minDistance = 0.1f;
    private float _lineWidth = 0.1f;

    public bool isActive = false;


    void Start()
    {
        _panelManger = _panelManagerGO.GetComponent<PanelManager>();
    }

    void Update()
    {
        if (isActive && !_panelManger.isPanelOpened)
        {

            if (Input.GetMouseButtonDown(0))
            {
                _drawing = new GameObject();
                _drawing.transform.parent = _drawingsContainer.transform;
                _line = _drawing.AddComponent<LineRenderer>();
                _previousPosition = _drawing.transform.position;

                _line.startWidth = _lineWidth;
                _line.material = _lineMaterial;
                _line.positionCount = 1;

            }


            if (Input.GetMouseButton(0))
            {
                Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                currentPosition.z = 1;

                if (Vector3.Distance(currentPosition, _previousPosition) > minDistance)
                {

                    if (_previousPosition == transform.position)
                    {
                        _line.SetPosition(0, currentPosition);
                    }

                    else
                    {
                        _line.positionCount++;
                        _line.SetPosition(_line.positionCount - 1, currentPosition);
                    }

                    _previousPosition = currentPosition;
                }
            }
        }
    }

    public void ChangeActivenessStatus()
    {
        isActive = !isActive;
    }
}

