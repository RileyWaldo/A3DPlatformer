using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] Transform model = default;

    Vector3 startPos;
    private float direction = 0f;

    private void Start()
    {
        startPos = model.position;
    }

    private void Update()
    {
        direction += Time.deltaTime;
        if(direction > 360f)
        {
            direction -= 360f;
        }

        model.position = startPos + (Vector3.up * Mathf.Sin(direction) * 0.25f);
        model.rotation = Quaternion.AngleAxis(direction, Vector3.up);
    }
}
