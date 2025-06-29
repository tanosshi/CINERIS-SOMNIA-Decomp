using UnityEngine;

namespace WellFired
{
	[USequencerFriendlyName("Send Message (Int)")]
	[USequencerEvent("Signal/Send Message (Int)")]
	[USequencerEventHideDuration]
	public class USSendMessageIntEvent : USEventBase
	{
		public GameObject receiver;

		public string action = "OnSignal";

		[SerializeField]
		private int valueToSend;

		public override void FireEvent()
		{
			if (Application.isPlaying)
			{
				if ((bool)receiver)
				{
					receiver.SendMessage(action, valueToSend);
				}
				else
				{
					Debug.LogWarning(string.Format("No receiver of signal \"{0}\" on object {1} ({2})", action, receiver.name, receiver.GetType().Name), receiver);
				}
			}
		}

		public override void ProcessEvent(float deltaTime)
		{
		}
	}
}
