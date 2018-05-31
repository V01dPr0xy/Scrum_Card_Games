using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
	public enum eDeckTupe { STANDARD, FULL, CUSTOM,  }

	[SerializeField] GameObject m_cardBase = null;
	List<Card> m_cards;
	string[] m_cardImages;

	public List<Card> Cards { get { return m_cards; } }
	
	public void Build(eDeckTupe type = eDeckTupe.STANDARD, List<int> included = null)
	{
		switch (type)
		{
			case eDeckTupe.STANDARD:
				for(int i=0;i<14;i++)
				{
					for(int j = 0;j<4;j++)
					{
						GameObject card = Instantiate(m_cardBase);
						Card piece = card.GetComponent<Card>();
						if(piece)
						{

						}
					}
				}
				break;
			case eDeckTupe.FULL:
				for(int i=0;i<14;i++)
				{

				}
				break;
			case eDeckTupe.CUSTOM:
				foreach(var value in included)
				{

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
			while(true)
			{
				int test = Random.Range(0, starting.Count - 1);

				if(!indexes.Contains(test))
				{
					indexes.Add(test);
					break;
				}
			}
		}

		foreach(int i in indexes)
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
		foreach(Card c in deck)
		{
			if (index >= points.Length) index = 0;

			points[index].Add(c);
		}
	}    
}
