using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Rotate Cylinder continuously
public class Cylinder : MonoBehaviour
{

    float speed = 4;
    void Update()
    {
      transform.Rotate(0, speed * Time.deltaTime , 0);
      foreach(Transform child in transform)
        {
            child.Rotate(0, -speed * Time.deltaTime, 0);
        }
    }
}
