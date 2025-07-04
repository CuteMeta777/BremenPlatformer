using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float speed;
    private float pitch;

    [SerializeField] private Transform chicken;

    private void Awake()
    {
        InitFields();
    }

    private void InitFields()
    {
        speed = 100f;
        pitch = 0f;
    }

    private void Start()
    {
        // 마우스 커서 숨기기 & 고정하기
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float dx = 0;
        float dy = 0;

        if (Input.GetKey(KeyCode.UpArrow))    { dx -= 1f; }
        if (Input.GetKey(KeyCode.DownArrow))  { dx += 1f; }
        if (Input.GetKey(KeyCode.RightArrow)) { dy += 1f; }
        if (Input.GetKey(KeyCode.LeftArrow))  { dy -= 1f; }

        dx *= (speed * Time.deltaTime);
        dy *= (speed * Time.deltaTime);

        pitch += dx;
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        // Pitch
        transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);

        // Yaw
        chicken.Rotate(Vector3.up * dy);
    }
}