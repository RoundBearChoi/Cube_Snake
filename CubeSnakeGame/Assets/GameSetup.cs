using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class GameSetup : MonoBehaviour
    {
        void Start()
        {
            SnakeBodyManager.Instance.InitSnake();
        }
    }
}