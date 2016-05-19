using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject button = Instantiate(m_buttonPrefab);
        button.GetComponent<ButtonScript>().SetButton(ButtonTypes.Start, "Start");
        button.transform.position = new Vector3(0, 5, 0);
        m_buttons.Add("StartButton", button);
        button = Instantiate(m_buttonPrefab);
        button.GetComponent<ButtonScript>().SetButton(ButtonTypes.Exit, "Exit");
        button.transform.position = new Vector3(10, 5, 0);
        m_buttons.Add("ExitButton", button);
    }

    // Update is called once per frame
    void Update()
    {
        //User Pressed the left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            //Shoot a ray and find a tile to fire event
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHitInfo;
            Physics.Raycast(ray, out rayHitInfo);
            //Hit something then
            if (rayHitInfo.transform != null)
            {
                ButtonScript buttonScript = rayHitInfo.transform.gameObject.GetComponent<ButtonScript>();
                if (buttonScript != null)
                {
                    buttonScript.OnMouseHit();
                }
            }
        }
    }

    public void StartLevelSelect()
    {
        //Create the buttons for the Levels and the Exit
        GameObject button;

        if (m_buttons.ContainsKey("StartButton"))
        {
            Destroy(m_buttons["StartButton"]);
            m_buttons.Remove("StartButton");
        }
        if (!m_buttons.ContainsKey("ExitButton"))
        {
            button = Instantiate(m_buttonPrefab);
            button.GetComponent<ButtonScript>().SetButton(ButtonTypes.Exit, "Exit");
            button.transform.position = new Vector3(10, 5, 0);
            m_buttons.Add("ExitButton", button);
        }
        m_buttons["ExitButton"].transform.position = new Vector3(5, 2, 0.0f);
        button = Instantiate(m_buttonPrefab);
        button.GetComponent<ButtonScript>().SetButton(ButtonTypes.Level, "Level1");
        button.transform.position = new Vector3(0, 5, 0);
        m_buttons.Add("Level1", button);
        button = Instantiate(m_buttonPrefab);
        button.GetComponent<ButtonScript>().SetButton(ButtonTypes.Level, "Level2");
        button.transform.position = new Vector3(5, 5, 0);
        m_buttons.Add("Level2", button);
        button = Instantiate(m_buttonPrefab);
        button.GetComponent<ButtonScript>().SetButton(ButtonTypes.Level, "Level3");
        button.transform.position = new Vector3(10, 5, 0);
        m_buttons.Add("Level3", button);
    }

    public void StartLevel(string level)
    {
        //Start the game
        GameObject.Find("Game Background").GetComponent<GameScript>().StartGame(level);
        //Delete all the gameobject in the scene
        foreach (var go in m_buttons.Values)
            Destroy(go);
        //Clear the map    
        m_buttons.Clear();
    }

    Dictionary<string, GameObject> m_buttons = new Dictionary<string, GameObject>();

    public GameObject m_buttonPrefab;
}
