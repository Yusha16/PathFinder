using UnityEngine;
using System.Collections;

enum ButtonTypes
{
    Start,
    Exit,
    Level,
    Options
}

public class ButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetButton(string buttonName)
    {
        m_buttonText = buttonName;
        if (buttonName == "Start")
        {
            m_buttonType = ButtonTypes.Start;
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().StartButton;
        }
        if (buttonName == "Exit")
        {
            m_buttonType = ButtonTypes.Exit;
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ExitButton;
        }
        if (buttonName == "Level")
        {
            m_buttonType = ButtonTypes.Level;
            DetermineLevelSprite();
        }
        if (buttonName == "Options")
        {
            m_buttonType = ButtonTypes.Options;
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().OptionsButton;
        }
    }

    public void OnMouseHit()
    {
        if (m_buttonType == ButtonTypes.Start)
        {
            GameObject.Find("GameBackground").GetComponent<LevelScript>().StartLevelSelect();
        }
        if (m_buttonType == ButtonTypes.Exit)
        {
            Application.Quit();
        }
        if (m_buttonType == ButtonTypes.Level)
        {
            GameObject.Find("GameBackground").GetComponent<LevelScript>().StartLevel(m_buttonText);
        }
    }

    void DetermineLevelSprite()
    {
        if (m_buttonText == "Level1")
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().Level1Button;
        }
        else if (m_buttonText == "Level2")
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().Level2Button;
        }
        else if (m_buttonText == "Level3")
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().Level3Button;
        }
    }

    //Properties
    ButtonTypes m_buttonType;
    string m_buttonText;
}
