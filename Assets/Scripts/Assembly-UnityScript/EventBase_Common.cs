using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class EventBase_Common : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024CommonAction_00241018 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal eventType _0024_0024switch_0024162_00241019;

			internal int _0024num_00241020;

			internal EventBase_Common _0024self__00241021;

			public _0024(int num, EventBase_Common self_)
			{
				_0024num_00241020 = num;
				_0024self__00241021 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241021.playerStatus.nowEventing = true;
					_0024self__00241021.nowEventing = true;
					_0024self__00241021.activePageTemp = _0024num_00241020;
					result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				case 2:
					if (_0024self__00241021.pages[_0024self__00241021.activePageTemp].contents.Length != 0)
					{
						_0024self__00241021.k = 0;
						goto IL_0b5c;
					}
					goto IL_0b8d;
				case 3:
					if (_0024self__00241021.nowCommandProcessing)
					{
						result = (Yield(3, new WaitForEndOfFrame()) ? 1 : 0);
						break;
					}
					if (!_0024self__00241021.nowEventing)
					{
						goto IL_0b8d;
					}
					_0024self__00241021.k++;
					goto IL_0b5c;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0b5c:
					if (_0024self__00241021.k < _0024self__00241021.pages[_0024self__00241021.activePageTemp].contents.Length)
					{
						_0024self__00241021.nowCommandProcessing = true;
						_0024_0024switch_0024162_00241019 = _0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].type;
						if (_0024_0024switch_0024162_00241019 == eventType.ShowText)
						{
							_0024self__00241021.SendMessage("ShowText", _0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.ShowChoices)
						{
							_0024self__00241021.SendMessage("ShowChoices", _0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.ControlSwitches)
						{
							_0024self__00241021.SendMessage("ControlSwitches", _0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.ControlVariables)
						{
							_0024self__00241021.SendMessage("ControlVariables", _0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.ConditionalBranch)
						{
							_0024self__00241021.SendMessage("ConditionalBranch", _0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.ExitEventProcessing)
						{
							_0024self__00241021.StartCoroutine_Auto(_0024self__00241021.ExitEventProcessing());
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.JumpToNumber)
						{
							_0024self__00241021.SendMessage("JumpToNumber", _0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.ChangeLevel)
						{
							_0024self__00241021.SendMessage("ChangeLevel", _0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.SetObjectTransform)
						{
							_0024self__00241021.SendMessage("SetObjectTransform", _0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.SetMoveRoute)
						{
							_0024self__00241021.SendMessage("SetMoveRoute", _0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.FadeScreen)
						{
							_0024self__00241021.SendMessage("FadeScreen", _0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.FlashScreen)
						{
							_0024self__00241021.SendMessage("FlashScreen", _0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.Wait)
						{
							_0024self__00241021.StartCoroutine_Auto(_0024self__00241021.Wait(_0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number));
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.ShowPicture)
						{
							_0024self__00241021.SendMessage("ShowPicture", _0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.MovePicture)
						{
							_0024self__00241021.SendMessage("MovePicture", _0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.ErasePicture)
						{
							_0024self__00241021.ErasePicture(_0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.PlayBGMorBGS)
						{
							_0024self__00241021.SendMessage("PlayBGMorBGS", _0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.FadeoutBGMorBGS)
						{
							_0024self__00241021.SendMessage("FadeoutBGMorBGS", _0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.PlaySE)
						{
							_0024self__00241021.SendMessage("PlaySE", _0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.ChangePlayerControlable)
						{
							_0024self__00241021.ChangePlayerControlable(_0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.ChangeCameraControlable)
						{
							_0024self__00241021.ChangeCameraControlable(_0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.ChangeMenuAccess)
						{
							_0024self__00241021.SendMessage("ChangeMenuAccess", _0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.ChangeCameraInfo)
						{
							_0024self__00241021.SendMessage("ChangeCameraInfo", _0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.ChangeLightInfo)
						{
							_0024self__00241021.SendMessage("ChangeLightInfo", _0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.PlayAnimation)
						{
							_0024self__00241021.SendMessage("PlayAnimation", _0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.SetHeadLookTarget)
						{
							_0024self__00241021.SendMessage("SetHeadLookTarget", _0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.SetFootstepId)
						{
							_0024self__00241021.SendMessage("SetFootstepId", _0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.SendExtraMessage)
						{
							_0024self__00241021.SendMessage("SendExtraMessage", _0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.GetItem)
						{
							_0024self__00241021.SendMessage("GetItem", _0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.ChangeActive)
						{
							_0024self__00241021.SendMessage("ChangeActive", _0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.DestroyObjects)
						{
							_0024self__00241021.SendMessage("DestroyObjects", _0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						else if (_0024_0024switch_0024162_00241019 == eventType.InputNumber)
						{
							_0024self__00241021.SendMessage("InputNumber", _0024self__00241021.pages[_0024self__00241021.activePageTemp].contents[_0024self__00241021.k].number);
						}
						goto case 3;
					}
					goto IL_0b8d;
					IL_0b8d:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024num_00241022;

		internal EventBase_Common _0024self__00241023;

		public _0024CommonAction_00241018(int num, EventBase_Common self_)
		{
			_0024num_00241022 = num;
			_0024self__00241023 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024num_00241022, _0024self__00241023);
		}
	}

	[Serializable]
	internal sealed class _0024ExitEventProcessing_00241024 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal EventBase_Common _0024self__00241025;

			public _0024(EventBase_Common self_)
			{
				_0024self__00241025 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				case 2:
					_0024self__00241025.nowEventing = false;
					_0024self__00241025.playerStatus.nowEventing = false;
					_0024self__00241025.nowCommandProcessing = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal EventBase_Common _0024self__00241026;

		public _0024ExitEventProcessing_00241024(EventBase_Common self_)
		{
			_0024self__00241026 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024self__00241026);
		}
	}

	[Serializable]
	internal sealed class _0024Wait_00241027 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024num_00241028;

			internal EventBase_Common _0024self__00241029;

			public _0024(int num, EventBase_Common self_)
			{
				_0024num_00241028 = num;
				_0024self__00241029 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024num_00241028 > 0)
					{
						_0024self__00241029.w = 0;
						goto IL_0062;
					}
					goto IL_0078;
				case 2:
					_0024self__00241029.w++;
					goto IL_0062;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0078:
					_0024self__00241029.nowCommandProcessing = false;
					YieldDefault(1);
					goto case 1;
					IL_0062:
					if (_0024self__00241029.w < _0024num_00241028)
					{
						result = (Yield(2, new WaitForSeconds(0.1f)) ? 1 : 0);
						break;
					}
					goto IL_0078;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024num_00241030;

		internal EventBase_Common _0024self__00241031;

		public _0024Wait_00241027(int num, EventBase_Common self_)
		{
			_0024num_00241030 = num;
			_0024self__00241031 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024num_00241030, _0024self__00241031);
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

	private int tempSwitchTemp;

	private int i;

	private int j;

	private int k;

	private int w;

	private bool nowEventing;

	private bool nowCommandProcessing;

	private Transform myTransform;

	public EventBase_Common()
	{
		activePage = -1;
		activePageTemp2 = 999;
	}

	public virtual void Start()
	{
		playerStatus = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		if (GameObject.FindWithTag("Player") != null)
		{
			player = (Player_Controller)GameObject.FindWithTag("Player").GetComponent(typeof(Player_Controller));
		}
		mainCamera = (Camera_Controller)GameObject.FindWithTag("MainCamera").GetComponent(typeof(Camera_Controller));
		myTransform = transform;
	}

	public virtual void Update()
	{
		if (player == null && GameObject.FindWithTag("Player") != null)
		{
			player = (Player_Controller)GameObject.FindWithTag("Player").GetComponent(typeof(Player_Controller));
		}
		if (mainCamera == null)
		{
			mainCamera = (Camera_Controller)GameObject.FindWithTag("MainCamera").GetComponent(typeof(Camera_Controller));
		}
	}

	public virtual IEnumerator CommonAction(int num)
	{
		return new _0024CommonAction_00241018(num, this).GetEnumerator();
	}

	public virtual void ExitCommandProcessing()
	{
		nowCommandProcessing = false;
	}

	public virtual IEnumerator ExitEventProcessing()
	{
		return new _0024ExitEventProcessing_00241024(this).GetEnumerator();
	}

	public virtual void JumpToNumber(int num)
	{
		k = num - 1;
		nowCommandProcessing = false;
	}

	public virtual IEnumerator Wait(int num)
	{
		return new _0024Wait_00241027(num, this).GetEnumerator();
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

	public virtual void Main()
	{
	}
}
