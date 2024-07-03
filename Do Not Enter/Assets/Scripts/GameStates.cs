using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStates : MonoBehaviour
{
    //game states
    public string[] states;
    private int currIndex = 0;

    //dialog manager
    private Dialog dl;

    // parallel arrays of interactables
    public GameObject[] inter;

    // Start is called before the first frame update
    void Start()
    {
        dl = GetComponent<Dialog>();

        currIndex = 0;
        ActivateObjects();
    }

    public void ChangeState()
    {
        if(currIndex < states.Length) //to avoid errors and stuff
        {
            currIndex += 1;
        }
    }

    void ActivateObjects()
    {
        //set objects active/ not active
        for (int i = 0; i < inter.Length; i++)
        {
            if (inter[i].GetComponent<Interactable>().stateInd == currIndex)
            {
                inter[i].active = true;
            }
            else
            {
                inter[i].active = false;
            }
        }
    }

    bool ConfirmStateChange()
    {
        for(int i = 0; i < inter.Length; i++)
        {
            if (inter[i].GetComponent<Interactable>().stateInd == currIndex)
            {
                if(inter[i].active == true) //not interacted with yet
                {
                    return false;
                }
            }
        }
        return true;

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
