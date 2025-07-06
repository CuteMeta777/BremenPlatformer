using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float mouse_sensitivity;

    [SerializeField] private Transform player_transform;

    private float xRotation = 0f;

    private void Awake()
    {
        InitFields();
    }

    private void InitFields()
    {
        mouse_sensitivity = 300f;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouse_sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouse_sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Pitch
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Yaw
        player_transform.Rotate(Vector3.up * mouseX);
    }
}