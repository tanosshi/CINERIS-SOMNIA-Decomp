using UnityEngine;

namespace WellFired
{
	[USequencerFriendlyName("Stop Emitter (Legacy)")]
	[USequencerEventHideDuration]
	[USequencerEvent("Particle System/Stop Emitter")]
	public class USParticleEmitterStopEvent : USEventBase
	{
		public override void FireEvent()
		{
			ParticleSystem component = base.AffectedObject.GetComponent<ParticleSystem>();
			if (!component)
			{
				Debug.Log("Attempting to emit particles, but the object has no particleSystem USParticleEmitterStartEvent::FireEvent");
			}
			else
			{
				component.Stop();
			}
		}

		public override void ProcessEvent(float deltaTime)
		{
		}
	}
}
