using BlockRooms.Model;
using UnityEngine;

public abstract class ExtensionPresenter : MonoBehaviour
{
    [SerializeField] protected bool isEnabled = true;

    public bool IsEnabled => isEnabled;

    public abstract void IncludeExtension(Unit unit);
}

