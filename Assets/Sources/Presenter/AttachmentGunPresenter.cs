using BlockRooms.Model;
using UnityEngine;

[RequireComponent(typeof(PlayerPresenter))]
public class AttachmentGunPresenter : MonoBehaviour
{
    private AttachmentGun _gun;
    private IMovable _playerMovement;

    public void OnInteraction()
    {
        if (_gun.Attached)
            _gun.ResetIfAttached();
        else
            TrySetSingleAttachableBlock();
    }

    public void OnInteraction(Direction direction)
    {
        bool attached = TrySetAttachableBlock(direction);
        if (attached == false)
            _gun.ResetIfAttached();
    }

    public void OnGoingToMove(Direction direction)
    {
        _gun.TryPushBlock(direction);
    }

    private void OnEnable()
    {
        Unit model = GetComponent<PlayerPresenter>().Model;
        _playerMovement = (IMovable)model.Behavior;
        _playerMovement.GoingToMove += OnGoingToMove;
        _gun = new AttachmentGun(model);
    }

    private void OnDisable()
    {
        _playerMovement.GoingToMove -= OnGoingToMove;
    }

    private void Update()
    {
        _gun.Update(Time.deltaTime);
    }

    private void TrySetSingleAttachableBlock()
    {
        Unit attachableBlock = null;
        Direction blockDirection = default;

        foreach (Direction direction in Direction.Directions)
        {
            Unit foundBlock = FindAttachableBlock(direction);
            bool foundAttachableBlock = foundBlock != null && attachableBlock != null;

            if (foundAttachableBlock)
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
            _gun.Set(attachableBlock, blockDirection);
    }

    private bool TrySetAttachableBlock(Direction direction)
    {
        Unit foundBlock = FindAttachableBlock(direction);
        if (foundBlock != null)
        {
            _gun.Set(foundBlock, direction);
            return true;
        }
        else
        {
            return false;
        }
    }

    private Unit FindAttachableBlock(Direction direction)
    {
        Vector2 nextPosition = _gun.Position + direction.Position;

        bool foundAttachableBlock = UnitFinder.TryGetTopUnit(nextPosition, out UnitPresenter presenter)
            && _gun.CanBeAttached(presenter.Model, direction);

        return foundAttachableBlock ? presenter.Model : null;
    }
}

