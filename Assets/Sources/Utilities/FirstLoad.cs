using UnityEngine;

public class FirstLoad : MonoBehaviour
{
    private void Awake()
    {
        RoomLoader.LoadRoom(1);
    }
}
