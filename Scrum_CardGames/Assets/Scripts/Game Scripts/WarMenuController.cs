using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarMenuController : MonoBehaviour {

    [SerializeField] GameObject[] MenuObjects;

    bool m_Shown = true;

    public void ShowHideMenu()
    {
        m_Shown = !m_Shown;

        foreach (GameObject obj in MenuObjects)
        {
            obj.SetActive(m_Shown);
        }
    }
    public void loadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
