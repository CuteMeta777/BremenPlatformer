using UnityEngine;

public class PlayerAction_Donkey : MonoBehaviour
{
    private PlayerInput_Donkey pi;
    private Rigidbody rb;

    private float move_speed;
    private float move_damp;
    private float jump_force;

    private void Awake()
    {
        GetReferences();
        InitFields();
    }

    private void GetReferences()
    {
        pi = GetComponent<PlayerInput_Donkey>();
        rb = GetComponent<Rigidbody>();
    }

    private void InitFields()
    {
        move_speed = 100f;
        move_damp = 0.80f;
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
        Vector3 move_dir = (pi.move_x * transform.right + transform.forward * pi.move_z).normalized;
        rb.linearVelocity += (move_dir * move_speed * Time.fixedDeltaTime);
        rb.linearVelocity = new Vector3(rb.linearVelocity.x * move_damp, rb.linearVelocity.y, rb.linearVelocity.z * move_damp);
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jump_force);
    }
}