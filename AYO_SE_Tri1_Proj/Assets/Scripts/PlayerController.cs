using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private float speedNormal = 5.0f;
    private Vector2 input;
    private Rigidbody2D playerRb;
    private Animator playerAnimator;
    public bool gameOver;
    private bool hasEffect;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        hasEffect = false;

    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;
        playerAnimator.SetFloat("Horizontal", input.x);
        playerAnimator.SetFloat("Vertical", input.y);
        playerAnimator.SetFloat("Speed", input.sqrMagnitude);

    }

    private void FixedUpdate()
    {
        playerRb.linearVelocity = input * speed;
        Debug.Log(playerRb.linearVelocity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasEffect) {return;}

        if (other.gameObject.CompareTag("AppleDebuff"))
        {
            Destroy(other.gameObject);
            hasEffect = true;
            speed = 3.0f;
            StartCoroutine(EffectCooldown());
        }

        if (other.gameObject.CompareTag("LemonBuff"))
        {
            Destroy(other.gameObject);
            hasEffect = true;
            speed = 7.0f;
            StartCoroutine(EffectCooldown());
        }


    }

   IEnumerator EffectCooldown()
    {
        yield return new WaitForSeconds(7);
        hasEffect = false;
        speed = speedNormal;
    }
}
