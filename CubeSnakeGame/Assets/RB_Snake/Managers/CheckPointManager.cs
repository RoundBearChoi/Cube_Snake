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
    }
}