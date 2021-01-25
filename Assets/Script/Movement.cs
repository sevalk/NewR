#define KEYBOARD 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] float speed;
    
    public Corner corner ;
    
    bool right;
    bool left;
    [SerializeField] float min = -1f;
    [SerializeField] float max = 1f;
    float speed_touch = 1f;
    [SerializeField] Waypoint waypoint;
    private void Start()
    {
        corner.state = Corner.State.Forward;
    }

    void Update()
    {
       
       if(corner.state.Equals(Corner.State.Forward) )
        {
            Move();
        }
        else if(corner.state.Equals(Corner.State.Left))
        {
            MoveLeft();
        }
       
    }

    private void GoForward()
    {
        var X = new Vector3(0, 0, speed);
        transform.position = transform.position + X;
       
    }

    private void GoLeft()
    {
        var X = new Vector3(speed, 0, 0);
        transform.position = transform.position + X;
        
    }
    private void Move()
    {
#if KEYBOARD
 
        var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        
        transform.position = Vector3.Lerp(transform.position, transform.position + move, 1f * Time.deltaTime);
       
#else

        if (Input.touchCount > 0)
        {
            Touch parmak = Input.GetTouch(0);

            Vector3 go_right = new Vector3(max,0, 0);
            Vector3 go_left = new Vector3(min,0 ,0);
            
            if (parmak.deltaPosition.x > 1.0f)
            {
                right = true;
                left = false;
            }

            if (parmak.deltaPosition.x < -1.0f)
            {
                right = false;
                left = true;
            }

            if (right == true)
            {
                transform.position = Vector3.Lerp(transform.position,transform.position + go_right, speed_touch * Time.deltaTime);
            }

            if (left == true)
            {
                transform.position = Vector3.Lerp(transform.position,transform.position+ go_left, speed_touch*Time.deltaTime);
            }
        }
#endif
        }
    private void MoveLeft()
    {
#if KEYBOARD
       
        var move = new Vector3(0, 0,- Input.GetAxis("Horizontal"));
        
        transform.position = Vector3.Lerp(transform.position, transform.position + move, 1f * Time.deltaTime);
#else

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 go_letf = new Vector3(0,0,-max);
            Vector3 go_right = new Vector3(0,0,-min);
            
            if (touch.deltaPosition.x > 1.0f)
            {
                right = true;
                left = false;
            }

            if (touch.deltaPosition.x < -1.0f)
            {
                right = false;
                left = true;
            }

            if (right == true)
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + go_letf, speed_touch * Time.deltaTime);
            }

            if (left == true)
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + go_right, speed_touch * Time.deltaTime);
            }
        }
#endif
    }

}

