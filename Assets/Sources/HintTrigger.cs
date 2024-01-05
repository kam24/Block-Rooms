using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class HintTrigger : MonoBehaviour
{
    [SerializeField] private HintView _hintView;
    [SerializeField] private KeyCode _key;

    private bool _trackPressedKey = false;

    private void Awake()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        if (_key.ToString().Length == 1)
            _hintView.SetText($"[{_key}]");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerPresenter>(out _))
        {
            _hintView.Show();
            _trackPressedKey = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _hintView.Hide();
        _trackPressedKey = false;
    }

    private void Update()
    {
        if (_trackPressedKey && Input.GetKeyDown(_key))
        {
            _hintView.HideAsPressed();
            gameObject.SetActive(false);
        }
    }
}
