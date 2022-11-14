using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisp;
    public GameObject displayBox;
    public bool active = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        displayBox.SetActive(active);
    }

    public void SetText(string text) { textDisp.text = text; }

}
