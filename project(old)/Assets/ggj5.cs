using UnityEngine;
using UnityEngine.SceneManagement;
namespace TrollBridge 
{
	public class ggj5 : MonoBehaviour
	{
		public Animator Hero;
		public Animator Vilain;
		int anim = 1000;
		public GameObject o;
		void Update()
		{			
				if(Input.GetKeyDown(KeyCode.Space))
				{
					anim += 1000;
				}
				Hero.SetInteger ("Direction", anim);
				Vilain.SetInteger ("Direction", anim);
		}
	}
}
