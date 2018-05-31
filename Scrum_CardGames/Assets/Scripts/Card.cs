using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] public int Value;
    [SerializeField] public Sprite Front;
    [SerializeField] public Sprite Back;

    private bool m_faceUp = false;

    public void Flip() { m_faceUp = !m_faceUp; }

    private void ChangeTexture() { }

    // Use this for initialization
    void Start()
    {
        GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
