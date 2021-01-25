using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Scroll the hand image to left and right
public class Scroller : MonoBehaviour
{
    [SerializeField] Vector2 movementVector = new Vector2(10f, 10f);
    [SerializeField] float period = 2f;

    float movementFactor;
    Vector2 startingPos;
    
    void Start()
    {
        startingPos = transform.position;
    }

   
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }//protect against period is zero, Mathf.Epsilon = smallest value that ve can represrent
        float cycles = Time.time / period; // grows continually from 0

        const float tau = Mathf.PI * 2f; 
        float rawSinWave = Mathf.Sin(cycles * tau); 

        movementFactor = rawSinWave / 2f + 0.5f;
        Vector2 offset = movementFactor * movementVector;
        transform.position = startingPos + offset;
    }
}
