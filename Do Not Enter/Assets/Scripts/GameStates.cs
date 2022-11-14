using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStates : MonoBehaviour
{
    //game states
    private string[] states;
    private int currIndex = 0;

    //dialog manager
    private Dialog dl;

    // parallel arrays of interactables
    public GameObject[] inter;
    public string[] desc;

    // Start is called before the first frame update
    void Start()
    {
        dl = GetComponent<Dialog>();
    }

    public void ChangeState()
    {
        if(currIndex < states.Length) //to avoid errors and stuff
        {
            currIndex += 1;
            dl.SetText(desc[currIndex]);
        }
    }

    void Update()
    {
        //if player looking at current interactable from a certain distance, make disp box active
        //if looking at it and clicks change state

        /*
            check if at relevant state
            gs.ChangeState(this.gameObject);
            //make disp show up on textbox
            //call relevant script
            //call animation maybe, or timing thingy
            //change state and remove this script I guess
         */

    }


}
