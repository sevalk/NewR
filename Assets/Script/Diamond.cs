using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Diamond : MonoBehaviour
{
    [SerializeField] AudioClip diamondCollect;
    [SerializeField] Player player;
    [SerializeField] ParticleSystem _particleSystem;
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "collected")
        {
            player.collectedDiamondCount++;
            player.collectedDiamondCountText.text = player.collectedDiamondCount.ToString();

            AudioSource.PlayClipAtPoint(diamondCollect, Camera.main.transform.position);

            Destroy(this.gameObject);


            ParticleSystem instParticleSystem = Instantiate(_particleSystem);
            instParticleSystem.transform.position = this.transform.position;
            instParticleSystem.Play();
            Destroy(instParticleSystem, 0.5f);
        }
    }
}
