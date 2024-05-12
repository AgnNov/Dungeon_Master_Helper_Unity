using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Managers
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

        public void ManageButtonInteractibility(bool condition, Button button)
        {
            if (condition)
            {
                button.interactable = true;
            }
            else
            {
                button.interactable = false;
            }
        }
    }
}