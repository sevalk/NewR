using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//When player reach the corner state changes
public class Corner : MonoBehaviour
{
    public State state;
    Movement movement;
  
    private void Start()
    {
        movement = FindObjectOfType<Movement>();
    }
    
    public enum State
    {
        Forward,
        Left
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "collected")
        {

           
            if (movement.corner.state.Equals(State.Forward))
            {
                StartCoroutine(ChangeStateToLeft());
            }
            if(movement.corner.state.Equals(State.Left))
            {
                StartCoroutine(ChangeStateToForward());

            }
        }
    }
    
    

    IEnumerator ChangeStateToLeft()
    {
        yield return new WaitForSeconds(1f);
        
        movement.corner.state = Corner.State.Left;

    }
    IEnumerator ChangeStateToForward()
    {
        yield return new WaitForSeconds(1f);
        
        movement.corner.state = Corner.State.Forward;

    }

}
