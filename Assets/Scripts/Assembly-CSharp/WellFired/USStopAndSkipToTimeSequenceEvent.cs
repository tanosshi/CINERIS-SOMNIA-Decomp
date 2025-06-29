using UnityEngine;

namespace WellFired
{
	[USequencerFriendlyName("Stop and Skip sequencer")]
	[USequencerEvent("Sequence/Stop And Skip")]
	[USequencerEventHideDuration]
	public class USStopAndSkipToTimeSequenceEvent : USEventBase
	{
		[SerializeField]
		private USSequencer sequence;

		[SerializeField]
		private float timeToSkipTo;

		public override void FireEvent()
		{
			if (!sequence)
			{
				Debug.LogWarning("No sequence for USstopSequenceEvent : " + base.name, this);
			}
			if ((bool)sequence)
			{
				sequence.Stop();
				sequence.SkipTimelineTo(timeToSkipTo);
				sequence.UpdateSequencer(0f);
			}
		}

		public override void ProcessEvent(float deltaTime)
		{
		}
	}
}
