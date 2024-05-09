using Panel;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Panels
{    
    public class CreatureSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject _creaturePrefab;
        [SerializeField]
        private GameObject _creaturePanel;

        private CreatureaPanelBehavior _creaturePanelBehavior;

        private void Start()
        {
            _creaturePanelBehavior = _creaturePanel.GetComponent<CreatureaPanelBehavior>();
        }

        public void SpawnCreature(string creatureType)
        {
            GameObject creature = Instantiate(_creaturePrefab, new Vector3(0, 0, -1), Quaternion.identity);
            creature.AddComponent<CircleCollider2D>().isTrigger = true;
            creature.AddComponent<DragDropManager>();
            creature.GetComponentInChildren<Canvas>().renderMode = RenderMode.WorldSpace;
            creature.GetComponentInChildren<TMP_Text>().text = _creaturePanelBehavior.creatureName;

            switch (creatureType)
            {
                case "Hero":
                    creature.GetComponent<SpriteRenderer>().color = Color.green;
                    break;
                case "Enemy":
                    creature.GetComponent<SpriteRenderer>().color = Color.red;
                    break;
                case "Allay":
                    creature.GetComponent<SpriteRenderer>().color = Color.blue;
                    break;
                case "Neutral":
                    creature.GetComponent<SpriteRenderer>().color = Color.gray;
                    break;
                default:
                    Debug.Log("Type not recognized");
                    break;
            }
        }
    }
}