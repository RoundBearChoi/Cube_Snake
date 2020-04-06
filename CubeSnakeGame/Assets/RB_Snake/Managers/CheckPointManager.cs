using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class CheckPointManager : Singleton<CheckPointManager>
    {
        public CheckPointLoader checkPointLoader
        {
            get
            {
                if (cpl == null)
                {
                    GameObject obj = Instantiate(Resources.Load("CheckPointLoader", typeof(GameObject)) as GameObject);
                    cpl = obj.GetComponent<CheckPointLoader>();
                }
                return cpl;
            }
        }

        public List<CheckPoint> PointsList = new List<CheckPoint>();

        private CheckPointLoader cpl;

        public void SaveMapSelection(SceneSelection sceneSelection)
        {
            string json = JsonUtility.ToJson(sceneSelection);
            string path = Application.persistentDataPath +
                System.IO.Path.DirectorySeparatorChar +
                "MapSelection.txt";
            System.IO.File.WriteAllText(path, json);

            Debug.Log("map selection saved: " + path);
        }

        public void LoadMapSelection()
        {
            string path = Application.persistentDataPath +
                System.IO.Path.DirectorySeparatorChar +
                "MapSelection.txt";

            if (System.IO.File.Exists(path))
            {
                string json = System.IO.File.ReadAllText(path);
                JsonUtility.FromJsonOverwrite(json, checkPointLoader.sceneSelection);

                Debug.Log("map selection loaded: " + checkPointLoader.sceneSelection);
            }
        }
    }
}