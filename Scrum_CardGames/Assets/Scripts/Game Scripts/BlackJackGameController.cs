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
	[SerializeField] Card_Placement m_dealer = null;
	[SerializeField] Transform[] m_cycleSlots; //middle - out, clockwise turn
	[SerializeField] GameObject m_playerBase = null;
	[SerializeField] GameObject m_house;
	GameObject[] m_players;

	public int m_turn = 0;
	public int m_playerCount = 5;

	int[] m_bets;
	bool m_phase = false; //false for actions; true for bets
	bool m_playerBetted = false;

	public void NewGame()
	{
		foreach(Transform child in transform)
		{
			GameObject.Destroy(child.gameObject);
		}

		m_deck.Build();
		m_deck.ShuffleThis();
		m_dealer.m_Cards = m_deck.m_cards;

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

	void Deal()
	{

	}

	public void CyclePlayer()
	{
		
		if (m_phase) BettingPhase();

		m_currentBetTxt.text = m_bets[m_turn].ToString();

		do
		{
			++m_turn;

			if (m_turn >= m_playerCount)
			{
				HouseTurn();
				CalculateRoundWinnings();
				m_turn -= m_playerCount;
			}

			int placeIndex = m_turn;
			for (int i = 0; i < m_playerCount; i++)
			{
				if (placeIndex >= m_playerCount) placeIndex -= m_playerCount;
				m_players[placeIndex].transform.position = m_cycleSlots[i].position;

				++placeIndex;
			}
		} while (!m_players[m_turn].GetComponent<BJPlayer>().m_active);
		
	}

	void CalculateRoundWinnings()
	{
		int house = m_house.GetComponent<BJPlayer>().m_handValue;

		for(int i=0;i<m_playerCount;i++)
		{
			
		}
	}

	public void BettingPhase()
	{
		for(int i=0;i < m_playerCount;i++)
		{
			m_turn = i;
			while(!m_playerBetted)
			{
				m_currentPlayerTxt.text = m_players[m_turn].GetComponent<Player>().m_Name;
			}

			m_playerBetted = false;
		}

		m_phase = false;
		CyclePlayer();
	}

	public void SmallBet()
	{
		if(m_phase)
		{
			m_playerBetted = true;
			m_bets[m_turn] = 1;
		}
	}

	public void MediumBet()
	{
		if (m_phase)
		{
			m_playerBetted = true;
			m_bets[m_turn] = 5;
		}
	}

	public void HardlBet()
	{
		if (m_phase)
		{
			m_playerBetted = true;
			m_bets[m_turn] = 10;
		}
	}


	public void Hit()
	{
		Card hit = m_dealer.TakeFromTop();
		hit.Flip();
		m_players[m_turn].GetComponent<Player>().m_Hand.Add(hit);
	}

	public void Stand()
	{
		CyclePlayer();
	}

	public void Fold()
	{
		m_bets[m_turn] = 0;

		m_players[m_turn].GetComponent<BJPlayer>().m_active = false;
	}

	public void Double()
	{
		m_bets[m_turn] *= 2;
		Hit();
		Stand();
	}

	public void Split()
	{

	}

	public void HouseTurn()
	{
		while(m_house.GetComponent<BJPlayer>().m_handValue < 17)
		{
			Hit();
		}

		Stand();

		m_phase = true;
	}

	public void OnNamePlayerChange()
	{
		string test = m_currentPlayerTxt.text.Replace(" ", "");
		if(m_currentPlayerTxt.text.Length > 0 && test.Length > 0)
		{
			m_players[m_turn].GetComponent<Player>().ChangeName(m_currentPlayerTxt.text);
		}
	}
}

public class BJPlayer : Player
{

	public float m_bank = 0.0f;
	public bool m_active = true;

	public int m_handValue = 0;

	BlackJackGameController bjcontrol;

	[SerializeField] Card_Placement[] m_standardPlaces; //0 - up; 1 - down
	[SerializeField] Card_Placement[] m_splitPlaces;

	private void Start()
	{
		bjcontrol = GetComponentInParent<BlackJackGameController>();
	}

	private void Update()
	{
		if (m_active && m_bank <= -50) m_active = false;
	}

	public void AddCard(Card newCard)
	{
		foreach (Card card in m_Hand)
		{
			if((eValues)m_handValue == eValues.Ace)
			{
			}
			else m_handValue += (int)card.Value;
		}

		if (m_handValue >= 21)
		{
			m_active = false;
			bjcontrol.CyclePlayer();
		}
		m_standardPlaces[0].GiveCard(newCard);

	}

	public void Split()
	{

	}
}
