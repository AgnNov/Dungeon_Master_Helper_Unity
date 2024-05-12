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

        private GameObject _terrainSpawned;
        private BoxCollider2D _terraiinContainerCollider;
        private Vector3 _right;
        private Vector3 _up;

        private string _terrainWidth;
        private string _terrainHeight;

        private float _terrainOffset = 0.75f;

        public void InstantiateTerrain()
        {
            int width;
            int height;
            int.TryParse(GetWidthInputValue(), out width);
            int.TryParse(GetHeightInputValue(), out height);

            _right = transform.right;
            _up = transform.up;
            _terrainSpawned = new GameObject();
            _terrainSpawned.transform.parent = _terrainContainer.transform;


            for (var i = 0; i < width; i++)
            {
                float widthOffset = i * _terrainOffset;
                Vector3 horizontalPosition = transform.position + _right * widthOffset;
                GameObject horizontalTile = Instantiate(_terrainPrefab, horizontalPosition, transform.rotation);
                horizontalTile.transform.parent = _terrainSpawned.transform;

                for (var j = 1; j < height; j++)
                {
                    float heightOffset = j * _terrainOffset;
                    Vector3 verticalPosition = transform.position + _right * widthOffset + _up * heightOffset;
                    GameObject verticalTile = Instantiate(_terrainPrefab, verticalPosition, transform.rotation);
                    verticalTile.transform.parent = _terrainSpawned.transform;
                }
            }

            _terrainSpawned.transform.position = transform.position + transform.right * (width * -(_terrainOffset/2)) + transform.up * (height * -(_terrainOffset / 2));

            AddTerrainComponents(width, height);
        }


        private string GetHeightInputValue()
        {
            _terrainHeight = GameObject.Find("HeightInput").GetComponent<TMP_InputField>().text;

            return _terrainHeight;
        }

        private string GetWidthInputValue()
        {
            _terrainWidth = GameObject.Find("WidthInput").GetComponent<TMP_InputField>().text;

            return _terrainWidth;
        }

        private void AddTerrainComponents(int width, int height)
        {
            _terrainSpawned.AddComponent<BoxCollider2D>();
            _terraiinContainerCollider = _terrainSpawned.GetComponent<BoxCollider2D>();
            _terraiinContainerCollider.size = new Vector2(width * _terrainOffset, height * _terrainOffset);
            _terraiinContainerCollider.offset = new Vector2((_terrainOffset/2) * (width - 1), (_terrainOffset/2) * (height - 1));
            _terraiinContainerCollider.isTrigger = true;

            _terrainSpawned.AddComponent<DragablesBehavior>();
        }
    }
}