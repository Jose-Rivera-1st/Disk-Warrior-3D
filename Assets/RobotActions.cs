using UnityEngine;

public class RobotActions : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed = 3f;

    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode jumpKey = KeyCode.E;
    public KeyCode throwKey = KeyCode.F;

    void Update()
    {
        HandleMovement();
        HandleJump();
        HandleThrow();
    }

    void HandleMovement()
    {
        Vector3 move = Vector3.zero;

        if (Input.GetKey(moveLeft))
            move += Vector3.left;

        if (Input.GetKey(moveRight))
            move += Vector3.right;

        if (Input.GetKey(moveUp))
            move += Vector3.forward;

        if (Input.GetKey(moveDown))
            move += Vector3.back;

        bool isMoving = move != Vector3.zero;

        animator.SetBool("IsWalking", isMoving);

        if (isMoving)
        {
            transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
        }
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            animator.SetTrigger("Jump");
        }
    }

    void HandleThrow()
    {
        if (Input.GetKeyDown(throwKey))
        {
            animator.SetTrigger("Throw");
        }
    }
}
