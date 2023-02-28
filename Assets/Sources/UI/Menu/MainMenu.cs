using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button roomsButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button closeRoomSelectionMenu;
    [SerializeField] private RectTransform roomSelectionMenu;
    [SerializeField] private RectTransform buttons;
    [SerializeField] private CanvasScaler UICanvasScaler;

    private PauseController PauseController => Root.Instance.PauseController;
    private CanvasGroup canvasGroup;
    private float offset;
    private readonly float menuSlidingTime = 0.5f;
    private readonly float fadeTime = 0.2f;

    public void Open()
    {
        if (roomSelectionMenu.gameObject.activeInHierarchy == true)
            OnCloseRoomSelectionClicked();

        enabled = true;
    }

    public void Hide()
    {
        canvasGroup.DOFade(0, fadeTime).OnComplete(() =>
        {
            PauseController.Continue();
            gameObject.SetActive(false);
        });
    }

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        offset = canvasGroup.GetComponent<RectTransform>().rect.width;
        if (offset < UICanvasScaler.referenceResolution.x)
            offset = UICanvasScaler.referenceResolution.x;
        roomSelectionMenu.DOAnchorPosX(-offset, 0);

        playButton.onClick.AddListener(Hide);
        roomsButton.onClick.AddListener(OnRoomsClicked);
        exitButton.onClick.AddListener(OnExitClicked);
        closeRoomSelectionMenu.onClick.AddListener(OnCloseRoomSelectionClicked);
    }

    private void OnEnable()
    {
        if (canvasGroup.alpha == 1)
            canvasGroup.alpha = 0;
        canvasGroup.DOFade(1, fadeTime);
    }

    private void OnDestroy()
    {
        playButton.onClick.RemoveListener(Hide);
        roomsButton.onClick.RemoveListener(OnRoomsClicked);
        exitButton.onClick.RemoveListener(OnExitClicked);
        closeRoomSelectionMenu.onClick.RemoveListener(OnCloseRoomSelectionClicked);
    }

    private void OnRoomsClicked()
    {
        if (roomSelectionMenu.gameObject.activeInHierarchy == false)
            roomSelectionMenu.gameObject.SetActive(true);

        buttons.DOAnchorPosX(offset, menuSlidingTime).SetEase(Ease.OutQuart);
        roomSelectionMenu.DOAnchorPosX(0, menuSlidingTime).SetEase(Ease.OutQuart);
    }

    private void OnCloseRoomSelectionClicked()
    {
        buttons.DOAnchorPosX(0, menuSlidingTime).SetEase(Ease.OutQuart);
        roomSelectionMenu.DOAnchorPosX(-offset, menuSlidingTime).SetEase(Ease.OutQuart);
    }
    private void OnExitClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
