using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Panels
{

    public class InputsManager : MonoBehaviour
    {
        private TMP_InputField m_InputValue;

        public void ResetInputText(TMP_InputField input)
        {
            input.text = "";
        }
        public void DisableButtonOnEmptyInput(Button button)
        {
            button.interactable = false;
        }

    }
}
