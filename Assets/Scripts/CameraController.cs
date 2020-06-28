using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform follow = default;
    [SerializeField] float mouseSensitivity = 1f;
    [SerializeField] float lookDistance = 5f;
    [SerializeField] Vector2 yClamp = new Vector2(-5f, 90f);

    Vector2 lookRot = Vector2.zero;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
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
        transform.rotation = Quaternion.Euler(Mathf.Clamp(lookRot.y, yClamp.x, yClamp.y), lookRot.x, 0f);

        RaycastHit hit;
        if(Physics.Raycast(follow.position, -Camera.main.transform.forward, out hit, Mathf.Abs(Camera.main.transform.position.z)))
        {
            transform.position = hit.point;
        }
    }
}
