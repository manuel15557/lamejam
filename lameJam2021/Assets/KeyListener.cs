using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyListener : MonoBehaviour
{
    private int moveSelected = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            if (moveSelected != 1)
            {
                moveSelected = 1;
                EventManager.current.selectMoveHandler(1);
            }
            else
            {
                moveSelected = 0;
                EventManager.current.selectMoveHandler(0);
            }
            print("key 1 pressed and moveselected is " + moveSelected);
        }
    }
}
