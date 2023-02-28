using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HintView : MonoBehaviour
{
    [SerializeField] private Text text;
    private Image image;

    public void SetText(string text)
    {
        this.text.text = text;
    }

    public void Show()
    {
        gameObject.SetActive(true);
        image.DOFade(1, 0.3f);
        text.DOFade(1, 0.3f);
    }

    public void Hide()
    {
        image.DOFade(0, 0.3f);
        text.DOFade(0, 0.3f);
    }

    public void HideAsPressed()
    {
        image.color = Color.blue;
        text.color = Color.white;
        transform.DOScale(1.5f, 0.3f);
        image.DOFade(0, 0.3f);
        text.DOFade(0, 0.3f);
    }

    private void Awake()
    {
        image = GetComponent<Image>();
        text.color = Color.black;
        gameObject.SetActive(false);
    }
}
