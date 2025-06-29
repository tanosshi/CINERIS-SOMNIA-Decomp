using System;
using UnityEngine;

[Serializable]
public class Event_18_PlaySE : MonoBehaviour
{
	public CtrlPlaySE[] state;

	private Player_Status status;

	private AudioSource[] source;

	private bool[] pauseFlag;

	private int i;

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		source = new AudioSource[state.Length];
		pauseFlag = new bool[state.Length];
		for (i = 0; i < state.Length; i++)
		{
			source[i] = (AudioSource)state[i].target.GetComponent(typeof(AudioSource));
			pauseFlag[i] = false;
		}
	}

	public virtual void Update()
	{
		for (i = 0; i < state.Length; i++)
		{
			if (source[i].isPlaying && status.nowPausing)
			{
				source[i].Pause();
				pauseFlag[i] = true;
			}
			else if (!source[i].isPlaying && !status.nowPausing && pauseFlag[i])
			{
				source[i].Play();
				pauseFlag[i] = false;
			}
		}
	}

	public virtual void PlaySE(int num)
	{
		if (state[num].audioFile != null)
		{
			source[num].volume = state[num].volume;
			source[num].pitch = state[num].pitch;
			source[num].clip = state[num].audioFile;
			source[num].Play();
		}
		else
		{
			source[num].clip = null;
			source[num].Stop();
		}
		SendMessage("ExitCommandProcessing");
	}

	public virtual void Main()
	{
	}
}
