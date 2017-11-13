using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    
    private AudioSource audioSource;

    [SerializeField]
    private PolygonCollider2D coinCollider;

    [SerializeField]
    private SpriteRenderer coinSprite;

    public static int coinCount;

    // Use this for initialization
    void Start () {

        audioSource = GetComponent<AudioSource>();
        coinCollider = GetComponent<PolygonCollider2D>();
        coinSprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            coinCollider.enabled = false;
            coinSprite.enabled = false;
            coinCount++;
            Destroy(gameObject);

        }
    }
}
