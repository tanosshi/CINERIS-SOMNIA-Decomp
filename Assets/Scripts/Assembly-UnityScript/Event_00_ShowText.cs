using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class Event_00_ShowText : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024ShowText_00241032 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal float _0024_0024421_00241033;

			internal Vector3 _0024_0024422_00241034;

			internal float _0024_0024423_00241035;

			internal Vector2 _0024_0024424_00241036;

			internal float _0024_0024425_00241037;

			internal Vector2 _0024_0024426_00241038;

			internal int _0024num_00241039;

			internal Event_00_ShowText _0024self__00241040;

			public _0024(int num, Event_00_ShowText self_)
			{
				_0024num_00241039 = num;
				_0024self__00241040 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241040.passageTemp = _0024self__00241040.state[_0024num_00241039];
					_0024self__00241040.StartCoroutine_Auto(_0024self__00241040.SetPassage(_0024self__00241040.passageTemp));
					goto IL_005b;
				case 2:
				{
					if (_0024self__00241040.nowShowing)
					{
						goto IL_005b;
					}
					_0024self__00241040.gText.text = string.Empty;
					_0024self__00241040.gText.font = _0024self__00241040.status.defaultFont;
					_0024self__00241040.gText.anchor = TextAnchor.LowerCenter;
					_0024self__00241040.gText.alignment = TextAlignment.Center;
					float num = (_0024_0024421_00241033 = 0f);
					Vector3 vector = (_0024_0024422_00241034 = _0024self__00241040.gText.gameObject.transform.position);
					float num2 = (_0024_0024422_00241034.y = _0024_0024421_00241033);
					Vector3 vector2 = (_0024self__00241040.gText.gameObject.transform.position = _0024_0024422_00241034);
					float num3 = (_0024_0024423_00241035 = 0f);
					Vector2 vector4 = (_0024_0024424_00241036 = _0024self__00241040.gText.pixelOffset);
					float num4 = (_0024_0024424_00241036.x = _0024_0024423_00241035);
					Vector2 vector5 = (_0024self__00241040.gText.pixelOffset = _0024_0024424_00241036);
					float num5 = (_0024_0024425_00241037 = 8f);
					Vector2 vector7 = (_0024_0024426_00241038 = _0024self__00241040.gText.pixelOffset);
					float num6 = (_0024_0024426_00241038.y = _0024_0024425_00241037);
					Vector2 vector8 = (_0024self__00241040.gText.pixelOffset = _0024_0024426_00241038);
					_0024self__00241040.SendMessage("ExitCommandProcessing");
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

		internal int _0024num_00241041;

		internal Event_00_ShowText _0024self__00241042;

		public _0024ShowText_00241032(int num, Event_00_ShowText self_)
		{
			_0024num_00241041 = num;
			_0024self__00241042 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024num_00241041, _0024self__00241042);
		}
	}

	[Serializable]
	internal sealed class _0024SetPassage_00241043 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal int _0024k_00241044;

			internal int _0024l_00241045;

			internal TextAnchor _0024_0024switch_0024164_00241046;

			internal TextAlignment _0024_0024switch_0024166_00241047;

			internal TextPosition _0024_0024switch_0024168_00241048;

			internal float _0024_0024427_00241049;

			internal Vector3 _0024_0024428_00241050;

			internal float _0024_0024429_00241051;

			internal Vector3 _0024_0024430_00241052;

			internal float _0024_0024431_00241053;

			internal Vector3 _0024_0024432_00241054;

			internal float _0024_0024433_00241055;

			internal Vector2 _0024_0024434_00241056;

			internal float _0024_0024435_00241057;

			internal Vector2 _0024_0024436_00241058;

			internal Passage _0024pas_00241059;

			internal Event_00_ShowText _0024self__00241060;

			public _0024(Passage pas, Event_00_ShowText self_)
			{
				_0024pas_00241059 = pas;
				_0024self__00241060 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024k_00241044 = default(int);
					_0024l_00241045 = default(int);
					_0024self__00241060.nowShowing = true;
					if (_0024pas_00241059.font == null)
					{
						_0024self__00241060.gText.font = _0024self__00241060.status.defaultFont;
					}
					else
					{
						_0024self__00241060.gText.font = _0024pas_00241059.font;
					}
					_0024_0024switch_0024164_00241046 = _0024pas_00241059.anchor;
					if (_0024_0024switch_0024164_00241046 == TextAnchor.UpperLeft)
					{
						_0024self__00241060.gText.anchor = TextAnchor.UpperLeft;
					}
					else if (_0024_0024switch_0024164_00241046 == TextAnchor.UpperCenter)
					{
						_0024self__00241060.gText.anchor = TextAnchor.UpperCenter;
					}
					else if (_0024_0024switch_0024164_00241046 == TextAnchor.UpperRight)
					{
						_0024self__00241060.gText.anchor = TextAnchor.UpperRight;
					}
					else if (_0024_0024switch_0024164_00241046 == TextAnchor.MiddleLeft)
					{
						_0024self__00241060.gText.anchor = TextAnchor.MiddleLeft;
					}
					else if (_0024_0024switch_0024164_00241046 == TextAnchor.MiddleCenter)
					{
						_0024self__00241060.gText.anchor = TextAnchor.MiddleCenter;
					}
					else if (_0024_0024switch_0024164_00241046 == TextAnchor.MiddleRight)
					{
						_0024self__00241060.gText.anchor = TextAnchor.MiddleRight;
					}
					else if (_0024_0024switch_0024164_00241046 == TextAnchor.LowerLeft)
					{
						_0024self__00241060.gText.anchor = TextAnchor.LowerLeft;
					}
					else if (_0024_0024switch_0024164_00241046 == TextAnchor.LowerCenter)
					{
						_0024self__00241060.gText.anchor = TextAnchor.LowerCenter;
					}
					else if (_0024_0024switch_0024164_00241046 == TextAnchor.LowerRight)
					{
						_0024self__00241060.gText.anchor = TextAnchor.LowerRight;
					}
					_0024_0024switch_0024166_00241047 = _0024pas_00241059.alignment;
					if (_0024_0024switch_0024166_00241047 == TextAlignment.Center)
					{
						_0024self__00241060.gText.alignment = TextAlignment.Center;
					}
					else if (_0024_0024switch_0024166_00241047 == TextAlignment.Left)
					{
						_0024self__00241060.gText.alignment = TextAlignment.Left;
					}
					else if (_0024_0024switch_0024166_00241047 == TextAlignment.Right)
					{
						_0024self__00241060.gText.alignment = TextAlignment.Right;
					}
					_0024_0024switch_0024168_00241048 = _0024pas_00241059.position;
					if (_0024_0024switch_0024168_00241048 == TextPosition.Lower)
					{
						float num = (_0024_0024427_00241049 = 0f);
						Vector3 vector = (_0024_0024428_00241050 = _0024self__00241060.gText.gameObject.transform.position);
						float num2 = (_0024_0024428_00241050.y = _0024_0024427_00241049);
						Vector3 vector2 = (_0024self__00241060.gText.gameObject.transform.position = _0024_0024428_00241050);
					}
					else if (_0024_0024switch_0024168_00241048 == TextPosition.Middle)
					{
						float num3 = (_0024_0024429_00241051 = 0.5f);
						Vector3 vector4 = (_0024_0024430_00241052 = _0024self__00241060.gText.gameObject.transform.position);
						float num4 = (_0024_0024430_00241052.y = _0024_0024429_00241051);
						Vector3 vector5 = (_0024self__00241060.gText.gameObject.transform.position = _0024_0024430_00241052);
					}
					else if (_0024_0024switch_0024168_00241048 == TextPosition.Upper)
					{
						float num5 = (_0024_0024431_00241053 = 1f);
						Vector3 vector7 = (_0024_0024432_00241054 = _0024self__00241060.gText.gameObject.transform.position);
						float num6 = (_0024_0024432_00241054.y = _0024_0024431_00241053);
						Vector3 vector8 = (_0024self__00241060.gText.gameObject.transform.position = _0024_0024432_00241054);
					}
					if (_0024pas_00241059.changeOffset)
					{
						float num7 = (_0024_0024433_00241055 = _0024pas_00241059.offsetX);
						Vector2 vector10 = (_0024_0024434_00241056 = _0024self__00241060.gText.pixelOffset);
						float num8 = (_0024_0024434_00241056.x = _0024_0024433_00241055);
						Vector2 vector11 = (_0024self__00241060.gText.pixelOffset = _0024_0024434_00241056);
						float num9 = (_0024_0024435_00241057 = _0024pas_00241059.offsetY);
						Vector2 vector13 = (_0024_0024436_00241058 = _0024self__00241060.gText.pixelOffset);
						float num10 = (_0024_0024436_00241058.y = _0024_0024435_00241057);
						Vector2 vector14 = (_0024self__00241060.gText.pixelOffset = _0024_0024436_00241058);
					}
					_0024self__00241060.gText.text = string.Empty;
					_0024k_00241044 = 0;
					goto IL_0706;
				case 2:
					if (_0024self__00241060.nowLooping)
					{
						goto IL_06cd;
					}
					_0024k_00241044++;
					goto IL_0706;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0706:
					if (_0024k_00241044 < _0024pas_00241059.pageAmount.Length)
					{
						if (_0024pas_00241059.showSE != null)
						{
							_0024self__00241060.audio.PlayOneShot(_0024pas_00241059.showSE, _0024pas_00241059.SeVolume);
						}
						_0024self__00241060.gText.text = string.Empty;
						if (_0024self__00241060.status.language == 0)
						{
							for (_0024l_00241045 = 0; _0024l_00241045 < _0024pas_00241059.pageAmount[_0024k_00241044].passage_Jap.Length; _0024l_00241045++)
							{
								if (_0024l_00241045 >= 1)
								{
									_0024self__00241060.gText.text = _0024self__00241060.gText.text + "\n";
								}
								_0024self__00241060.gText.text = _0024self__00241060.gText.text + _0024pas_00241059.pageAmount[_0024k_00241044].passage_Jap[_0024l_00241045];
							}
						}
						else
						{
							for (_0024l_00241045 = 0; _0024l_00241045 < _0024pas_00241059.pageAmount[_0024k_00241044].passage_Eng.Length; _0024l_00241045++)
							{
								if (_0024l_00241045 >= 1)
								{
									_0024self__00241060.gText.text = _0024self__00241060.gText.text + "\n";
								}
								_0024self__00241060.gText.text = _0024self__00241060.gText.text + _0024pas_00241059.pageAmount[_0024k_00241044].passage_Eng[_0024l_00241045];
							}
						}
						_0024self__00241060.nowLooping = true;
						goto IL_06cd;
					}
					_0024self__00241060.nowShowing = false;
					YieldDefault(1);
					goto case 1;
					IL_06cd:
					result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Passage _0024pas_00241061;

		internal Event_00_ShowText _0024self__00241062;

		public _0024SetPassage_00241043(Passage pas, Event_00_ShowText self_)
		{
			_0024pas_00241061 = pas;
			_0024self__00241062 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024pas_00241061, _0024self__00241062);
		}
	}

	public Passage[] state;

	private Player_Status status;

	private GUIText gText;

	private bool nowShowing;

	private bool nowLooping;

	private int cursor;

	private Passage passageTemp;

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		gText = (GUIText)GameObject.Find("SystemObject").GetComponent(typeof(GUIText));
	}

	public virtual void Update()
	{
		if (gText == null)
		{
			gText = (GUIText)GameObject.Find("SystemObject").GetComponent(typeof(GUIText));
		}
		if (nowShowing && nowLooping && (SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Action") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Action")))
		{
			nowLooping = false;
		}
	}

	public virtual IEnumerator ShowText(int num)
	{
		return new _0024ShowText_00241032(num, this).GetEnumerator();
	}

	public virtual IEnumerator SetPassage(Passage pas)
	{
		return new _0024SetPassage_00241043(pas, this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
