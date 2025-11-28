using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector2 input;
    private Rigidbody2D playerRb;
    private Animator playerAnimator;
    public bool gameOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

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
}
