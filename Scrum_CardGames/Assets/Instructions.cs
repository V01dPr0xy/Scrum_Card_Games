using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    [SerializeField] GameObject warTxt;
    [SerializeField] GameObject bJackTxt;
    [SerializeField] GameObject pokerTxt;
    [SerializeField] GameObject gFishTxt;

    // Use this for initialization
    public void loadWarText()
    {
        warTxt.SetActive(true);
    }

    // Update is called once per frame
    public void exitWarTxt()
    {
        warTxt.SetActive(false);
    }
    public void loadJackText()
    {
        bJackTxt.SetActive(true);
    }

    // Update is called once per frame
    public void exitJackTxt()
    {
        bJackTxt.SetActive(false);
    }
    public void loadPokerText()
    {
        pokerTxt.SetActive(true);
    }

    // Update is called once per frame
    public void exitPokerTxt()
    {
        pokerTxt.SetActive(false);
    }
    public void loadFishText()
    {
        gFishTxt.SetActive(true);
    }

    // Update is called once per frame
    public void exitFishTxt()
    {
        gFishTxt.SetActive(false);
    }

}
