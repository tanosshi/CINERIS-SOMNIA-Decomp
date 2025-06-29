using UnityEngine;

namespace WellFired
{
	[USequencerFriendlyName("Play Advanced Animation (Legacy)")]
	[USequencerEvent("Animation (Legacy)/Play Animation Advanced")]
	public class USPlayAdvancedAnimEvent : USEventBase
	{
		public AnimationClip animationClip;

		public WrapMode wrapMode;

		public AnimationBlendMode blendMode;

		public float playbackSpeed = 1f;

		public float animationWeight = 1f;

		public int animationLayer = 1;

		public bool crossFadeAnimation;

		public void Update()
		{
			if (wrapMode != WrapMode.Loop && (bool)animationClip)
			{
				base.Duration = animationClip.length / playbackSpeed;
			}
		}

		public override void FireEvent()
		{
			if (!animationClip)
			{
				Debug.Log("Attempting to play an animation on a GameObject but you haven't given the event an animation clip from USPlayAnimEvent::FireEvent");
				return;
			}
			Animation component = base.AffectedObject.GetComponent<Animation>();
			if (!component)
			{
				Debug.Log("Attempting to play an animation on a GameObject without an Animation Component from USPlayAnimEvent.FireEvent");
				return;
			}
			component.wrapMode = wrapMode;
			if (crossFadeAnimation)
			{
				component.CrossFade(animationClip.name);
			}
			else
			{
				component.Play(animationClip.name);
			}
			AnimationState animationState = component[animationClip.name];
			if ((bool)animationState)
			{
				animationState.enabled = true;
				animationState.weight = animationWeight;
				animationState.blendMode = blendMode;
				animationState.layer = animationLayer;
				animationState.speed = playbackSpeed;
			}
		}

		public override void ProcessEvent(float deltaTime)
		{
			Animation animation = base.AffectedObject.GetComponent<Animation>();
			if (!animation)
			{
				Debug.LogError(string.Concat("Trying to play an animation : ", animationClip.name, " but : ", base.AffectedObject, " doesn't have an animation component, we will add one, this time, though you should add it manually"));
				animation = base.AffectedObject.AddComponent<Animation>();
			}
			if (animation[animationClip.name] == null)
			{
				Debug.LogError("Trying to play an animation : " + animationClip.name + " but it isn't in the animation list. I will add it, this time, though you should add it manually.");
				animation.AddClip(animationClip, animationClip.name);
			}
			AnimationState animationState = animation[animationClip.name];
			if (!animation.IsPlaying(animationClip.name))
			{
				animation.wrapMode = wrapMode;
				if (crossFadeAnimation)
				{
					animation.CrossFade(animationClip.name);
				}
				else
				{
					animation.Play(animationClip.name);
				}
			}
			animationState.weight = animationWeight;
			animationState.blendMode = blendMode;
			animationState.layer = animationLayer;
			animationState.speed = playbackSpeed;
			animationState.time = deltaTime * playbackSpeed;
			animationState.enabled = true;
			animation.Sample();
		}

		public override void StopEvent()
		{
			if ((bool)base.AffectedObject)
			{
				Animation component = base.AffectedObject.GetComponent<Animation>();
				if ((bool)component)
				{
					component.Stop();
				}
			}
		}

		public override void EndEvent()
		{
			StopEvent();
		}
	}
}
