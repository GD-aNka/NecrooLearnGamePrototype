using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float speed = 5f;
    public NPC_Manager npcManager;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float coyoteTime = 0.1f;
    [SerializeField] private float jumpBufferTime = 0.1f;
    [SerializeField] private bool isGrounded;
    private Rigidbody2D rgb;
    private Vector2 direction;
    private float coyoteCounter;
    private float jumpBufferCounter;

    void Awake()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        direction = new Vector2(inputManager.GetMovement().x, 0);

        if (inputManager.IsJumpPressed())
        {
            jumpBufferCounter = jumpBufferTime;
        }
    }

    private void FixedUpdate()
    {
        if (isGrounded)
            coyoteCounter = coyoteTime;
        else
            coyoteCounter -= Time.fixedDeltaTime;

        jumpBufferCounter -= Time.fixedDeltaTime;

        float velocityY = rgb.linearVelocity.y;

        if (jumpBufferCounter > 0f && coyoteCounter > 0f && rgb.linearVelocity.y <= 0.1f)
        {
            velocityY = jumpForce;
            jumpBufferCounter = 0f;
            coyoteCounter = 0f;
        }

        rgb.linearVelocity = new Vector2(direction.x * speed, velocityY);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ground")) return;

        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.7f)
            {
                isGrounded = true;
                return;
            }
        }

        if (collision.gameObject.CompareTag("NPC"))
        {

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}