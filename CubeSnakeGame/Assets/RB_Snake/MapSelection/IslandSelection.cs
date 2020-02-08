using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

		public Animator IslandOneAnimator;
		public Animator IslandTwoAnimator;
		public Animator IslandThreeAnimator;
		public Animator IslandFourAnimator;

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
	}
}