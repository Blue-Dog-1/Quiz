using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using DG.Tweening;


public class Cell : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private string _nameCard;
    [SerializeField] bool _isTrue;
    [SerializeField] UnityEvent _OnRightClick;
    [SerializeField] UnityEvent _OnWroneClick;

    public CardData card { get; private set; }
    public bool isTrue { get => _isTrue; set => _isTrue = value; }

    private Sequence sequence;

    public void Start()
    {
    }
    
    public void SetCard(CardData card)
    {
        _image.sprite = card._sprite;
        _nameCard = card.name;
        this.card = card;
    }
    public void SetAction(UnityAction WinAction, UnityAction loseAction)
    {
        _OnRightClick.AddListener(WinAction);
        _OnWroneClick.AddListener(loseAction);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_isTrue)
            OnRightClick();
        else
            OnWroneClick();
    }
    void OnRightClick()
    {
        Debug.Log("this cell is RIGHT");
        sequence = DOTween.Sequence();
        sequence.Append(_image.transform.DOScale(1.5f, 0.05f).SetEase(Ease.Linear));
        sequence.Append(_image.transform.DOScale(1f, 2f).SetEase(Ease.OutBounce));

        sequence.AppendCallback(() => _OnRightClick?.Invoke());

    }
    void OnWroneClick()
    {
        Debug.Log("this cell is WRONG");
        sequence = DOTween.Sequence();

        sequence.Append(_image.transform.DOLocalMoveX(-5f, 0.05f).SetEase(Ease.Linear));
        for (int i = 0; i < 3; i++)
        {
            sequence.Append(_image.transform.DOLocalMoveX(10f, 0.05f).SetEase(Ease.Linear));
            sequence.Append(_image.transform.DOLocalMoveX(-10f, 0.05f).SetEase(Ease.Linear));
        }
        sequence.Append(_image.transform.DOLocalMoveX(0f, 0.05f).SetEase(Ease.Linear));

        _OnWroneClick?.Invoke();

    }
}
