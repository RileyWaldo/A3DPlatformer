using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float jumpForce = 10f;
    [Range(0f, 1f)]
    [SerializeField] float gravityFactor = 0.5f;

    CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");
        bool jumpPressed = Input.GetButtonDown("Jump");

        Vector3 moveDirection = new Vector3(xThrow * moveSpeed, controller.velocity.y, yThrow * moveSpeed);

        moveDirection += Physics.gravity * gravityFactor;

        if(jumpPressed)
        {
            moveDirection.y = jumpForce;
        }

        controller.Move(moveDirection * Time.deltaTime);
    }
}
