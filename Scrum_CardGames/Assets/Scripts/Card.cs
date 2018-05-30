using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int Value { get; set; }

    public Image Front { get; set; }
    public Image Back { get; set; }

    private bool m_faceUp = false;

    public void Flip() { m_faceUp = !m_faceUp; }

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
