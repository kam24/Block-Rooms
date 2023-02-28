using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class HintTrigger : MonoBehaviour
{
    [SerializeField] private HintView hintView;
    [SerializeField] private KeyCode key;

    private bool trackPressedKey = false;

    private void Awake()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        if (key.ToString().Length == 1)
            hintView.SetText($"[{key}]");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerBallPresenter>(out _))
        {
            hintView.Show();
            trackPressedKey = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hintView.Hide();
        trackPressedKey = false;
    }

    private void Update()
    {
        if (trackPressedKey && Input.GetKeyDown(key))
        {
            hintView.HideAsPressed();
            gameObject.SetActive(false);
        }
    }
}
