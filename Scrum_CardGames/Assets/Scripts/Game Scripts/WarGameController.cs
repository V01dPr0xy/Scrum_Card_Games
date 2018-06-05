using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarGameController : MonoBehaviour {

    [SerializeField] GameObject WinTXT;
    [SerializeField] Text WinTXTp1;
    [SerializeField] Text WinTXTp2;

    [SerializeField] Card_Placement P1Deck;
    [SerializeField] Card_Placement P2Deck;

    [SerializeField] Card_Placement P1War;
    [SerializeField] Card_Placement P2War;

    [SerializeField] Card_Placement P1Discard;
    [SerializeField] Card_Placement P2Discard;

    [SerializeField] Text P1CardCount;
    [SerializeField] Text P2CardCount;

    [SerializeField] Text P1DiscardCount;
    [SerializeField] Text P2DiscardCount;

    [SerializeField] Text P1NameBox;
    [SerializeField] Text P2NameBox;

    [SerializeField] Deck m_Deck;

    Card_Placement m_winningDeck = null;

    bool GameEnd = false;
    bool IsWar = false;
    int WarCount = 0;

    string PlayerOneName = "Player One";
    string PlayerTwoName = "Player Two";

    public void Update()
    {
        if (IsWar) return;

        if (Input.GetKey(KeyCode.Space))
            NextRound();
    }

    public void TextBoxP1Change()
    {
        string name = P1NameBox.text;

        if (name == "") name = "Player One";

        PlayerOneName = name;

        UpdatePlayerCardCounts();
    }

    public void TextBoxP2Change()
    {
        string name = P2NameBox.text;

        if (name == "") name = "Player Two";

        PlayerTwoName = name;

        UpdatePlayerCardCounts();
    }

    public void newGame()
    {
        GameEnd = false;

        WinTXT.SetActive(false);
        WinTXTp1.gameObject.SetActive(false);
        WinTXTp2.gameObject.SetActive(false);

        P1Deck.Clear();
        P2Deck.Clear();
        P1War.Clear();
        P2War.Clear();
        P1Discard.Clear();
        P2Discard.Clear();

        m_Deck.Dropbox();
        m_Deck.Shuffle(m_Deck.Cards);

        bool GiveP1 = true;

        foreach (Card c in m_Deck.Cards)
        {
            if (GiveP1)
            {
                P1Deck.GiveCard(c);
            }
            else
                P2Deck.GiveCard(c);

            c.gameObject.transform.localScale = new Vector3(1,1,1);

            c.gameObject.GetComponent<Button>().interactable = false;

            GiveP1 = !GiveP1;
        }

        P1Deck.Shuffle();
        P2Deck.Shuffle();

        m_Deck.Cards.Clear();
        UpdatePlayerCardCounts();
    }

    public void UpdatePlayerCardCounts()
    {
        //odd game aspect patch.
        WinTXT.SetActive(false);
        WinTXTp1.gameObject.SetActive(false);
        WinTXTp2.gameObject.SetActive(false);

        P1CardCount.text = PlayerOneName +"'s\n" +
                           "Hand Count\n" +
                           P1Deck.m_Cards.Count;

        P2CardCount.text = PlayerTwoName+"'s\n" +
                           "Hand Count\n" +
                           P2Deck.m_Cards.Count;

        P1DiscardCount.text = "" + P1Discard.m_Cards.Count;
        P2DiscardCount.text = "" + P2Discard.m_Cards.Count;

    }

    public void NextRound()
    {
        if (GameEnd) return;

        if (m_winningDeck != null)
        {
            while (P1War.m_Cards.Count > 0)
            {
                Card card = P1War.TakeFromTop();
                m_winningDeck.GiveCard(card);
            }

            while (P2War.m_Cards.Count > 0)
            {
                Card card = P2War.TakeFromTop();
                m_winningDeck.GiveCard(card);
            }
            UpdatePlayerCardCounts();
            m_winningDeck.Shuffle();

            m_winningDeck = null;
            IsWar = false;
        }

        try
        {

            if (IsWar)
            {
                WarCount++;

                if (P1Deck.m_Cards.Count < 4)
                {
                    ReShuffleIn(P1Deck, P1Discard);

                    if (P1Deck.m_Cards.Count < 4)
                    {
                        GameWin(true);
                        return;
                    }
                }
                if (P2Deck.m_Cards.Count < 4)
                {
                    ReShuffleIn(P2Deck, P2Discard);

                    if (P2Deck.m_Cards.Count < 4)
                    {
                        GameWin(false);
                        return;
                    }
                }

                Card POne1 = P1Deck.TakeFromTop();
                Card POne2 = P1Deck.TakeFromTop();
                Card POne3 = P1Deck.TakeFromTop();
                Card POne4 = P1Deck.TakeFromTop();

                Card PTwo1 = P2Deck.TakeFromTop();
                Card PTwo2 = P2Deck.TakeFromTop();
                Card PTwo3 = P2Deck.TakeFromTop();
                Card PTwo4 = P2Deck.TakeFromTop();

                P1War.GiveCard(POne1);
                P1War.GiveCard(POne2);
                P1War.GiveCard(POne3);
                P1War.GiveCard(POne4);

                P2War.GiveCard(PTwo1);
                P2War.GiveCard(PTwo2);
                P2War.GiveCard(PTwo3);
                P2War.GiveCard(PTwo4);

                POne1.transform.localPosition += new Vector3(0, 15, 0) + (new Vector3(0, 60, 0) * (WarCount - 1));
                POne2.transform.localPosition += new Vector3(0, 15, 0) * 2 + (new Vector3(0, 60, 0) * (WarCount - 1));
                POne3.transform.localPosition += new Vector3(0, 15, 0) * 3 + (new Vector3(0, 60, 0) * (WarCount - 1));
                POne4.transform.localPosition += new Vector3(0, 15, 0) * 4 + (new Vector3(0, 60, 0) * (WarCount - 1));

                PTwo1.transform.localPosition -= new Vector3(0, 15, 0) + (new Vector3(0, 60, 0) * (WarCount - 1));
                PTwo2.transform.localPosition -= new Vector3(0, 15, 0) * 2 + (new Vector3(0, 60, 0) * (WarCount - 1));
                PTwo3.transform.localPosition -= new Vector3(0, 15, 0) * 3 + (new Vector3(0, 60, 0) * (WarCount - 1));
                PTwo4.transform.localPosition -= new Vector3(0, 15, 0) * 4 + (new Vector3(0, 60, 0) * (WarCount - 1));

                POne4.Flip();
                PTwo4.Flip();

                RoundWinCheck(POne4, PTwo4);
            }
            else
            {
                if (P1Deck.m_Cards.Count < 1)
                {
                    ReShuffleIn(P1Deck, P1Discard);

                    if (P1Deck.m_Cards.Count <= 3)
                    { 
                        GameWin(true);
                        return;
                    }
                }
                if (P2Deck.m_Cards.Count < 1)
                {
                    ReShuffleIn(P2Deck, P2Discard);

                    if (P2Deck.m_Cards.Count <= 3)
                    {
                        GameWin(false);
                        return;
                    }
                }

                Card c1 = P1Deck.TakeFromTop();
                Card c2 = P2Deck.TakeFromTop();

                P1War.GiveCard(c1);
                P2War.GiveCard(c2);

                c1.Flip();
                c2.Flip();
                RoundWinCheck(c1, c2);
            }
        }
        catch (NullReferenceException)
        {
            UpdatePlayerCardCounts();
        }
    }

    public void ReShuffleIn(Card_Placement deck, Card_Placement discard)
    {
        while (discard.m_Cards.Count > 0)
        {
            deck.GiveCard(discard.TakeFromTop());
        }
        deck.Shuffle();

        foreach (Card c in deck.m_Cards)
        {
            if (c.m_faceUp)
                c.Flip();
        }
        UpdatePlayerCardCounts();
    }

    public void GameWin(bool playerOne)
    {
        if (playerOne)
        {
            //player two Wins.
            WinTXTp2.text = PlayerTwoName;
            WinTXTp2.gameObject.SetActive(true);
        }
        else
        {
            //Player One Wins.
            WinTXTp1.text = PlayerTwoName;
            WinTXTp1.gameObject.SetActive(true);
        }
        WinTXT.SetActive(true);
        GameEnd = true;
    }

    public void RoundWinCheck(Card c1, Card c2)
    {
        int p1 = (int)c1.Value;
        int p2 = (int)c2.Value;

        if (p1 == 0) p1 = 14;
        if (p2 == 0) p2 = 14;

        if (p1 > p2) m_winningDeck = P1Discard;
        else if (p2 > p1) m_winningDeck = P2Discard;
        else
        {//war            
            m_winningDeck = null;
            IsWar = true;
        }

        if (p1 != p2) WarCount = 0;
    }

}
