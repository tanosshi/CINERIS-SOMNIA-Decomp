using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class Event_31_InputNumber : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024InputNumber_00241105 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal int _0024num_00241106;

			internal Event_31_InputNumber _0024self__00241107;

			public _0024(int num, Event_31_InputNumber self_)
			{
				_0024num_00241106 = num;
				_0024self__00241107 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241107.passageTemp = _0024self__00241107.state[_0024num_00241106];
					_0024self__00241107.StartCoroutine_Auto(_0024self__00241107.SetPassage(_0024self__00241107.passageTemp));
					goto IL_005b;
				case 2:
					if (_0024self__00241107.nowShowing)
					{
						goto IL_005b;
					}
					_0024self__00241107.gText.text = string.Empty;
					_0024self__00241107.gText.font = _0024self__00241107.status.defaultFont;
					_0024self__00241107.gText.anchor = TextAnchor.LowerCenter;
					_0024self__00241107.SendMessage("ExitCommandProcessing");
					YieldDefault(1);
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_005b:
					result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024num_00241108;

		internal Event_31_InputNumber _0024self__00241109;

		public _0024InputNumber_00241105(int num, Event_31_InputNumber self_)
		{
			_0024num_00241108 = num;
			_0024self__00241109 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024num_00241108, _0024self__00241109);
		}
	}

	[Serializable]
	internal sealed class _0024SetPassage_00241110 : GenericGenerator<YieldInstruction>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<YieldInstruction>, IEnumerator
		{
			internal int _0024k_00241111;

			internal int[] _0024num_00241112;

			internal TextAnchor _0024_0024switch_0024182_00241113;

			internal CtrlInputNumber _0024pas_00241114;

			internal Event_31_InputNumber _0024self__00241115;

			public _0024(CtrlInputNumber pas, Event_31_InputNumber self_)
			{
				_0024pas_00241114 = pas;
				_0024self__00241115 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024k_00241111 = default(int);
					_0024num_00241112 = null;
					_0024num_00241112 = new int[_0024pas_00241114.length];
					for (_0024k_00241111 = 0; _0024k_00241111 < _0024pas_00241114.length; _0024k_00241111++)
					{
						_0024num_00241112[_0024k_00241111] = 0;
					}
					_0024self__00241115.nowShowing = true;
					if (_0024pas_00241114.font == null)
					{
						_0024self__00241115.gText.font = _0024self__00241115.status.defaultFont;
					}
					else
					{
						_0024self__00241115.gText.font = _0024pas_00241114.font;
					}
					_0024_0024switch_0024182_00241113 = _0024pas_00241114.anchor;
					if (_0024_0024switch_0024182_00241113 == TextAnchor.UpperLeft)
					{
						_0024self__00241115.gText.anchor = TextAnchor.UpperLeft;
					}
					else if (_0024_0024switch_0024182_00241113 == TextAnchor.UpperCenter)
					{
						_0024self__00241115.gText.anchor = TextAnchor.UpperCenter;
					}
					else if (_0024_0024switch_0024182_00241113 == TextAnchor.UpperRight)
					{
						_0024self__00241115.gText.anchor = TextAnchor.UpperRight;
					}
					else if (_0024_0024switch_0024182_00241113 == TextAnchor.MiddleLeft)
					{
						_0024self__00241115.gText.anchor = TextAnchor.MiddleLeft;
					}
					else if (_0024_0024switch_0024182_00241113 == TextAnchor.MiddleCenter)
					{
						_0024self__00241115.gText.anchor = TextAnchor.MiddleCenter;
					}
					else if (_0024_0024switch_0024182_00241113 == TextAnchor.MiddleRight)
					{
						_0024self__00241115.gText.anchor = TextAnchor.MiddleRight;
					}
					else if (_0024_0024switch_0024182_00241113 == TextAnchor.LowerLeft)
					{
						_0024self__00241115.gText.anchor = TextAnchor.LowerLeft;
					}
					else if (_0024_0024switch_0024182_00241113 == TextAnchor.LowerCenter)
					{
						_0024self__00241115.gText.anchor = TextAnchor.LowerCenter;
					}
					else if (_0024_0024switch_0024182_00241113 == TextAnchor.LowerRight)
					{
						_0024self__00241115.gText.anchor = TextAnchor.LowerRight;
					}
					_0024self__00241115.gText.text = string.Empty;
					if (_0024pas_00241114.length != 0)
					{
						_0024self__00241115.cursor = 0;
						goto IL_0269;
					}
					goto IL_0837;
				case 2:
					if (Input.GetAxisRaw("Horizontal") == 0f)
					{
						goto IL_0594;
					}
					goto IL_0563;
				case 3:
					if (Input.GetAxisRaw("Horizontal") == 0f)
					{
						goto IL_061f;
					}
					goto IL_05ee;
				case 4:
					if (Input.GetAxisRaw("Vertical") == 0f)
					{
						goto IL_06bb;
					}
					goto IL_068a;
				case 5:
					if (Input.GetAxisRaw("Vertical") == 0f)
					{
						goto IL_0757;
					}
					goto IL_0726;
				case 6:
					if (!_0024self__00241115.nowShowing)
					{
						goto IL_0837;
					}
					goto IL_0269;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0563:
					result = (Yield(2, new WaitForSeconds(1E-07f)) ? 1 : 0);
					break;
					IL_0269:
					_0024self__00241115.gText.text = string.Empty;
					if (_0024self__00241115.status.language == 0)
					{
						if (_0024pas_00241114.firstText_Jap != string.Empty)
						{
							_0024self__00241115.gText.text = _0024self__00241115.gText.text + _0024pas_00241114.firstText_Jap;
							_0024self__00241115.gText.text = _0024self__00241115.gText.text + "\n";
						}
					}
					else if (_0024pas_00241114.firstText_Eng != string.Empty)
					{
						_0024self__00241115.gText.text = _0024self__00241115.gText.text + _0024pas_00241114.firstText_Eng;
						_0024self__00241115.gText.text = _0024self__00241115.gText.text + "\n";
					}
					for (_0024k_00241111 = 0; _0024k_00241111 < _0024pas_00241114.length; _0024k_00241111++)
					{
						if (_0024self__00241115.cursor == _0024k_00241111)
						{
							_0024self__00241115.gText.text = _0024self__00241115.gText.text + "《";
						}
						else
						{
							_0024self__00241115.gText.text = _0024self__00241115.gText.text + "\u3000";
						}
						_0024self__00241115.gText.text = _0024self__00241115.gText.text + _0024num_00241112[_0024k_00241111].ToString();
						if (_0024self__00241115.cursor == _0024k_00241111)
						{
							_0024self__00241115.gText.text = _0024self__00241115.gText.text + "》";
						}
						else
						{
							_0024self__00241115.gText.text = _0024self__00241115.gText.text + "\u3000";
						}
						if (_0024k_00241111 != _0024pas_00241114.length - 1)
						{
							_0024self__00241115.gText.text = _0024self__00241115.gText.text + "\t\t\t\t";
						}
					}
					if (!(Input.GetAxisRaw("Horizontal") < 0.1f))
					{
						_0024self__00241115.cursor++;
						if (_0024self__00241115.cursor >= _0024pas_00241114.length)
						{
							_0024self__00241115.cursor = 0;
						}
						goto IL_0563;
					}
					goto IL_0594;
					IL_05ee:
					result = (Yield(3, new WaitForSeconds(1E-07f)) ? 1 : 0);
					break;
					IL_0837:
					_0024self__00241115.nowShowing = false;
					YieldDefault(1);
					goto case 1;
					IL_0594:
					if (!(Input.GetAxisRaw("Horizontal") > -0.1f))
					{
						_0024self__00241115.cursor--;
						if (_0024self__00241115.cursor < 0)
						{
							_0024self__00241115.cursor = _0024pas_00241114.length - 1;
						}
						goto IL_05ee;
					}
					goto IL_061f;
					IL_0726:
					result = (Yield(5, new WaitForSeconds(1E-07f)) ? 1 : 0);
					break;
					IL_0757:
					_0024self__00241115.status.variables[_0024pas_00241114.variableNumber] = 0f;
					for (_0024k_00241111 = 0; _0024k_00241111 < _0024pas_00241114.length; _0024k_00241111++)
					{
						_0024self__00241115.status.variables[_0024pas_00241114.variableNumber] = _0024self__00241115.status.variables[_0024pas_00241114.variableNumber] + (float)_0024num_00241112[_0024k_00241111] * Mathf.Pow(10f, _0024pas_00241114.length - 1 - _0024k_00241111);
					}
					result = (Yield(6, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_068a:
					result = (Yield(4, new WaitForSeconds(1E-07f)) ? 1 : 0);
					break;
					IL_06bb:
					if (!(Input.GetAxisRaw("Vertical") > -0.1f))
					{
						_0024num_00241112[_0024self__00241115.cursor] = _0024num_00241112[_0024self__00241115.cursor] - 1;
						if (_0024num_00241112[_0024self__00241115.cursor] < 0)
						{
							_0024num_00241112[_0024self__00241115.cursor] = 9;
						}
						goto IL_0726;
					}
					goto IL_0757;
					IL_061f:
					if (!(Input.GetAxisRaw("Vertical") < 0.1f))
					{
						_0024num_00241112[_0024self__00241115.cursor] = _0024num_00241112[_0024self__00241115.cursor] + 1;
						if (_0024num_00241112[_0024self__00241115.cursor] > 9)
						{
							_0024num_00241112[_0024self__00241115.cursor] = 0;
						}
						goto IL_068a;
					}
					goto IL_06bb;
				}
				return (byte)result != 0;
			}
		}

		internal CtrlInputNumber _0024pas_00241116;

		internal Event_31_InputNumber _0024self__00241117;

		public _0024SetPassage_00241110(CtrlInputNumber pas, Event_31_InputNumber self_)
		{
			_0024pas_00241116 = pas;
			_0024self__00241117 = self_;
		}

		public override IEnumerator<YieldInstruction> GetEnumerator()
		{
			return new _0024(_0024pas_00241116, _0024self__00241117);
		}
	}

	public CtrlInputNumber[] state;

	private Player_Status status;

	private GUIText gText;

	private bool nowShowing;

	private int cursor;

	private CtrlInputNumber passageTemp;

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		gText = (GUIText)GameObject.Find("SystemObject").GetComponent(typeof(GUIText));
	}

	public virtual void Update()
	{
		if (nowShowing && Input.GetButtonDown("Action"))
		{
			nowShowing = false;
		}
	}

	public virtual IEnumerator InputNumber(int num)
	{
		return new _0024InputNumber_00241105(num, this).GetEnumerator();
	}

	public virtual IEnumerator SetPassage(CtrlInputNumber pas)
	{
		return new _0024SetPassage_00241110(pas, this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
