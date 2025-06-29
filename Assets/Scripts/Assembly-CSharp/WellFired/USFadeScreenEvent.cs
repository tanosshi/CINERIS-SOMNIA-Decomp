using UnityEngine;

namespace WellFired
{
	[USequencerFriendlyName("Fade Screen")]
	[USequencerEventHideDuration]
	[USequencerEvent("Fullscreen/Fade Screen")]
	public class USFadeScreenEvent : USEventBase
	{
		public UILayer uiLayer;

		public AnimationCurve fadeCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f), new Keyframe(3f, 1f), new Keyframe(4f, 0f));

		public Color fadeColour = Color.black;

		private float currentCurveSampleTime;

		public static Texture2D texture;

		public override void FireEvent()
		{
		}

		public override void ProcessEvent(float deltaTime)
		{
			currentCurveSampleTime = deltaTime;
			if (!texture)
			{
				texture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
			}
			float b = fadeCurve.Evaluate(currentCurveSampleTime);
			b = Mathf.Min(Mathf.Max(0f, b), 1f);
			texture.SetPixel(0, 0, new Color(fadeColour.r, fadeColour.g, fadeColour.b, b));
			texture.Apply();
		}

		public override void EndEvent()
		{
			if (!texture)
			{
				texture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
			}
			float b = fadeCurve.Evaluate(fadeCurve.keys[fadeCurve.length - 1].time);
			b = Mathf.Min(Mathf.Max(0f, b), 1f);
			texture.SetPixel(0, 0, new Color(fadeColour.r, fadeColour.g, fadeColour.b, b));
			texture.Apply();
		}

		public override void StopEvent()
		{
			UndoEvent();
		}

		public override void UndoEvent()
		{
			currentCurveSampleTime = 0f;
			if (!texture)
			{
				texture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
			}
			texture.SetPixel(0, 0, new Color(fadeColour.r, fadeColour.g, fadeColour.b, 0f));
			texture.Apply();
		}

		private void OnGUI()
		{
			if (!base.Sequence.IsPlaying)
			{
				return;
			}
			float num = 0f;
			Keyframe[] keys = fadeCurve.keys;
			for (int i = 0; i < keys.Length; i++)
			{
				Keyframe keyframe = keys[i];
				if (keyframe.time > num)
				{
					num = keyframe.time;
				}
			}
			base.Duration = num;
			if ((bool)texture)
			{
				int depth = GUI.depth;
				GUI.depth = (int)uiLayer;
				GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), texture);
				GUI.depth = depth;
			}
		}

		private void OnEnable()
		{
			if (texture == null)
			{
				texture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
			}
			texture.SetPixel(0, 0, new Color(fadeColour.r, fadeColour.g, fadeColour.b, 0f));
			texture.Apply();
		}
	}
}
