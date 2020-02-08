using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    [CreateAssetMenu(fileName = "SceneSelectionObject", menuName = "Roundbeargames/SceneSelection/SceneSelectionObject")]
    public class SceneSelection : ScriptableObject
    {
        public SnakeIslandType LastSelectedScene;
        public int LastSelectedCheckpoint;

        [Header("Scene Names")]
        public string IslandTypeOne;
        public string IslandTypeTwo;
        public string IslandTypeThree;
        public string IslandTypeFour;
    }
}