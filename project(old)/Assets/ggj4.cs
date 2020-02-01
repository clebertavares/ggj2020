using UnityEngine;
namespace TrollBridge 
{
	public class ggj4 : MonoBehaviour
	{
		public GameObject o1;
		public GameObject o2;
		public GameObject d1;
		public GameObject d2;
		public GameObject d3;

		void Awake()
		{
			o1.SetActive (true);
			o2.SetActive (true);
			d1.SetActive (true);
			d2.SetActive (false);
			d3.SetActive (false);

			if(ggj1.hasWeapon)
			{
				o1.SetActive (false);
				o2.SetActive (false);
				d1.SetActive (false);
				d2.SetActive (true);
			}

			if(ggj1.deliverWeapon)
			{
				o1.SetActive (false);
				o2.SetActive (false);
				d1.SetActive (false);
				d3.SetActive (true);
			}
		}
	}
}