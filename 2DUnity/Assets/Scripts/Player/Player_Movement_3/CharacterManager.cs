using UnityEngine;

public class CharacterManager : CharacterController2D
{
    [SerializeField] private float _moveSpeed = 40f;
    private float _horizontalMove = 0f;
    private bool _jump = false;

    private void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal") * _moveSpeed;

        if (Input.GetButtonDown("Jump"))
            _jump= true;
    }

    private void FixedUpdate()
    {
        Move(_horizontalMove * Time.deltaTime, false, _jump);
        ResetJump();
    }

    private void ResetJump()
    {
        _jump = false;
    }
}
