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
        }
        else if (m_type == TileType.Moving)
        {
            //Call the game scene to swap this tile and the empty tile
        }
    }

    //Set the tile type from the filename and set all the properties of the specific type
    public void setTile(string tileType, string shape)
    {
        if (tileType == "Regular")
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


    //Set the bottom and left properties 
    void setBottomLeftType()
    {
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
        m_side1 = 4;
        m_side2 = 4;
        if (m_type == TileType.Regular)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RegWarp1;
        }
        else if (m_type == TileType.Moving)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MovingWarp1;
        }
        else if (m_type == TileType.Rotating)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RotatingWarp1;
        }
        else if (m_type == TileType.MultiRotate)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MultiRotateWarp1;
        }
    }

    //Set the warp 2 properties 
    void setWarp2Type()
    {
        m_side1 = 4;
        m_side2 = 4;
        if (m_type == TileType.Regular)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RegWarp2;
        }
        else if (m_type == TileType.Moving)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MovingWarp2;
        }
        else if (m_type == TileType.Rotating)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().RotatingWarp2;
        }
        else if (m_type == TileType.MultiRotate)
        {
            GetComponent<SpriteRenderer>().sprite = GameObject.Find("StaticData").GetComponent<SpriteManager>().MultiRotateWarp2;
        }
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

    //Properties

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
}
