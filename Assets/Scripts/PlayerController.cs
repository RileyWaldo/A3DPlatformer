using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float jumpForce = 10f;
    [Range(0f, 1f)]
    [SerializeField] float gravityFactor = 0.5f;
    [SerializeField] Transform body = default;

    CharacterController controller;
    Animator animator;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");
        bool jumpPressed = Input.GetButtonDown("Jump");

        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;
        camForward.y = 0f;
        camRight.y = 0f;
        camRight *= xThrow * moveSpeed;
        camForward *= yThrow * moveSpeed;

        Vector3 moveDirection = camForward + camRight;

        moveDirection += Physics.gravity * gravityFactor;

        if(jumpPressed)
        {
            moveDirection.y += jumpForce;
        }

        if(moveDirection.magnitude > 0.5f)
        {
            animator.SetBool("isWalking", true);
            body.localRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        controller.Move(moveDirection * Time.deltaTime);
    }
}
