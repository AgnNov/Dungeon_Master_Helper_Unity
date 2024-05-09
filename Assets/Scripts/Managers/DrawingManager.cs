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

    public bool isActive = false;


    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _drawing = new GameObject();
            _drawingCanvas = _drawing.AddComponent<Canvas>();
            _line = _drawing.AddComponent<LineRenderer>();
            _previousPosition = _drawing.transform.position;

            _drawingCanvas.renderMode = RenderMode.WorldSpace;

            _line.startWidth = lineWidth;
            _line.material = lineMaterial;
            _line.positionCount = 1;

        }


        if (Input.GetMouseButton(0))
        {
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(currentPosition);
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

    public void ChangeVisibility()
    {
        isActive = !isActive;
        this.gameObject.SetActive(isActive);
    }
}

