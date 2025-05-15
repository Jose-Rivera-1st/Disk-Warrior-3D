using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string horizontalInput = "Horizontal";
    public string verticalInput = "Vertical";
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode shootKey = KeyCode.Mouse0;
    public Transform muzzle;
    public GameObject bulletPrefab;
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float shootForce = 500f;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        float h = Input.GetAxisRaw(horizontalInput);
        float v = Input.GetAxisRaw(verticalInput);

        Vector3 move = new Vector3(h, 0, v) * moveSpeed;
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);

        // Jump
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Shoot
        if (Input.GetKeyDown(shootKey) && muzzle != null && bulletPrefab != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.AddForce(muzzle.forward * shootForce);
            Destroy(bullet, 3f);
        }
        
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }
}
