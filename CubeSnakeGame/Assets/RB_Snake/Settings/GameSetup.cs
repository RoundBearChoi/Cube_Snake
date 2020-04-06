using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class GameSetup : MonoBehaviour
    {
        IEnumerator Start()
        {
            yield return new WaitForEndOfFrame();
            SnakeBodyManager.Instance.InitSnake();
        }
    }
}