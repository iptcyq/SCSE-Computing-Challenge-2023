using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    void OnMouseDown()
    {
        GameObject p = GameObject.FindWithTag("Player");
        
        if ((transform.position - p.transform.position).magnitude < 5f)
        {
            Debug.Log("clicked");
            Destroy(this.gameObject);
        }
    }
}
