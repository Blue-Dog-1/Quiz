using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardBundleData", menuName = "Projcet/CardBundleData")]
public class CardBundleData : ScriptableObject
{
    [SerializeField] CardData[] _cardData;
    public CardData[] cardData => _cardData;
}
[System.Serializable]
public struct CardData
{
    public string name;
    public Sprite _sprite;

    public static bool operator ==(CardData c1, CardData c2) => c1._sprite == c2._sprite;
    public static bool operator !=(CardData c1, CardData c2) => c1._sprite == c2._sprite;

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }
}



