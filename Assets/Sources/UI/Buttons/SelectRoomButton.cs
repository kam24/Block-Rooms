using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SelectRoomButton : MonoBehaviour
{
    private Button button;
    private int roomNumber;

    private void Start()
    {
        button = GetComponent<Button>();
        string buttonText = button.GetComponentInChildren<Text>().text;
        roomNumber = Int32.Parse(buttonText);
        button.onClick.AddListener(SelectRoom);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(SelectRoom);
    }

    private void SelectRoom()
    {
        RoomLoader.LoadRoom(roomNumber);
    }
}
