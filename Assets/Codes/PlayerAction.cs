using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private PlayerInput pi;
    private Rigidbody rb;

    private float move_speed;
    private float move_damp;
    private float jump_force;

    [SerializeField] private Transform chicken;

    private void Awake()
    {
        GetReferences();
        InitFields();
    }

    private void GetReferences()
    {
        pi = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
    }

    private void InitFields()
    {
        move_speed = 150f;
        move_damp = 0.75f;
        jump_force = 500f;
    }

    private void FixedUpdate()
    {
        Move();
        // if (pi.do_jump) Jump();
    }

    private void Update()
    {
        if (pi.do_jump) Jump();
    }

    private void Move()
    {
        Vector3 move_dir = (chicken.right * pi.move_x + chicken.forward * pi.move_z).normalized;
        rb.linearVelocity += (move_dir * move_speed * Time.fixedDeltaTime);
        rb.linearVelocity = new Vector3(rb.linearVelocity.x * move_damp, rb.linearVelocity.y, rb.linearVelocity.z * move_damp);
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jump_force);
    }
}