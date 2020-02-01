using UnityEngine;
namespace TrollBridge 
{
	public class ggj3 : MonoBehaviour
	{
		public GameObject hero;
		public GameObject vilain;
		public GameObject door;
		public GameObject sign;

		void Awake()
		{
			hero.SetActive (false);
			vilain.SetActive (false);
			door.SetActive (true);
			sign.SetActive (true);

			if(ggj1.deliverWeapon)
			{
				hero.SetActive (true);
				vilain.SetActive (true);
				door.SetActive (false);
				sign.SetActive (false);
			}
		}
	}
}