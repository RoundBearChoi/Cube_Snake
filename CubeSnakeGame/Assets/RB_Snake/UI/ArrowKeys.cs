using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class ArrowKeys : MonoBehaviour
    {
        public Dictionary<PoolObject, Arrow> DicArrows = new Dictionary<PoolObject, Arrow>();
        public Arrow LastArrow;

        private Control control;
        public Control CONTROL
        {
            get
            {
                if (control == null)
                {
                    control = FindObjectOfType<Control>();
                }
                return control;
            }
        }

        public void UpdateArrows()
        {
            foreach(KeyValuePair<PoolObject, Arrow> data in DicArrows)
            {
                data.Key.transform.parent = null;
                data.Key.TurnOff();
            }

            DicArrows.Clear();
                       
            for (int i = 0; i < CONTROL.KeyPresses.Count; i++)
            {
                GameObject obj = PoolManager.Instance.GetObject(PoolObjectType.ARROW_KEY);
                obj.transform.parent = this.transform;
                obj.SetActive(true);

                PoolObject p = obj.GetComponent<PoolObject>();
                Arrow a = obj.GetComponent<Arrow>();
                a.UpdateRectPos(new Vector3(0f, i * -110f, 0f));
                a.UpdateRectRot(CONTROL.KeyPresses[i]);
                DicArrows.Add(p, a);
            }
        }

        public void UpdateLastArrow()
        {
            if (LastArrow == null)
            {
                GameObject obj = PoolManager.Instance.GetObject(PoolObjectType.ARROW_KEY);
                obj.transform.parent = this.transform;
                obj.transform.localPosition = Vector3.zero;

                LastArrow = obj.GetComponent<Arrow>();
            }

            if (CONTROL.LastPress == KeyCode.None)
            {
                LastArrow.gameObject.SetActive(false);
            }
            else
            {
                if (control.KeyPresses.Count == 0)
                {
                    LastArrow.gameObject.SetActive(true);
                    LastArrow.UpdateRectRot(CONTROL.LastPress);
                }
                else
                {
                    LastArrow.gameObject.SetActive(false);
                }
            }
        }
    }
}