using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Text;

public class GameScript : MonoBehaviour {

    //Map of tile data
    Dictionary<string, GameObject> m_tiles;
    //List<GameObject> m_tiles;

    const int MAX_SIZE = 5;
    public GameObject m_tileObject;
    Vector3 SIZE_OF_SPRITE;

    // Use this for initialization
    void Start () {
        //Intialize the map
        m_tiles = new Dictionary<string, GameObject>();
        SIZE_OF_SPRITE = m_tileObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
        //At the start of the game it will initialze the tiles by reading xml file
        //For now have a default layout
        //GameObject tile;
        //for (int x = 0; x < MAX_SIZE; x++)
        //{
        //    for (int y = 0; y < MAX_SIZE; y++)
        //    {
        //        //Instantiating a prefab of the tile
        //        tile = Instantiate(m_tileObject);
        //        //Get the component and call the set tile function
        //        tile.GetComponent<TileScript>().setTile("Cross Tile");
        //        //Set the position of the tile
        //        tile.transform.position = new Vector3(x * SIZE_OF_SPRITE.x, y * SIZE_OF_SPRITE.y, 0);
        //        //Add the tile to the list
        //        m_tiles.Add("Row: " + y + " Column: " + x, tile);
        //    }
        //}

        loadTile("Assets/LevelData/Level1.xml");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void loadTile(string filepath)
    {
        XmlDocument xmlFile = new XmlDocument();
        xmlFile.Load(filepath);
        GameObject tile;
        //Go to the First Tile Tag node
        XmlNode currentTileNode = xmlFile.FirstChild.FirstChild;
        XmlNode currentNode;
        //Get the size of the level (number of tile tags)
        int TotalTiles = xmlFile.FirstChild.ChildNodes.Count;
        //The position of the tile
        Vector3 tilePosition;
        for (int i = 0; i < TotalTiles; i++)
        {
            //Instantiating a prefab of the tile
            tile = Instantiate(m_tileObject);
            //Go to the Position tag
            currentNode = currentTileNode.FirstChild;
            //Get the tile position from the Position node
            tilePosition = new Vector3(float.Parse(currentNode.FirstChild.InnerText),
                float.Parse(currentNode.FirstChild.NextSibling.InnerText), 0);
            //Set the position of the tile
            tile.transform.position = new Vector3(tilePosition.x * SIZE_OF_SPRITE.x,
                tilePosition.y * SIZE_OF_SPRITE.y, 0);
            //Go to the Type tag
            currentNode = currentNode.NextSibling;
            //Get the component and call the set tile function
            tile.GetComponent<TileScript>().setTile(currentNode.InnerText, currentNode.NextSibling.InnerText);
            //Add the tile to the list
            m_tiles.Add("Row: " + tilePosition.y + " Column: " + tilePosition.x, tile);
            currentTileNode = currentTileNode.NextSibling;
        }
    }

    void MultipleRotate()
    {

    }

    void Move()
    {

    }
}
