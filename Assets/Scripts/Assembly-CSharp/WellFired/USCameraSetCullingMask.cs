using UnityEngine;

namespace WellFired
{
	[USequencerEvent("Camera/Set Culling Mask")]
	[USequencerEventHideDuration]
	[ExecuteInEditMode]
	[USequencerFriendlyName("Set Culling Mask")]
	public class USCameraSetCullingMask : USEventBase
	{
		[SerializeField]
		private LayerMask newLayerMask;

		private int prevLayerMask;

		private Camera cameraToAffect;

		public override void FireEvent()
		{
			if (base.AffectedObject != null)
			{
				cameraToAffect = base.AffectedObject.GetComponent<Camera>();
			}
			if ((bool)cameraToAffect)
			{
				prevLayerMask = cameraToAffect.cullingMask;
				cameraToAffect.cullingMask = newLayerMask;
			}
		}

		public override void ProcessEvent(float deltaTime)
		{
		}

		public override void EndEvent()
		{
		}

		public override void StopEvent()
		{
			UndoEvent();
		}

		public override void UndoEvent()
		{
			if ((bool)cameraToAffect)
			{
				cameraToAffect.cullingMask = prevLayerMask;
			}
		}
	}
}
