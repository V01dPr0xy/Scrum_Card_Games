using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
	public enum eDeckTupe { STANDARD, FULL, CUSTOM,  }

	List<int> m_cards;


	public void Build(eDeckTupe type = eDeckTupe.STANDARD, List<int> included = null) //the list needs to be of cards
	{
		switch (type)
		{
			case eDeckTupe.STANDARD:
				for(int i=0;i<14;i++)
				{

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

	public List<int> Shuffle(List<int> starting)
	{
		if (starting == null) return null;

		List<int> deck = new List<int>();
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
}
