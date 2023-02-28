using System;
using UnityEngine.SceneManagement;

public class RoomLoader
{
    private static string scenePathPrefix = "Scenes/Rooms/";
    private static string scenePrefix = "r";

    public static void LoadRoom(int roomNumber)
    {
        SceneManager.LoadScene(scenePathPrefix + scenePrefix + roomNumber);
    }

    public static void ReloadRoom()
    {
        string thisRoom = GetRoomName();
        SceneManager.LoadScene(scenePathPrefix + thisRoom);
    }

    public static void LoadNextRoom()
    {
        string thisRoom = GetRoomName();
        int roomNumber = Int32.Parse(GetRoomNumber(thisRoom));
        int nextRoomNumber = roomNumber + 1;
        SceneManager.LoadScene(scenePathPrefix + scenePrefix + nextRoomNumber);
    }

    public static string GetRoomName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public static string GetRoomNumber(string roomName)
    {
        return roomName[scenePrefix.Length..];
    }
}
