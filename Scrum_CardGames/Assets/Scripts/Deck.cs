//using SFB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
	public enum eDeckType { STANDARD, FULL, CUSTOM, }

	[SerializeField] GameObject m_cardBase = null;
	List<Card> m_cards;
	[SerializeField] Sprite[] m_cardImages;
	[SerializeField] int[] m_cardValues;
	[SerializeField] Sprite m_cardBack;

	public List<Card> Cards { get { return m_cards; } }

	public void Build(eDeckType type = eDeckType.STANDARD, List<int> included = null)
	{
		m_cards = new List<Card>();

		switch (type)
		{
			case eDeckType.STANDARD:
				for (int i = 0; i < m_cardValues.Length; i++)
				{
					GameObject go = Instantiate(m_cardBase, gameObject.transform);
					Card card = go.GetComponent<Card>();

					if (card)
					{
						card.Initialize((eValues)m_cardValues[i], m_cardImages[i], m_cardBack);

						m_cards.Add(card);
					}
				}
				break;
			case eDeckType.FULL:
				for (int i = 0; i < 52; i++)
				{
					GameObject go = Instantiate(m_cardBase);
					Card card = go.GetComponent<Card>();

					if (card)
					{
						card.Initialize((eValues)i, m_cardImages[i], m_cardBack);

						m_cards.Add(card);
					}
				}
				break;
			case eDeckType.CUSTOM:
				for(int i = 0;i<included.Count;i++)
				{
					GameObject go = Instantiate(m_cardBase);
					Card card = go.GetComponent<Card>();

					if (card)
					{
						card.Initialize((eValues)i, m_cardImages[i], m_cardBack);

						m_cards.Add(card);
					}
				}
				break;
		}

	}

	//SHuffle that does not alter the original
	public List<Card> Shuffle(List<Card> starting)
	{
		if (starting == null) return null;

		List<Card> deck = new List<Card>();
		List<int> indexes = new List<int>();

		for (int i = 0; i < starting.Count; i++)
		{
			indexes.Add(i);
		}

		while(indexes.Count > 0)
		{
			int index = Random.Range(0, indexes.Count);

			deck.Add(starting[indexes[index]]);

			indexes.RemoveAt(index);
		}

		return deck;
	}

	public void ShuffleThis()
	{
		m_cards = Shuffle(m_cards);
	}

	public void Deal(List<Card>[] points, List<Card> deck = null)
	{
		if (points == null || points.Length < 1) return;
		if (deck == null) deck = Cards;

		int index = 0;
		foreach (Card c in deck)
		{
			if (index >= points.Length) index = 0;

			points[index].Add(c);
		}
	}

	public void Dropbox()
	{
		Build();
	}
}
