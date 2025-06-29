using System;
using DG.Tweening;
using UnityEngine;

[Serializable]
public class Event_17_FadeoutBGMorBGS : MonoBehaviour
{
	public CtrlFadeoutBGM[] state;

	private AudioSource bgm;

	private AudioSource bgs;

	private AudioManager audioManager;

	public virtual void Start()
	{
		bgm = (AudioSource)GameObject.Find("BGM").GetComponent(typeof(AudioSource));
		bgs = (AudioSource)GameObject.Find("BGS").GetComponent(typeof(AudioSource));
		audioManager = (AudioManager)GameObject.Find("SystemObject").GetComponent(typeof(AudioManager));
	}

	public virtual void FadeoutBGMorBGS(int num)
	{
		if (state[num].type == BGMorBGS.BGM)
		{
			DOTween.Kill(bgm);
			bgm.DOFade(0f, state[num].fadeTime).SetUpdate(true).OnComplete(CompleteFadeoutBgm);
		}
		else
		{
			DOTween.Kill(bgs);
			bgs.DOFade(0f, state[num].fadeTime).SetUpdate(true).OnComplete(CompleteFadeoutBgs);
		}
		if (state[num].fixAmbientSound)
		{
			audioManager.FixAmbientSound(state[num].fadeTime, 1f);
		}
		SendMessage("ExitCommandProcessing");
	}

	public virtual void CompleteFadeoutBgm()
	{
		bgm.volume = 0f;
		bgm.Stop();
		bgm.audio.clip = null;
	}

	public virtual void CompleteFadeoutBgs()
	{
		bgs.volume = 0f;
		bgs.Stop();
		bgs.audio.clip = null;
	}

	public virtual void Main()
	{
	}
}
