using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class Marker : MonoBehaviour
    {
        public Ground NextGround;

        public void DetectGroundCollision()
        {
            Collider[] arr = Physics.OverlapSphere(this.transform.position, 0.1f);

            foreach(Collider c in arr)
            {
                Ground g = c.gameObject.GetComponent<Ground>();

                if (g != null)
                {
                    NextGround = g;
                    break;
                }
            }
        }
    }
}