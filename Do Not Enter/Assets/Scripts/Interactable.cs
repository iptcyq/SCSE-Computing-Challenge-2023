using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    //dialog manager
    public GameObject gc;
    private Dialog dl;
    private GameStates gs;
    public GameObject player;
    public GameObject setting;
    public bool active = false;
    public int[] index;
    public string[] desc;

    [HideInInspector]
    public int stateInd;
    private int i = 0;
    
    void Awake()
    {
        /*
        dl = gc.GetComponent<Dialog>();
        gs = gc.GetComponent<GameStates>();
        stateInd = index[0];
        */
    }
    void FixedUpdate()
    {
        if (!active && Input.GetMouseButtonDown(0)) { setting.SetActive(false); }
    }

    void OnMouseDown()
    {
        if (active)
        {
            player = GameObject.FindWithTag("Player");

            setting.SetActive(true);

        }
    }

    void OnMouseOver()
    {
        //display desc and show highlight
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 0, 250);
        active = true;
    }
    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 225, 255);
        active = false;
    }
}