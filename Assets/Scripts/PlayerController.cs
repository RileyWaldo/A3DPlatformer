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

        Vector3 camForward = Camera.main.transform.forward.normalized;
        Vector3 camRight = Camera.main.transform.right.normalized;
        camForward.y = 0f;
        camRight.y = 0f;
        camRight *= xThrow * moveSpeed;
        camForward *= yThrow * moveSpeed;

        Vector3 moveDirection = controller.velocity;

        moveDirection += Physics.gravity * gravityFactor;
        moveDirection += camForward;
        moveDirection += camRight;

        if(jumpPressed)
        {
            moveDirection.y = jumpForce;
        }

        controller.Move(moveDirection * Time.deltaTime);
    }
}
