using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] bool _FadeSart;
    [SerializeField] [Range (0f, 1f)] float value;
    [SerializeField] float _time = 1f;
    [SerializeField] UnityAction _EndFade;
    private Sequence sequence;

    public float time { get => _time; set => _time = value; }

    private void Start()
    {
        if (_FadeSart)
        {
            FadeColor(value, _time);
            FadeText(value, _time);
        }
    }
    public void FadeText(float value, float time)
    {
        var text = gameObject.GetComponent<TextMeshProUGUI>();
        if (!text) return;
        sequence = DOTween.Sequence();
        sequence.Append(text.DOFade(value, time).SetEase(Ease.OutQuart));
    }
    public void FadeColor(float value, TweenCallback posAction)
    {
        var image = gameObject.GetComponent<Image>();
        if (!image) return;
        sequence = DOTween.Sequence();
        sequence.Append(image.DOFade(value, 0.1f).SetEase(Ease.InQuad));

        sequence.AppendCallback(posAction);
    }
    public void FadeColor(float value)
    {
        FadeColor(value, time);
    }
    public void FadeColor(float value, float time)
    {
        var image = gameObject.GetComponent<Image>();
        if (!image) return;
        sequence = DOTween.Sequence();
        sequence.Append(image.DOFade(value, time).SetEase(Ease.InQuad));
        Debug.Log("FadeColor");
    }

}
