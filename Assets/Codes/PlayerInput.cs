using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float move_x { get; private set; }
    public float move_z { get; private set; }
    public bool do_jump { get; private set; }

    private void Awake()
    {
        InitFields();
    }

    private void InitFields()
    {
        move_x = 0;
        move_z = 0;
        do_jump = false;
    }

    private void Update()
    {
        // if (GameManager.game_over) { InitFields(); return; }

        float dx = 0;
        float dz = 0;

        if (Input.GetKey(KeyCode.D)) { dx += 1f; }
        if (Input.GetKey(KeyCode.A)) { dx -= 1f; }
        if (Input.GetKey(KeyCode.W)) { dz += 1f; }
        if (Input.GetKey(KeyCode.S)) { dz -= 1f; }

        move_x = dx;
        move_z = dz;

        do_jump = Input.GetKeyDown(KeyCode.Space);
    }
}