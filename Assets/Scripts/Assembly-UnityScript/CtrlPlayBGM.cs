using System;
using UnityEngine;

[Serializable]
public class CtrlPlayBGM
{
	public BGMorBGS type;

	public AudioClip audioFile;

	public float volume;

	public float pitch;

	public float startSeconds;

	public float fadeTime;

	public bool loop;

	public bool delay;

	public float delayTime;

	public bool fixAmbientSound;

	public float ambientSoundMultiply;

	public float ambientSoundFadeTime;

	public CtrlPlayBGM()
	{
		volume = 1f;
		pitch = 1f;
		loop = true;
		fixAmbientSound = true;
		ambientSoundMultiply = 0.5f;
		ambientSoundFadeTime = 0.5f;
	}
}
