using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Placement : MonoBehaviour {

    public class Card { }

    [SerializeField] int m_MaxCardCount = 1;

    public List<Card> m_Cards;

    int count = 0;

    private void Start()
    {
        m_Cards = new List<Card>();
    }

    public bool GiveCard(Card card)
    {
        if (count < m_MaxCardCount)
        {
            count++;

            m_Cards.Add(card);
            return true;
        }
        return false;
    }

    public Card TakeFromTop()
    {
        if (count > 0)
        {

            m_Cards.Reverse();

            Card toReturn = m_Cards[0];

            m_Cards.RemoveAt(0);
            m_Cards.Reverse();
            count--;
            return toReturn;
        }

        return null;
    }

    public Card TakeAtIndex(int index)
    {
        if (index < count)
        {
            Card toReturn = m_Cards[index];

            m_Cards.RemoveAt(index);
            count--;
            return toReturn;
        }

        return null;
    }
}
