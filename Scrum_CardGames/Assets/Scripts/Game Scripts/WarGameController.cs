using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarGameController : MonoBehaviour {

    [SerializeField] GameObject WinTXT;
    [SerializeField] GameObject WinTXTp1;
    [SerializeField] GameObject WinTXTp2;

    [SerializeField] Card_Placement P1Deck;
    [SerializeField] Card_Placement P2Deck;

    [SerializeField] Deck m_Deck;

    public void newGame()
    {
        m_Deck.Dropbox();

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

            GiveP1 = !GiveP1;
        }

        m_Deck.Cards.Clear();
    }
}
