using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackJackGameController : MonoBehaviour
{
	[SerializeField] Slider m_playerMaker = null;

	[SerializeField] Deck m_deck = null;
	[SerializeField] Transform[] m_cycleSlots; //middle - out, clockwise turn
	[SerializeField] GameObject[] m_playerSlots;
	[SerializeField] Player m_house;
	public int[] m_banks;

	public int m_turn = 0;
	int m_playerCount = 5;

	public void NewGame()
	{
		m_deck.Build();
		m_deck.ShuffleThis();

		m_playerCount = (int)m_playerMaker.value;

	}

	public void CyclePlayer()
	{
		++m_turn;

		if (m_turn >= m_playerCount) m_turn -= m_playerCount;

		int placeIndex = m_turn;
		for(int i=0;i<m_playerCount;i++)
		{
			if (placeIndex >= m_playerCount) placeIndex -= m_playerCount;
			m_playerSlots[i].transform.position = m_cycleSlots[placeIndex].position;

			++m_playerCount;
		}
	}

	public void HouseTurn()
	{

	}
}
