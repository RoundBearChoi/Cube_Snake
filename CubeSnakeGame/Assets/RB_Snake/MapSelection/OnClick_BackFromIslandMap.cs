using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class OnClick_BackFromIslandMap : MonoBehaviour
    {
        private IslandSelection islandSelection;

        private void Start()
        {
            islandSelection = FindObjectOfType<IslandSelection>();
        }

        public void RemoveIslandMap()
        {
            Debug.Log("removing all island maps");
            islandSelection.IslandOneAnimator.SetBool("ToggleSelection", false);
            islandSelection.IslandTwoAnimator.SetBool("ToggleSelection", false);
            islandSelection.IslandThreeAnimator.SetBool("ToggleSelection", false);
            islandSelection.IslandFourAnimator.SetBool("ToggleSelection", false);
        }
    }
}