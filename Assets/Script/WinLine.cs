using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WinLine : MonoBehaviour
{
    [SerializeField] Waypoint waypoint;
    
    private void OnCollisionEnter(Collision collision)
    {
        waypoint.isFinished = true;
        
    }
}
