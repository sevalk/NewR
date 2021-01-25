using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstcile : MonoBehaviour
{
    [SerializeField] GameObject dropList;
    [SerializeField] Transform parent;
    float _unitHeight = 0.29f;

    [SerializeField] Transform Character;

    [SerializeField] AudioClip drop;

    private void OnCollisionEnter(Collision collision)
    {
      
        if (collision.gameObject.tag == "collected")
        {
           
            collision.transform.parent = dropList.transform;//
            StartCoroutine(SetHigh());
        }

        
    }


    //Sets the height of each cube collected and the character
    IEnumerator SetHigh()
    {
        AudioSource.PlayClipAtPoint(drop, Camera.main.transform.position);
        yield return new WaitForSeconds(0.65f);
    
        foreach (Transform child in parent)
        {
            child.position = new Vector3(child.position.x, child.position.y - _unitHeight, child.position.z);
        }
        if(parent.childCount > 0)
        {
            Character.position = new Vector3(Character.position.x, Character.position.y - _unitHeight, Character.position.z);
        }
       
     }
}
