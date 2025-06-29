using System;

[Serializable]
public class CtrlFadeoutBGM
{
	public BGMorBGS type;

	public float fadeTime;

	public bool fixAmbientSound;

	public CtrlFadeoutBGM()
	{
		fixAmbientSound = true;
	}
}
