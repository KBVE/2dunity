using UnityEngine;

public class Player : PhysicsObject
{
    [SerializeField] private float _maxSpeed = 1;
    [SerializeField] private float _jumpForce = 10;

    private void Update()
    {
        if (grounded && Input.GetButtonDown("Jump"))
            velocity.y = _jumpForce;


        float horizontal = Input.GetAxis("Horizontal") * _maxSpeed;

        targetVelocity = new Vector2(horizontal, 0f);
    }
}
