using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarGameController : MonoBehaviour {

    [SerializeField] GameObject WinTXT;
    [SerializeField] GameObject WinTXTp1;
    [SerializeField] GameObject WinTXTp2;

    [SerializeField] Card_Placement P1Deck;
    [SerializeField] Card_Placement P2Deck;

    [SerializeField] Card_Placement P1War;
    [SerializeField] Card_Placement P2War;

    [SerializeField] Deck m_Deck;

    public void newGame()
    {
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
    }

    public void NextRound()
    {
        Card c1 = P1Deck.TakeFromTop();
        Card c2 = P2Deck.TakeFromTop();

        P1War.GiveCard(c1);
        P2War.GiveCard(c2);

        c1.Flip();
        c2.Flip();
    }

}
