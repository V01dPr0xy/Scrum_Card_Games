using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    string Name;
    List<Card> Hand;

    public Player(string name, List<Card> hand)
    {
        Name = name;
        Hand = hand;
    }

    public void ChangeName(string name)
    {
        Name = name;
    }
}
