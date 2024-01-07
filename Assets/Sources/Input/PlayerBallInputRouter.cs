using BlockRooms.Model;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBallInputRouter
{
    private PlayerBallInput _input;
    private IMovable _playerMovement;
    private AttachmentGunPresenter _gun;

    public PlayerBallInputRouter(PlayerPresenter playerPresenter, AttachmentGunPresenter attachmentGun)
    {
        _input = new PlayerBallInput();

        _playerMovement = (IMovable)playerPresenter.Behavior;
        _gun = attachmentGun;
    }

    public void OnEnable()
    {
        _input.Enable();
        _input.PlayerBall.Interaction.performed += OnInteractionPerfomed;
    }

    public void OnDisable()
    {
        _input.Disable();
        _input.PlayerBall.Interaction.performed -= OnInteractionPerfomed;
    }

    public void Update()
    {
        Vector2 inputVector = _input.PlayerBall.Movement.ReadValue<Vector2>();
        Vector2 interactionVector = _input.PlayerBall.DirectedInteraction.ReadValue<Vector2>();

        if (inputVector != Vector2.zero)
            _playerMovement.TryStartPush(GetDirection(inputVector));

        if (interactionVector != Vector2.zero)
            _gun.OnInteraction(GetDirection(interactionVector));
    }

    private void OnInteractionPerfomed(InputAction.CallbackContext obj)
    {
        _gun.OnInteraction();
    }

    private Direction GetDirection(Vector2 vector)
    {
        float angleBetween = Vector2.SignedAngle(Vector2.one, vector);
        if (angleBetween < 0)
            angleBetween += 360;

        return angleBetween switch
        {
            >= 0 and < 90 => Direction.Up,
            >= 90 and < 180 => Direction.Left,
            >= 180 and < 270 => Direction.Down,
            >= 270 and < 360 => Direction.Right,
            _ => throw new ArgumentOutOfRangeException(nameof(vector))
        };
    }
}
