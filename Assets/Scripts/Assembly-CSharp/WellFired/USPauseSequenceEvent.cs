using UnityEngine;

namespace WellFired
{
	[USequencerEvent("Sequence/Pause uSequence")]
	[USequencerFriendlyName("Pause uSequence")]
	[USequencerEventHideDuration]
	public class USPauseSequenceEvent : USEventBase
	{
		public USSequencer sequence;

		public override void FireEvent()
		{
			if (!sequence)
			{
				Debug.LogWarning("No sequence for USPauseSequenceEvent : " + base.name, this);
			}
			if ((bool)sequence)
			{
				sequence.Pause();
			}
		}

		public override void ProcessEvent(float deltaTime)
		{
		}
	}
}
