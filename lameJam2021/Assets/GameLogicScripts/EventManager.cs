using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;
    public GameObject mainMenuScreen; //must be linked on the inspector.
    public GameObject hud; //must be linked on the inspector.

    private void Awake()
    {
        current = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            EventManager.current.deconstructLevelHander(0);
        }
        
    }

    public event Action<int> startLevelEvent;
    public void startLevelHandler(int levelNum)
    {
        if(startLevelEvent != null)
        {
            startLevelEvent(levelNum);
            if(mainMenuScreen != null)
            {
                mainMenuScreen.SetActive(false);
                //hud.SetActive(true);
            }
        }
    }

    public event Action<int> deconstructLevelEvent;
    public void deconstructLevelHander(int levelNum)
    {
        if(deconstructLevelEvent != null)
        {
            deconstructLevelEvent(levelNum);
            if (mainMenuScreen != null)
            {
                mainMenuScreen.SetActive(true);
                //hud.SetActive(false);
            }
        }
    }

    public event Action<int> selectMoveEvent;
    public void selectMoveHandler(int moveID)
    {
        if (selectMoveEvent != null)
        {
            selectMoveEvent(moveID);
        }
    }

    public event Action<int, int> selectTileEvent;
    public void selectTileHandler(int x, int y)
    {
        print("recieved signal to handle tile selection at " + x + " " + y);
        if (selectTileEvent != null)
        {
            print("select tile event not null");
            selectTileEvent(x, y);
        }
    }

    public event Action advanceTimeEvent;
    public void advanceTimeHandler()
    {
        if (advanceTimeEvent != null)
        {
            advanceTimeEvent();
        }
    }

    public event Action winLevelEvent;
    public void winLevelHandler()
    {
        if (winLevelEvent != null)
        {
            winLevelEvent();
        }
    }

    public event Action loseLevelEvent;
    public void loseLevelHandler()
    {
        if (loseLevelEvent != null)
        {
            loseLevelEvent();
        }
    }






    /*
    LIST OF ACTIONS MANAGED
    selectMove - called when the player selects from their available abilities (such as move, shoot, throw grenade)
    Responsibility - alert the player and map of the selected move type

    selectTile - called when the player selects clicks a tile on the map
    Responsibility - alert the player and map of the selected tile

    advanceTime - called when the players move completes
    Responsibility - alert enemy units that time has advanced

    winLevel - called when the requirments for a level are achieved
    Responsibility - alert the level that a win state has occured

    loseLevel - called when the player: 
        restarts
        dies
        runs out of moves and has not won
    Responsibility - alert the level that a lose state has occured
    */

}