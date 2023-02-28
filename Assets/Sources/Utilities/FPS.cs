using UnityEngine;

public class FPS : MonoBehaviour
{
    [SerializeField] private int value = -1;

    private void Start()
    {
#if PLATFORM_ANDROID
        Application.targetFrameRate = 120;
#else
        Application.targetFrameRate = value;
#endif
    }

}