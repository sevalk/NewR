using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Camera follows the player
public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private Vector3 _offset;

    void Start()
    {
        _offset = _target.position - transform.position;
    }


    void LateUpdate()
    {
       
        transform.position = _target.position - _offset;
       
        transform.LookAt(_target);

    }

}
