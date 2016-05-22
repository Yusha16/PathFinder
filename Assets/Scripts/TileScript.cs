using UnityEngine;
using System.Collections;

//Tile type flag
enum TileType
{
    Start, 
    Finish,
    Regular,
    Moving,
    Rotating,
    MultiRotate,
    Warp
}

public class TileScript : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }
	
	// Update is called once per frame
	void Update () {

    }

    //User input with mouse on this tile
    public void onMouseHit()
    {
        if (m_type == TileType.Rotating)
        {
            RotateTile();
        }
        else if (m_type == TileType.MultiRotate)
        {
            //Call the game scene and have it swap the multi tile
            GameObject.Find("Game Background").GetComponent<GameScript>().MultipleRotate(name);
        }
        else if (m_type == TileType.Moving)
        {
            //Call the game scene to swap this tile and the empty tile
            GameObject.Find("Game Background").GetComponent<GameScript>().Move(name);
        }
    }

    //Set the tile type from the filename and set all the properties of the specific type
    public void setTile(string tileType, string shape)
    {
        if (tileType == "Start")
        {
            m_type = TileType.Start;
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().StartTile;
            m_shape = "Start";
            m_side1 = 4;
            m_side2 = 4;
            return;
        }
        else if (tileType == "Finish")
        {
            m_type = TileType.Finish;
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishTile;
            m_shape = "Finish";
            m_side1 = 4;
            m_side2 = 4;
            return;
        }
        else if (tileType == "Regular")
        {
            m_type = TileType.Regular;
        }
        else if (tileType == "Moving")
        {
            m_type = TileType.Moving;
        }
        else if (tileType == "Rotating")
        {
            m_type = TileType.Rotating;
        }
        else if (tileType == "MultiRotate")
        {
            m_type = TileType.MultiRotate;
        }
        else if (tileType == "Warp")
        {
            m_type = TileType.Warp;
        }

        if (shape == "BottomLeft")
        {
            setBottomLeftType();
        }
        else if (shape == "BottomRight")
        {
            setBottomRightType();
        }
        else if (shape == "Cross")
        {
            setCrossType();
        }
        else if (shape == "Empty")
        {
            setEmptyType();
        }
        else if (shape == "LineAcross")
        {
            setLineAcross();
        }
        else if (shape == "LineDown")
        {
            setLineDown();
        }
        else if (shape == "TopLeft")
        {
            setTopLeftType();
        }
        else if (shape == "TopRight")
        {
            setTopRightType();
        }
        else if (shape == "Warp1")
        {
            setWarp1Type();
        }
        else if (shape == "Warp2")
        {
            setWarp2Type();
        }
    }

    //Set the position of the tile in Level Position
    public void setTilePosition(Vector3 position)
    {
        m_position = position;
    }

    //Get the position of the tile in Level Position
    public Vector3 getTilePosition()
    {
        return m_position;
    }

    //Set the bottom and left properties 
    void setBottomLeftType()
    {
        m_shape = "BottomLeft";
        m_side1 = 2;
        m_side2 = 3;
        if (m_type == TileType.Regular)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RegBottomAndLeft;
        }
        else if (m_type == TileType.Moving)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MovingBottomAndLeft;
        }
        else if (m_type == TileType.Rotating)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RotatingBottomAndLeft;
        }
        else if (m_type == TileType.MultiRotate)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MultiRotateBottomAndLeft;
        }
    }

    //Set the bottom and right properties 
    void setBottomRightType()
    {
        m_shape = "BottomRight";
        m_side1 = 1;
        m_side2 = 2;
        if (m_type == TileType.Regular)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RegBottomAndRight;
        }
        else if (m_type == TileType.Moving)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MovingBottomAndRight;
        }
        else if (m_type == TileType.Rotating)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RotatingBottomAndRight;
        }
        else if (m_type == TileType.MultiRotate)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MultiRotateBottomAndRight;
        }
    }

    //Set the cross properties
    void setCrossType()
    {
        m_shape = "Cross";
        m_side1 = 4;
        m_side2 = 4;
        if (m_type == TileType.Regular)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RegCross;
        }
        else if (m_type == TileType.Moving)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MovingCross;
        }
        else if (m_type == TileType.Rotating)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RotatingCross;
        }
        else if (m_type == TileType.MultiRotate)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MultiRotateCross;
        }
    }

    //Set the empty properties
    void setEmptyType()
    {
        m_shape = "Empty";
        m_side1 = 5;
        m_side2 = 5;
        if (m_type == TileType.Regular)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RegEmpty;
        }
        else if (m_type == TileType.Moving)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MovingEmpty;
        }
        else if (m_type == TileType.Rotating)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RotatingEmpty;
        }
        else if (m_type == TileType.MultiRotate)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MultiRotateEmpty;
        }
    }

    //Set the line across properties
    void setLineAcross()
    {
        m_shape = "LineAcross";
        m_side1 = 1;
        m_side2 = 3;
        if (m_type == TileType.Regular)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RegLineAcross;
        }
        else if (m_type == TileType.Moving)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MovingLineAcross;
        }
        else if (m_type == TileType.Rotating)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RotatingLineAcross;
        }
        else if (m_type == TileType.MultiRotate)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MultiRotateLineAcross;
        }
    }

    //Set the line down properties
    void setLineDown()
    {
        m_shape = "LineDown";
        m_side1 = 0;
        m_side2 = 2;
        if (m_type == TileType.Regular)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RegLineDown;
        }
        else if (m_type == TileType.Moving)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MovingLineDown;
        }
        else if (m_type == TileType.Rotating)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RotatingLineDown;
        }
        else if (m_type == TileType.MultiRotate)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MultiRotateLineDown;
        }
    }

    //Set the top and left properties 
    void setTopLeftType()
    {
        m_shape = "TopLeft";
        m_side1 = 0;
        m_side2 = 3;
        if (m_type == TileType.Regular)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RegTopAndLeft;
        }
        else if (m_type == TileType.Moving)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MovingTopAndLeft;
        }
        else if (m_type == TileType.Rotating)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RotatingTopAndLeft;
        }
        else if (m_type == TileType.MultiRotate)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MultiRotateTopAndLeft;
        }
    }

    //Set the top and right properties 
    void setTopRightType()
    {
        m_shape = "TopRight";
        m_side1 = 0;
        m_side2 = 1;
        if (m_type == TileType.Regular)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RegTopAndRight;
        }
        else if (m_type == TileType.Moving)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MovingTopAndRight;
        }
        else if (m_type == TileType.Rotating)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RotatingTopAndRight;
        }
        else if (m_type == TileType.MultiRotate)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MultiRotateTopAndRight;
        }
    }

    //Set the warp 1 properties 
    void setWarp1Type()
    {
        m_shape = "Warp1";
        m_side1 = 4;
        m_side2 = 4;
        GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RegWarp1;
    }

    //Set the warp 2 properties 
    void setWarp2Type()
    {
        m_shape = "Warp2";
        m_side1 = 4;
        m_side2 = 4;
        GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RegWarp2;
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
            transform.Rotate(0, 0, -90);
        }
    }

    public bool checkType(string typeName)
    {
        if (typeName == "Start")
        {
            return m_type == TileType.Start;
        }
        else if (typeName == "Finish")
        {
            return m_type == TileType.Finish;
        }
        else if (typeName == "Regular")
        {
            return m_type == TileType.Regular;
        }
        else if (typeName == "Moving")
        {
            return m_type == TileType.Moving;
        }
        else if (typeName == "Rotating")
        {
            return m_type == TileType.Rotating;
        }
        else if (typeName == "MultiRotate")
        {
            return m_type == TileType.MultiRotate;
        }
        else if (typeName == "Warp")
        {
            return m_type == TileType.Warp;
        }
        return false;
    }

    public int doTileConnect(int side)
    {
        if (m_shape != "Empty")
        {
            //Cross shape
            if (m_side1 == 4 || m_side2 == 4)
            {
                //Return the side because you will be entering from the same side again to the next tile
                return side;
            }
            //Side is coming in from the bottom 
            if (side == 0)
            {
                //if side connect then return the other side of connection
                if (m_side1 == 2)
                {
                    return m_side2;
                }
                if (m_side2 == 2)
                {
                    return m_side1;
                }
                //No connection
                return 5;
            }
            //Side is coming in from the left 
            if (side == 1)
            {
                //if side connect then return the other side of connection
                if (m_side1 == 3)
                {
                    return m_side2;
                }
                if (m_side2 == 3)
                {
                    return m_side1;
                }
                //No connection
                return 5;
            }
            //Side is coming in from the top 
            if (side == 2)
            {
                //if side connect then return the other side of connection
                if (m_side1 == 0)
                {
                    return m_side2;
                }
                if (m_side2 == 0)
                {
                    return m_side1;
                }
                //No connection
                return 5;
            }
            //Side is coming in from the right 
            if (side == 3)
            {
                //if side connect then return the other side of connection
                if (m_side1 == 1)
                {
                    return m_side2;
                }
                if (m_side2 == 1)
                {
                    return m_side1;
                }
                //No connection
                return 5;
            }
        }
        //Shape is empty no connection
        return 5;
    }

    //Properties

    //Tile Shape 
    string m_shape = "Empty";

    //Tile type
    TileType m_type = TileType.Regular;

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
    int m_side1 = 5;
    int m_side2 = 5;

    Vector3 m_position = new Vector3();
}
