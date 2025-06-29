using System;
using System.Reflection;
using UnityEngine;
using WellFired.Shared;

namespace WellFired
{
	[USequencerFriendlyName("Dissolve Transition")]
	[USequencerEvent("Camera/Transition/Dissolve")]
	[ExecuteInEditMode]
	public class USCameraDissolveTransition : USEventBase
	{
		[SerializeField]
		private Camera introCamera;

		[SerializeField]
		private Camera outroCamera;

		[SerializeField]
		private Material renderMaterial;

		private RenderTexture introRenderTexture;

		private RenderTexture outroRenderTexture;

		private bool shouldRender;

		private bool prevIntroCameraState;

		private bool prevOutroCameraState;

		private float alpha;

		private Vector2 MainGameViewSize
		{
			get
			{
				if (Application.isEditor)
				{
					Type type = Type.GetType("UnityEditor.GameView,UnityEditor");
					MethodInfo nonPublicStaticMethod = PlatformSpecificFactory.ReflectionHelper.GetNonPublicStaticMethod(type, "GetMainGameView");
					FieldInfo nonPublicInstanceField = PlatformSpecificFactory.ReflectionHelper.GetNonPublicInstanceField(type, "m_ShownResolution");
					object obj = nonPublicStaticMethod.Invoke(null, null);
					object value = nonPublicInstanceField.GetValue(obj);
					return (Vector2)value;
				}
				return new Vector2(Screen.width, Screen.height);
			}
			set
			{
			}
		}

		private RenderTexture IntroRenderTexture
		{
			get
			{
				if (introRenderTexture == null)
				{
					introRenderTexture = new RenderTexture((int)MainGameViewSize.x, (int)MainGameViewSize.y, 24);
				}
				return introRenderTexture;
			}
			set
			{
			}
		}

		private RenderTexture OutroRenderTexture
		{
			get
			{
				if (outroRenderTexture == null)
				{
					outroRenderTexture = new RenderTexture((int)MainGameViewSize.x, (int)MainGameViewSize.y, 24);
				}
				return outroRenderTexture;
			}
			set
			{
			}
		}

		private void OnGUI()
		{
			if (shouldRender)
			{
				renderMaterial.SetTexture("_SecondTex", OutroRenderTexture);
				renderMaterial.SetFloat("_Alpha", alpha);
				Graphics.Blit(IntroRenderTexture, null, renderMaterial);
			}
		}

		public override void FireEvent()
		{
			Debug.Log("Fire");
			if ((bool)introCamera)
			{
				prevIntroCameraState = introCamera.enabled;
			}
			if ((bool)outroCamera)
			{
				prevOutroCameraState = outroCamera.enabled;
			}
		}

		public override void ProcessEvent(float deltaTime)
		{
			Debug.Log("Process");
			if ((bool)introCamera)
			{
				introCamera.enabled = false;
			}
			if ((bool)outroCamera)
			{
				outroCamera.enabled = false;
			}
			if ((bool)introCamera)
			{
				introCamera.targetTexture = IntroRenderTexture;
				introCamera.Render();
			}
			if ((bool)outroCamera)
			{
				outroCamera.targetTexture = OutroRenderTexture;
				outroCamera.Render();
			}
			alpha = 1f - deltaTime / base.Duration;
			shouldRender = true;
		}

		public override void EndEvent()
		{
			Debug.Log("End");
			shouldRender = false;
			if ((bool)outroCamera)
			{
				outroCamera.enabled = true;
				outroCamera.targetTexture = null;
			}
			if ((bool)introCamera)
			{
				introCamera.enabled = false;
				introCamera.targetTexture = null;
			}
		}

		public override void StopEvent()
		{
			Debug.Log("Stop");
			UndoEvent();
		}

		public override void UndoEvent()
		{
			Debug.Log("Undo");
			if ((bool)introCamera)
			{
				introCamera.enabled = prevIntroCameraState;
				introCamera.targetTexture = null;
			}
			if ((bool)outroCamera)
			{
				outroCamera.enabled = prevOutroCameraState;
				outroCamera.targetTexture = null;
			}
			UnityEngine.Object.DestroyImmediate(IntroRenderTexture);
			UnityEngine.Object.DestroyImmediate(OutroRenderTexture);
			shouldRender = false;
		}
	}
}
