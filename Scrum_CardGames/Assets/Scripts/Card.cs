using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] public eValues Value;
    [SerializeField] public Sprite Front;
    [SerializeField] public Sprite Back;
    private Image m_CurrentFace;
    private bool m_faceUp = false;

    public void Initialize(eValues value, Sprite front, Sprite back)
    {
        Value = value;
        Front = front;
        Back = back;
	}

    public void Flip()
    {
        m_faceUp = !m_faceUp;
        if (!m_faceUp)
            m_CurrentFace.sprite = Back;
        else
            m_CurrentFace.sprite = Front;
    }

    // Use this for initialization
    void Start()
    {
        m_CurrentFace = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
