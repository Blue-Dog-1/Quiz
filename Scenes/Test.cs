using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] Image rectangle;
    private Sequence sequence;

    [ContextMenu("Rstart")]
    void Start()
    {
        sequence = DOTween.Sequence();

        sequence.Append(rectangle.transform.DOLocalMoveX(500, 2).SetEase(Ease.OutBounce));

        sequence.AppendCallback(() => 
        {
            Debug.Log("Colbacl ----------------------------");
        
        });
    }
    
}
