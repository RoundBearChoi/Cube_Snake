using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class IntPositions : MonoBehaviour
    {
        [ContextMenu("RemoveDecimals")]
        void RemoveDecimals()
        {
            foreach (Transform child in transform)
            {
                Ground grass = child.GetComponent<Ground>();
                Water water = child.GetComponent<Water>();

                if (grass != null || water != null)
                {
                    Debug.Log("removing decimals: " + child.gameObject.name);
                    child.transform.position = new Vector3(
                        Mathf.Round(child.transform.position.x),
                        Mathf.Round(child.transform.position.y),
                        Mathf.Round(child.transform.position.z));
                }
            }
        }
    }
}