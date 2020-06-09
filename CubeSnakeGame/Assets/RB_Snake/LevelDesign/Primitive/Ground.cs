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
        public BoxCollider boxCollider;

        public Vector3 GetPlayerPosition()
        {
            return boxCollider.transform.position + boxCollider.center + (Vector3.up * 1f); 
        }
    }
}