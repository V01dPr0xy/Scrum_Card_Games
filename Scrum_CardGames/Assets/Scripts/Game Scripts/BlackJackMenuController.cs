using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackJackMenuController : WarMenuController {

	[SerializeField] Text m_playerSliderTxt = null;

	public void UpdatePlayerCounter(float newValue)
	{
		m_playerSliderTxt.text = newValue.ToString();
	}

}
