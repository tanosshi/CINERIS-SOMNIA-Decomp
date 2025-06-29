using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class EventBase : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Action_00241009 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal eventType _0024_0024switch_0024160_00241010;

			internal EventBase _0024self__00241011;

			public _0024(EventBase self_)
			{
				_0024self__00241011 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00241011.pages[_0024self__00241011.activePage].contents.Length != 0)
					{
						if (_0024self__00241011.pages[_0024self__00241011.activePage].trigger != Trigger.ParallelProcess && _0024self__00241011.pages[_0024self__00241011.activePage].trigger != Trigger.StayTrigger)
						{
							_0024self__00241011.playerStatus.nowEventing = true;
						}
						_0024self__00241011.nowEventing = true;
					}
					_0024self__00241011.activePageTemp = _0024self__00241011.activePage;
					result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				case 2:
					if (_0024self__00241011.pages[_0024self__00241011.activePageTemp].contents.Length != 0)
					{
						_0024self__00241011.k = 0;
						goto IL_0bbf;
					}
					goto IL_0bf0;
				case 3:
					if (_0024self__00241011.nowCommandProcessing)
					{
						result = (Yield(3, new WaitForEndOfFrame()) ? 1 : 0);
						break;
					}
					if (!_0024self__00241011.nowEventing)
					{
						goto IL_0bf0;
					}
					_0024self__00241011.k++;
					goto IL_0bbf;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0bbf:
					if (_0024self__00241011.k < _0024self__00241011.pages[_0024self__00241011.activePageTemp].contents.Length)
					{
						_0024self__00241011.nowCommandProcessing = true;
						_0024_0024switch_0024160_00241010 = _0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].type;
						if (_0024_0024switch_0024160_00241010 == eventType.ShowText)
						{
							_0024self__00241011.SendMessage("ShowText", _0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.ShowChoices)
						{
							_0024self__00241011.SendMessage("ShowChoices", _0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.ControlSwitches)
						{
							_0024self__00241011.SendMessage("ControlSwitches", _0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.ControlVariables)
						{
							_0024self__00241011.SendMessage("ControlVariables", _0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.ConditionalBranch)
						{
							_0024self__00241011.SendMessage("ConditionalBranch", _0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.ExitEventProcessing)
						{
							_0024self__00241011.ExitEventProcessing();
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.JumpToNumber)
						{
							_0024self__00241011.SendMessage("JumpToNumber", _0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.ChangeLevel)
						{
							_0024self__00241011.SendMessage("ChangeLevel", _0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.SetObjectTransform)
						{
							_0024self__00241011.SendMessage("SetObjectTransform", _0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.SetMoveRoute)
						{
							_0024self__00241011.SendMessage("SetMoveRoute", _0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.FadeScreen)
						{
							_0024self__00241011.SendMessage("FadeScreen", _0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.FlashScreen)
						{
							_0024self__00241011.SendMessage("FlashScreen", _0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.Wait)
						{
							_0024self__00241011.StartCoroutine_Auto(_0024self__00241011.Wait(_0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number));
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.ShowPicture)
						{
							_0024self__00241011.SendMessage("ShowPicture", _0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.MovePicture)
						{
							_0024self__00241011.SendMessage("MovePicture", _0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.ErasePicture)
						{
							_0024self__00241011.ErasePicture(_0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.PlayBGMorBGS)
						{
							_0024self__00241011.SendMessage("PlayBGMorBGS", _0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.FadeoutBGMorBGS)
						{
							_0024self__00241011.SendMessage("FadeoutBGMorBGS", _0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.PlaySE)
						{
							_0024self__00241011.SendMessage("PlaySE", _0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.ChangePlayerControlable)
						{
							_0024self__00241011.ChangePlayerControlable(_0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.ChangeCameraControlable)
						{
							_0024self__00241011.ChangeCameraControlable(_0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.ChangeMenuAccess)
						{
							_0024self__00241011.SendMessage("ChangeMenuAccess", _0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.ChangeCameraInfo)
						{
							_0024self__00241011.SendMessage("ChangeCameraInfo", _0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.ChangeLightInfo)
						{
							_0024self__00241011.SendMessage("ChangeLightInfo", _0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.PlayAnimation)
						{
							_0024self__00241011.SendMessage("PlayAnimation", _0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.SetHeadLookTarget)
						{
							_0024self__00241011.SendMessage("SetHeadLookTarget", _0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.SetFootstepId)
						{
							_0024self__00241011.SendMessage("SetFootstepId", _0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.SendExtraMessage)
						{
							_0024self__00241011.SendMessage("SendExtraMessage", _0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.GetItem)
						{
							_0024self__00241011.SendMessage("GetItem", _0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.ChangeActive)
						{
							_0024self__00241011.SendMessage("ChangeActive", _0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.DestroyObjects)
						{
							_0024self__00241011.SendMessage("DestroyObjects", _0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						else if (_0024_0024switch_0024160_00241010 == eventType.InputNumber)
						{
							_0024self__00241011.SendMessage("InputNumber", _0024self__00241011.pages[_0024self__00241011.activePageTemp].contents[_0024self__00241011.k].number);
						}
						goto case 3;
					}
					goto IL_0bf0;
					IL_0bf0:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal EventBase _0024self__00241012;

		public _0024Action_00241009(EventBase self_)
		{
			_0024self__00241012 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024self__00241012);
		}
	}

	[Serializable]
	internal sealed class _0024Wait_00241013 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024num_00241014;

			internal EventBase _0024self__00241015;

			public _0024(int num, EventBase self_)
			{
				_0024num_00241014 = num;
				_0024self__00241015 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024num_00241014 > 0)
					{
						_0024self__00241015.w = 0;
						goto IL_0062;
					}
					goto IL_0078;
				case 2:
					_0024self__00241015.w++;
					goto IL_0062;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0078:
					_0024self__00241015.nowCommandProcessing = false;
					YieldDefault(1);
					goto case 1;
					IL_0062:
					if (_0024self__00241015.w < _0024num_00241014)
					{
						result = (Yield(2, new WaitForSeconds(0.1f)) ? 1 : 0);
						break;
					}
					goto IL_0078;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024num_00241016;

		internal EventBase _0024self__00241017;

		public _0024Wait_00241013(int num, EventBase self_)
		{
			_0024num_00241016 = num;
			_0024self__00241017 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024num_00241016, _0024self__00241017);
		}
	}

	public Pages[] pages;

	private Player_Status playerStatus;

	private Player_Controller player;

	private Camera_Controller mainCamera;

	private int activePage;

	private int activePageTemp;

	private int activePageTemp2;

	private int switchTemp;

	private int variableTemp;

	private int angleTemp;

	private int i;

	private int j;

	private int k;

	private int w;

	private bool nowEventing;

	private bool nowCommandProcessing;

	private Transform myTransform;

	private Transform playerTransform;

	private bool firstActive;

	public EventBase()
	{
		activePage = -1;
		activePageTemp2 = 999;
	}

	public virtual void Start()
	{
		playerStatus = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		player = (Player_Controller)GameObject.FindWithTag("Player").GetComponent(typeof(Player_Controller));
		mainCamera = (Camera_Controller)GameObject.FindWithTag("MainCamera").GetComponent(typeof(Camera_Controller));
		myTransform = transform;
		if (player != null)
		{
			playerTransform = player.transform;
		}
	}

	public virtual void Update()
	{
		if (pages.Length != 0)
		{
			for (i = pages.Length - 1; i >= 0; i--)
			{
				switchTemp = 0;
				variableTemp = 0;
				angleTemp = 0;
				for (j = 0; j < pages[i].conditions.switchIsOn.Length; j++)
				{
					if (playerStatus.switches[pages[i].conditions.switchIsOn[j]] == 1)
					{
						switchTemp++;
					}
				}
				for (j = 0; j < pages[i].conditions.variables.Length; j++)
				{
					if (!(playerStatus.variables[pages[i].conditions.variables[j].variableNumber] < (float)pages[i].conditions.variables[j].valueOrAbove))
					{
						variableTemp++;
					}
				}
				for (j = 0; j < pages[i].conditions.tempSwitchIsOn.Length; j++)
				{
					if (!(pages[i].conditions.tempSwitchIsOn[j].minAngles >= pages[i].conditions.tempSwitchIsOn[j].maxAngles))
					{
						if (!(playerTransform.eulerAngles.y < pages[i].conditions.tempSwitchIsOn[j].minAngles) && !(playerTransform.eulerAngles.y > pages[i].conditions.tempSwitchIsOn[j].maxAngles))
						{
							angleTemp++;
						}
					}
					else if ((!(playerTransform.eulerAngles.y < pages[i].conditions.tempSwitchIsOn[j].minAngles) && playerTransform.eulerAngles.y <= 360f) || (!(playerTransform.eulerAngles.y < 0f) && !(playerTransform.eulerAngles.y > pages[i].conditions.tempSwitchIsOn[j].maxAngles)))
					{
						angleTemp++;
					}
				}
				if (switchTemp >= pages[i].conditions.switchIsOn.Length && variableTemp >= pages[i].conditions.variables.Length && angleTemp >= pages[i].conditions.tempSwitchIsOn.Length)
				{
					activePage = i;
					break;
				}
			}
		}
		if (!nowEventing)
		{
			if (activePageTemp2 != activePage)
			{
				if (gameObject.renderer != null && gameObject.renderer.material != null)
				{
					if (pages[activePage].show && !gameObject.renderer.enabled)
					{
						gameObject.renderer.enabled = true;
					}
					else if (!pages[activePage].show && gameObject.renderer.enabled)
					{
						gameObject.renderer.enabled = false;
					}
				}
				if (pages[activePage].objectTransform != null)
				{
					if (myTransform.position != pages[activePage].objectTransform.position)
					{
						myTransform.position = pages[activePage].objectTransform.position;
					}
					if (myTransform.rotation != pages[activePage].objectTransform.rotation)
					{
						myTransform.rotation = pages[activePage].objectTransform.rotation;
					}
					if (myTransform.localScale != pages[activePage].objectTransform.localScale)
					{
						myTransform.localScale = pages[activePage].objectTransform.localScale;
					}
				}
				activePageTemp2 = activePage;
			}
			if ((pages[activePage].trigger == Trigger.AutoRun && !playerStatus.nowEventing) || pages[activePage].trigger == Trigger.ParallelProcess)
			{
				StartCoroutine_Auto(Action());
			}
		}
		firstActive = true;
	}

	public virtual IEnumerator Action()
	{
		return new _0024Action_00241009(this).GetEnumerator();
	}

	public virtual void ExitCommandProcessing()
	{
		nowCommandProcessing = false;
	}

	public virtual void ActionButton()
	{
		if (pages[activePage].trigger == Trigger.ActionButton && pages[activePage].contents.Length != 0)
		{
			StartCoroutine_Auto(Action());
		}
	}

	public virtual void OnTriggerEnter(Collider collisionInfo)
	{
		if (firstActive && collisionInfo.gameObject.tag == "Player" && pages[activePage].trigger == Trigger.EnterTrigger && pages[activePage].contents.Length != 0 && !playerStatus.nowEventing)
		{
			StartCoroutine_Auto(Action());
		}
	}

	public virtual void OnTriggerStay(Collider collisionInfo)
	{
		if (!firstActive)
		{
			return;
		}
		if (collisionInfo.gameObject.tag == "Player" && pages[activePage].trigger == Trigger.StayTrigger && pages[activePage].contents.Length != 0)
		{
			StartCoroutine_Auto(Action());
		}
		if (activePage < 0)
		{
			return;
		}
		if (pages[activePage].trigger == Trigger.ActionButton && pages[activePage].contents.Length > 0)
		{
			if (collisionInfo.gameObject.tag == "ActionTrigger")
			{
				collisionInfo.SendMessage("SetActionTarget", this);
			}
		}
		else if (collisionInfo.gameObject.tag == "ActionTrigger")
		{
			collisionInfo.SendMessage("DeleteActionTarget", this);
		}
	}

	public virtual void OnTriggerExit(Collider collisionInfo)
	{
		if (collisionInfo.gameObject.tag == "Player" && pages[activePage].trigger == Trigger.ExitTrigger && pages[activePage].contents.Length != 0 && !playerStatus.nowEventing)
		{
			StartCoroutine_Auto(Action());
		}
		if (collisionInfo.gameObject.tag == "ActionTrigger")
		{
			collisionInfo.SendMessage("DeleteActionTarget", this);
		}
	}

	public virtual void ExitEventProcessing()
	{
		nowEventing = false;
		if (pages[activePage].trigger != Trigger.ParallelProcess && pages[activePage].trigger != Trigger.StayTrigger && !playerStatus.nowChangeLeveling)
		{
			playerStatus.nowEventing = false;
		}
		nowCommandProcessing = false;
	}

	public virtual void JumpToNumber(int num)
	{
		k = num - 1;
		nowCommandProcessing = false;
	}

	public virtual IEnumerator Wait(int num)
	{
		return new _0024Wait_00241013(num, this).GetEnumerator();
	}

	public virtual void ErasePicture(int num)
	{
		((GUITexture)GameObject.Find("Picture" + num.ToString()).GetComponent(typeof(GUITexture))).guiTexture.texture = null;
		nowCommandProcessing = false;
	}

	public virtual void ChangePlayerControlable(int num)
	{
		switch (num)
		{
		case 0:
			player.isControllable = false;
			break;
		case 1:
			player.isControllable = true;
			break;
		case 2:
			player.canRun = false;
			break;
		default:
			player.canRun = true;
			break;
		}
		nowCommandProcessing = false;
	}

	public virtual void ChangeCameraControlable(int num)
	{
		if (num == 0)
		{
			mainCamera.DontControllCamera(true);
		}
		else
		{
			mainCamera.DontControllCamera(false);
		}
		nowCommandProcessing = false;
	}

	public virtual int GetActivePage()
	{
		return activePage;
	}

	public virtual void Main()
	{
	}
}
