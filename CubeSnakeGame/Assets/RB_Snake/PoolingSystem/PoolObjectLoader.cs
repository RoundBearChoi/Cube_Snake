using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public enum PoolObjectType
    {
        ARROW_KEY = 10,

        VFX_BLOOD = 100,
        VFX_RAT = 101,
        VFX_SNAKE = 102,
        VFX_WATER = 103,
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
                    }
                    break;
                case PoolObjectType.VFX_BLOOD:
                    {
                        obj = Instantiate(Resources.Load("Blood Particles", typeof(GameObject)) as GameObject);
                    }
                    break;
                case PoolObjectType.VFX_RAT:
                    {
                        obj = Instantiate(Resources.Load("Rat Particles Variant", typeof(GameObject)) as GameObject);
                    }
                    break;
                case PoolObjectType.VFX_SNAKE:
                    {
                        obj = Instantiate(Resources.Load("Snake Particles Variant", typeof(GameObject)) as GameObject);
                    }
                    break;
                case PoolObjectType.VFX_WATER:
                    {
                        obj = Instantiate(Resources.Load("Water Particles Variant", typeof(GameObject)) as GameObject);
                    }
                    break;
            }

            return obj.GetComponent<PoolObject>();
        }
    }
}