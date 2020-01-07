using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public enum PoolObjectType
    {
        ARROW_KEY,
    }

    public class PoolObjectLoader : MonoBehaviour
    {
        public static PoolObject InstantiatePrefab(PoolObjectType objType)
        {
            GameObject obj = null;

            switch (objType)
            {
                case PoolObjectType.ARROW_KEY:
                    {
                        obj = Instantiate(Resources.Load("Arrow", typeof(GameObject)) as GameObject);
                        break;
                    }
            }

            return obj.GetComponent<PoolObject>();
        }
    }
}