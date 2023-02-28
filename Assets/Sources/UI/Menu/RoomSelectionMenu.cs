using UnityEngine;
using UnityEngine.UI;

public class RoomSelectionMenu : MonoBehaviour
{
    [SerializeField] private GameObject buttonsGrid;
    [SerializeField] private MainMenu mainMenu;

    private void Awake()
    {
        var buttons = buttonsGrid.GetComponentsInChildren<Button>();
        var buttonTexts = buttonsGrid.GetComponentsInChildren<Text>();
        int levelNumber = 1;
        foreach (var button in buttons)
        {
            button.onClick.AddListener(mainMenu.Hide);
            button.GetComponentInChildren<Text>().text = levelNumber.ToString();
            levelNumber++;
        }
    }
}
