using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
    public bool canMove = true;

    [Header("Audio Settings")]
    public AudioSource footstepSource; // Assign an AudioSource with a looping footstep clip

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;

        // Handle footstep audio logic
        HandleFootstepAudio();
    }

    private void HandleFootstepAudio()
    {
        if (footstepSource == null) return;

        // If we are moving and allowed to move, play audio
        if (moveInput.magnitude > 0.1f && canMove)
        {
            if (!footstepSource.isPlaying)
            {
                footstepSource.Play();
            }
        }
        else
        {
            // Stop audio if we stop moving
            if (footstepSource.isPlaying)
            {
                footstepSource.Stop();
            }
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (!canMove)
        {
            moveInput = Vector2.zero; // Stop movement input if canMove is false
            return;
        }

        animator.SetBool("isWalking", true);

        if (context.canceled)
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
        }

        moveInput = context.ReadValue<Vector2>();
        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);
    }
}