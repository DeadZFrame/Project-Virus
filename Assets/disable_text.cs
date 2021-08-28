using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class disable_text : MonoBehaviour
{
    public void disable()
    {
        TextMeshProUGUI txt = gameObject.GetComponent<TextMeshProUGUI>();
        txt.enabled = false;
    }
}
