using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Control : MonoBehaviour {

	// Use this for initialization
public void loadWar()
    {
        SceneManager.LoadScene("War");
    }

    public void loadJack()
    {
        SceneManager.LoadScene("BlackJack");
    }
    public void loadPoker()
    {
        SceneManager.LoadScene("Poker");
    }
    public void loadFish()
    {
        SceneManager.LoadScene("GoFish");
    }

}
