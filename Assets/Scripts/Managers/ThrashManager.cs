using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{    public class ThrashManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _thrashIcon;
        private SpriteRenderer _thrashIconSpriteRenderer;

        private void Start()
        {
            _thrashIconSpriteRenderer = _thrashIcon.GetComponent<SpriteRenderer>();
        }

        public void ActivateThrash()
        {
            _thrashIcon.SetActive(true);
        }

        public void DeactivateThrash()
        {
            _thrashIcon.SetActive(false);
            _thrashIconSpriteRenderer.color = Color.white;
        }
    }
}

