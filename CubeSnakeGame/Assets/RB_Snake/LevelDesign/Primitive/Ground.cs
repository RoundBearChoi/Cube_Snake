using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public enum MoveDirection
    {
        NONE,
        FLAT,
        FORWARD_UP,
        FORWARD_DOWN,
    }
    public class Ground : MonoBehaviour
    {
        public MoveDirection moveDir;
    }
}