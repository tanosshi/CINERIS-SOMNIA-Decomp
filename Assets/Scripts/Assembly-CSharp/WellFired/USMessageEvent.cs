using UnityEngine;

namespace WellFired
{
	[USequencerEventHideDuration]
	[USequencerFriendlyName("Debug Message")]
	[USequencerEvent("Debug/Log Message")]
	public class USMessageEvent : USEventBase
	{
		public string message = "Default Message";

		public override void FireEvent()
		{
			Debug.Log(message);
		}

		public override void ProcessEvent(float deltaTime)
		{
		}
	}
}
