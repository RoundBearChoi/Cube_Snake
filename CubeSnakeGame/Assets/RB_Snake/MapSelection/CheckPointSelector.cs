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
        public IslandSelection islandSelection;

        private void Start()
        {
            sceneChanger = FindObjectOfType<SceneChanger>();
            islandSelection = FindObjectOfType<IslandSelection>();
        }

        public void LoadCheckPoint()
        {
            if (CheckPointIsUnlocked())
            {
                ProcLoad();
            }
            else
            {
                ShakeLockIcon();
            }
        }
        
        public void SetDefaultCheckPoint()
        {
            List<int> defaultone = SaveManager.Instance.checkPointLoader.sceneSelection.
                GetUnlockedCheckPoints(SnakeIslandType.ONE);

            if (!defaultone.Contains(0))
            {
                defaultone.Add(0);
                SaveManager.Instance.SaveData();
                SaveManager.Instance.LoadData();
            }
        }

        bool CheckPointIsUnlocked()
        {
            SetDefaultCheckPoint();

            List<int> cplist = SaveManager.Instance.checkPointLoader.sceneSelection.
                GetUnlockedCheckPoints(selection);

            if (cplist.Contains(listener.gameEvent.INDEX))
            {
                Debug.Log(selection.ToString() + " " + listener.gameEvent.INDEX.ToString() + " is unlocked");
                return true;
            }
            else
            {
                Debug.Log(selection.ToString() + " " + listener.gameEvent.INDEX.ToString() + " is NOT unlocked");
                return false;
            }
        }

        void ProcLoad()
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

            SaveManager.Instance.SaveData();
            sceneChanger.ChangeScene();
        }

        void ShakeLockIcon()
        {
            List<Animator> animators = islandSelection.GetLockAnimators(selection);

            if (animators.Count > listener.gameEvent.INDEX)
            {
                animators[listener.gameEvent.INDEX].SetBool("ShakeLock", true);
            }
        }
    }
}