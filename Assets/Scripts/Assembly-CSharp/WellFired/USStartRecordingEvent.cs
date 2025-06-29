using UnityEngine;

namespace WellFired
{
	[USequencerEventHideDuration]
	[USequencerFriendlyName("Start Recording")]
	[USequencerEvent("Recording/Start Recording")]
	public class USStartRecordingEvent : USEventBase
	{
		public override void FireEvent()
		{
			if (!Application.isPlaying)
			{
				Debug.Log("Recording events only work when in play mode");
			}
			else
			{
				USRuntimeUtility.StartRecordingSequence(base.Sequence, USRecordRuntimePreferences.CapturePath, USRecord.GetFramerate(), USRecord.GetUpscaleAmount());
			}
		}

		public override void ProcessEvent(float deltaTime)
		{
		}
	}
}
