using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


[ExecuteAlways]
public class Table : MonoBehaviour
{
    [SerializeField] RectTransform rectTransform;
    [SerializeField] 
    float _cellSize = 100f;
    [SerializeField]
    float _cellSpacing = 25f;

    private Sequence sequence;

    void Start()
    {
    }
    public void OnEnable()
    {
        if (!rectTransform) rectTransform = GetComponent<RectTransform>();

        if (Application.isPlaying)
        {
            sequence = DOTween.Sequence();

            transform.localScale = Vector3.zero;

            sequence.Append(transform.DOScale(1, 2).SetEase(Ease.OutBounce));
        }
    }
    void Update()
    {
        int cellCout = transform.childCount;
        int cellCoutY = Mathf.FloorToInt(cellCout / 3);

        var height = (cellCoutY * _cellSize) + _cellSpacing * (cellCoutY + 1);

        rectTransform.sizeDelta = new Vector2(0, height);
    }

    public void Clear()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
