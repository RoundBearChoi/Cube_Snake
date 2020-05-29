﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

namespace RBSnake
{
    public class SnakePlayer : MonoBehaviour
    {
        public bool IsDead;
        public bool IsDrowning;

        [SerializeField] List<GameObject> Markers = new List<GameObject>();
        Control control;

        private void Awake()
        {
            IsDead = false;
            control = FindObjectOfType<Control>();
            Markers.Clear();
        }

        private void Update()
        {
            ToggleDeathMenu();
            InstantiateMarkers();
            CheckNextBlock();
        }

        void ToggleDeathMenu()
        {
            if (IsDead)
            {
                if (UIManager.Instance.DeathMenu != null)
                {
                    if (!UIManager.Instance.DeathMenu.DeathMenuIsOn())
                    {
                        UIManager.Instance.DeathMenu.ShowDeathMenu();
                    }
                }
            }
        }

        void CheckNextBlock()
        {
            if (control.KeyPresses.Count > 0)
            {
                KeyCode key = control.KeyPresses[0];

                if (key == KeyCode.LeftArrow)
                {
                    UpdateMarkers(-Vector3.right);
                }
                else if (key == KeyCode.RightArrow)
                {
                    UpdateMarkers(Vector3.right);
                }
                else if (key == KeyCode.UpArrow)
                {
                    UpdateMarkers(Vector3.forward);
                }
                else if (key == KeyCode.DownArrow)
                {
                    UpdateMarkers(-Vector3.forward);
                }
            }
            else
            {
                UpdateMarkers(this.transform.forward);
            }
        }

        void UpdateMarkers(Vector3 dir)
        {
            Markers[0].transform.position = this.transform.position + (1f * dir);
            Markers[1].transform.position = this.transform.position + (1f * dir);
            Markers[2].transform.position = this.transform.position + (1f * dir);

            Markers[1].transform.position += 1f * Vector3.up;
            Markers[2].transform.position -= 1f * Vector3.up;
        }

        void InstantiateMarkers()
        {
            if (Markers.Count == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    GameObject m = Instantiate(Resources.Load("Marker")) as GameObject;
                    m.transform.position = Vector3.zero;
                    m.transform.rotation = Quaternion.identity;
                    Markers.Add(m);
                }
            }
        }
    }
}