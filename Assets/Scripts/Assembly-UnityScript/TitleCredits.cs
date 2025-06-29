using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class TitleCredits : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Init_00241412 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal TitleCredits _0024self__00241413;

			public _0024(TitleCredits self_)
			{
				_0024self__00241413 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241413.creditsObjects.SetActive(true);
					result = (Yield(2, new WaitForSeconds(0.01f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241413.creditsObjects.SetActive(false);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TitleCredits _0024self__00241414;

		public _0024Init_00241412(TitleCredits self_)
		{
			_0024self__00241414 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241414);
		}
	}

	[Serializable]
	internal sealed class _0024StartCredits_00241415 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal float _0024_0024848_00241416;

			internal Vector3 _0024_0024849_00241417;

			internal int _0024_0024850_00241418;

			internal Rect _0024_0024851_00241419;

			internal TitleCredits _0024self__00241420;

			public _0024(TitleCredits self_)
			{
				_0024self__00241420 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					if (_0024self__00241420.status.language == 0)
					{
						_0024self__00241420.textJapanese.text = _0024self__00241420.japStr;
					}
					else
					{
						_0024self__00241420.textJapanese.text = _0024self__00241420.engStr;
					}
					_0024self__00241420.creditsObjects.SetActive(true);
					float num = (_0024_0024848_00241416 = _0024self__00241420.scrollStartPosition);
					Vector3 vector = (_0024_0024849_00241417 = _0024self__00241420.creditsTransform.localPosition);
					float num2 = (_0024_0024849_00241417.y = _0024_0024848_00241416);
					Vector3 vector2 = (_0024self__00241420.creditsTransform.localPosition = _0024_0024849_00241417);
					int num3 = (_0024_0024850_00241418 = 33);
					Rect rect = (_0024_0024851_00241419 = _0024self__00241420.scrollBar.pixelInset);
					float num4 = (_0024_0024851_00241419.y = _0024_0024850_00241418);
					Rect rect2 = (_0024self__00241420.scrollBar.pixelInset = _0024_0024851_00241419);
					result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				}
				case 2:
					_0024self__00241420.nowCredits = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TitleCredits _0024self__00241421;

		public _0024StartCredits_00241415(TitleCredits self_)
		{
			_0024self__00241421 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024self__00241421);
		}
	}

	[Serializable]
	internal sealed class _0024EndCredits_00241422 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal TitleCredits _0024self__00241423;

			public _0024(TitleCredits self_)
			{
				_0024self__00241423 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241423.nowCredits = false;
					result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				case 2:
					_0024self__00241423.creditsObjects.SetActive(false);
					_0024self__00241423.SendMessage("ReturnPause", SendMessageOptions.DontRequireReceiver);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TitleCredits _0024self__00241424;

		public _0024EndCredits_00241422(TitleCredits self_)
		{
			_0024self__00241424 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024self__00241424);
		}
	}

	public GameObject creditsObjects;

	public RectTransform creditsTransform;

	public Text textJapanese;

	public Text textEnglish;

	public float creditsScrollSpeed;

	public GUITexture scrollBar;

	public AudioClip decideSE;

	public float scrollStartPosition;

	public float scrollEndPosition;

	public bool nowCredits;

	private Player_Status status;

	private string japStr;

	private string engStr;

	public TitleCredits()
	{
		scrollStartPosition = -530f;
		scrollEndPosition = 80f;
	}

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		japStr = textJapanese.text;
		engStr = textEnglish.text;
		StartCoroutine_Auto(Init());
	}

	public virtual void Update()
	{
		if (!nowCredits)
		{
			return;
		}
		float num = 33f + (scrollStartPosition - creditsTransform.localPosition.y) / (scrollEndPosition - scrollStartPosition) * 206f;
		Rect pixelInset = scrollBar.pixelInset;
		float num2 = (pixelInset.y = num);
		Rect rect = (scrollBar.pixelInset = pixelInset);
		if (cInput.GetAxisRaw("Vertical") >= 0.1f || cInput.GetAxisRaw("J_Vertical") >= 0.1f || !(cInput.GetAxisRaw("DPad_Vertical") < 0.1f))
		{
			float y = creditsTransform.localPosition.y - creditsScrollSpeed * Time.deltaTime;
			Vector3 localPosition = creditsTransform.localPosition;
			float num4 = (localPosition.y = y);
			Vector3 vector = (creditsTransform.localPosition = localPosition);
		}
		else if (cInput.GetAxisRaw("Vertical") <= -0.1f || cInput.GetAxisRaw("J_Vertical") <= -0.1f || !(cInput.GetAxisRaw("DPad_Vertical") > -0.1f))
		{
			float y2 = creditsTransform.localPosition.y + creditsScrollSpeed * Time.deltaTime;
			Vector3 localPosition2 = creditsTransform.localPosition;
			float num5 = (localPosition2.y = y2);
			Vector3 vector3 = (creditsTransform.localPosition = localPosition2);
		}
		else if (!(Input.GetAxis("Mouse ScrollWheel") <= 0f))
		{
			float y3 = creditsTransform.localPosition.y - Input.GetAxis("Mouse ScrollWheel") * creditsScrollSpeed * Time.deltaTime * 64f;
			Vector3 localPosition3 = creditsTransform.localPosition;
			float num6 = (localPosition3.y = y3);
			Vector3 vector5 = (creditsTransform.localPosition = localPosition3);
		}
		else if (!(Input.GetAxis("Mouse ScrollWheel") >= 0f))
		{
			float y4 = creditsTransform.localPosition.y - Input.GetAxis("Mouse ScrollWheel") * creditsScrollSpeed * Time.deltaTime * 64f;
			Vector3 localPosition4 = creditsTransform.localPosition;
			float num7 = (localPosition4.y = y4);
			Vector3 vector7 = (creditsTransform.localPosition = localPosition4);
		}
		if (!(creditsTransform.localPosition.y >= scrollStartPosition))
		{
			float y5 = scrollStartPosition;
			Vector3 localPosition5 = creditsTransform.localPosition;
			float num8 = (localPosition5.y = y5);
			Vector3 vector9 = (creditsTransform.localPosition = localPosition5);
		}
		if (!(creditsTransform.localPosition.y <= scrollEndPosition))
		{
			float y6 = scrollEndPosition;
			Vector3 localPosition6 = creditsTransform.localPosition;
			float num9 = (localPosition6.y = y6);
			Vector3 vector11 = (creditsTransform.localPosition = localPosition6);
		}
		if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(1) || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Sprint") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Sprint") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Pause") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Pause"))
		{
			Input.ResetInputAxes();
			StartCoroutine_Auto(EndCredits());
			if (decideSE != null)
			{
				audio.PlayOneShot(decideSE, 0.6f);
			}
		}
	}

	public virtual IEnumerator Init()
	{
		return new _0024Init_00241412(this).GetEnumerator();
	}

	public virtual IEnumerator StartCredits()
	{
		return new _0024StartCredits_00241415(this).GetEnumerator();
	}

	public virtual IEnumerator EndCredits()
	{
		return new _0024EndCredits_00241422(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
