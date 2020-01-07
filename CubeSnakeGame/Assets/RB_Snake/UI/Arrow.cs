using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RBSnake
{
    public class Arrow : MonoBehaviour
    {
        [SerializeField]
        Image image;

        public void UpdateRectPos(Vector3 vec)
        {
            image.rectTransform.localPosition = vec;
        }

        public void UpdateRectRot(KeyCode key)
        {
            if (key == KeyCode.LeftArrow)
            {
                image.rectTransform.localRotation = Quaternion.Euler(0f, 0f, -90f);
            }

            if (key == KeyCode.RightArrow)
            {
                image.rectTransform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            }

            if (key == KeyCode.UpArrow)
            {
                image.rectTransform.localRotation = Quaternion.Euler(0f, 0f, 180f);
            }

            if (key == KeyCode.DownArrow)
            {
                image.rectTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
    }
}