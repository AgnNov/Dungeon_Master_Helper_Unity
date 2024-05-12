using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Panels
{
    public class PanelManager : MonoBehaviour
    {
        public bool isPanelOpened;

        public void OpenPanel(GameObject panel)
        {
            panel.SetActive(true);
            isPanelOpened = true;
        }

        public void ClosePanel(GameObject panel)
        {
            panel.SetActive(false);
            isPanelOpened = false;
        }

    }
}