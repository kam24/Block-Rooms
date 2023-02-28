using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InRoomMenu : MonoBehaviour
{
    [SerializeField] private Button pauseBatton;
    [SerializeField] private Button reloadBatton;
    [SerializeField] private Text levelName;
    [SerializeField] private MainMenu pauseMenu;

    private void Awake()
    {
        pauseBatton.onClick.AddListener(OnPauseClicked);
        reloadBatton.onClick.AddListener(RoomLoader.ReloadRoom);
        SceneManager.sceneLoaded += SceneLoaded;
    }

    private void OnDestroy()
    {
        pauseBatton.onClick.RemoveListener(OnPauseClicked);
        reloadBatton.onClick.RemoveListener(RoomLoader.ReloadRoom);
    }

    private void SceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        levelName.text = RoomLoader.GetRoomNumber(RoomLoader.GetRoomName());
    }

    private void OnPauseClicked()
    {
        Root.Instance.PauseController.Pause();
        pauseMenu.gameObject.SetActive(true);
    }
}
