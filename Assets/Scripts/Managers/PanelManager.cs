using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Panels
{
    public class PanelManager : MonoBehaviour
    {
        public void OpenPanel(GameObject panel)
        {
            panel.SetActive(true);
        }

        public void ClosePanel(GameObject panel)
        {
            panel.SetActive(false);
        }

    }
}