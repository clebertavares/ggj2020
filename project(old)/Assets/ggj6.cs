using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
namespace TrollBridge 
{
	public class ggj6 : MonoBehaviour 
	{
		public Action_Key_Dialogue a;

		void Update()
		{
			if (Input.GetKeyDown (KeyCode.Space) )
			{
				if (a.dialogueIndex == 0) {
					a.dialogueBox.transform.position = new Vector3 (-2.5f, a.dialogueBox.transform.position.y, a.dialogueBox.transform.position.z);
				}
				if (a.dialogueIndex == 1) {
					a.dialogueBox.transform.position = new Vector3 (2.5f, a.dialogueBox.transform.position.y, a.dialogueBox.transform.position.z);
				}
				if (a.dialogueIndex == 2) {
					a.dialogueBox.transform.position = new Vector3 (2.5f, a.dialogueBox.transform.position.y, a.dialogueBox.transform.position.z);
				}
				if (a.dialogueIndex == 3) {
					a.dialogueBox.transform.position = new Vector3 (-2.5f, a.dialogueBox.transform.position.y, a.dialogueBox.transform.position.z);
				}
				if (a.dialogueIndex == 4) {
					a.dialogueBox.transform.position = new Vector3 (-2.5f, a.dialogueBox.transform.position.y, a.dialogueBox.transform.position.z);
				}
				if (a.dialogueIndex == 5) {
					a.dialogueBox.transform.position = new Vector3 (2.5f, a.dialogueBox.transform.position.y, a.dialogueBox.transform.position.z);
				}
				if (a.dialogueIndex == 6) {
					a.dialogueBox.transform.position = new Vector3 (-2.5f, a.dialogueBox.transform.position.y, a.dialogueBox.transform.position.z);
				}
				if (a.dialogueIndex == 7) {
					a.dialogueBox.transform.position = new Vector3 (2.5f, a.dialogueBox.transform.position.y, a.dialogueBox.transform.position.z);
				}
				if (a.dialogueIndex == 8) {
					a.dialogueBox.transform.position = new Vector3 (-2.5f, a.dialogueBox.transform.position.y, a.dialogueBox.transform.position.z);
				}
				if (a.dialogueIndex == 9) {
					a.dialogueBox.transform.position = new Vector3 (2.5f, a.dialogueBox.transform.position.y, a.dialogueBox.transform.position.z);

				}
			} 

			if(Input.GetKeyDown(KeyCode.Space) && a.dialogueIndex == 10)
			{
				StartCoroutine (foo ());
			}

		}

		IEnumerator foo()
		{
			yield return new WaitForSeconds (0);
			SceneManager.LoadScene ("_GGJ2017@HARMONIA HouseSml (1)");
		}
	}
}
