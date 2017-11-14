using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private BoxCollider2D pickupCollider;

    [SerializeField]
    private SpriteRenderer pickupSprite;



    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();

        pickupCollider = GetComponent<BoxCollider2D>();
        pickupSprite = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag =="Player")
        {
            audioSource.Play();
            pickupCollider.enabled = false;
            pickupSprite.enabled = false;

            float length = audioSource.clip.length + 0.2f;
            
            Destroy(gameObject, length);
        }
    }

}
