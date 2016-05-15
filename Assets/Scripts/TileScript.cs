using UnityEngine;
using System.Collections;

//Tile type flag
enum TileType
{
    Regular,
    Moving,
    Rotating,
    MultiRotate
}

public class TileScript : MonoBehaviour {

    // Use this for initialization
    void Start() {
        m_type = TileType.Regular;
        m_side1 = 5;
        m_side2 = 5;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    //User input with mouse on this tile
    void onMouseHit()
    {
        if (m_type == TileType.Rotating)
        {
            RotateTile();
        }
        else if (m_type == TileType.MultiRotate)
        {
            //Call the game scene and have it swap the multi tile
        }
        else if (m_type == TileType.Moving)
        {
            //Call the game scene to swap this tile and the empty tile
        }
    }

    //Set the tile type from the filename and set all the properties of the specific type
    public void setTile(string filename)
    {
        if (filename == "Bottom and Left Tile")
        {

        }
        else if (filename == "Bottom and Right Tile")
        {

        }
        else if (filename == "Cross Tile")
        {
            setCrossType();
            //For now...
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RegCross;
        }
        else if (filename == "Empty Tile")
        {
            
        }
        else if (filename == "Line Across Tile")
        {

        }
        else if (filename == "Line Down Tile")
        {

        }
        else if (filename == "Top and Left Tile")
        {

        }
        else if (filename == "Top and Right Tile")
        {

        }
        else if (filename == "Warp 1 Tile")
        {

        }
        else if (filename == "Warp 2 Tile")
        {

        }


        //Read the string to see if it can rotate or move
        //Have if statement and set the bool flag for the tile to their corresponding type
    }


    //Set the cross properties
    void setCrossType()
    {
        m_side1 = 5;
        m_side2 = 5;
    }


    //Rotate the tile
    void RotateTile()
    {
        //Special case statement for the cross or empty tile
        if (m_side1 != 4 || m_side1 != 5)
        {
            //Rotate the ends clockwise
            m_side1 = (m_side1 + 1) % 4;
            m_side2 = (m_side2 + 1) % 4;
        }
    }

    //Properties

    //Tile type
    TileType m_type;

    //The opening and closing of the tile
    /*
            0
        ----------
        |        |
      3 |        | 1
        |        |
        ----------
            2
        
        4 for all side opening (only used for the cross tile)
        5 for no side opening (only used for the empty tile)
    */
    int m_side1;
    int m_side2;
}
