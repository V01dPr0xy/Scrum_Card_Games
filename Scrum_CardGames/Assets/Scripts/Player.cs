﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string m_Name;
    public List<Card> m_Hand;

    public void ChangeName(string name)
    {
        m_Name = name;
    }
    public void ReceiveCards(List<Card> card)
    {
        m_Hand.AddRange(card);
    }

}
