using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;


public class TaskGenerator : MonoBehaviour
{
    [SerializeField] CardBundleData _cardBundleData;
    [SerializeField] TextMeshProUGUI TaskLable;
    [SerializeField] Table _table;
    [SerializeField] Cell _cell;

    //cards that were already in the tasks for the player
    [SerializeField] List<CardData> _oldCarts = new List<CardData>();
    //cards that are already used in cells
    [SerializeField] List<CardData> _cardUse = new List<CardData>();

    // card that the player needs to find
    [SerializeField] CardData _favoriteCard;

    public CardData GenerateNewTask(int level, UnityAction WinAction, UnityAction loseAction)
    {
        _favoriteCard = GetRadomCard(ref _oldCarts);
        List<Cell> cells = new List<Cell>();
        _cardUse = new List<CardData>();
        Debug.Log(level * 3);
        for (int i = 0; i < Mathf.Clamp(level * 3, 3, 9); i++)
        {
            var cell = Instantiate(_cell, _table.transform);
            cell.SetCard(GetRadomCard(ref _cardUse));
            cells.Add(cell);
            cell.SetAction(WinAction, loseAction);
        }
        foreach (var cell in cells)
        {
            if (cell.card == _favoriteCard)
            {
                cell.isTrue = true;
                return _favoriteCard;
            }
        }

        var randomCell = cells[Random.Range(0, cells.Count)];
        randomCell.SetCard(_favoriteCard);
        randomCell.isTrue = true;
        
        return _favoriteCard;
    }
    CardData GetRadomCard(ref List<CardData> cash)
    {
        var card = _cardBundleData.cardData[Random.Range(0, _cardBundleData.cardData.Length) ];
        foreach (var use in cash)
        {
            if( use == card)
            {
                return GetRadomCard(ref cash);
            }
        }
        cash.Add(card);
        return card;
    }

    public void ResetSessionData()
    {
        _oldCarts = new List<CardData>();
        _cardUse = new List<CardData>();
    }
    public void SetBundle(CardBundleData bundle)
    {
        _cardBundleData = bundle;
    }




}
