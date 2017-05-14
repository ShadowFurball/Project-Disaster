using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndDrag : MonoBehaviour
{
    private bool beingDragged = false;
    private GameManager gameManager;
    private Wander wanderScript;
    private Attract attractScript;

	// Use this for initialization
	void Start ()
    {
        gameManager = GameManager.instance;
        wanderScript = GetComponent<Wander>();
        attractScript = GetComponent<Attract>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        bool overSprite = GetComponent<SpriteRenderer>().bounds.Contains(mousePosition);
        beingDragged = beingDragged && Input.GetButton("Fire1");

        if (!overSprite && Input.GetButtonDown("Fire1"))
        {
            wanderScript.StopWander();
            attractScript.DoAttract(mousePosition);
        }

        if (overSprite && gameManager.selectedPerson == null)
        {
            attractScript.StopAttract();
            //If we've pressed down on the mouse (or touched on the iphone)
            if (Input.GetButton("Fire1"))
            {
                beingDragged = true;
                gameManager.selectedPerson = gameObject;
                wanderScript.StopWander();
            }
        }

        if (beingDragged)
        {
            //Set the position to the mouse position
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                             Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                                             0.0f);
        }
        else if (gameManager.selectedPerson == gameObject)
        {
            gameManager.selectedPerson = null;
        }
    }
}
