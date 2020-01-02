using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class SnakeBody : MonoBehaviour
    {
        [Header("Parts")]
        public SnakeBody Front;
        public SnakeBody Back;

        [Header("Control")]
        public Control SnakeControl;

        private void Start()
        {
            SnakeControl = FindObjectOfType<Control>();
        }

        public void RegisterBody()
        {
            if (!SnakeBodyManager.Instance.Bodies.Contains(this))
            {
                SnakeBodyManager.Instance.Bodies.Add(this);

                if (Front != null)
                {
                    Front.RegisterBody();
                }
            }
        }

        public void UpdateBody()
        {
            MoveBody();
        }

        public void MoveBody()
        {
            if (Front != null)
            {
                if (Front.transform.position == this.transform.position)
                {
                    return;
                }
                else
                {
                    this.transform.position = Front.transform.position;
                }
            }
            else
            {
                if (SnakeControl.KeyPresses.Count != 0)
                {
                    MoveDir(SnakeControl.KeyPresses[0]);
                }
                else
                {
                    this.transform.position += this.transform.forward;
                }
            }
        }

        public void MoveDir(KeyCode key)
        {
            if (!IsReverse(key))
            {
                if (key == KeyCode.LeftArrow)
                {
                    this.transform.position -= Vector3.right;
                    this.transform.forward = -Vector3.right;
                    SnakeControl.KeyDirection = KeyCode.None;
                }

                if (key == KeyCode.RightArrow)
                {
                    this.transform.position += Vector3.right;
                    this.transform.forward = Vector3.right;
                    SnakeControl.KeyDirection = KeyCode.None;
                }

                if (key == KeyCode.UpArrow)
                {
                    this.transform.position += Vector3.forward;
                    this.transform.forward = Vector3.forward;
                    SnakeControl.KeyDirection = KeyCode.None;
                }

                if (key == KeyCode.DownArrow)
                {
                    this.transform.position -= Vector3.forward;
                    this.transform.forward = -Vector3.forward;
                    SnakeControl.KeyDirection = KeyCode.None;
                }
            }
            else
            {
                this.transform.position += this.transform.forward;
            }

            SnakeControl.KeyPresses.RemoveAt(0);
        }

        bool IsReverse(KeyCode key)
        {
            if (key == KeyCode.LeftArrow)
            {
                if (this.transform.forward == Vector3.right)
                {
                    return true;
                }
            }

            if (key == KeyCode.RightArrow)
            {
                if (this.transform.forward == -Vector3.right)
                {
                    return true;
                }
            }

            if (key == KeyCode.DownArrow)
            {
                if (this.transform.forward == Vector3.forward)
                {
                    return true;
                }
            }

            if (key == KeyCode.UpArrow)
            {
                if (this.transform.forward == -Vector3.forward)
                {
                    return true;
                }
            }

            return false;
        }
    }
}