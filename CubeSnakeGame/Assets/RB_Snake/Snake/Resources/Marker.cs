using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class Marker : MonoBehaviour
    {
        public Ground NextGround;

        private void OnTriggerStay(Collider other)
        {
            Ground g = other.gameObject.GetComponent<Ground>();
            
            if (g != null)
            {
                NextGround = g;
            }
        }
    }
}