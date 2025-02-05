using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //message displayed to plater when looking at an interactable
    public string promptMessage;

    //this function will be called from our player
    public void BaseInteract(){
        Interact();
    }
    
    protected virtual void Interact()
    {
        //no code will be written in this function
        //this is a template function to be overridden by our subclasses
    }
}
