using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    [CreateAssetMenu(fileName = "SceneSelectionObject", menuName = "Roundbeargames/SceneSelection/SceneSelectionObject")]
    public class SceneSelection : ScriptableObject
    {
        [Header("Selection")]
        public SnakeIslandType LastSelectedScene;
        public int LastSelectedCheckpoint;

        [Header("Scene Names")]
        public string IslandTypeOne;
        public string IslandTypeTwo;
        public string IslandTypeThree;
        public string IslandTypeFour;

        [Header("Unlocked")]
        public List<int> IslandOneCheckpoints;
        public List<int> IslandTwoCheckpoints;
        public List<int> IslandThreeCheckpoints;
        public List<int> IslandFourCheckpoints;

        public List<int> GetUnlockedCheckpointsList(SnakeIslandType islandType)
        {
            if (islandType == SnakeIslandType.ONE)
            {
                return IslandOneCheckpoints;
            }
            else if (islandType == SnakeIslandType.TWO)
            {
                return IslandTwoCheckpoints;
            }
            else if (islandType == SnakeIslandType.THREE)
            {
                return IslandThreeCheckpoints;
            }
            else if (islandType == SnakeIslandType.FOUR)
            {
                return IslandFourCheckpoints;
            }

            return null;
        }
    }
}