using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

namespace RBSnake
{
    public class SnakePlayer : MonoBehaviour
    {
        public bool IsDead;
        public bool IsDrowning;
        public SnakeTime snakeTime;

        [SerializeField] List<Marker> Markers = new List<Marker>();

        private void Awake()
        {
            IsDead = false;
            Markers.Clear();
        }

        private void Update()
        {
            ToggleDeathMenu();
            InstantiateMarkers();
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

        public Ground GetNextGround(KeyCode key)
        {
            ClearMarkers();

            Vector3 dir = Vector3.zero;

            if (key == KeyCode.LeftArrow)
            {
                dir  = -Vector3.right;
            }
            else if (key == KeyCode.RightArrow)
            {
                dir = Vector3.right;
            }
            else if (key == KeyCode.UpArrow)
            {
                dir = Vector3.forward;
            }
            else if (key == KeyCode.DownArrow)
            {
                dir = -Vector3.forward;
            }

            Markers[0].transform.position = this.transform.position + (1f * dir);
            Markers[1].transform.position = this.transform.position + (1f * dir);
            Markers[2].transform.position = this.transform.position + (1f * dir);

            Markers[1].transform.position += 1f * Vector3.up;
            Markers[2].transform.position -= 1f * Vector3.up;

            foreach (Marker marker in Markers)
            {
                marker.DetectGroundCollision();

                if (marker.NextGround != null)
                {
                    return marker.NextGround;
                }
            }

            return null;
        }

        void InstantiateMarkers()
        {
            if (Markers.Count == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    GameObject obj = Instantiate(Resources.Load("Marker")) as GameObject;
                    obj.transform.position = Vector3.zero;
                    obj.transform.rotation = Quaternion.identity;
                    Marker m = obj.GetComponent<Marker>();
                    m.NextGround = null;
                    Markers.Add(m);
                }
            }
        }

        void ClearMarkers()
        {
            foreach(Marker marker in Markers)
            {
                marker.NextGround = null;
            }
        }
    }
}