using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : NetworkBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public override void OnNetworkSpawn()
    {
        if (!IsOwner)
        {
            enabled = false; // 내 로컬 플레이어만 조작 가능
        }
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        // 바닥 체크
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
