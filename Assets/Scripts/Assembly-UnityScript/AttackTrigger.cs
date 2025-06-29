using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using DG.Tweening;
using UnityEngine;

[Serializable]
public class AttackTrigger : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024PlayerDead_0024904 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal AttackTrigger _0024self__0024905;

			public _0024(AttackTrigger self_)
			{
				_0024self__0024905 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Debug.Log("PlayerDead...");
					_0024self__0024905.deadFlag = true;
					_0024self__0024905.player.Controllable(false);
					_0024self__0024905.black.FadeSpeed = 0.04f;
					_0024self__0024905.black.FadeIn();
					_0024self__0024905.bgm.DOFade(0f, 1f).SetUpdate(true);
					result = (Yield(2, new WaitForSeconds(_0024self__0024905.black.FadeSpeed)) ? 1 : 0);
					break;
				case 2:
					_0024self__0024905.endFlag = true;
					_0024self__0024905.status.savePermission = true;
					_0024self__0024905.status.loadPermission = true;
					Time.timeScale = 1f;
					_0024self__0024905.status.nowEventing = false;
					_0024self__0024905.status.variables[14] = 11f;
					_0024self__0024905.status.variables[15] = 59f;
					_0024self__0024905.status.switches[15] = 1;
					_0024self__0024905.status.switches[28] = 1;
					_0024self__0024905.status.variables[10] = _0024self__0024905.status.variables[10] + 1f;
					_0024self__0024905.status.switches[419] = 0;
					_0024self__0024905.status.item[292] = 0;
					((GUITexture)GameObject.Find("Picture0").GetComponent(typeof(GUITexture))).guiTexture.texture = null;
					((GUITexture)GameObject.Find("Picture1").GetComponent(typeof(GUITexture))).guiTexture.texture = null;
					((GUITexture)GameObject.Find("Picture2").GetComponent(typeof(GUITexture))).guiTexture.texture = null;
					((GUITexture)GameObject.Find("Picture3").GetComponent(typeof(GUITexture))).guiTexture.texture = null;
					((GUITexture)GameObject.Find("Picture4").GetComponent(typeof(GUITexture))).guiTexture.texture = null;
					if (_0024self__0024905.steamManager != null)
					{
						_0024self__0024905.steamManager.SendMessage("UnlockSteamAchievement", 4, SendMessageOptions.DontRequireReceiver);
					}
					if (!(_0024self__0024905.status.variables[10] > 2f))
					{
						Application.LoadLevel("[00-]specimenroom1_2");
					}
					else
					{
						Application.LoadLevel("[00-]specimenroom1_3");
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AttackTrigger _0024self__0024906;

		public _0024PlayerDead_0024904(AttackTrigger self_)
		{
			_0024self__0024906 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024906);
		}
	}

	private Player_Status status;

	private BlackOutController black;

	private Player_Controller player;

	private bool deadFlag;

	private bool endFlag;

	private GameObject steamManager;

	private AudioSource bgm;

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		black = (BlackOutController)GameObject.Find("SystemObject").GetComponent(typeof(BlackOutController));
		player = (Player_Controller)GameObject.FindWithTag("Player").GetComponent(typeof(Player_Controller));
		steamManager = GameObject.FindWithTag("SteamManager");
		bgm = (AudioSource)GameObject.Find("BGM").GetComponent(typeof(AudioSource));
	}

	public virtual void Update()
	{
		if (deadFlag && !endFlag)
		{
			Time.timeScale = Mathf.MoveTowards(Time.timeScale, 0.04f, Time.unscaledTime * 1024f);
		}
	}

	public virtual void OnTriggerStay(Collider collisionInfo)
	{
		if (collisionInfo.tag == "Player")
		{
			Debug.Log("AttackHit!");
			if (!status.nowChangeLeveling && !deadFlag)
			{
				StartCoroutine_Auto(PlayerDead());
			}
		}
	}

	public virtual IEnumerator PlayerDead()
	{
		return new _0024PlayerDead_0024904(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
