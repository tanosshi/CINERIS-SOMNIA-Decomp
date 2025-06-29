using UnityEngine;

namespace WellFired
{
	[USequencerEvent("Transform/Look At Object")]
	[USequencerFriendlyName("Look At Object")]
	public class USLookAtObjectEvent : USEventBase
	{
		public GameObject objectToLookAt;

		public AnimationCurve inCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		public AnimationCurve outCurve = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(1f, 0f));

		public float lookAtTime = 2f;

		private Quaternion sourceOrientation = Quaternion.identity;

		private Quaternion previousRotation = Quaternion.identity;

		public override void FireEvent()
		{
			if (!objectToLookAt)
			{
				Debug.LogWarning("The USLookAtObject event does not provice a object to look at", this);
				return;
			}
			previousRotation = base.AffectedObject.transform.rotation;
			sourceOrientation = base.AffectedObject.transform.rotation;
		}

		public override void ProcessEvent(float deltaTime)
		{
			if (!objectToLookAt)
			{
				Debug.LogWarning("The USLookAtObject event does not provice a object to look at", this);
				return;
			}
			float time = inCurve[inCurve.length - 1].time;
			float num = lookAtTime + time;
			float t = 1f;
			if (deltaTime <= time)
			{
				t = Mathf.Clamp(inCurve.Evaluate(deltaTime), 0f, 1f);
			}
			else if (deltaTime >= num)
			{
				t = Mathf.Clamp(outCurve.Evaluate(deltaTime - num), 0f, 1f);
			}
			Vector3 position = base.AffectedObject.transform.position;
			Vector3 position2 = objectToLookAt.transform.position;
			Vector3 forward = position2 - position;
			Quaternion to = Quaternion.LookRotation(forward);
			base.AffectedObject.transform.rotation = Quaternion.Slerp(sourceOrientation, to, t);
		}

		public override void StopEvent()
		{
			UndoEvent();
		}

		public override void UndoEvent()
		{
			if ((bool)base.AffectedObject)
			{
				base.AffectedObject.transform.rotation = previousRotation;
			}
		}
	}
}
