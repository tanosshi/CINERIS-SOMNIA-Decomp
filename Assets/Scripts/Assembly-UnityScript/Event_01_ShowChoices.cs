using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class Event_01_ShowChoices : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024ShowChoices_00241063 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal float _0024_0024437_00241064;

			internal Vector3 _0024_0024438_00241065;

			internal int _0024num_00241066;

			internal Event_01_ShowChoices _0024self__00241067;

			public _0024(int num, Event_01_ShowChoices self_)
			{
				_0024num_00241066 = num;
				_0024self__00241067 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241067.passageTemp = _0024self__00241067.state[_0024num_00241066];
					_0024self__00241067.StartCoroutine_Auto(_0024self__00241067.SetPassage(_0024self__00241067.passageTemp));
					goto IL_005b;
				case 2:
				{
					if (_0024self__00241067.nowShowing)
					{
						goto IL_005b;
					}
					_0024self__00241067.gText.text = string.Empty;
					_0024self__00241067.gText.font = _0024self__00241067.status.defaultFont;
					_0024self__00241067.gText.anchor = TextAnchor.LowerCenter;
					float num = (_0024_0024437_00241064 = 0f);
					Vector3 vector = (_0024_0024438_00241065 = _0024self__00241067.gText.gameObject.transform.position);
					float num2 = (_0024_0024438_00241065.y = _0024_0024437_00241064);
					Vector3 vector2 = (_0024self__00241067.gText.gameObject.transform.position = _0024_0024438_00241065);
					_0024self__00241067.SendMessage("JumpToNumber", _0024self__00241067.state[_0024num_00241066].choices[_0024self__00241067.cursor].nextNumber);
					_0024self__00241067.SendMessage("ExitCommandProcessing");
					YieldDefault(1);
					goto case 1;
				}
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

		internal int _0024num_00241068;

		internal Event_01_ShowChoices _0024self__00241069;

		public _0024ShowChoices_00241063(int num, Event_01_ShowChoices self_)
		{
			_0024num_00241068 = num;
			_0024self__00241069 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024num_00241068, _0024self__00241069);
		}
	}

	[Serializable]
	internal sealed class _0024SetPassage_00241070 : GenericGenerator<YieldInstruction>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<YieldInstruction>, IEnumerator
		{
			internal int _0024k_00241071;

			internal TextAnchor _0024_0024switch_0024170_00241072;

			internal TextPosition _0024_0024switch_0024172_00241073;

			internal float _0024_0024439_00241074;

			internal Vector3 _0024_0024440_00241075;

			internal float _0024_0024441_00241076;

			internal Vector3 _0024_0024442_00241077;

			internal float _0024_0024443_00241078;

			internal Vector3 _0024_0024444_00241079;

			internal TextChoice _0024pas_00241080;

			internal Event_01_ShowChoices _0024self__00241081;

			public _0024(TextChoice pas, Event_01_ShowChoices self_)
			{
				_0024pas_00241080 = pas;
				_0024self__00241081 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024k_00241071 = default(int);
					_0024self__00241081.nowShowing = true;
					if (_0024pas_00241080.font == null)
					{
						_0024self__00241081.gText.font = _0024self__00241081.status.defaultFont;
					}
					else
					{
						_0024self__00241081.gText.font = _0024pas_00241080.font;
					}
					_0024_0024switch_0024170_00241072 = _0024pas_00241080.anchor;
					if (_0024_0024switch_0024170_00241072 == TextAnchor.UpperLeft)
					{
						_0024self__00241081.gText.anchor = TextAnchor.UpperLeft;
					}
					else if (_0024_0024switch_0024170_00241072 == TextAnchor.UpperCenter)
					{
						_0024self__00241081.gText.anchor = TextAnchor.UpperCenter;
					}
					else if (_0024_0024switch_0024170_00241072 == TextAnchor.UpperRight)
					{
						_0024self__00241081.gText.anchor = TextAnchor.UpperRight;
					}
					else if (_0024_0024switch_0024170_00241072 == TextAnchor.MiddleLeft)
					{
						_0024self__00241081.gText.anchor = TextAnchor.MiddleLeft;
					}
					else if (_0024_0024switch_0024170_00241072 == TextAnchor.MiddleCenter)
					{
						_0024self__00241081.gText.anchor = TextAnchor.MiddleCenter;
					}
					else if (_0024_0024switch_0024170_00241072 == TextAnchor.MiddleRight)
					{
						_0024self__00241081.gText.anchor = TextAnchor.MiddleRight;
					}
					else if (_0024_0024switch_0024170_00241072 == TextAnchor.LowerLeft)
					{
						_0024self__00241081.gText.anchor = TextAnchor.LowerLeft;
					}
					else if (_0024_0024switch_0024170_00241072 == TextAnchor.LowerCenter)
					{
						_0024self__00241081.gText.anchor = TextAnchor.LowerCenter;
					}
					else if (_0024_0024switch_0024170_00241072 == TextAnchor.LowerRight)
					{
						_0024self__00241081.gText.anchor = TextAnchor.LowerRight;
					}
					_0024_0024switch_0024172_00241073 = _0024pas_00241080.position;
					if (_0024_0024switch_0024172_00241073 == TextPosition.Lower)
					{
						float num = (_0024_0024439_00241074 = 0f);
						Vector3 vector = (_0024_0024440_00241075 = _0024self__00241081.gText.gameObject.transform.position);
						float num2 = (_0024_0024440_00241075.y = _0024_0024439_00241074);
						Vector3 vector2 = (_0024self__00241081.gText.gameObject.transform.position = _0024_0024440_00241075);
					}
					else if (_0024_0024switch_0024172_00241073 == TextPosition.Middle)
					{
						float num3 = (_0024_0024441_00241076 = 0.5f);
						Vector3 vector4 = (_0024_0024442_00241077 = _0024self__00241081.gText.gameObject.transform.position);
						float num4 = (_0024_0024442_00241077.y = _0024_0024441_00241076);
						Vector3 vector5 = (_0024self__00241081.gText.gameObject.transform.position = _0024_0024442_00241077);
					}
					else if (_0024_0024switch_0024172_00241073 == TextPosition.Upper)
					{
						float num5 = (_0024_0024443_00241078 = 1f);
						Vector3 vector7 = (_0024_0024444_00241079 = _0024self__00241081.gText.gameObject.transform.position);
						float num6 = (_0024_0024444_00241079.y = _0024_0024443_00241078);
						Vector3 vector8 = (_0024self__00241081.gText.gameObject.transform.position = _0024_0024444_00241079);
					}
					_0024self__00241081.gText.text = string.Empty;
					if (_0024pas_00241080.choices.Length != 0)
					{
						if (_0024pas_00241080.choices.Length == 2)
						{
							_0024self__00241081.cursor = 1;
						}
						else
						{
							_0024self__00241081.cursor = 0;
						}
						goto IL_03c6;
					}
					goto IL_0c88;
				case 2:
					if (cInput.GetAxisRaw("Horizontal") == 0f && cInput.GetAxisRaw("J_Horizontal") == 0f && cInput.GetAxisRaw("DPad_Horizontal") == 0f)
					{
						goto IL_0c5d;
					}
					goto IL_074e;
				case 3:
					if (cInput.GetAxisRaw("Horizontal") == 0f && cInput.GetAxisRaw("J_Horizontal") == 0f && cInput.GetAxisRaw("DPad_Horizontal") == 0f)
					{
						goto IL_0c5d;
					}
					goto IL_0a19;
				case 4:
					if (!_0024self__00241081.nowShowing)
					{
						goto IL_0c88;
					}
					goto IL_03c6;
				case 1:
					{
						result = 0;
						break;
					}
					IL_03c6:
					_0024self__00241081.gText.text = string.Empty;
					if (_0024self__00241081.status.language == 0)
					{
						if (_0024pas_00241080.firstText_Jap != string.Empty)
						{
							_0024self__00241081.gText.text = _0024self__00241081.gText.text + _0024pas_00241080.firstText_Jap;
							_0024self__00241081.gText.text = _0024self__00241081.gText.text + "\n";
						}
					}
					else if (_0024pas_00241080.firstText_Eng != string.Empty)
					{
						_0024self__00241081.gText.text = _0024self__00241081.gText.text + _0024pas_00241080.firstText_Eng;
						_0024self__00241081.gText.text = _0024self__00241081.gText.text + "\n";
					}
					if (cInput.GetAxisRaw("Horizontal") >= 0.1f || cInput.GetAxisRaw("J_Horizontal") >= 0.1f || !(cInput.GetAxisRaw("DPad_Horizontal") < 0.1f))
					{
						_0024self__00241081.cursor++;
						if (_0024self__00241081.cursor >= _0024pas_00241080.choices.Length)
						{
							_0024self__00241081.cursor = 0;
						}
						for (_0024k_00241071 = 0; _0024k_00241071 < _0024pas_00241080.choices.Length; _0024k_00241071++)
						{
							if (_0024self__00241081.cursor == _0024k_00241071)
							{
								_0024self__00241081.gText.text = _0024self__00241081.gText.text + "《";
							}
							else
							{
								_0024self__00241081.gText.text = _0024self__00241081.gText.text + "\u3000";
							}
							if (_0024self__00241081.status.language == 0)
							{
								_0024self__00241081.gText.text = _0024self__00241081.gText.text + _0024pas_00241080.choices[_0024k_00241071].text_Jap;
							}
							else
							{
								_0024self__00241081.gText.text = _0024self__00241081.gText.text + _0024pas_00241080.choices[_0024k_00241071].text_Eng;
							}
							if (_0024self__00241081.cursor == _0024k_00241071)
							{
								_0024self__00241081.gText.text = _0024self__00241081.gText.text + "》";
							}
							else
							{
								_0024self__00241081.gText.text = _0024self__00241081.gText.text + "\u3000";
							}
							if (_0024k_00241071 != _0024pas_00241080.choices.Length - 1)
							{
								_0024self__00241081.gText.text = _0024self__00241081.gText.text + "\t\t\t\t";
							}
						}
						goto IL_074e;
					}
					if (cInput.GetAxisRaw("Horizontal") <= -0.1f || cInput.GetAxisRaw("J_Horizontal") <= -0.1f || !(cInput.GetAxisRaw("DPad_Horizontal") > -0.1f))
					{
						_0024self__00241081.cursor--;
						if (_0024self__00241081.cursor < 0)
						{
							_0024self__00241081.cursor = _0024pas_00241080.choices.Length - 1;
						}
						for (_0024k_00241071 = 0; _0024k_00241071 < _0024pas_00241080.choices.Length; _0024k_00241071++)
						{
							if (_0024self__00241081.cursor == _0024k_00241071)
							{
								_0024self__00241081.gText.text = _0024self__00241081.gText.text + "《";
							}
							else
							{
								_0024self__00241081.gText.text = _0024self__00241081.gText.text + "\u3000";
							}
							if (_0024self__00241081.status.language == 0)
							{
								_0024self__00241081.gText.text = _0024self__00241081.gText.text + _0024pas_00241080.choices[_0024k_00241071].text_Jap;
							}
							else
							{
								_0024self__00241081.gText.text = _0024self__00241081.gText.text + _0024pas_00241080.choices[_0024k_00241071].text_Eng;
							}
							if (_0024self__00241081.cursor == _0024k_00241071)
							{
								_0024self__00241081.gText.text = _0024self__00241081.gText.text + "》";
							}
							else
							{
								_0024self__00241081.gText.text = _0024self__00241081.gText.text + "\u3000";
							}
							if (_0024k_00241071 != _0024pas_00241080.choices.Length - 1)
							{
								_0024self__00241081.gText.text = _0024self__00241081.gText.text + "\t\t\t\t";
							}
						}
						goto IL_0a19;
					}
					for (_0024k_00241071 = 0; _0024k_00241071 < _0024pas_00241080.choices.Length; _0024k_00241071++)
					{
						if (_0024self__00241081.cursor == _0024k_00241071)
						{
							_0024self__00241081.gText.text = _0024self__00241081.gText.text + "《";
						}
						else
						{
							_0024self__00241081.gText.text = _0024self__00241081.gText.text + "\u3000";
						}
						if (_0024self__00241081.status.language == 0)
						{
							_0024self__00241081.gText.text = _0024self__00241081.gText.text + _0024pas_00241080.choices[_0024k_00241071].text_Jap;
						}
						else
						{
							_0024self__00241081.gText.text = _0024self__00241081.gText.text + _0024pas_00241080.choices[_0024k_00241071].text_Eng;
						}
						if (_0024self__00241081.cursor == _0024k_00241071)
						{
							_0024self__00241081.gText.text = _0024self__00241081.gText.text + "》";
						}
						else
						{
							_0024self__00241081.gText.text = _0024self__00241081.gText.text + "\u3000";
						}
						if (_0024k_00241071 != _0024pas_00241080.choices.Length - 1)
						{
							_0024self__00241081.gText.text = _0024self__00241081.gText.text + "\t\t\t\t";
						}
					}
					goto IL_0c5d;
					IL_0c5d:
					result = (Yield(4, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_0c88:
					_0024self__00241081.nowShowing = false;
					YieldDefault(1);
					goto case 1;
					IL_074e:
					result = (Yield(2, new WaitForSeconds(1E-07f)) ? 1 : 0);
					break;
					IL_0a19:
					result = (Yield(3, new WaitForSeconds(1E-07f)) ? 1 : 0);
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TextChoice _0024pas_00241082;

		internal Event_01_ShowChoices _0024self__00241083;

		public _0024SetPassage_00241070(TextChoice pas, Event_01_ShowChoices self_)
		{
			_0024pas_00241082 = pas;
			_0024self__00241083 = self_;
		}

		public override IEnumerator<YieldInstruction> GetEnumerator()
		{
			return new _0024(_0024pas_00241082, _0024self__00241083);
		}
	}

	public TextChoice[] state;

	private Player_Status status;

	private GUIText gText;

	private bool nowShowing;

	private int cursor;

	private TextChoice passageTemp;

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		gText = (GUIText)GameObject.Find("SystemObject").GetComponent(typeof(GUIText));
	}

	public virtual void Update()
	{
		if (nowShowing && (SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Action") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Action")))
		{
			nowShowing = false;
		}
	}

	public virtual IEnumerator ShowChoices(int num)
	{
		return new _0024ShowChoices_00241063(num, this).GetEnumerator();
	}

	public virtual IEnumerator SetPassage(TextChoice pas)
	{
		return new _0024SetPassage_00241070(pas, this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
