using UnityEngine;

namespace WellFired
{
	[USequencerEventHideDuration]
	[USequencerEvent("Animation (Mecanim)/Animator/Toggle Animate Physics")]
	[USequencerFriendlyName("Toggle Animate Physics")]
	public class USToggleAnimatorAnimatePhysics : USEventBase
	{
		public bool animatePhysics = true;

		private bool prevAnimatePhysics;

		public override void FireEvent()
		{
			Animator component = base.AffectedObject.GetComponent<Animator>();
			if (!component)
			{
				Debug.LogWarning("Affected Object has no Animator component, for uSequencer Event", this);
				return;
			}
			prevAnimatePhysics = component.animatePhysics;
			component.animatePhysics = animatePhysics;
		}

		public override void ProcessEvent(float runningTime)
		{
		}

		public override void StopEvent()
		{
			UndoEvent();
		}

		public override void UndoEvent()
		{
			Animator component = base.AffectedObject.GetComponent<Animator>();
			if ((bool)component)
			{
				component.animatePhysics = prevAnimatePhysics;
			}
		}
	}
}
