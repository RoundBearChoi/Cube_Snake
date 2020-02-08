using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class CheckPointSelector : ListenerResponse
    {
        public SnakeIslandType selection;

        public void LoadCheckPoint()
        {
            GameObject uiObj = listener.gameEvent.EVENTOBJ;
            Debug.Log("selected island: " + selection);
            Debug.Log("selected checkpoint: " + listener.gameEvent.INDEX);
        }
    }
}