using UnityEngine;
using UnityEngine.InputSystem;

public class Player : PhysicsObject
{
    [SerializeField] private float _maxSpeed = 8;
    [SerializeField] private float _jumpSpeedMultiplier = 0.75f;
    [SerializeField] private float _jumpForce = 12;

    [SerializeField] private TMPro.TextMeshProUGUI _coinsCollectedText;

    private Vector2 _movement;

    private int _coinsCollected;

    private void Update()
    {
        if(grounded)
            targetVelocity = _movement * _maxSpeed;
        else
            targetVelocity = _movement * _maxSpeed * _jumpSpeedMultiplier;
    }

    public void CollectCoin()
    {
        _coinsCollected++;
        _coinsCollectedText.text = " x " + _coinsCollected.ToString();
    }

    #region New Input System
    public void OnMove(InputValue value) => _movement = value.Get<Vector2>();
    public void OnJump(InputValue value)
    {
        if (grounded)
            velocity.y = _jumpForce;
    }
    #endregion
}
