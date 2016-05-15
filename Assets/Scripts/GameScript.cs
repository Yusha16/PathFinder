using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameScript : MonoBehaviour {

    //Map of tile data
    Dictionary<string, GameObject> m_tiles;
    //List<GameObject> m_tiles;

    const int MAX_SIZE = 5;
    public GameObject m_tileObject;

	// Use this for initialization
	void Start () {
        //Intialize the map
        m_tiles = new Dictionary<string, GameObject>();

        //At the start of the game it will initialze the tiles by reading xml file
        //For now have a default layout
        GameObject tile;
        for (int x = 0; x < MAX_SIZE; x++)
        {
            for (int y = 0; y < MAX_SIZE; y++)
            {
                //Instantiating a prefab of the tile
                tile = Instantiate(m_tileObject);
                //Get the component and call the set tile function
                tile.GetComponent<TileScript>().setTile("Cross Tile");
                //Set the position of the tile
                tile.transform.position = new Vector3(x * tile.GetComponent<SpriteRenderer>().sprite.bounds.size.x,
                    y * tile.GetComponent<SpriteRenderer>().sprite.bounds.size.y, 0);
                //Add the tile to the list
                m_tiles.Add("Row: " + y + " Column: " + x, tile);
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void MultipleRotate()
    {

    }

    void Move()
    {

    }
}
