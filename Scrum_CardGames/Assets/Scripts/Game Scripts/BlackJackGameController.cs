using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackJackGameController : MonoBehaviour
{
	[SerializeField] Slider m_playerMaker = null;
	[SerializeField] Text m_currentBetTxt = null;
	[SerializeField] Text m_currentPlayerTxt = null;

	[SerializeField] Deck m_deck = null;
	[SerializeField] Transform[] m_cycleSlots; //middle - out, clockwise turn
	[SerializeField] GameObject m_playerBase = null;
	[SerializeField] GameObject m_house;
	GameObject[] m_players;

	public int m_turn = 0;
	public int m_playerCount = 5;

	int[] m_bets;
	int m_currentBet = 0;

	public void NewGame()
	{
		foreach(GameObject child in transform)
		{
			GameObject.Destroy(child.gameObject);
		}

		m_deck.Build();
		m_deck.ShuffleThis();

		m_playerCount = (int)m_playerMaker.value;
		m_players = new GameObject[m_playerCount];
		m_bets = new int[m_playerCount];

		for(int i=0;i<m_playerCount;i++)
		{
			m_players[i] = Instantiate(m_playerBase, gameObject.transform);
			m_players[i].AddComponent<BJPlayer>();
			m_players[i].GetComponent<BJPlayer>().m_bank = 20; 

		}
	}

	public void CyclePlayer()
	{
		++m_turn;

		if (m_turn >= m_playerCount) m_turn -= m_playerCount;

		int placeIndex = m_turn;
		for(int i=0;i<m_playerCount;i++)
		{
			if (placeIndex >= m_playerCount) placeIndex -= m_playerCount;
			m_players[placeIndex].transform.position = m_cycleSlots[i].position;

			++placeIndex;
		}
	}

	public void Hit()
	{

	}

	public void Stand()
	{

	}

	public void Fold()
	{

	}

	public void Double()
	{

	}

	public void Split()
	{

	}

	public void HouseTurn()
	{

	}
}

public class BJPlayer : Player
{

	public float m_bank = 0.0f;
	public bool m_active = false;

	public float m_handValue = 0.0f;

	private void Update()
	{
		foreach(Card card in m_Hand)
		{
			m_handValue += (int)card.Value;
		}
	}

}
