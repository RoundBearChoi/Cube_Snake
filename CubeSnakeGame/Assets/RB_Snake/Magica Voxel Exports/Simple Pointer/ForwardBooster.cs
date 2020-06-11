using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class ForwardBooster : MonoBehaviour
    {
        public List<Renderer> Renderers = new List<Renderer>();
        [Space(10)]
        public Material DefaultMVMaterial;
        public Material YellowEmissionMVMaterial;
        public float SwitchTiming;
        
        int LightedIndex = 0;

        private IEnumerator Start()
        {
            while(true)
            {
                TurnOnEmission(LightedIndex);
                LightedIndex++;
                if (LightedIndex >= Renderers.Count)
                {
                    LightedIndex = 0;
                }
                yield return new WaitForSeconds(SwitchTiming);
            }
        }

        void TurnOnEmission(int index)
        {
            for (int i = 0; i < Renderers.Count; i++)
            {
                if (i == index)
                {
                    Renderers[i].material = YellowEmissionMVMaterial;
                }
                else
                {
                    Renderers[i].material = DefaultMVMaterial;
                }
            }
        }
    }
}