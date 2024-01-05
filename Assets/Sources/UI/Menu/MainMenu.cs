using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _roomsButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _closeRoomSelectionMenu;
    [SerializeField] private RectTransform _roomSelectionMenu;
    [SerializeField] private RectTransform _buttons;
    [SerializeField] private CanvasScaler _uICanvasScaler;

    private PauseController PauseController => Root.Instance.PauseController;
    private CanvasGroup _canvasGroup;
    private float _offset;
    private readonly float _menuSlidingTime = 0.5f;
    private readonly float _fadeTime = 0.2f;

    public void Open()
    {
        if (_roomSelectionMenu.gameObject.activeInHierarchy == true)
            OnCloseRoomSelectionClicked();

        enabled = true;
    }

    public void Hide()
    {
        _canvasGroup.DOFade(0, _fadeTime).OnComplete(() =>
        {
            PauseController.Continue();
            gameObject.SetActive(false);
        });
    }

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _offset = _canvasGroup.GetComponent<RectTransform>().rect.width;
        if (_offset < _uICanvasScaler.referenceResolution.x)
            _offset = _uICanvasScaler.referenceResolution.x;
        _roomSelectionMenu.DOAnchorPosX(-_offset, 0);

        _playButton.onClick.AddListener(Hide);
        _roomsButton.onClick.AddListener(OnRoomsClicked);
        _exitButton.onClick.AddListener(OnExitClicked);
        _closeRoomSelectionMenu.onClick.AddListener(OnCloseRoomSelectionClicked);
    }

    private void OnEnable()
    {
        if (_canvasGroup.alpha == 1)
            _canvasGroup.alpha = 0;
        _canvasGroup.DOFade(1, _fadeTime);
    }

    private void OnDestroy()
    {
        _playButton.onClick.RemoveListener(Hide);
        _roomsButton.onClick.RemoveListener(OnRoomsClicked);
        _exitButton.onClick.RemoveListener(OnExitClicked);
        _closeRoomSelectionMenu.onClick.RemoveListener(OnCloseRoomSelectionClicked);
    }

    private void OnRoomsClicked()
    {
        if (_roomSelectionMenu.gameObject.activeInHierarchy == false)
            _roomSelectionMenu.gameObject.SetActive(true);

        _buttons.DOAnchorPosX(_offset, _menuSlidingTime).SetEase(Ease.OutQuart);
        _roomSelectionMenu.DOAnchorPosX(0, _menuSlidingTime).SetEase(Ease.OutQuart);
    }

    private void OnCloseRoomSelectionClicked()
    {
        _buttons.DOAnchorPosX(0, _menuSlidingTime).SetEase(Ease.OutQuart);
        _roomSelectionMenu.DOAnchorPosX(-_offset, _menuSlidingTime).SetEase(Ease.OutQuart);
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
