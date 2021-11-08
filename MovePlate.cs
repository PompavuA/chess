using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{

    public GameObject controller;

    GameObject reference = null;

    //posiitons on board
    int matrixX;
    int matrixY;

    //false is moving, true is attack
    public bool attack = false;

    public void Start()
    {
        if (attack)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
    }

    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        //destroys pieces
        if(attack)
        {
            GameObject cp = controller.GetComponent<Game>().GetPosition(matrixX, matrixY);

            Destroy(cp);
        }

        //aparantry sets original location to empty after I use it
        controller.GetComponent<Game>().SetPositionEmpty(reference.GetComponent<Player>().GetXBoard(),
        reference.GetComponent<Player>().GetYBoard());

        reference.GetComponent<Player>().SetXBoard(matrixX);
        reference.GetComponent<Player>().SetYBoard(matrixY);
        reference.GetComponent<Player>().SetCoords();
        //update locations
        controller.GetComponent<Game>().setPosition(reference);

        //destroys moveplates, sheesh
        reference.GetComponent<Player>().DestroyMovePlates();
    } 
    public void SetCoords(int x, int y)
    {
        matrixX = x;
        matrixY = y;
    }

    public void SetReference(GameObject obj)
    {
        reference = obj;
    }

    public GameObject GetReference()
    {
        return reference;
    }
}
