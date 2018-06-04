using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Placement : MonoBehaviour {
    /// <summary>
    /// Card Class is temporary, please remove once an actually card class/object has been made
    /// </summary>

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

            card.transform.parent = gameObject.transform;
            card.transform.localPosition = Vector3.zero;
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

    public void Shuffle()
    {
        List<Card> newOrder = new List<Card>();

        while (m_Cards.Count > 0)
        {
            int spot = Random.Range(0, m_Cards.Count - 1);
            Card nextCard = m_Cards[spot];
            m_Cards.RemoveAt(spot);
            newOrder.Add(nextCard);
        }

        m_Cards = newOrder;
    }
}
