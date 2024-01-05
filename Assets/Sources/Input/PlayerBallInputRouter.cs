using BlockRooms.Model;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBallInputRouter
{
    private PlayerBallInput input;
    private IMovable playerMovement;
    private IMovable playerMovement2;
    private AttachmentGunPresenter gun;

    public PlayerBallInputRouter(PlayerPresenter playerPresenter, AttachmentGunPresenter attachmentGun)
    {
        input = new PlayerBallInput();

        playerMovement = (IMovable)playerPresenter.Behavior;
        gun = attachmentGun;
    }

    public void OnEnable()
    {
        input.Enable();
        input.PlayerBall.Interaction.performed += OnInteractionPerfomed;
    }

    public void OnDisable()
    {
        input.Disable();
        input.PlayerBall.Interaction.performed -= OnInteractionPerfomed;
    }

    public void Update()
    {
        Vector2 inputVector = input.PlayerBall.Movement.ReadValue<Vector2>();
        Vector2 interactionVector = input.PlayerBall.DirectedInteraction.ReadValue<Vector2>();

        if (inputVector != Vector2.zero)
            playerMovement.TryStartPush(GetDirection(inputVector));

        if (interactionVector != Vector2.zero)
            gun.OnInteraction(GetDirection(interactionVector));
    }

    private void OnInteractionPerfomed(InputAction.CallbackContext obj)
    {
        gun.OnInteraction();
    }

    private Direction GetDirection(Vector2 vector)
    {
        float angleBetween = Vector2.SignedAngle(Vector2.one, vector);
        if (angleBetween < 0)
            angleBetween += 360;

        if (angleBetween >= 0 && angleBetween < 90)
            return Direction.Up;
        if (angleBetween >= 90 && angleBetween < 180)
            return Direction.Left;
        if (angleBetween >= 180 && angleBetween < 270)
            return Direction.Down;
        if (angleBetween >= 270 && angleBetween < 360)
            return Direction.Right;

        throw new ArgumentOutOfRangeException(nameof(vector));
    }
}
