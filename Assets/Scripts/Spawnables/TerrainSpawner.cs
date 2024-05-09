using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Panels
{
    public class TerrainSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject _terrainPrefab;

        private GameObject m_TerrainContainer;
        private BoxCollider2D m_TerraiinContainerCollider;
        private Vector3 m_Right;
        private Vector3 m_Up;

        private string _terrainWidth;
        private string _terrainHeight;

        public void InstantiateTerrain()
        {
            int width;
            int height;
            int.TryParse(GetWidthInputValue(), out width);
            int.TryParse(GetHeightInputValue(), out height);

            m_Right = transform.right;
            m_Up = transform.up;
            m_TerrainContainer = new GameObject();


            for (var i = 0; i < width; i++)
            {
                float widthOffset = i * 0.75f;
                Vector3 horizontalPosition = transform.position + m_Right * widthOffset;
                GameObject horizontalTile = Instantiate(_terrainPrefab, horizontalPosition, transform.rotation);
                horizontalTile.transform.parent = m_TerrainContainer.transform;

                for (var j = 1; j < height; j++)
                {
                    float heightOffset = j * 0.75f;
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
            m_TerraiinContainerCollider.size = new Vector2(width * 0.75f, height * 0.75f);
            m_TerraiinContainerCollider.offset = new Vector2(0.37f * (width - 1), 0.37f * (height - 1));
            m_TerraiinContainerCollider.isTrigger = true;

            m_TerrainContainer.AddComponent<DragDropManager>();
        }
    }
}