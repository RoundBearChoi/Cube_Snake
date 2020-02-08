using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class ListenerResponse : MonoBehaviour
    {
        protected GameEventListener listener;

        private void Awake()
        {
            listener = GetComponent<GameEventListener>();
        }
    }
}