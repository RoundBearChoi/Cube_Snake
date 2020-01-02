using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class Control : MonoBehaviour
    {
        public List<KeyCode> KeyPresses = new List<KeyCode>();

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                KeyPresses.Add(KeyCode.LeftArrow);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                KeyPresses.Add(KeyCode.RightArrow);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                KeyPresses.Add(KeyCode.UpArrow);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                KeyPresses.Add(KeyCode.DownArrow);
            }
        }
    }
}