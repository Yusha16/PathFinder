using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Text;

enum Corners
{
    TopLeft,
    TopRight,
    BottomRight,
    BottomLeft
}

public class GameScript : MonoBehaviour {

    //Map of tile data
    Dictionary<string, GameObject> m_tiles;
    //List<GameObject> m_tiles;

    int MAX_SIZE = 0;
    public GameObject m_tileObject;
    Vector3 SIZE_OF_SPRITE;

    public Camera m_mainCamera;

    Vector3 m_startTilePosition = new Vector3(-1, -1, -1);
    int m_startSideDirection = 0;

    bool m_inGame = false;

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

        
    }

    public void StartGame(string level)
    {
        loadTile("Assets/LevelData/" + level + ".xml");
        m_inGame = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (m_inGame)
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
                    TileScript tileScript = rayHitInfo.transform.gameObject.GetComponent<TileScript>();
                    if (tileScript != null)
                    {
                        tileScript.onMouseHit();
                        if (checkPathCreated(m_startTilePosition, m_startSideDirection))
                        {
                            //User finish game so switch scene
                            //For now...
                            Debug.Log("You Win");
                            //Start the game
                            GameObject.Find("Game Background").GetComponent<LevelScript>().StartLevelSelect();
                            //Delete all the gameobject in the scene
                            foreach (var go in m_tiles.Values)
                                Destroy(go);
                            //Clear the map    
                            m_tiles.Clear();
                            m_inGame = false;
                        }
                        else
                        {
                            Debug.Log("No Connection Yet");
                        }
                    }
                }
            }
            //Keyboard inputs
            if (Input.GetKeyDown(KeyCode.W))
            {
                m_mainCamera.transform.Translate(0, 1, 0);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                m_mainCamera.transform.Translate(0, -1, 0);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                m_mainCamera.transform.Translate(-1, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                m_mainCamera.transform.Translate(1, 0, 0);
            }
        }
    }

    void loadTile(string filepath)
    {
        XmlDocument xmlFile = new XmlDocument();
        xmlFile.Load(filepath);
        //Set the Max Size and the start direction
        MAX_SIZE = int.Parse(xmlFile.FirstChild.Attributes.Item(0).Value);
        m_startSideDirection = int.Parse(xmlFile.FirstChild.Attributes.Item(1).Value);

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

            //Check to see if the tile is start position
            if (m_startTilePosition == new Vector3(-1, -1, -1) && tile.GetComponent<TileScript>().checkType(TileType.Start))
            {
                m_startTilePosition = tilePosition;
            }
        }
    }

    public void MultipleRotate(string tileMoveName)
    {
        Vector3 tilePosition = m_tiles[tileMoveName].GetComponent<TileScript>().getTilePosition();
        Corners tileCornerPosition = FindTilesCornerMultiRotation(tilePosition);
        Vector3 topLeftCorner, topRightCorner, bottomLeftCorner, bottomRightCorner;
        //Determine the corner position
        if (tileCornerPosition == Corners.TopLeft)
        {
            topLeftCorner = tilePosition;
            topRightCorner = new Vector3(tilePosition.x + 1, tilePosition.y, tilePosition.z);
            bottomLeftCorner = new Vector3(tilePosition.x, tilePosition.y - 1, tilePosition.z);
            bottomRightCorner = new Vector3(tilePosition.x + 1, tilePosition.y - 1, tilePosition.z);
        }
        else if (tileCornerPosition == Corners.TopRight)
        {
            topLeftCorner = new Vector3(tilePosition.x - 1, tilePosition.y, tilePosition.z);
            topRightCorner = tilePosition;
            bottomLeftCorner = new Vector3(tilePosition.x - 1, tilePosition.y - 1, tilePosition.z);
            bottomRightCorner = new Vector3(tilePosition.x, tilePosition.y - 1, tilePosition.z);
        }
        else if (tileCornerPosition == Corners.BottomLeft)
        {
            topLeftCorner = new Vector3(tilePosition.x, tilePosition.y + 1, tilePosition.z);
            topRightCorner = new Vector3(tilePosition.x + 1, tilePosition.y + 1, tilePosition.z);
            bottomLeftCorner = tilePosition;
            bottomRightCorner = new Vector3(tilePosition.x + 1, tilePosition.y, tilePosition.z);
        }
        else
        {
            topLeftCorner = new Vector3(tilePosition.x - 1, tilePosition.y + 1, tilePosition.z);
            topRightCorner = new Vector3(tilePosition.x, tilePosition.y + 1, tilePosition.z);
            bottomLeftCorner = new Vector3(tilePosition.x - 1, tilePosition.y, tilePosition.z);
            bottomRightCorner = tilePosition;
        }

        //Swap the tiles
        SwapTile(topLeftCorner, topRightCorner);
        SwapTile(topLeftCorner, bottomRightCorner);
        SwapTile(topLeftCorner, bottomLeftCorner);
    }

    Corners FindTilesCornerMultiRotation(Vector3 tilePosition)
    {
        //Assume the MultiRotation Tiles is not on the edges of the Level

        //is the tile on the right a MultiRotate Tile
        if (m_tiles["Row: " + tilePosition.y + " Column: " + (tilePosition.x + 1)].GetComponent<TileScript>().checkType(TileType.MultiRotate))
        {
            //is the tile on the top a MultiRotate Tile
            if (m_tiles["Row: " + (tilePosition.y + 1) + " Column: " + tilePosition.x].GetComponent<TileScript>().checkType(TileType.MultiRotate))
            {
                return Corners.BottomLeft;
            }
            //the tile of the MultiRotate is on the bottom side
            else
            {
                return Corners.TopLeft;
            }
        }
        //the tile of the MultiRotate is on the left side 
        else
        {
            //is the tile on the top a MultiRotate Tile
            if (m_tiles["Row: " + (tilePosition.y + 1) + " Column: " + tilePosition.x].GetComponent<TileScript>().checkType(TileType.MultiRotate))
            {
                return Corners.BottomRight;
            }
            //the tile of the MultiRotate is on the bottom side
            else
            {
                return Corners.TopRight;
            }
        }
    }

    void SwapTile(Vector3 tilePosition1, Vector3 tilePosition2)
    {
        //Change the tile position of the object
        m_tiles["Row: " + tilePosition1.y + " Column: " + tilePosition1.x].GetComponent<TileScript>().setTilePosition(tilePosition2);
        m_tiles["Row: " + tilePosition1.y + " Column: " + tilePosition1.x].transform.position = new Vector3(tilePosition2.x * SIZE_OF_SPRITE.x,
                tilePosition2.y * SIZE_OF_SPRITE.y, 0);
        m_tiles["Row: " + tilePosition2.y + " Column: " + tilePosition2.x].GetComponent<TileScript>().setTilePosition(tilePosition1);
        m_tiles["Row: " + tilePosition2.y + " Column: " + tilePosition2.x].transform.position = new Vector3(tilePosition1.x * SIZE_OF_SPRITE.x,
                tilePosition1.y * SIZE_OF_SPRITE.y, 0);
        //Change the data in the map
        GameObject tileObject = m_tiles["Row: " + tilePosition1.y + " Column: " + tilePosition1.x];
        m_tiles["Row: " + tilePosition1.y + " Column: " + tilePosition1.x] = m_tiles["Row: " + tilePosition2.y + " Column: " + tilePosition2.x];
        m_tiles["Row: " + tilePosition2.y + " Column: " + tilePosition2.x] = tileObject;
    }

    public void Move(string tileMoveName)
    {
        Vector3 tilePosition = m_tiles[tileMoveName].GetComponent<TileScript>().getTilePosition();
        Vector3 otherMoveTilePosition = findOtherMoveTile(tilePosition);
        SwapTile(tilePosition, otherMoveTilePosition);
        ////Change the tile position of the object
        //m_tiles[tileMoveName].GetComponent<TileScript>().setTilePosition(otherMoveTilePosition);
        //m_tiles[tileMoveName].transform.position = new Vector3(otherMoveTilePosition.x * SIZE_OF_SPRITE.x,
        //        otherMoveTilePosition.y * SIZE_OF_SPRITE.y, 0);
        //m_tiles["Row: " + otherMoveTilePosition.y + " Column: " + otherMoveTilePosition.x].GetComponent<TileScript>().setTilePosition(tilePosition);
        //m_tiles["Row: " + otherMoveTilePosition.y + " Column: " + otherMoveTilePosition.x].transform.position = new Vector3(tilePosition.x * SIZE_OF_SPRITE.x,
        //        tilePosition.y * SIZE_OF_SPRITE.y, 0);
        ////Change the data in the map
        //GameObject tileObject = m_tiles[tileMoveName];
        //m_tiles[tileMoveName] = m_tiles["Row: " + otherMoveTilePosition.y + " Column: " + otherMoveTilePosition.x];
        //m_tiles["Row: " + otherMoveTilePosition.y + " Column: " + otherMoveTilePosition.x] = tileObject;
    }

    Vector3 findOtherMoveTile(Vector3 tilePosition)
    {
        //if the tile is not the left side of the edge
        if (tilePosition.x != 0)
        {
            if (m_tiles["Row: " + tilePosition.y + " Column: " + (tilePosition.x - 1)].GetComponent<TileScript>().checkType(TileType.Moving))
            {
                return new Vector3(tilePosition.x - 1, tilePosition.y, tilePosition.z);
            }
        }
        //if the tile is not the top side of the edge
        if (tilePosition.y != MAX_SIZE - 1)
        {
            if (m_tiles["Row: " + (tilePosition.y + 1) + " Column: " + tilePosition.x].GetComponent<TileScript>().checkType(TileType.Moving))
            {
                return new Vector3(tilePosition.x, tilePosition.y + 1, tilePosition.z);
            }
        }
        //if the tile is not the right side of the edge
        if (tilePosition.x != MAX_SIZE - 1)
        {
            if (m_tiles["Row: " + tilePosition.y + " Column: " + (tilePosition.x + 1)].GetComponent<TileScript>().checkType(TileType.Moving))
            {
                return new Vector3(tilePosition.x + 1, tilePosition.y, tilePosition.z);
            }
        }
        //if the tile is not the bottom side of the edge
        if (tilePosition.y != 0)
        {
            if (m_tiles["Row: " + (tilePosition.y - 1) + " Column: " + tilePosition.x].GetComponent<TileScript>().checkType(TileType.Moving))
            {
                return new Vector3(tilePosition.x, tilePosition.y - 1, tilePosition.z);
            }
        }

        //No other tile (not possible)
        return new Vector3(-1, -1, -1);
    }

    bool checkPathCreated(Vector3 tilePosition, int tileSide)
    {
        //Edge case
        //Left side
        int result;
        if (tilePosition.x != 0)
        {
            if (tileSide == 3)
            {
                //Get the next side it will go off from
                result = m_tiles["Row: " + tilePosition.y + " Column: " + (tilePosition.x - 1)].GetComponent<TileScript>().doTileConnect(
                    tileSide);
                //Debug.Log("Left: " + result);
                //if there is a connection then
                if (result != 5)
                {
                    //Check to see if the tile was the finish tile 
                    if (m_tiles["Row: " + tilePosition.y + " Column: " + (tilePosition.x - 1)].GetComponent<TileScript>().checkType(TileType.Finish))
                    {
                        return true;
                    }
                    else if (m_tiles["Row: " + tilePosition.y + " Column: " + (tilePosition.x - 1)].GetComponent<TileScript>().checkType(TileType.Warp))
                    {
                        return checkPathCreated(findOtherWarpTile(new Vector3(tilePosition.x - 1, tilePosition.y, tilePosition.z)), result);
                    }
                    else
                    {
                        //Call to check the next tile in its path
                        return checkPathCreated(new Vector3(tilePosition.x - 1, tilePosition.y, tilePosition.z), result);
                    }
                }
                //No connection
                return false;
            }
        }
        //Right side
        if (tilePosition.x != MAX_SIZE - 1)
        {
            if (tileSide == 1)
            {
                //Get the next side it will go off from
                result = m_tiles["Row: " + tilePosition.y + " Column: " + (tilePosition.x + 1)].GetComponent<TileScript>().doTileConnect(
                    tileSide);
                //Debug.Log("Right: " + result);
                //if there is a connection then
                if (result != 5)
                {
                    //Check to see if the tile was the finish tile 
                    if (m_tiles["Row: " + tilePosition.y + " Column: " + (tilePosition.x + 1)].GetComponent<TileScript>().checkType(TileType.Finish))
                    {
                        return true;
                    }
                    else if (m_tiles["Row: " + tilePosition.y + " Column: " + (tilePosition.x + 1)].GetComponent<TileScript>().checkType(TileType.Warp))
                    {
                        return checkPathCreated(findOtherWarpTile(new Vector3(tilePosition.x + 1, tilePosition.y, tilePosition.z)), result);
                    }
                    else
                    {
                        //Call to check the next tile in its path
                        return checkPathCreated(new Vector3(tilePosition.x + 1, tilePosition.y, tilePosition.z), result);
                    }
                }
                //No connection
                return false;
            }
        }
        //Top side
        if (tilePosition.y != MAX_SIZE - 1)
        {
            if (tileSide == 0)
            {
                //Get the next side it will go off from
                result = m_tiles["Row: " + (tilePosition.y + 1) + " Column: " + tilePosition.x].GetComponent<TileScript>().doTileConnect(
                    tileSide);
                //Debug.Log("Top: " + result);
                //if there is a connection then
                if (result != 5)
                {
                    //Check to see if the tile was the finish tile 
                    if (m_tiles["Row: " + (tilePosition.y + 1) + " Column: " + tilePosition.x].GetComponent<TileScript>().checkType(TileType.Finish))
                    {
                        return true;
                    }
                    else if (m_tiles["Row: " + (tilePosition.y + 1) + " Column: " + tilePosition.x].GetComponent<TileScript>().checkType(TileType.Warp))
                    {
                        return checkPathCreated(findOtherWarpTile(new Vector3(tilePosition.x, tilePosition.y + 1, tilePosition.z)), result);
                    }
                    else
                    {
                        //Call to check the next tile in its path
                        return checkPathCreated(new Vector3(tilePosition.x, tilePosition.y + 1, tilePosition.z), result);
                    }
                }
                //No connection
                return false;
            }
        }
        //Bottom side
        if (tilePosition.y != 0)
        {
            if (tileSide == 2)
            {
                //Get the next side it will go off from
                result = m_tiles["Row: " + (tilePosition.y - 1) + " Column: " + tilePosition.x].GetComponent<TileScript>().doTileConnect(
                    tileSide);
                //Debug.Log("Bottom: " + result);
                //if there is a connection then
                if (result != 5)
                {
                    //Check to see if the tile was the finish tile 
                    if (m_tiles["Row: " + (tilePosition.y - 1) + " Column: " + tilePosition.x].GetComponent<TileScript>().checkType(TileType.Finish))
                    {
                        return true;
                    }
                    else if (m_tiles["Row: " + (tilePosition.y + 1) + " Column: " + tilePosition.x].GetComponent<TileScript>().checkType(TileType.Warp))
                    {
                        return checkPathCreated(findOtherWarpTile(new Vector3(tilePosition.x, tilePosition.y + 1, tilePosition.z)), result);
                    }
                    else
                    {
                        //Call to check the next tile in its path
                        return checkPathCreated(new Vector3(tilePosition.x, tilePosition.y - 1, tilePosition.z), result);
                    }
                }
                //No connection
                return false;
            }
        }
        return false;
    }

    Vector3 findOtherWarpTile(Vector3 tilePosition)
    {
        for (int y = 0; y < MAX_SIZE; y++)
        {
            for (int x = 0; x < MAX_SIZE; x++)
            {
                if (tilePosition.x != x && tilePosition.y != y)
                {
                    if (m_tiles["Row: " + y + " Column: " + x].GetComponent<TileScript>().checkType(TileType.Warp))
                    {
                        return new Vector3(x, y, tilePosition.z);
                    }
                }
            }
        }
        //Never going to happen, but just for error checking 
        return new Vector3();
    }

    bool doTileConnect(Vector3 tilePosition)
    {

        return false;
    }
}
