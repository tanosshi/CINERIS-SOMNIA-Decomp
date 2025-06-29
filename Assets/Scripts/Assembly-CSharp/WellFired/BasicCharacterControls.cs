using UnityEngine;

namespace WellFired
{
	public class BasicCharacterControls : MonoBehaviour
	{
		public USSequencer cutscene;

		public float strength = 10f;

		private void Update()
		{
			if (!cutscene || !cutscene.IsPlaying)
			{
				float num = strength * Time.deltaTime;
				if (Input.GetKey(KeyCode.W))
				{
					GetComponent<Rigidbody>().AddRelativeForce(0f - num, 0f, 0f);
				}
				if (Input.GetKey(KeyCode.S))
				{
					GetComponent<Rigidbody>().AddRelativeForce(num, 0f, 0f);
				}
				if (Input.GetKey(KeyCode.A))
				{
					GetComponent<Rigidbody>().AddRelativeForce(0f, 0f, 0f - num);
				}
				if (Input.GetKey(KeyCode.D))
				{
					GetComponent<Rigidbody>().AddRelativeForce(0f, 0f, num);
				}
			}
		}
	}
}
