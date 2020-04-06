using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class CheckPointSelector : ListenerResponse
    {
        public SnakeIslandType selection;
        public SceneSelection sceneSelectionObj;
        public SceneChanger sceneChanger;

        private void Start()
        {
            sceneChanger = FindObjectOfType<SceneChanger>();
        }

        public void LoadCheckPoint()
        {
            GameObject uiObj = listener.gameEvent.EVENTOBJ;

            Debug.Log("selected island: " + selection);
            Debug.Log("selected checkpoint: " + listener.gameEvent.INDEX);
            sceneSelectionObj.LastSelectedScene = selection;
            sceneSelectionObj.LastSelectedCheckpoint = listener.gameEvent.INDEX;

            if (selection == SnakeIslandType.ONE)
            {
                sceneChanger.NextScene = sceneSelectionObj.IslandTypeOne;
            }
            else if (selection == SnakeIslandType.TWO)
            {
                sceneChanger.NextScene = sceneSelectionObj.IslandTypeTwo;
            }
            else if (selection == SnakeIslandType.THREE)
            {
                sceneChanger.NextScene = sceneSelectionObj.IslandTypeThree;
            }
            else if (selection == SnakeIslandType.FOUR)
            {
                sceneChanger.NextScene = sceneSelectionObj.IslandTypeFour;
            }

            CheckPointManager.Instance.SaveMapSelection(sceneSelectionObj);
            sceneChanger.ChangeScene();
        }
    }
}