using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropManager : MonoBehaviour
{
    Vector3 mousePosition;
    private ThrashManager _thrashManager;
    private bool _isDraggedAboveThrash;
    private SpriteRenderer _thrashSpriteRenderer;

    private void Start()
    {
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
        _thrashManager.GetComponent<ThrashManager>().ActivateThrash();
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }

    private void OnMouseUp()
    {
        if (_isDraggedAboveThrash)
        {
            Destroy(this.gameObject);
            _isDraggedAboveThrash = false;
        }

        _thrashManager.GetComponent<ThrashManager>().DeactivateThrash();
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
