using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    //unity reference thing
    public GameObject ChessPiece;

    //arrays for posiitons on map, 
    //some arrays for diffrent colors so  I can easely segregate by race
    private GameObject[,] positions = new GameObject[8,8];
    private GameObject[] playerBlack = new GameObject[16];
    private GameObject[] playerWhite = new GameObject[16];

    
    private string currentPlayer = "white";

    private bool gameOver = false;

    //unity thingy when game start, hence(start)
    public void Start()
    {
        
        playerWhite = new GameObject[] 
            {
            Create("white_rook", 0, 0), Create("white_knight", 1, 0),
            Create("white_bishop", 2, 0), Create("white_queen", 3, 0), Create("white_king", 4, 0),
            Create("white_bishop", 5, 0), Create("white_knight", 6, 0), Create("white_rook", 7, 0),
            Create("white_pawn", 0, 1), Create("white_pawn", 1, 1), Create("white_pawn", 2, 1),
            Create("white_pawn", 3, 1), Create("white_pawn", 4, 1), Create("white_pawn", 5, 1),
            Create("white_pawn", 6, 1), Create("white_pawn", 7, 1) 
            };
        playerBlack = new GameObject[] 
            {
            Create("black_rook", 0, 7), Create("black_knight",1,7),
            Create("black_bishop",2,7), Create("black_queen",3,7), Create("black_king",4,7),
            Create("black_bishop",5,7), Create("black_knight",6,7), Create("black_rook",7,7),
            Create("black_pawn", 0, 6), Create("black_pawn", 1, 6), Create("black_pawn", 2, 6),
            Create("black_pawn", 3, 6), Create("black_pawn", 4, 6), Create("black_pawn", 5, 6),
            Create("black_pawn", 6, 6), Create("black_pawn", 7, 6) 
            };

        //setting positions like uh
        for(int i = 0; i < playerBlack.Length; i++)
        {
            setPosition(playerBlack[i]);
            setPosition(playerWhite[i]);
        }
        
    }

    //this is obvious
    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(ChessPiece, new Vector3(0,0,-1), Quaternion.identity);
        Player Pl =  obj.GetComponent<Player>();
        Pl.name = name;
        Pl.SetXBoard(x);
        Pl.SetYBoard(y);
        Pl.Activate();
        return obj;
    }
    
    public void setPosition(GameObject obj)
    {
        Player Pl = obj.GetComponent<Player>();
        positions[Pl.GetXBoard(), Pl.GetYBoard()] = obj;
    }

    public void SetPositionEmpty (int x, int y)
    {
        positions[x, y] = null;
    }

    public GameObject GetPosition(int x, int y)
    {
        return positions[x, y];
    }

    public bool PositionOnBoard(int x, int y)
    {
        if(x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1)) return false;
        return true;
    }
}