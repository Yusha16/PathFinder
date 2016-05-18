using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject button = Instantiate(m_buttonPrefab);
        button.GetComponent<ButtonScript>().SetButton("Start");
        m_buttons.Add("StartButton", button);
        button = Instantiate(m_buttonPrefab);
        button.GetComponent<ButtonScript>().SetButton("Exit");
        m_buttons.Add("ExitButton", button);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void StartLevelSelect()
    {
        m_buttons.Remove("StartButton");
        //Create the buttons for the Levels and the Exit
        GameObject button = Instantiate(m_buttonPrefab);
        button.GetComponent<ButtonScript>().SetButton("Level1");
        m_buttons.Add("Level1", button);
        button = Instantiate(m_buttonPrefab);
        button.GetComponent<ButtonScript>().SetButton("Level2");
        m_buttons.Add("Level2", button);
        button = Instantiate(m_buttonPrefab);
        button.GetComponent<ButtonScript>().SetButton("Level3");
        m_buttons.Add("Level3", button);
    }

    public void StartLevel(string level)
    {
        GameObject.Find("GameBackground").GetComponent<GameScript>().StartGame(level);
        m_buttons.Clear();
    }

    Dictionary<string, GameObject> m_buttons = new Dictionary<string, GameObject>();

    public GameObject m_buttonPrefab;
}
