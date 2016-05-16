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
        //User Pressed the left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            //Shoot a ray and find a tile to fire event
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHitInfo;
            Physics.Raycast(ray, out rayHitInfo);
            rayHitInfo.transform.gameObject.GetComponent<TileScript>().onMouseHit();
        }
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
            //Change the name of the tile
            tile.name = "Row: " + tilePosition.y + " Column: " + tilePosition.x;
            //Set the position of the tile
            tile.GetComponent<TileScript>().setTilePosition(tilePosition);
            //Add the tile to the list
            m_tiles.Add("Row: " + tilePosition.y + " Column: " + tilePosition.x, tile);
            currentTileNode = currentTileNode.NextSibling;
        }
    }

    void MultipleRotate()
    {

    }

    public void Move(string tileMoveName)
    {
        Vector3 tilePosition = m_tiles[tileMoveName].GetComponent<TileScript>().getTilePosition();
        Vector3 otherMoveTilePosition = findOtherMoveTile(tilePosition);
        //Change the tile position of the object
        m_tiles[tileMoveName].GetComponent<TileScript>().setTilePosition(otherMoveTilePosition);
        m_tiles[tileMoveName].transform.position = new Vector3(otherMoveTilePosition.x * SIZE_OF_SPRITE.x,
                otherMoveTilePosition.y * SIZE_OF_SPRITE.y, 0);
        m_tiles["Row: " + otherMoveTilePosition.y + " Column: " + otherMoveTilePosition.x].GetComponent<TileScript>().setTilePosition(tilePosition);
        m_tiles["Row: " + otherMoveTilePosition.y + " Column: " + otherMoveTilePosition.x].transform.position = new Vector3(tilePosition.x * SIZE_OF_SPRITE.x,
                tilePosition.y * SIZE_OF_SPRITE.y, 0);
        //Change the data in the map
        GameObject tileObject = m_tiles[tileMoveName];
        m_tiles[tileMoveName] = m_tiles["Row: " + otherMoveTilePosition.y + " Column: " + otherMoveTilePosition.x];
        m_tiles["Row: " + otherMoveTilePosition.y + " Column: " + otherMoveTilePosition.x] = tileObject;
    }

    Vector3 findOtherMoveTile(Vector3 tilePosition)
    {
        //if the tile is not the left side of the edge
        if (tilePosition.x != 0)
        {
            if (m_tiles["Row: " + tilePosition.y + " Column: " + (tilePosition.x - 1)].GetComponent<TileScript>().checkType("Moving"))
            {
                return new Vector3(tilePosition.x - 1, tilePosition.y, tilePosition.z);
            }
        }
        //if the tile is not the top side of the edge
        if (tilePosition.y != MAX_SIZE - 1)
        {
            if (m_tiles["Row: " + (tilePosition.y + 1) + " Column: " + tilePosition.x].GetComponent<TileScript>().checkType("Moving"))
            {
                return new Vector3(tilePosition.x, tilePosition.y + 1, tilePosition.z);
            }
        }
        //if the tile is not the right side of the edge
        if (tilePosition.x != MAX_SIZE - 1)
        {
            if (m_tiles["Row: " + tilePosition.y + " Column: " + (tilePosition.x + 1)].GetComponent<TileScript>().checkType("Moving"))
            {
                return new Vector3(tilePosition.x + 1, tilePosition.y, tilePosition.z);
            }
        }
        //if the tile is not the bottom side of the edge
        if (tilePosition.y != 0)
        {
            if (m_tiles["Row: " + (tilePosition.y - 1) + " Column: " + tilePosition.x].GetComponent<TileScript>().checkType("Moving"))
            {
                return new Vector3(tilePosition.x, tilePosition.y - 1, tilePosition.z);
            }
        }

        //No other tile (not possible)
        return new Vector3(-1, -1, -1);
    }
}
