using UnityEngine;
public class SixDOFCamera : MonoBehaviour
{
    public float speed = 1.0f;
    public float fastSpeed = 2.0f;
    public float mouseSpeed = 4.0f;

    private Transform TR;

    private void OnEnable() { Cursor.lockState = CursorLockMode.Locked; }

    private void OnDisable() { Cursor.lockState = CursorLockMode.None; }

    private void Awake()
    {
        TR = transform;
    }

    private void Update()
    {
        // Pitch/Yaw
        TR.Rotate(-Vector3.right * (Input.GetAxis("Mouse Y") * 1200) * Time.deltaTime);
        TR.Rotate(Vector3.up * (Input.GetAxis("Mouse X") * 1200) * Time.deltaTime);
        
        // Roll
        if (Input.GetKey(KeyCode.Q))
            TR.Rotate(Vector3.forward * 120 * Time.deltaTime);
        if (Input.GetKey(KeyCode.E))
            TR.Rotate(Vector3.forward * -120 * Time.deltaTime);

        float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? fastSpeed : speed;
        
        // Up/Down
        if (Input.GetKey(KeyCode.Space))
            TR.position += moveSpeed * TR.up;
        if (Input.GetKey(KeyCode.LeftAlt))
            TR.position += moveSpeed * -TR.up;

        // Left/Right, Forward/Back
        TR.position +=
            Input.GetAxis("Horizontal") * moveSpeed * TR.right +
            Input.GetAxis("Vertical") * moveSpeed * TR.forward;
    }
}