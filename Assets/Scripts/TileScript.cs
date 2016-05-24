using UnityEngine;
using System.Collections;

//Tile type flag
public enum TileType
{
    Start, 
    Finish,
    Regular,
    Moving,
    Rotating,
    MultiRotate,
    Warp
}

public enum TileState
{
    Regular,
    Connected,
    Finish
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
            m_tileState = TileState.Connected;
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().StartTile;
            m_pathConnectedSprite = m_originalSprite;
            m_finishPathSprite = m_originalSprite;
            GetComponent<SpriteRenderer>().sprite = m_originalSprite;
            m_shape = "Start";
            m_side1 = 4;
            m_side2 = 4;
            return;
        }
        else if (tileType == "Finish")
        {
            m_type = TileType.Finish;
            m_tileState = TileState.Regular;
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishTile;
            m_pathConnectedSprite = m_originalSprite;
            m_finishPathSprite = m_originalSprite;
            GetComponent<SpriteRenderer>().sprite = m_originalSprite;
            m_shape = "Finish";
            m_side1 = 4;
            m_side2 = 4;
            return;
        }
        else if (tileType == "Regular")
        {
            m_type = TileType.Regular;
            m_tileState = TileState.Regular;
        }
        else if (tileType == "Moving")
        {
            m_type = TileType.Moving;
            m_tileState = TileState.Regular;
        }
        else if (tileType == "Rotating")
        {
            m_type = TileType.Rotating;
            m_tileState = TileState.Regular;
        }
        else if (tileType == "MultiRotate")
        {
            m_type = TileType.MultiRotate;
            m_tileState = TileState.Regular;
        }
        else if (tileType == "Warp")
        {
            m_type = TileType.Warp;
            m_tileState = TileState.Regular;
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
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RegBottomAndLeft;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedRegBottomAndLeft;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishRegBottomAndLeft;
        }
        else if (m_type == TileType.Moving)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MovingBottomAndLeft;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedMovingBottomAndLeft;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishMovingBottomAndLeft;
        }
        else if (m_type == TileType.Rotating)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RotatingBottomAndLeft;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedRotatingBottomAndLeft;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishRotatingBottomAndLeft;
        }
        else if (m_type == TileType.MultiRotate)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MultiRotateBottomAndLeft;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedMultiRotateBottomAndLeft;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishMultiRotateBottomAndLeft;
        }
        GetComponent<SpriteRenderer>().sprite = m_originalSprite;
    }

    //Set the bottom and right properties 
    void setBottomRightType()
    {
        m_shape = "BottomRight";
        m_side1 = 1;
        m_side2 = 2;
        if (m_type == TileType.Regular)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RegBottomAndRight;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedRegBottomAndRight;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishRegBottomAndRight;
        }
        else if (m_type == TileType.Moving)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MovingBottomAndRight;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedMovingBottomAndRight;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishMovingBottomAndRight;
        }
        else if (m_type == TileType.Rotating)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RotatingBottomAndRight;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedRotatingBottomAndRight;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishRotatingBottomAndRight;
        }
        else if (m_type == TileType.MultiRotate)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MultiRotateBottomAndRight;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedMultiRotateBottomAndRight;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishMultiRotateBottomAndRight;
        }
        GetComponent<SpriteRenderer>().sprite = m_originalSprite;
    }

    //Set the cross properties
    void setCrossType()
    {
        m_shape = "Cross";
        m_side1 = 4;
        m_side2 = 4;
        if (m_type == TileType.Regular)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RegCross;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedRegCross;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishRegCross;
        }
        else if (m_type == TileType.Moving)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MovingCross;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedMovingCross;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishMovingCross;
        }
        else if (m_type == TileType.Rotating)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RotatingCross;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedRotatingCross;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishRotatingCross;
        }
        else if (m_type == TileType.MultiRotate)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MultiRotateCross;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedMultiRotateCross;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishMultiRotateCross;
        }
        GetComponent<SpriteRenderer>().sprite = m_originalSprite;
    }

    //Set the empty properties
    void setEmptyType()
    {
        m_shape = "Empty";
        m_side1 = 5;
        m_side2 = 5;
        if (m_type == TileType.Regular)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RegEmpty;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedRegEmpty;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishRegEmpty;
        }
        else if (m_type == TileType.Moving)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MovingEmpty;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedMovingEmpty;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishMovingEmpty;
        }
        else if (m_type == TileType.Rotating)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RotatingEmpty;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedRotatingEmpty;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishRotatingEmpty;
        }
        else if (m_type == TileType.MultiRotate)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MultiRotateEmpty;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedMultiRotateEmpty;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishMultiRotateEmpty;
        }
        GetComponent<SpriteRenderer>().sprite = m_originalSprite;
    }

    //Set the line across properties
    void setLineAcross()
    {
        m_shape = "LineAcross";
        m_side1 = 1;
        m_side2 = 3;
        if (m_type == TileType.Regular)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RegLineAcross;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedRegLineAcross;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishRegLineAcross;
        }
        else if (m_type == TileType.Moving)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MovingLineAcross;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedMovingLineAcross;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishMovingLineAcross;
        }
        else if (m_type == TileType.Rotating)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RotatingLineAcross;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedRotatingLineAcross;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishRotatingLineAcross;
        }
        else if (m_type == TileType.MultiRotate)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MultiRotateLineAcross;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedMultiRotateLineAcross;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishMultiRotateLineAcross;
        }
        GetComponent<SpriteRenderer>().sprite = m_originalSprite;
    }

    //Set the line down properties
    void setLineDown()
    {
        m_shape = "LineDown";
        m_side1 = 0;
        m_side2 = 2;
        if (m_type == TileType.Regular)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RegLineDown;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedRegLineDown;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishRegLineDown;
        }
        else if (m_type == TileType.Moving)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MovingLineDown;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedMovingLineDown;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishMovingLineDown;
        }
        else if (m_type == TileType.Rotating)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RotatingLineDown;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedRotatingLineDown;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishRotatingLineDown;
        }
        else if (m_type == TileType.MultiRotate)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MultiRotateLineDown;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedMultiRotateLineDown;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishMultiRotateLineDown;
        }
        GetComponent<SpriteRenderer>().sprite = m_originalSprite;
    }

    //Set the top and left properties 
    void setTopLeftType()
    {
        m_shape = "TopLeft";
        m_side1 = 0;
        m_side2 = 3;
        if (m_type == TileType.Regular)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RegTopAndLeft;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedRegTopAndLeft;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishRegTopAndLeft;
        }
        else if (m_type == TileType.Moving)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MovingTopAndLeft;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedMovingTopAndLeft;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishMovingTopAndLeft;
        }
        else if (m_type == TileType.Rotating)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RotatingTopAndLeft;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedRotatingTopAndLeft;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishRotatingTopAndLeft;
        }
        else if (m_type == TileType.MultiRotate)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MultiRotateTopAndLeft;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedMultiRotateTopAndLeft;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishMultiRotateTopAndLeft;
        }
        GetComponent<SpriteRenderer>().sprite = m_originalSprite;
    }

    //Set the top and right properties 
    void setTopRightType()
    {
        m_shape = "TopRight";
        m_side1 = 0;
        m_side2 = 1;
        if (m_type == TileType.Regular)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RegTopAndRight;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedRegTopAndRight;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishRegTopAndRight;
        }
        else if (m_type == TileType.Moving)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MovingTopAndRight;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedMovingTopAndRight;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishMovingTopAndRight;
        }
        else if (m_type == TileType.Rotating)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RotatingTopAndRight;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedRotatingTopAndRight;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishRotatingTopAndRight;
        }
        else if (m_type == TileType.MultiRotate)
        {
            m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MultiRotateTopAndRight;
            m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedMultiRotateTopAndRight;
            m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishMultiRotateTopAndRight;
        }
        GetComponent<SpriteRenderer>().sprite = m_originalSprite;
    }

    //Set the warp 1 properties 
    void setWarp1Type()
    {
        m_shape = "Warp1";
        m_side1 = 4;
        m_side2 = 4;

        m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RegWarp1;
        m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedRegWarp1;
        m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishRegWarp1;

        GetComponent<SpriteRenderer>().sprite = m_originalSprite;
    }

    //Set the warp 2 properties 
    void setWarp2Type()
    {
        m_shape = "Warp2";
        m_side1 = 4;
        m_side2 = 4;

        m_originalSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RegWarp2;
        m_pathConnectedSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().ConnectedRegWarp2;
        m_finishPathSprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().FinishRegWarp2;

        GetComponent<SpriteRenderer>().sprite = m_originalSprite;
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

    public bool checkType(TileType tileType)
    {
        return tileType == m_type;

        //if (typeName == "Start")
        //{
        //    return m_type == TileType.Start;
        //}
        //else if (typeName == "Finish")
        //{
        //    return m_type == TileType.Finish;
        //}
        //else if (typeName == "Regular")
        //{
        //    return m_type == TileType.Regular;
        //}
        //else if (typeName == "Moving")
        //{
        //    return m_type == TileType.Moving;
        //}
        //else if (typeName == "Rotating")
        //{
        //    return m_type == TileType.Rotating;
        //}
        //else if (typeName == "MultiRotate")
        //{
        //    return m_type == TileType.MultiRotate;
        //}
        //else if (typeName == "Warp")
        //{
        //    return m_type == TileType.Warp;
        //}
        //return false;
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

    Sprite m_originalSprite;
    Sprite m_pathConnectedSprite;
    Sprite m_finishPathSprite;
    TileState m_tileState;
}
