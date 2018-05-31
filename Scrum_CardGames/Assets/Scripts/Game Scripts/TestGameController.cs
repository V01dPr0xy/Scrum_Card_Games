using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameController : MonoBehaviour {

    [SerializeField] Card m_ToPlace;
    [SerializeField] Card_Placement m_ThePlace;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_ThePlace.GiveCard(m_ToPlace);
        }
		
	}
}
