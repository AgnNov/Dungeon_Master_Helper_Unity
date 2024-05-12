using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{

    public class InputsManager : MonoBehaviour
    {

        public void ResetInputText(TMP_InputField input)
        {
            input.text = "";
        }
    }
}
