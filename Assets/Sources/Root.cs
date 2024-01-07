using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private PlayerPresenter _player;
    [SerializeField] private AttachmentGunPresenter _attachmentGun;
    [SerializeField] private bool _isPaused = false;

    public PauseController PauseController { get; private set; }

    public static Root Instance { get; private set; }

    private PlayerBallInputRouter _playerBallInputRouter;

    private void Awake()
    {
        if (_player == null)
        {
            _player = FindObjectOfType<PlayerPresenter>();
            _attachmentGun = _player.GetComponent<AttachmentGunPresenter>();
        }

        _playerBallInputRouter = new PlayerBallInputRouter(_player, _attachmentGun);

        PauseController = new();
        if (_isPaused)
            PauseController.Pause();

        Instance = this;
    }

    private void OnEnable()
    {
        _playerBallInputRouter.OnEnable();
    }

    private void OnDisable()
    {
        _playerBallInputRouter.OnDisable();
    }

    private void Update()
    {
        if (PauseController.IsPaused)
            return;

        _playerBallInputRouter.Update();
    }
}

