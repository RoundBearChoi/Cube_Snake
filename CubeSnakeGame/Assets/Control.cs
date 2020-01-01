using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class Control : MonoBehaviour
    {
        public KeyCode KeyDirection;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                KeyDirection = KeyCode.LeftArrow;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                KeyDirection = KeyCode.RightArrow;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                KeyDirection = KeyCode.UpArrow;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                KeyDirection = KeyCode.DownArrow;
            }
        }
    }
}