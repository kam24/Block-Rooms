using BlockRooms.Model;
using UnityEngine;

[RequireComponent(typeof(PlayerBallPresenter))]
public class AttachmentGunPresenter : MonoBehaviour
{
    private AttachmentGun gun;
    private IMovable playerMovement;

    public void OnInteraction()
    {
        if (gun.Attached)
            gun.Reset();
        else
            TrySetSingleAttachableBlock();
    }

    public void OnInteraction(Direction direction)
    {
        bool attached = TrySetAttachableBlock(direction);
        if (attached == false)
            gun.Reset();
    }

    public void OnGoingToMove(Direction direction)
    {
        gun.TryPushBlock(direction);
    }

    private void OnEnable()
    {
        TransformableCell model = GetComponent<PlayerBallPresenter>().Model;
        playerMovement = (IMovable)model.Behavior;
        playerMovement.GoingToMove += OnGoingToMove;
        gun = new AttachmentGun(model);
    }

    private void OnDisable()
    {
        playerMovement.GoingToMove -= OnGoingToMove;
    }

    private void Update()
    {
        gun.Update(Time.deltaTime);
    }

    private void TrySetSingleAttachableBlock()
    {
        TransformableCell attachableBlock = null;
        Direction blockDirection = null;

        foreach (var direction in Direction.Directions)
        {
            TransformableCell foundBlock = FindAttachableBlock(direction);

            if (foundBlock != null && attachableBlock != null)
            {
                return;
            }
            else if (foundBlock != null)
            {
                attachableBlock = foundBlock;
                blockDirection = direction;
            }
        }

        if (attachableBlock != null)
            gun.Set(attachableBlock, blockDirection);
    }

    private bool TrySetAttachableBlock(Direction direction)
    {
        TransformableCell foundBlock = FindAttachableBlock(direction);
        if (foundBlock != null)
        {
            gun.Set(foundBlock, direction);
            return true;
        }
        else
        {
            return false;
        }
    }

    private TransformableCell FindAttachableBlock(Direction direction)
    {
        Vector2 nextPosition = (Vector2)gun.Position + direction.Position;

        bool foundAttachableBlock = CellFinder.TryGetTopCell(nextPosition, out CellPresenter presenter)
            && gun.CanBeAttached(presenter.Model, direction);

        return foundAttachableBlock ? presenter.Model : null;
    }
}

