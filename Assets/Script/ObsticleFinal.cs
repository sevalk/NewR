using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Same with Obsticle.cs but this script not changes the cube's and character's high
public class ObsticleFinal : MonoBehaviour
{
    [SerializeField] GameObject dropList; // When the player hits the obstacle, the cubes separated from the theirs parent become the child of this object.
    [SerializeField] Transform parent;//The collected cubes become the child of this object
    float _unitHeight = 0.29f;

    [SerializeField] AudioClip drop;

   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "collected")
        {
            collision.transform.parent = dropList.transform;
            AudioSource.PlayClipAtPoint(drop, Camera.main.transform.position);
        }
    }

}
