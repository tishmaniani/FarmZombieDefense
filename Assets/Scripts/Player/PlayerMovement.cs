 using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    Rigidbody rb;
    private Vector3 moveDirection;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX 
                       | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float verctical = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(horizontal, 0f, verctical).normalized;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);

        if(moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, 10f * Time.fixedDeltaTime);
        }
    }
}
