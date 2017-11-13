using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    
    public static Checkpoint currentCheck;

    [SerializeField]
    private float activeScale = 1.5f, deactivatedScale = 1;

    [SerializeField]
    private Color activeColor, deactiveColor;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        DeactiveCheck();
    }

    private void DeactiveCheck()
    {
        transform.localScale = Vector3.one * (deactivatedScale);
        spriteRenderer.color = deactiveColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="Player")
        {
            bool touchNewCheck = currentCheck != this;

            if (touchNewCheck)
            {
                if (currentCheck != null)
                {
                    currentCheck.DeactiveCheck();
                }
                ActivatedCheck();
                
            }

        }
       
    }

    private void ActivatedCheck()
    {
        currentCheck = this;
        transform.localScale = Vector3.one * (activeScale);
        spriteRenderer.color = activeColor;
    }
}
