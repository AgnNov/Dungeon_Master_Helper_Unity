using Panels;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using RenderMode = UnityEngine.RenderMode;

public class DrawingManager : MonoBehaviour
{
    private GameObject _drawing;
    private LineRenderer _line;
    private Canvas _drawingCanvas;
    private Vector3 _previousPosition;

    [SerializeField]
    private float minDistance = 0.1f;
    [SerializeField]
    private float lineWidth = 0.1f;
    [SerializeField]
    private Material lineMaterial;
    [SerializeField]
    private GameObject _drawingsContainer;
    [SerializeField]
    private GameObject _panelManager;

    private PanelManager _panelBehavior;


    public bool isActive = false;


    void Start()
    {
        _panelBehavior = _panelManager.GetComponent<PanelManager>();
    }

    void Update()
    {
        if (isActive && !_panelBehavior.isPanelOpened)
        {

            if (Input.GetMouseButtonDown(0))
            {
                _drawing = new GameObject();
                _drawing.transform.parent = _drawingsContainer.transform;
                _line = _drawing.AddComponent<LineRenderer>();
                _previousPosition = _drawing.transform.position;

                _line.startWidth = lineWidth;
                _line.material = lineMaterial;
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

    public void ChangeActiveness()
    {
        isActive = !isActive;
    }
}

