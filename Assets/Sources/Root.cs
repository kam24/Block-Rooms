using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private PlayerPresenter player;
    [SerializeField] private AttachmentGunPresenter attachmentGun;
    [SerializeField] private bool IsPaused = false;

    public PauseController PauseController { get; private set; }

    public static Root Instance { get; private set; }

    private PlayerBallInputRouter playerBallInputRouter;

    private void Awake()
    {
        playerBallInputRouter = new PlayerBallInputRouter(player, attachmentGun);

        PauseController = new();
        if (IsPaused)
            PauseController.Pause();

        Instance = this;
    }

    private void OnEnable()
    {
        playerBallInputRouter.OnEnable();
    }

    private void OnDisable()
    {
        playerBallInputRouter.OnDisable();
    }

    private void Update()
    {
        if (PauseController.IsPaused)
            return;

        playerBallInputRouter.Update();
    }
}

