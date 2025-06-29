using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class StartPositionSetter : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024SetControllable_00241387 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal StartPositionSetter _0024self__00241388;

			public _0024(StartPositionSetter self_)
			{
				_0024self__00241388 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00241388.Status.saveLoadFlag == 2 || _0024self__00241388.Status.saveLoadFlag == 3)
					{
						result = (Yield(2, new WaitForSeconds(_0024self__00241388.waitTime.firstFadeWaitTime + _0024self__00241388.waitTime.FadeSpeed)) ? 1 : 0);
						break;
					}
					if (_0024self__00241388.Status.audioFadeFlag)
					{
						_0024self__00241388.Status.audioFadeFlag = false;
					}
					result = (Yield(3, new WaitForSeconds(_0024self__00241388.waitTime.firstFadeWaitTime + _0024self__00241388.waitTime.FadeSpeed)) ? 1 : 0);
					break;
				case 2:
					UnityEngine.Object.Destroy(_0024self__00241388);
					goto IL_0124;
				case 3:
					if (!_0024self__00241388.Status.nowEventing)
					{
						_0024self__00241388.player.Controllable(true);
						_0024self__00241388.cameraMain.DontControllCamera(false);
					}
					UnityEngine.Object.Destroy(_0024self__00241388);
					goto IL_0124;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0124:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal StartPositionSetter _0024self__00241389;

		public _0024SetControllable_00241387(StartPositionSetter self_)
		{
			_0024self__00241389 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241389);
		}
	}

	public bool notSet_Debug;

	private Player_Status Status;

	private Player_Controller player;

	private BlackOutController waitTime;

	private Camera_Controller cameraMain;

	public virtual void Start()
	{
		Status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		player = (Player_Controller)GameObject.FindWithTag("Player").GetComponent(typeof(Player_Controller));
		cameraMain = (Camera_Controller)GameObject.FindWithTag("MainCamera").GetComponent(typeof(Camera_Controller));
		waitTime = (BlackOutController)GetComponent(typeof(BlackOutController));
		if (waitTime.notWait_Debug)
		{
			waitTime.firstFadeWaitTime = 0f;
		}
		else if (!Status.fadeFlag)
		{
			waitTime.firstFadeWaitTime = 0f;
			waitTime.FadeSpeed = 0f;
		}
		if (player != null)
		{
			if (!notSet_Debug && !(Time.realtimeSinceStartup <= 2f))
			{
				player.gameObject.transform.position = new Vector3(Status.mapX, Status.mapY, Status.mapZ);
				float playerRotation = Status.playerRotation;
				Vector3 eulerAngles = player.gameObject.transform.eulerAngles;
				float num = (eulerAngles.y = playerRotation);
				Vector3 vector = (player.gameObject.transform.eulerAngles = eulerAngles);
				player.ChangeFootstepId(Status.footStepId);
				player.ChangeFootEffectId(Status.footEffectId);
			}
			StartCoroutine_Auto(SetControllable());
		}
		if (cameraMain != null)
		{
			cameraMain.gameObject.transform.position = new Vector3(Status.cameraX, Status.cameraY, Status.cameraZ);
			cameraMain.FixedRot(Status.cameraRotX, Status.cameraRotY);
		}
		Status.mapName = Application.loadedLevelName;
	}

	public virtual IEnumerator SetControllable()
	{
		return new _0024SetControllable_00241387(this).GetEnumerator();
	}

	public virtual void SetAudioVolume(float audioVolume)
	{
		AudioListener.volume = audioVolume;
	}

	public virtual void Main()
	{
	}
}
