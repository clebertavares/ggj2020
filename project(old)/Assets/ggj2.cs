using UnityEngine;
using System.Collections;

namespace TrollBridge 
{
	public class ggj2 : MonoBehaviour 
	{
		void OnTriggerEnter2D(Collider2D other) 
		{
			if (other.tag == "Player")
			{
				ggj1.hasWeapon = true;
			}
		}
	}
}