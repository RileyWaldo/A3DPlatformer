using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform follow = default;
    [SerializeField] float mouseSensitivity = 1f;
    [SerializeField] float lookDistance = 5f;

    Vector2 lookRot = Vector2.zero;

    private void Start()
    {
        
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector2 addRot = new Vector2(mouseX, -mouseY);
        addRot *= mouseSensitivity * Time.deltaTime;

        lookRot += addRot;
    }

    private void LateUpdate()
    {
        transform.position = follow.position;
        transform.rotation = Quaternion.Euler(lookRot.y, lookRot.x, 0f);
    }
}
