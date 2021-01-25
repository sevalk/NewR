using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [SerializeField] Transform Character;

    [SerializeField] AudioClip stack;

    [SerializeField] ParticleSystem _particleSystem;

    public int collectedDiamondCount;
    [SerializeField] public Text collectedDiamondCountText;
    private void OnCollisionEnter(Collision collision)
    {
        Stack(collision);
    }

    private void Stack(Collision collision)
    {
        if (collision.gameObject.tag == "cube")
        {
           
            float _heightToAdd = 0f;
            float _unitHeight = 0.29f;
            
            float playersChildCount = this.transform.childCount -1f ;
            
            if (!collision.transform.parent)
            {
                    
                collision.gameObject.tag = "collected";

                _heightToAdd = (_unitHeight + (playersChildCount * 0.31f));


                collision.transform.parent = this.gameObject.transform;
                Vector3 position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + _heightToAdd, this.gameObject.transform.position.z);
                collision.gameObject.transform.position = position;
                Character.position = position + new Vector3(0, _unitHeight, 0);
                collision.gameObject.transform.rotation = this.gameObject.transform.rotation;
                Debug.Log(playersChildCount + "**1");
            }
            else
            {
                AudioSource.PlayClipAtPoint(stack, Camera.main.transform.position);
                GameObject collectableCubesParent = collision.transform.parent.gameObject;


                //Adjusts the height of the collected cubes and the characters
                foreach (Transform child in collectableCubesParent.transform)
                {
                    child.gameObject.tag = "collected";
                    _heightToAdd += _unitHeight;

                    Vector3 position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + (_heightToAdd + (playersChildCount * 0.29f)), this.gameObject.transform.position.z);
                    child.position = position;


                    Character.position = position + new Vector3(0, _unitHeight, 0);
                    child.gameObject.transform.rotation = this.gameObject.transform.rotation;


                    ParticleSystem instParticleSystem = Instantiate(_particleSystem);
                    instParticleSystem .transform.position = position;
                    instParticleSystem .Play() ;
                    Destroy(instParticleSystem , 0.5f);
                }

               
                DestroyListParent(collectableCubesParent);

            }


        }
    }


    //Makes the parent of the collected cubes a player and destroys the empty parent
    private void DestroyListParent(GameObject collectableCubesParent)
    {
        int childcount;
        for (childcount = collectableCubesParent.transform.childCount; childcount > 0; childcount--)
        {
            collectableCubesParent.transform.GetChild(0).parent = this.gameObject.transform;
        }
        Destroy(collectableCubesParent);
    }
}
