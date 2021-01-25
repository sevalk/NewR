#define KEYBOARD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] Waypoint player;
    [SerializeField] Image hand;
    [SerializeField] Image arrow;
    [SerializeField] Image arrow1;
    
    private void Awake()
    {
        player.movementSpeed = 0f;
    }
    
    
    void Update()
    {
#if KEYBOARD
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            player.movementSpeed = 1f;
            Destroy(hand);
            Destroy(arrow);
            Destroy(arrow1);
        }
#else
        if (Input.touchCount > 0)
        {
            player.movementSpeed = 1f;
            Destroy(hand);
            Destroy(arrow);
            Destroy(arrow1);
        }
#endif
    }


}
