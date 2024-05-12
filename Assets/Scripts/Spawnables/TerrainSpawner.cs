using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Spawners
{
    public class TerrainSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject _terrainPrefab;
        [SerializeField]
        private GameObject _terrainContainer;

        private GameObject m_TerrainContainer;
        private BoxCollider2D m_TerraiinContainerCollider;
        private Vector3 m_Right;
        private Vector3 m_Up;

        private string _terrainWidth;
        private string _terrainHeight;

        private float _terrainOffset = 0.75f;

        public void InstantiateTerrain()
        {
            int width;
            int height;
            int.TryParse(GetWidthInputValue(), out width);
            int.TryParse(GetHeightInputValue(), out height);

            m_Right = transform.right;
            m_Up = transform.up;
            m_TerrainContainer = new GameObject();
            m_TerrainContainer.transform.parent = _terrainContainer.transform;


            for (var i = 0; i < width; i++)
            {
                float widthOffset = i * _terrainOffset;
                Vector3 horizontalPosition = transform.position + m_Right * widthOffset;
                GameObject horizontalTile = Instantiate(_terrainPrefab, horizontalPosition, transform.rotation);
                horizontalTile.transform.parent = m_TerrainContainer.transform;

                for (var j = 1; j < height; j++)
                {
                    float heightOffset = j * _terrainOffset;
                    Vector3 verticalPosition = transform.position + m_Right * widthOffset + m_Up * heightOffset;
                    GameObject verticalTile = Instantiate(_terrainPrefab, verticalPosition, transform.rotation);
                    verticalTile.transform.parent = m_TerrainContainer.transform;
                }
            }

            m_TerrainContainer.transform.position = transform.position + transform.right * (width * -0.37f) + transform.up * (height * -0.37f);

            AddTerrainComponents(width, height);
        }


        private string GetHeightInputValue()
        {
            _terrainHeight = GameObject.Find("HeightInput").GetComponent<TMP_InputField>().text;


            if (_terrainHeight == null)
            {
                Debug.Log("Height input value not found!");
            }

            return _terrainHeight;
        }

        private string GetWidthInputValue()
        {
            _terrainWidth = GameObject.Find("WidthInput").GetComponent<TMP_InputField>().text;

            if (_terrainWidth == null)
            {
                Debug.Log("Width input value not found!");
            }

            return _terrainWidth;
        }

        private void AddTerrainComponents(int width, int height)
        {
            m_TerrainContainer.AddComponent<BoxCollider2D>();
            m_TerraiinContainerCollider = m_TerrainContainer.GetComponent<BoxCollider2D>();
            m_TerraiinContainerCollider.size = new Vector2(width * _terrainOffset, height * _terrainOffset);
            m_TerraiinContainerCollider.offset = new Vector2((_terrainOffset/2) * (width - 1), (_terrainOffset/2) * (height - 1));
            m_TerraiinContainerCollider.isTrigger = true;

            m_TerrainContainer.AddComponent<DragablesBehavior>();
        }
    }
}