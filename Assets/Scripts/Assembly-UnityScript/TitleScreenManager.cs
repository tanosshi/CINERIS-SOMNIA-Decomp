using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class TitleScreenManager : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Cursor_00241456 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal TitleScreenManager _0024self__00241457;

			public _0024(TitleScreenManager self_)
			{
				_0024self__00241457 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024self__00241457.dontControl)
					{
						if ((cInput.GetAxisRaw("Vertical") >= 0.1f || cInput.GetAxisRaw("J_Vertical") >= 0.1f || !(cInput.GetAxisRaw("DPad_Vertical") < 0.1f)) && _0024self__00241457.cursor < 5)
						{
							if (_0024self__00241457.cursor >= 2)
							{
								_0024self__00241457.cursor = 1;
								if (_0024self__00241457.cursorSE != null)
								{
									_0024self__00241457.audio.PlayOneShot(_0024self__00241457.cursorSE, 0.6f);
								}
							}
							else if (_0024self__00241457.cursor == 1)
							{
								_0024self__00241457.cursor = 0;
								if (_0024self__00241457.cursorSE != null)
								{
									_0024self__00241457.audio.PlayOneShot(_0024self__00241457.cursorSE, 0.6f);
								}
							}
							else if (_0024self__00241457.canContinue)
							{
								_0024self__00241457.cursor = 5;
								if (_0024self__00241457.cursorSE != null)
								{
									_0024self__00241457.audio.PlayOneShot(_0024self__00241457.cursorSE, 0.6f);
								}
							}
							goto IL_0191;
						}
						goto IL_01df;
					}
					goto IL_0513;
				case 2:
					if (cInput.GetAxisRaw("Vertical") == 0f && cInput.GetAxisRaw("J_Vertical") == 0f && cInput.GetAxisRaw("DPad_Vertical") == 0f)
					{
						goto IL_01df;
					}
					goto IL_0191;
				case 3:
					if (cInput.GetAxisRaw("Vertical") == 0f && cInput.GetAxisRaw("J_Vertical") == 0f && cInput.GetAxisRaw("DPad_Vertical") == 0f)
					{
						goto IL_0315;
					}
					goto IL_02c7;
				case 4:
					if (cInput.GetAxisRaw("Horizontal") == 0f && cInput.GetAxisRaw("J_Horizontal") == 0f && cInput.GetAxisRaw("DPad_Horizontal") == 0f)
					{
						goto IL_0425;
					}
					goto IL_03d7;
				case 5:
					if (cInput.GetAxisRaw("Horizontal") == 0f && cInput.GetAxisRaw("J_Horizontal") == 0f && cInput.GetAxisRaw("DPad_Horizontal") == 0f)
					{
						goto IL_0513;
					}
					goto IL_04c5;
				case 1:
					{
						result = 0;
						break;
					}
					IL_03d7:
					result = (Yield(4, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_0513:
					result = (Yield(6, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_0315:
					if (_0024self__00241457.cursor >= 2 && _0024self__00241457.cursor <= 4)
					{
						if ((cInput.GetAxisRaw("Horizontal") >= 0.1f || cInput.GetAxisRaw("J_Horizontal") >= 0.1f || !(cInput.GetAxisRaw("DPad_Horizontal") < 0.1f)) && _0024self__00241457.cursor != 4)
						{
							_0024self__00241457.cursor++;
							if (_0024self__00241457.cursorSE != null)
							{
								_0024self__00241457.audio.PlayOneShot(_0024self__00241457.cursorSE, 0.6f);
							}
							goto IL_03d7;
						}
						goto IL_0425;
					}
					goto IL_0513;
					IL_0425:
					if ((cInput.GetAxisRaw("Horizontal") <= -0.1f || cInput.GetAxisRaw("J_Horizontal") <= -0.1f || !(cInput.GetAxisRaw("DPad_Horizontal") > -0.1f)) && _0024self__00241457.cursor != 2)
					{
						_0024self__00241457.cursor--;
						if (_0024self__00241457.cursorSE != null)
						{
							_0024self__00241457.audio.PlayOneShot(_0024self__00241457.cursorSE, 0.6f);
						}
						goto IL_04c5;
					}
					goto IL_0513;
					IL_02c7:
					result = (Yield(3, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_0191:
					result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_04c5:
					result = (Yield(5, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_01df:
					if ((cInput.GetAxisRaw("Vertical") <= -0.1f || cInput.GetAxisRaw("J_Vertical") <= -0.1f || !(cInput.GetAxisRaw("DPad_Vertical") > -0.1f)) && (_0024self__00241457.cursor <= 1 || _0024self__00241457.cursor == 5))
					{
						if (_0024self__00241457.cursor == 0)
						{
							_0024self__00241457.cursor = 1;
						}
						else if (_0024self__00241457.cursor == 5)
						{
							_0024self__00241457.cursor = 0;
						}
						else
						{
							_0024self__00241457.cursor = 3;
						}
						if (_0024self__00241457.cursorSE != null)
						{
							_0024self__00241457.audio.PlayOneShot(_0024self__00241457.cursorSE, 0.6f);
						}
						goto IL_02c7;
					}
					goto IL_0315;
				}
				return (byte)result != 0;
			}
		}

		internal TitleScreenManager _0024self__00241458;

		public _0024Cursor_00241456(TitleScreenManager self_)
		{
			_0024self__00241458 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024self__00241458);
		}
	}

	[Serializable]
	internal sealed class _0024SetPhoto_00241459 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal TitleScreenManager _0024self__00241460;

			public _0024(TitleScreenManager self_)
			{
				_0024self__00241460 = self_;
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
					if (_0024self__00241460.status.screenTexture0 != null)
					{
						_0024self__00241460.photoContinueScreen.renderer.material.mainTexture = _0024self__00241460.status.screenTexture0;
					}
					else
					{
						_0024self__00241460.photoContinueScreen.renderer.material.mainTexture = _0024self__00241460.defaultPhotoScreen;
					}
					if (_0024self__00241460.status.screenTexture1 != null)
					{
						_0024self__00241460.photoLoadScreen[0].renderer.material.mainTexture = _0024self__00241460.status.screenTexture1;
					}
					else
					{
						_0024self__00241460.photoLoadScreen[0].renderer.material.mainTexture = _0024self__00241460.defaultPhotoScreen;
					}
					if (_0024self__00241460.status.screenTexture2 != null)
					{
						_0024self__00241460.photoLoadScreen[1].renderer.material.mainTexture = _0024self__00241460.status.screenTexture2;
					}
					else
					{
						_0024self__00241460.photoLoadScreen[1].renderer.material.mainTexture = _0024self__00241460.defaultPhotoScreen;
					}
					if (_0024self__00241460.status.screenTexture3 != null)
					{
						_0024self__00241460.photoLoadScreen[2].renderer.material.mainTexture = _0024self__00241460.status.screenTexture3;
					}
					else
					{
						_0024self__00241460.photoLoadScreen[2].renderer.material.mainTexture = _0024self__00241460.defaultPhotoScreen;
					}
					if (_0024self__00241460.status.screenTexture4 != null)
					{
						_0024self__00241460.photoLoadScreen[3].renderer.material.mainTexture = _0024self__00241460.status.screenTexture4;
					}
					else
					{
						_0024self__00241460.photoLoadScreen[3].renderer.material.mainTexture = _0024self__00241460.defaultPhotoScreen;
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

		internal TitleScreenManager _0024self__00241461;

		public _0024SetPhoto_00241459(TitleScreenManager self_)
		{
			_0024self__00241461 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024self__00241461);
		}
	}

	[Serializable]
	internal sealed class _0024ReturnPause_00241462 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal float _0024_0024898_00241463;

			internal Color _0024_0024899_00241464;

			internal TitleScreenManager _0024self__00241465;

			public _0024(TitleScreenManager self_)
			{
				_0024self__00241465 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241465.dontControl = false;
					_0024self__00241465.photoLoadFlag = false;
					_0024self__00241465.optionFlag = false;
					_0024self__00241465.creditsFlag = false;
					result = (Yield(2, new WaitForSeconds(1f / _0024self__00241465.photoFadeSpeed)) ? 1 : 0);
					break;
				case 2:
				{
					float num = (_0024_0024898_00241463 = 0f);
					Color color = (_0024_0024899_00241464 = _0024self__00241465.photoContinue.renderer.material.color);
					float num2 = (_0024_0024899_00241464.a = _0024_0024898_00241463);
					Color color2 = (_0024self__00241465.photoContinue.renderer.material.color = _0024_0024899_00241464);
					_0024self__00241465.photoContinue.SetActive(true);
					YieldDefault(1);
					goto case 1;
				}
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TitleScreenManager _0024self__00241466;

		public _0024ReturnPause_00241462(TitleScreenManager self_)
		{
			_0024self__00241466 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241466);
		}
	}

	[Serializable]
	internal sealed class _0024StartGame_00241467 : GenericGenerator<YieldInstruction>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<YieldInstruction>, IEnumerator
		{
			internal AsyncOperation _0024async_00241468;

			internal TitleScreenManager _0024self__00241469;

			public _0024(TitleScreenManager self_)
			{
				_0024self__00241469 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Debug.Log("StartingGame...");
					Screen.lockCursor = true;
					Screen.showCursor = false;
					_0024self__00241469.dontControl = true;
					if (_0024self__00241469.decideSE != null)
					{
						_0024self__00241469.audio.PlayOneShot(_0024self__00241469.titleSE, 0.8f);
					}
					_0024self__00241469.photoContinue.SetActive(false);
					_0024self__00241469.sequenceNew.SendMessage("Play", SendMessageOptions.DontRequireReceiver);
					_0024self__00241469.black.SetFadeSpeed(4f);
					_0024self__00241469.black.FadeIn();
					_0024self__00241469.levelChanger.enabled = true;
					result = (Yield(2, new WaitForSeconds(_0024self__00241469.black.FadeSpeed + 0.4f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241469.isLoading = true;
					_0024async_00241468 = Application.LoadLevelAsync("[00-]fish_water1");
					_0024async_00241468.allowSceneActivation = false;
					goto case 3;
				case 3:
					if (_0024async_00241468.progress < 0.9f)
					{
						result = (Yield(3, new WaitForEndOfFrame()) ? 1 : 0);
						break;
					}
					_0024self__00241469.isLoading = false;
					goto IL_018e;
				case 4:
					if (!(_0024self__00241469.textureAlpha > 0f))
					{
						_0024async_00241468.allowSceneActivation = true;
					}
					goto IL_018e;
				case 1:
					{
						result = 0;
						break;
					}
					IL_018e:
					if (!_0024async_00241468.isDone)
					{
						result = (Yield(4, new WaitForEndOfFrame()) ? 1 : 0);
						break;
					}
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal TitleScreenManager _0024self__00241470;

		public _0024StartGame_00241467(TitleScreenManager self_)
		{
			_0024self__00241470 = self_;
		}

		public override IEnumerator<YieldInstruction> GetEnumerator()
		{
			return new _0024(_0024self__00241470);
		}
	}

	[Serializable]
	internal sealed class _0024QuitGame_00241471 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal TitleScreenManager _0024self__00241472;

			public _0024(TitleScreenManager self_)
			{
				_0024self__00241472 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Debug.Log("QuitingGame...");
					Screen.lockCursor = true;
					Screen.showCursor = false;
					_0024self__00241472.dontControl = true;
					if (_0024self__00241472.decideSE != null)
					{
						_0024self__00241472.audio.pitch = 0.8f;
						_0024self__00241472.audio.PlayOneShot(_0024self__00241472.titleSE, 0.8f);
					}
					_0024self__00241472.photoContinue.SetActive(false);
					_0024self__00241472.sequenceQuit.SendMessage("Play", SendMessageOptions.DontRequireReceiver);
					_0024self__00241472.black.SetFadeSpeed(2f);
					_0024self__00241472.black.FadeIn();
					result = (Yield(2, new WaitForSeconds(_0024self__00241472.black.FadeSpeed + 0.4f)) ? 1 : 0);
					break;
				case 2:
					Application.Quit();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TitleScreenManager _0024self__00241473;

		public _0024QuitGame_00241471(TitleScreenManager self_)
		{
			_0024self__00241473 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241473);
		}
	}

	[Serializable]
	internal sealed class _0024ResetStatus_00241474 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal TitleScreenManager _0024self__00241475;

			public _0024(TitleScreenManager self_)
			{
				_0024self__00241475 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241475.status.mapName = string.Empty;
					_0024self__00241475.status.mapX = 0f;
					_0024self__00241475.status.mapY = 0f;
					_0024self__00241475.status.mapZ = 0f;
					_0024self__00241475.status.playerRotation = 0f;
					_0024self__00241475.status.cameraX = 0f;
					_0024self__00241475.status.cameraY = 0f;
					_0024self__00241475.status.cameraZ = 0f;
					_0024self__00241475.status.cameraRotX = 0f;
					_0024self__00241475.status.cameraRotY = 0f;
					_0024self__00241475.status.footStepId = 0;
					_0024self__00241475.status.footEffectId = 0;
					_0024self__00241475.status.playTimeSeconds = 0f;
					_0024self__00241475.status.playTimeMinutes = 0;
					_0024self__00241475.status.playTimeHours = 0;
					_0024self__00241475.status.nowYear = 0;
					_0024self__00241475.status.nowMonth = 0;
					_0024self__00241475.status.nowDay = 0;
					_0024self__00241475.i = 0;
					while (_0024self__00241475.i < _0024self__00241475.status.switches.Length)
					{
						_0024self__00241475.status.switches[_0024self__00241475.i] = 0;
						_0024self__00241475.i++;
					}
					_0024self__00241475.i = 0;
					while (_0024self__00241475.i < _0024self__00241475.status.variables.Length)
					{
						_0024self__00241475.status.variables[_0024self__00241475.i] = 0f;
						_0024self__00241475.i++;
					}
					_0024self__00241475.i = 0;
					while (_0024self__00241475.i < _0024self__00241475.status.tempSwitches.Length)
					{
						_0024self__00241475.status.tempSwitches[_0024self__00241475.i] = 0;
						_0024self__00241475.i++;
					}
					_0024self__00241475.i = 0;
					while (_0024self__00241475.i < _0024self__00241475.status.item.Length)
					{
						_0024self__00241475.status.item[_0024self__00241475.i] = 0;
						_0024self__00241475.i++;
					}
					_0024self__00241475.i = 0;
					while (_0024self__00241475.i < _0024self__00241475.status.file.Length)
					{
						_0024self__00241475.status.file[_0024self__00241475.i] = 0;
						_0024self__00241475.i++;
					}
					result = (Yield(2, new WaitForSeconds(2f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241475.status.fadeColor = Color.black;
					_0024self__00241475.black.SetFadeColor(Color.black);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TitleScreenManager _0024self__00241476;

		public _0024ResetStatus_00241474(TitleScreenManager self_)
		{
			_0024self__00241476 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241476);
		}
	}

	public GUITexture[] contents;

	public Texture2D[] contentsTrueTex;

	public Texture2D[] contentsFalseTex;

	public AudioClip cursorSE;

	public AudioClip decideSE;

	public AudioClip titleSE;

	public Type startFadeTime;

	public Type quitFadeTime;

	public GameObject titleCharacters;

	public GameObject continueObject;

	public Texture defaultPhotoScreen;

	public GameObject photoContinue;

	public TextMesh photoContinueDate;

	public GameObject photoContinueScreen;

	public GameObject PhotoLoadObject;

	public GameObject[] photoLoad;

	public TextMesh[] photoLoadDate;

	public GameObject[] photoLoadScreen;

	public float photoFadeSpeed;

	public bool dontControl;

	public Texture2D[] contentsTrueTexClear;

	public Texture2D[] contentsFalseTexClear;

	public int cursor;

	public GameObject contentsObject;

	public GameObject sequenceNew;

	public GameObject sequenceQuit;

	private Player_Status status;

	private BlackOutController black;

	private LevelChanger levelChanger;

	private TitleLoad date;

	private int aspectId;

	private bool canContinue;

	private bool photoLoadFlag;

	private bool optionFlag;

	private bool creditsFlag;

	private int i;

	private float aspectTemp;

	public GameObject clearPicture;

	public GameObject clearSnow;

	public GameObject clearButterfly;

	public BloomAndLensFlares clearBloom;

	public Texture2D loadingTexture;

	public Vector2 textureSize;

	public Vector2 offset;

	public float textureFadeSpeed;

	public float textureFlickSpeed;

	public float textureFlickAmount;

	private bool isLoading;

	private float textureAlpha;

	public TitleScreenManager()
	{
		startFadeTime = typeof(float);
		quitFadeTime = typeof(float);
	}

	public virtual void Start()
	{
		AudioListener.volume = 1f;
		Screen.lockCursor = true;
		Screen.showCursor = false;
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		status.nowEventing = false;
		status.nowPausing = false;
		status.pausePermission = true;
		status.loadPermission = true;
		status.savePermission = true;
		status.menuPermission = true;
		levelChanger = (LevelChanger)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(LevelChanger));
		black = (BlackOutController)GetComponent(typeof(BlackOutController));
		date = (TitleLoad)GetComponent(typeof(TitleLoad));
		StartCoroutine_Auto(SetPhoto());
		if (ES2.Exists("save/savedata0.sav"))
		{
			canContinue = true;
			continueObject.SetActive(true);
			cursor = 5;
			if (status.clearFlag > 0)
			{
				cursor = 0;
			}
		}
		else
		{
			canContinue = false;
			continueObject.SetActive(false);
			cursor = 0;
		}
		if (status.clearFlag > 0)
		{
			clearPicture.SetActive(true);
			clearSnow.SetActive(true);
			clearButterfly.SetActive(false);
			clearBloom.enabled = false;
			for (i = 0; i < contentsFalseTex.Length; i++)
			{
				contentsTrueTex[i] = contentsTrueTexClear[i];
				contentsFalseTex[i] = contentsFalseTexClear[i];
			}
		}
		StartCoroutine_Auto(ResetStatus());
		if (!status.bootFlag)
		{
			status.bootFlag = true;
			status.fadeColor = new Color(0.984f, 0.984f, 0.984f);
			black.SetFadeColor(new Color(0.984f, 0.984f, 0.984f));
			StartCoroutine_Auto(black.FirstFadeOut());
		}
		else
		{
			black.SetFadeSpeed(2f);
			StartCoroutine_Auto(black.FirstFadeOut());
		}
		StartCoroutine_Auto(Cursor());
	}

	public virtual void Update()
	{
		if (isLoading)
		{
			textureAlpha += textureFadeSpeed * Time.deltaTime;
			if (!(textureAlpha <= 1f - textureFlickAmount))
			{
				textureAlpha = 1f - textureFlickAmount;
			}
		}
		else
		{
			textureAlpha -= textureFadeSpeed * Time.deltaTime;
			if (!(textureAlpha >= 0f))
			{
				textureAlpha = 0f;
			}
		}
		aspectTemp = Screen.width;
		aspectTemp /= Screen.height;
		if (!(aspectTemp < 1.7f))
		{
			aspectId = 1;
		}
		else if (!(aspectTemp < 1.5f) && !(aspectTemp > 1.7f))
		{
			aspectId = 2;
		}
		else
		{
			aspectId = 0;
		}
		if (aspectId == 0)
		{
			float x = 0.42f;
			Vector3 localScale = titleCharacters.transform.localScale;
			float num = (localScale.x = x);
			Vector3 vector = (titleCharacters.transform.localScale = localScale);
			float y = 0.3003973f;
			Vector3 localScale2 = titleCharacters.transform.localScale;
			float num2 = (localScale2.y = y);
			Vector3 vector3 = (titleCharacters.transform.localScale = localScale2);
		}
		else if (aspectId == 1)
		{
			float x2 = 0.36f;
			Vector3 localScale3 = titleCharacters.transform.localScale;
			float num3 = (localScale3.x = x2);
			Vector3 vector5 = (titleCharacters.transform.localScale = localScale3);
			float y2 = 0.3433113f;
			Vector3 localScale4 = titleCharacters.transform.localScale;
			float num4 = (localScale4.y = y2);
			Vector3 vector7 = (titleCharacters.transform.localScale = localScale4);
		}
		else
		{
			float x3 = 0.36f;
			Vector3 localScale5 = titleCharacters.transform.localScale;
			float num5 = (localScale5.x = x3);
			Vector3 vector9 = (titleCharacters.transform.localScale = localScale5);
			float y3 = 0.3089801f;
			Vector3 localScale6 = titleCharacters.transform.localScale;
			float num6 = (localScale6.y = y3);
			Vector3 vector11 = (titleCharacters.transform.localScale = localScale6);
		}
		if (cursor == 5)
		{
			float a = photoContinue.renderer.material.color.a + photoFadeSpeed * Time.deltaTime;
			Color color = photoContinue.renderer.material.color;
			float num7 = (color.a = a);
			Color color2 = (photoContinue.renderer.material.color = color);
			if (!(photoContinue.renderer.material.color.a < 1f))
			{
				float a2 = 1f;
				Color color4 = photoContinue.renderer.material.color;
				float num8 = (color4.a = a2);
				Color color5 = (photoContinue.renderer.material.color = color4);
			}
		}
		else
		{
			float a3 = photoContinue.renderer.material.color.a - photoFadeSpeed * Time.deltaTime;
			Color color7 = photoContinue.renderer.material.color;
			float num9 = (color7.a = a3);
			Color color8 = (photoContinue.renderer.material.color = color7);
			if (!(photoContinue.renderer.material.color.a > 0f))
			{
				int num10 = 0;
				Color color10 = photoContinue.renderer.material.color;
				float num11 = (color10.a = num10);
				Color color11 = (photoContinue.renderer.material.color = color10);
			}
		}
		if (!photoLoadFlag)
		{
			for (i = 0; i < 4; i++)
			{
				float a4 = photoLoad[i].renderer.material.color.a - photoFadeSpeed * Time.deltaTime;
				Color color13 = photoLoad[i].renderer.material.color;
				float num12 = (color13.a = a4);
				Color color14 = (photoLoad[i].renderer.material.color = color13);
				if (!(photoLoad[i].renderer.material.color.a > 0f))
				{
					int num13 = 0;
					Color color16 = photoLoad[i].renderer.material.color;
					float num14 = (color16.a = num13);
					Color color17 = (photoLoad[i].renderer.material.color = color16);
				}
			}
		}
		else
		{
			for (i = 0; i < 4; i++)
			{
				float a5 = photoLoad[i].renderer.material.color.a + photoFadeSpeed * Time.deltaTime;
				Color color19 = photoLoad[i].renderer.material.color;
				float num15 = (color19.a = a5);
				Color color20 = (photoLoad[i].renderer.material.color = color19);
				if (!(photoLoad[i].renderer.material.color.a < 1f))
				{
					float a6 = 1f;
					Color color22 = photoLoad[i].renderer.material.color;
					float num16 = (color22.a = a6);
					Color color23 = (photoLoad[i].renderer.material.color = color22);
				}
			}
		}
		photoContinueDate.text = date.dataYear[0].ToString() + "/" + date.dataMonth[0] + "/" + date.dataDay[0];
		if (date.dataYear[1] != 0)
		{
			photoLoadDate[0].text = date.dataYear[1].ToString() + "/" + date.dataMonth[1] + "/" + date.dataDay[1];
		}
		if (date.dataYear[2] != 0)
		{
			photoLoadDate[1].text = date.dataYear[2].ToString() + "/" + date.dataMonth[2] + "/" + date.dataDay[2];
		}
		if (date.dataYear[3] != 0)
		{
			photoLoadDate[2].text = date.dataYear[3].ToString() + "/" + date.dataMonth[3] + "/" + date.dataDay[3];
		}
		if (date.dataYear[4] != 0)
		{
			photoLoadDate[3].text = date.dataYear[4].ToString() + "/" + date.dataMonth[4] + "/" + date.dataDay[4];
		}
		if (!dontControl && (SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Action") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Action")))
		{
			switch (cursor)
			{
			case 0:
				StartCoroutine_Auto(StartGame());
				break;
			case 1:
				StartLoad();
				break;
			case 2:
				Options();
				break;
			case 3:
				Credits();
				break;
			case 4:
				StartCoroutine_Auto(QuitGame());
				break;
			case 5:
				Continue();
				break;
			}
		}
		switch (cursor)
		{
		case 0:
			contents[0].texture = contentsTrueTex[0];
			contents[1].texture = contentsFalseTex[1];
			contents[2].texture = contentsFalseTex[2];
			contents[3].texture = contentsFalseTex[3];
			contents[4].texture = contentsFalseTex[4];
			contents[5].texture = contentsFalseTex[5];
			if (status.clearFlag > 0 && clearBloom.enabled)
			{
				clearBloom.enabled = false;
			}
			break;
		case 1:
			contents[0].texture = contentsFalseTex[0];
			contents[1].texture = contentsTrueTex[1];
			contents[2].texture = contentsFalseTex[2];
			contents[3].texture = contentsFalseTex[3];
			contents[4].texture = contentsFalseTex[4];
			contents[5].texture = contentsFalseTex[5];
			if (status.clearFlag > 0 && clearBloom.enabled)
			{
				clearBloom.enabled = false;
			}
			break;
		case 2:
			contents[0].texture = contentsFalseTex[0];
			contents[1].texture = contentsFalseTex[1];
			contents[2].texture = contentsTrueTex[2];
			contents[3].texture = contentsFalseTex[3];
			contents[4].texture = contentsFalseTex[4];
			contents[5].texture = contentsFalseTex[5];
			if (status.clearFlag > 0 && clearBloom.enabled)
			{
				clearBloom.enabled = false;
			}
			break;
		case 3:
			contents[0].texture = contentsFalseTex[0];
			contents[1].texture = contentsFalseTex[1];
			contents[2].texture = contentsFalseTex[2];
			contents[3].texture = contentsTrueTex[3];
			contents[4].texture = contentsFalseTex[4];
			contents[5].texture = contentsFalseTex[5];
			if (status.clearFlag > 0 && clearBloom.enabled)
			{
				clearBloom.enabled = false;
			}
			break;
		case 4:
			contents[0].texture = contentsFalseTex[0];
			contents[1].texture = contentsFalseTex[1];
			contents[2].texture = contentsFalseTex[2];
			contents[3].texture = contentsFalseTex[3];
			contents[4].texture = contentsTrueTex[4];
			contents[5].texture = contentsFalseTex[5];
			if (status.clearFlag > 0 && clearBloom.enabled)
			{
				clearBloom.enabled = false;
			}
			break;
		case 5:
			contents[0].texture = contentsFalseTex[0];
			contents[1].texture = contentsFalseTex[1];
			contents[2].texture = contentsFalseTex[2];
			contents[3].texture = contentsFalseTex[3];
			contents[4].texture = contentsFalseTex[4];
			contents[5].texture = contentsTrueTex[5];
			if (status.clearFlag > 0 && !clearBloom.enabled)
			{
				clearBloom.enabled = true;
			}
			break;
		}
		if (photoLoadFlag || optionFlag || creditsFlag)
		{
			contentsObject.SetActive(false);
			if (status.clearFlag > 0 && !clearBloom.enabled && photoLoadFlag)
			{
				clearBloom.enabled = true;
			}
			return;
		}
		contentsObject.SetActive(true);
		if ((cInput.GetAxis("Mouse X") != 0f || cInput.GetAxis("Mouse Y") != 0f) && !Screen.showCursor && !dontControl)
		{
			Screen.lockCursor = false;
			Screen.showCursor = true;
		}
	}

	public virtual IEnumerator Cursor()
	{
		return new _0024Cursor_00241456(this).GetEnumerator();
	}

	public virtual IEnumerator SetPhoto()
	{
		return new _0024SetPhoto_00241459(this).GetEnumerator();
	}

	public virtual IEnumerator ReturnPause()
	{
		return new _0024ReturnPause_00241462(this).GetEnumerator();
	}

	public virtual void Continue()
	{
		dontControl = true;
		SendMessage("LoadGame", -1);
	}

	public virtual IEnumerator StartGame()
	{
		return new _0024StartGame_00241467(this).GetEnumerator();
	}

	public virtual void StartLoad()
	{
		dontControl = true;
		photoLoadFlag = true;
		if (decideSE != null)
		{
			audio.PlayOneShot(decideSE, 0.6f);
		}
		photoContinue.SetActive(false);
		SendMessage("StartSaveLoad", (object)0);
	}

	public virtual void Options()
	{
		dontControl = true;
		optionFlag = true;
		if (decideSE != null)
		{
			audio.PlayOneShot(decideSE, 0.6f);
		}
		photoContinue.SetActive(false);
		SendMessage("StartOption");
	}

	public virtual void Credits()
	{
		dontControl = true;
		creditsFlag = true;
		if (decideSE != null)
		{
			audio.PlayOneShot(decideSE, 0.6f);
		}
		photoContinue.SetActive(false);
		SendMessage("StartCredits");
	}

	public virtual IEnumerator QuitGame()
	{
		return new _0024QuitGame_00241471(this).GetEnumerator();
	}

	public virtual IEnumerator ResetStatus()
	{
		return new _0024ResetStatus_00241474(this).GetEnumerator();
	}

	public virtual void OnGUI()
	{
		if (!(textureAlpha <= 0f))
		{
			GUI.depth = -16;
			if (!(textureAlpha >= textureFlickAmount))
			{
				float a = textureAlpha;
				Color color = GUI.color;
				float num = (color.a = a);
				Color color2 = (GUI.color = color);
			}
			else
			{
				float a2 = Mathf.Lerp(textureAlpha, textureAlpha + Mathf.Sin(Time.time * textureFlickSpeed) * textureFlickAmount, textureFlickSpeed * Time.deltaTime);
				Color color4 = GUI.color;
				float num2 = (color4.a = a2);
				Color color5 = (GUI.color = color4);
			}
			GUI.DrawTexture(new Rect((float)Screen.width - textureSize.x - offset.x, (float)Screen.height - textureSize.y - offset.y, textureSize.x, textureSize.y), loadingTexture, ScaleMode.ScaleToFit, true);
		}
	}

	public virtual void Main()
	{
	}
}
