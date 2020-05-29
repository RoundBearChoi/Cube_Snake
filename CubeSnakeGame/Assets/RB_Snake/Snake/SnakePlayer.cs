using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

                }
                else if (key == KeyCode.RightArrow)
                {

                }
                else if (key == KeyCode.UpArrow)
                {

                }
                else if (key == KeyCode.DownArrow)
                {

                }
            }
        }

        void InstantiateMarkers()
        {
            if (Markers.Count == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    GameObject m = Instantiate(Resources.Load("Marker")) as GameObject;
                    m.transform.parent = this.transform;
                    m.transform.localPosition = Vector3.zero;
                    m.transform.localRotation = Quaternion.identity;
                    Markers.Add(m);
                }
            }
        }
    }
}