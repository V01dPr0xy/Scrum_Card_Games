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
	[SerializeField] Sprite m_cardBack;

	public List<Card> Cards { get { return m_cards; } }

	public void Build(eDeckType type = eDeckType.STANDARD, List<int> included = null)
	{
		m_cards = new List<Card>();

		switch (type)
		{
			case eDeckType.STANDARD:
				for (int i = 0; i < 52; i++)
				{
					Debug.Log(i);
					GameObject go = Instantiate(m_cardBase, gameObject.transform);
					Card card = go.GetComponent<Card>();

					if (card)
					{
						card.Initialize((eValues)i, m_cardImages[i], m_cardBack);

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

	public List<Card> Shuffle(List<Card> starting)
	{
		if (starting == null) return null;

		List<Card> deck = new List<Card>();
		List<int> indexes = new List<int>();

		foreach (var card in starting)
		{
			while (true)
			{
				int test = Random.Range(0, starting.Count - 1);

				if (!indexes.Contains(test))
				{
					indexes.Add(test);
					break;
				}
			}
		}

		foreach (int i in indexes)
		{
			deck.Add(starting[i]);
		}

		return deck;
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
