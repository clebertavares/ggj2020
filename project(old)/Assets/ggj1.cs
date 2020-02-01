using UnityEngine;
namespace TrollBridge 
{
	public class ggj1 : MonoBehaviour
	{
		public GameObject dialogueHasWeapon;
		public GameObject dialogueNoWeapon;
		public static bool hasWeapon;
		public static bool deliverWeapon;

		void Start () 
		{
			dialogueHasWeapon.SetActive (false);
			dialogueNoWeapon.SetActive (false);

			if (hasWeapon) 
			{
				dialogueHasWeapon.SetActive (true);
				deliverWeapon = true;
			}
			else
				dialogueNoWeapon.SetActive (true);				
		}
	}
}
