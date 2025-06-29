using UnityEngine;

namespace WellFired
{
	[USequencerEventHideDuration]
	[USequencerFriendlyName("Stop Recording")]
	[USequencerEvent("Recording/Stop Recording")]
	public class USStopRecordingEvent : USEventBase
	{
		public override void FireEvent()
		{
			if (!Application.isPlaying)
			{
				Debug.Log("Recording events only work when in play mode");
			}
			else
			{
				USRuntimeUtility.StopRecordingSequence();
			}
		}

		public override void ProcessEvent(float deltaTime)
		{
		}
	}
}
