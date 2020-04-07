using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class SaveManager : Singleton<SaveManager>
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

        public void SaveData()
        {
            string json = JsonUtility.ToJson(checkPointLoader);
            string path = Application.persistentDataPath +
                System.IO.Path.DirectorySeparatorChar +
                "SavedSnake.txt";
            System.IO.File.WriteAllText(path, json);

            Debug.Log("map selection saved: " + path);
        }

        public void LoadData()
        {
            string path = Application.persistentDataPath +
                System.IO.Path.DirectorySeparatorChar +
                "SavedSnake.txt";

            if (System.IO.File.Exists(path))
            {
                string json = System.IO.File.ReadAllText(path);
                JsonUtility.FromJsonOverwrite(json, checkPointLoader.sceneSelection);

                Debug.Log("map selection loaded: " + checkPointLoader.sceneSelection);
            }
        }
    }
}