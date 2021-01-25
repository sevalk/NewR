using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class FinishCollider : MonoBehaviour
{
    [SerializeField] Transform Character;
    
    [SerializeField] Waypoint waypoint;

    [SerializeField] Player parent;

    [SerializeField] GameObject pivot;
    float speed = 10f;

    [SerializeField] Button playAgainButton;

    [SerializeField] GameObject finishParticles;

    private void Update()
    {
        pivot.transform.Rotate(0, speed * Time.deltaTime , 0);
    }

    private void OnCollisionEnter(Collision collision)
    {

        /*When player reach the finish cameras parents cahanges to pivot ,and the 
        * parent rotates continiusly so camera rotates around the player
        */
        Camera.main.transform.parent = pivot.transform;
        pivot.transform.position = Character.position + new Vector3(0, (float)parent.transform.childCount * 0.19f, 0);
        
        playAgainButton.gameObject.SetActive(true);

        waypoint.movementSpeed = 0f;

        Character.gameObject.GetComponent<Animation>().Play("Runtojumpspring");
        finishParticles.SetActive(true);
        
    }
}
