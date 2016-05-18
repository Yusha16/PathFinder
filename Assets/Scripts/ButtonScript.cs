using UnityEngine;
using System.Collections;

public enum ButtonTypes
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

    public void SetButton(ButtonTypes buttonType, string buttonName)
    {
        m_buttonType = buttonType;
        m_buttonText = buttonName;
        if (m_buttonType == ButtonTypes.Start)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().StartButton;
        }
        if (m_buttonType == ButtonTypes.Exit)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ExitButton;
        }
        if (m_buttonType == ButtonTypes.Level)
        {
            DetermineLevelSprite();
        }
        if (m_buttonType == ButtonTypes.Options)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().OptionsButton;
        }
    }

    public void OnMouseHit()
    {
        if (m_buttonType == ButtonTypes.Start)
        {
            GameObject.Find("Game Background").GetComponent<LevelScript>().StartLevelSelect();
        }
        if (m_buttonType == ButtonTypes.Exit)
        {
            Application.Quit();
        }
        if (m_buttonType == ButtonTypes.Level)
        {
            GameObject.Find("Game Background").GetComponent<LevelScript>().StartLevel(m_buttonText);
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
