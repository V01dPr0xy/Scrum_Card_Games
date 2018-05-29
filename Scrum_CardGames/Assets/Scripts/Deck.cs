using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
	public enum eDeckTupe { STANDARD, FULL, CUSTOM }

	List<int> m_cards;
	

	public void Build(eDeckTupe type = eDeckTupe.STANDARD, List<int> included = null) //the list needs to be of cards
	{
		switch(type)
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
		int[] indexes = new int[m_cards.Count];

		
	}
}
