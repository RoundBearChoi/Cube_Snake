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
        public List<int> IslandOneCheckPoints;
        public List<int> IslandTwoCheckPoints;
        public List<int> IslandThreeCheckPoints;
        public List<int> IslandFourCheckPoints;

        public List<int> GetUnlockedCheckPoints(SnakeIslandType islandType)
        {
            if (islandType == SnakeIslandType.ONE)
            {
                return IslandOneCheckPoints;
            }
            else if (islandType == SnakeIslandType.TWO)
            {
                return IslandTwoCheckPoints;
            }
            else if (islandType == SnakeIslandType.THREE)
            {
                return IslandThreeCheckPoints;
            }
            else if (islandType == SnakeIslandType.FOUR)
            {
                return IslandFourCheckPoints;
            }

            return null;
        }
    }
}