using Panels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragablesBehavior : MonoBehaviour
{
    Vector3 mousePosition;
    private DrawingManager _drawingManager;
    private PanelManager _panelManager;
    private ThrashManager _thrashManager;
    private bool _isDraggedAboveThrash;
    private SpriteRenderer _thrashSpriteRenderer;

    private void Start()
    {
        _drawingManager = GameObject.Find("DrawingManager").GetComponent<DrawingManager>();
        _panelManager = GameObject.Find("PanelManager").GetComponent<PanelManager>();
        _thrashManager = GameObject.Find("ThrashManager").GetComponent<ThrashManager>();
    }

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        if (!_panelManager.isPanelOpened && !_drawingManager.isActive)
        {
            _thrashManager.ActivateThrash();
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        }
    }

    private void OnMouseUp()
    {
        if (_isDraggedAboveThrash && !_panelManager.isPanelOpened && !_drawingManager.isActive)
        {
            Destroy(this.gameObject);
            _isDraggedAboveThrash = false;
        }

        _thrashManager.DeactivateThrash();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Thrash")
        {
            _thrashSpriteRenderer = other.GetComponent<SpriteRenderer>();
            _thrashSpriteRenderer.color = Color.red;
           _isDraggedAboveThrash = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        {
            _thrashSpriteRenderer = other.GetComponent<SpriteRenderer>();
            _thrashSpriteRenderer.color = Color.white;
            _isDraggedAboveThrash = false;
        }
    }
}
