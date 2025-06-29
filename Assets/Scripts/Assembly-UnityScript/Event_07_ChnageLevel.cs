using System;
using UnityEngine;

[Serializable]
public class Event_07_ChnageLevel : MonoBehaviour
{
	public CtrlChangeLevel[] state;

	private LevelChanger changer;

	private Player_Status status;

	private AudioManager audioManager;

	public virtual void Start()
	{
		changer = (LevelChanger)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(LevelChanger));
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		audioManager = (AudioManager)GameObject.Find("SystemObject").GetComponent(typeof(AudioManager));
	}

	public virtual void ChangeLevel(int num)
	{
		StartCoroutine_Auto(changer.ChangeLevel(state[num].nextLevelName, state[num].nextLevelId, state[num].nextPlayerX, state[num].nextPlayerY, state[num].nextPlayerZ, state[num].nextPlayerRotate, state[num].nextCameraX, state[num].nextCameraY, state[num].nextCameraZ, state[num].nextCameraRotX, state[num].nextCameraRotY, state[num].startSEId, state[num].endSEId, state[num].fade, state[num].fadeSpeed, state[num].fadeColor));
		if (state[num].audioFade)
		{
			changer.gameObject.SendMessage("ChangeAudioFadeFlag", true, SendMessageOptions.DontRequireReceiver);
			audioManager.AudioFadeOut(state[num].audioFadeSpeed);
		}
		SendMessage("ExitCommandProcessing", SendMessageOptions.DontRequireReceiver);
	}

	public virtual void SetAudioVolume(float audioVolume)
	{
		AudioListener.volume = audioVolume;
	}

	public virtual void Main()
	{
	}
}
