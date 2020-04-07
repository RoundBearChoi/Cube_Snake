using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RBSnake
{
	public enum SnakeIslandType
	{
		NONE,
		ONE,
		TWO,
		THREE,
		FOUR,
	}

    public class IslandSelection : MonoBehaviour
    {
		public CheckPointSelector selector;

		[Header("Islands")]
		public Animator IslandOneAnimator;
		public Animator IslandTwoAnimator;
		public Animator IslandThreeAnimator;
		public Animator IslandFourAnimator;

		[Header("Locks")]
		public List<Animator> IslandOneLocks;
		public List<Animator> IslandTwoLocks;
		public List<Animator> IslandThreeLocks;
		public List<Animator> IslandFourLocks;

		private void Start()
		{
			selector = FindObjectOfType<CheckPointSelector>();
		}

		void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit))
				{
					if (IslandMapsAreOff())
					{
						Debug.Log("selected island: " + hit.collider.gameObject.name);
						selector.selection = hit.collider.gameObject.GetComponent<SnakeIsland>().islandType;
						ToggleLockIcons(selector.selection);
						ToggleIslandMap(selector.selection);
					}
					else
					{
						Debug.Log("duplicate island selection..");
					}
				}
			}
		}

		bool IslandMapsAreOff()
		{
			if (!IslandOneAnimator.GetBool("ToggleSelection") &&
				!IslandTwoAnimator.GetBool("ToggleSelection") &&
				!IslandThreeAnimator.GetBool("ToggleSelection") &&
				!IslandFourAnimator.GetBool("ToggleSelection"))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		void ToggleIslandMap(SnakeIslandType sel)
		{
			{
				if (sel == SnakeIslandType.ONE)
				{
					IslandOneAnimator.SetBool("ToggleSelection", true);
				}
				else if (sel == SnakeIslandType.TWO)
				{
					IslandTwoAnimator.SetBool("ToggleSelection", true);
				}
				else if (sel == SnakeIslandType.THREE)
				{
					IslandThreeAnimator.SetBool("ToggleSelection", true);
				}
				else if (sel == SnakeIslandType.FOUR)
				{
					IslandFourAnimator.SetBool("ToggleSelection", true);
				}
			}
		}

		public List<Animator> GetLockAnimators(SnakeIslandType islandType)
		{
			if (islandType == SnakeIslandType.ONE)
			{
				return IslandOneLocks;
			}
			else if (islandType == SnakeIslandType.TWO)
			{
				return IslandTwoLocks;
			}
			else if (islandType == SnakeIslandType.THREE)
			{
				return IslandThreeLocks;
			}
			else if (islandType == SnakeIslandType.FOUR)
			{
				return IslandFourLocks;
			}

			return null;
		}

		void ToggleLockIcons(SnakeIslandType sel)
		{
			FindObjectOfType<CheckPointSelector>().SetDefaultCheckPoint();

			List<Animator> animators = GetLockAnimators(sel);

			for (int i = 0; i < animators.Count; i++)
			{
				List<int> unlocked = SaveManager.Instance.checkPointLoader.sceneSelection.
					GetUnlockedCheckPoints(sel);

				if (unlocked.Contains(i))
				{
					animators[i].gameObject.GetComponent<Image>().enabled = false;
				}
				else
				{
					animators[i].gameObject.GetComponent<Image>().enabled = true;
				}
			}
		}
	}
}