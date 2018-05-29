using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
	public enum eDeckTupe { STANDARD, FULL, CUSTOM }

	List<int> m_cards;


	public void Build(eDeckTupe type = eDeckTupe.STANDARD, List<int> included = null) //the list needs to be of cards
	{
		switch (type)
		{
			case eDeckTupe.STANDARD:
				break;
			case eDeckTupe.FULL:
				break;
			case eDeckTupe.CUSTOM:
				break;
		}
	}

	public void Shuffle()
	{
		List<int> deck = new List<int>();
		List<int> indexes = new List<int>();

		//loop through cards
		foreach (int card in m_cards)
		{
			//setup lock loop
			while (true)
			{
				//generate random index
				int test = Random.Range(0, m_cards.Count - 1);
				int misses = 0;
				//loop through indexes
				foreach (int i in indexes)
				{
					//check if index is valid
					if (i != test) ++misses;
					else break;
				}
				//if true record index and add card[index] to new deck break from lock loop
				if(misses == indexes.Count)
				{
					indexes.Add(test);

				}
			}
		}
	}
}
