using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class TitleLoad : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024StartSaveLoad_00241425 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal int _0024num_00241426;

			internal TitleLoad _0024self__00241427;

			public _0024(int num, TitleLoad self_)
			{
				_0024num_00241426 = num;
				_0024self__00241427 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241427.mouseX = (int)Input.mousePosition.x;
					_0024self__00241427.mouseY = (int)Input.mousePosition.y;
					_0024self__00241427.screenId = _0024num_00241426;
					_0024self__00241427.cursor1 = _0024self__00241427.status.latestId;
					if (_0024self__00241427.cursor1 == 0)
					{
						_0024self__00241427.cursor1 = 1;
					}
					_0024self__00241427.StartCoroutine_Auto(_0024self__00241427.WaitKeyUp());
					result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				case 2:
					_0024self__00241427.StartCoroutine_Auto(_0024self__00241427.Cursor());
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024num_00241428;

		internal TitleLoad _0024self__00241429;

		public _0024StartSaveLoad_00241425(int num, TitleLoad self_)
		{
			_0024num_00241428 = num;
			_0024self__00241429 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024num_00241428, _0024self__00241429);
		}
	}

	[Serializable]
	internal sealed class _0024WaitKeyUp_00241430 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal TitleLoad _0024self__00241431;

			public _0024(TitleLoad self_)
			{
				_0024self__00241431 = self_;
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
					_0024self__00241431.nowSaveLoading = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TitleLoad _0024self__00241432;

		public _0024WaitKeyUp_00241430(TitleLoad self_)
		{
			_0024self__00241432 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024self__00241432);
		}
	}

	[Serializable]
	internal sealed class _0024EndSaveLoad_00241433 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal TitleLoad _0024self__00241434;

			public _0024(TitleLoad self_)
			{
				_0024self__00241434 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241434.nowSaveLoading = false;
					result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				case 2:
					_0024self__00241434.SendMessage("ReturnPause", SendMessageOptions.DontRequireReceiver);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TitleLoad _0024self__00241435;

		public _0024EndSaveLoad_00241433(TitleLoad self_)
		{
			_0024self__00241435 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024self__00241435);
		}
	}

	[Serializable]
	internal sealed class _0024LoadGame_00241436 : GenericGenerator<YieldInstruction>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<YieldInstruction>, IEnumerator
		{
			internal bool _0024continueFlag_00241437;

			internal ES2Reader _0024reader_00241438;

			internal AsyncOperation _0024async_00241439;

			internal int _0024number_00241440;

			internal TitleLoad _0024self__00241441;

			public _0024(int number, TitleLoad self_)
			{
				_0024number_00241440 = number;
				_0024self__00241441 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024continueFlag_00241437 = false;
					if (_0024number_00241440 < 0)
					{
						_0024number_00241440 = 0;
						_0024continueFlag_00241437 = true;
					}
					Screen.lockCursor = true;
					Screen.showCursor = false;
					Debug.Log("LoadingFile...");
					_0024self__00241441.nowLoading = true;
					_0024self__00241441.screenId = 4;
					_0024self__00241441.saveMessageJap = "ロード中";
					_0024self__00241441.saveMessageEng = "Loading";
					_0024self__00241441.StartCoroutine_Auto(_0024self__00241441.NowLoadingMessage());
					_0024self__00241441.status.nowPausing = false;
					_0024self__00241441.sequenceLoad.SendMessage("Play", SendMessageOptions.DontRequireReceiver);
					if (_0024continueFlag_00241437 && _0024self__00241441.continueSE != null)
					{
						_0024self__00241441.audio.PlayOneShot(_0024self__00241441.continueSE, 0.8f);
					}
					_0024self__00241441.black.SetFadeSpeed(4f);
					_0024self__00241441.black.FadeIn();
					_0024self__00241441.levelChanger.enabled = true;
					_0024self__00241441.status.audioFadeFlag = true;
					result = (Yield(2, new WaitForSeconds(_0024self__00241441.black.FadeSpeed)) ? 1 : 0);
					break;
				case 2:
					_0024reader_00241438 = ES2Reader.Create("save/savedata" + _0024number_00241440 + ".sav?encrypt=true&encryptiontype=obfuscate&password=fundoshi");
					_0024self__00241441.status.playTimeSeconds = _0024reader_00241438.Read<float>("playTimeSeconds");
					_0024self__00241441.status.playTimeMinutes = _0024reader_00241438.Read<int>("playTimeMinutes");
					_0024self__00241441.status.playTimeHours = _0024reader_00241438.Read<int>("playTimeHours");
					_0024self__00241441.status.nowYear = _0024reader_00241438.Read<int>("nowYear");
					_0024self__00241441.status.nowMonth = _0024reader_00241438.Read<int>("nowMonth");
					_0024self__00241441.status.nowDay = _0024reader_00241438.Read<int>("nowDay");
					_0024self__00241441.status.mapName = _0024reader_00241438.Read<string>("mapName");
					_0024self__00241441.status.mapX = _0024reader_00241438.Read<float>("mapX");
					_0024self__00241441.status.mapY = _0024reader_00241438.Read<float>("mapY");
					_0024self__00241441.status.mapZ = _0024reader_00241438.Read<float>("mapZ");
					_0024self__00241441.status.playerRotation = _0024reader_00241438.Read<float>("playerRotation");
					_0024self__00241441.status.footStepId = _0024reader_00241438.Read<int>("footStepId");
					_0024self__00241441.status.footEffectId = _0024reader_00241438.Read<int>("footEffectId");
					_0024self__00241441.i = 0;
					while (_0024self__00241441.i < _0024self__00241441.status.switches.Length)
					{
						_0024self__00241441.status.switches[_0024self__00241441.i] = _0024reader_00241438.Read<int>("switches" + _0024self__00241441.i);
						_0024self__00241441.i++;
					}
					_0024self__00241441.i = 0;
					while (_0024self__00241441.i < _0024self__00241441.status.variables.Length)
					{
						_0024self__00241441.status.variables[_0024self__00241441.i] = _0024reader_00241438.Read<float>("variables" + _0024self__00241441.i);
						_0024self__00241441.i++;
					}
					_0024self__00241441.status.cameraX = _0024reader_00241438.Read<float>("cameraX");
					_0024self__00241441.status.cameraY = _0024reader_00241438.Read<float>("cameraY");
					_0024self__00241441.status.cameraZ = _0024reader_00241438.Read<float>("cameraZ");
					_0024self__00241441.status.cameraRotX = _0024reader_00241438.Read<float>("cameraRotX");
					_0024self__00241441.status.cameraRotY = _0024reader_00241438.Read<float>("cameraRotY");
					_0024self__00241441.i = 0;
					while (_0024self__00241441.i < _0024self__00241441.status.item.Length)
					{
						_0024self__00241441.status.item[_0024self__00241441.i] = _0024reader_00241438.Read<int>("item" + _0024self__00241441.i);
						_0024self__00241441.i++;
					}
					_0024self__00241441.i = 0;
					while (_0024self__00241441.i < _0024self__00241441.status.file.Length)
					{
						_0024self__00241441.status.file[_0024self__00241441.i] = _0024reader_00241438.Read<int>("file" + _0024self__00241441.i);
						_0024self__00241441.i++;
					}
					_0024reader_00241438.Dispose();
					Debug.Log("LoadingLevel...");
					_0024self__00241441.status.loadPermission = true;
					_0024self__00241441.status.savePermission = true;
					_0024self__00241441.isLoading = true;
					_0024async_00241439 = Application.LoadLevelAsync(_0024self__00241441.status.mapName);
					_0024async_00241439.allowSceneActivation = false;
					goto case 3;
				case 3:
					if (_0024async_00241439.progress < 0.9f)
					{
						result = (Yield(3, new WaitForEndOfFrame()) ? 1 : 0);
						break;
					}
					_0024self__00241441.isLoading = false;
					goto IL_06f0;
				case 4:
					if (!(_0024self__00241441.textureAlpha > 0f))
					{
						_0024async_00241439.allowSceneActivation = true;
					}
					goto IL_06f0;
				case 1:
					{
						result = 0;
						break;
					}
					IL_06f0:
					if (!_0024async_00241439.isDone)
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

		internal int _0024number_00241442;

		internal TitleLoad _0024self__00241443;

		public _0024LoadGame_00241436(int number, TitleLoad self_)
		{
			_0024number_00241442 = number;
			_0024self__00241443 = self_;
		}

		public override IEnumerator<YieldInstruction> GetEnumerator()
		{
			return new _0024(_0024number_00241442, _0024self__00241443);
		}
	}

	[Serializable]
	internal sealed class _0024NowLoadingMessage_00241444 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal TitleLoad _0024self__00241445;

			public _0024(TitleLoad self_)
			{
				_0024self__00241445 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241445.saveMessageJap = "ロード中.";
					_0024self__00241445.saveMessageEng = "Loading.";
					result = (Yield(3, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 3:
					_0024self__00241445.saveMessageJap = "ロード中..";
					_0024self__00241445.saveMessageEng = "Loading..";
					result = (Yield(4, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 4:
					_0024self__00241445.saveMessageJap = "ロード中...";
					_0024self__00241445.saveMessageEng = "Loading...";
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TitleLoad _0024self__00241446;

		public _0024NowLoadingMessage_00241444(TitleLoad self_)
		{
			_0024self__00241446 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241446);
		}
	}

	[Serializable]
	internal sealed class _0024Cursor_00241447 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal TitleLoad _0024self__00241448;

			public _0024(TitleLoad self_)
			{
				_0024self__00241448 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00241448.nowSaveLoading)
					{
						if (_0024self__00241448.screenId == 0 || _0024self__00241448.screenId == 1)
						{
							if (cInput.GetAxisRaw("Vertical") >= 0.1f || cInput.GetAxisRaw("J_Vertical") >= 0.1f || !(cInput.GetAxisRaw("DPad_Vertical") < 0.1f))
							{
								if (_0024self__00241448.channelSE != null)
								{
									_0024self__00241448.audio.PlayOneShot(_0024self__00241448.channelSE, 0.8f);
								}
								if (_0024self__00241448.screenId == 0 && _0024self__00241448.cursor1 == 1)
								{
									_0024self__00241448.cursor1 = 4;
								}
								else if (_0024self__00241448.screenId == 1 && _0024self__00241448.cursor1 == 1)
								{
									_0024self__00241448.cursor1 = 4;
								}
								else
								{
									_0024self__00241448.cursor1--;
								}
								_0024self__00241448.StartCoroutine_Auto(_0024self__00241448.Noise2());
								goto IL_0169;
							}
							goto IL_01b7;
						}
						if ((_0024self__00241448.screenId == 2 || _0024self__00241448.screenId == 3) && !_0024self__00241448.nowLoading)
						{
							if (cInput.GetAxisRaw("Horizontal") >= 0.1f || cInput.GetAxisRaw("J_Horizontal") >= 0.1f || !(cInput.GetAxisRaw("DPad_Horizontal") < 0.1f))
							{
								_0024self__00241448.cursor2++;
								if (_0024self__00241448.cursorSE != null)
								{
									_0024self__00241448.audio.PlayOneShot(_0024self__00241448.cursorSE, 0.4f);
								}
								if (_0024self__00241448.cursor2 >= 2)
								{
									_0024self__00241448.cursor2 = 0;
								}
								goto IL_03f3;
							}
							goto IL_0441;
						}
						goto IL_0545;
					}
					YieldDefault(1);
					goto case 1;
				case 2:
					if (cInput.GetAxisRaw("Vertical") == 0f && cInput.GetAxisRaw("J_Vertical") == 0f && cInput.GetAxisRaw("DPad_Vertical") == 0f)
					{
						goto IL_01b7;
					}
					goto IL_0169;
				case 3:
					if (cInput.GetAxisRaw("Vertical") == 0f && cInput.GetAxisRaw("J_Vertical") == 0f && cInput.GetAxisRaw("DPad_Vertical") == 0f)
					{
						goto IL_0545;
					}
					goto IL_02c2;
				case 4:
					if (cInput.GetAxisRaw("Horizontal") == 0f && cInput.GetAxisRaw("J_Horizontal") == 0f && cInput.GetAxisRaw("DPad_Horizontal") == 0f)
					{
						goto IL_0441;
					}
					goto IL_03f3;
				case 5:
					if (cInput.GetAxisRaw("Horizontal") == 0f && cInput.GetAxisRaw("J_Horizontal") == 0f && cInput.GetAxisRaw("DPad_Horizontal") == 0f)
					{
						goto IL_0545;
					}
					goto IL_04ed;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0441:
					if (cInput.GetAxisRaw("Horizontal") <= -0.1f || cInput.GetAxisRaw("J_Horizontal") <= -0.1f || !(cInput.GetAxisRaw("DPad_Horizontal") > -0.1f))
					{
						_0024self__00241448.cursor2--;
						if (_0024self__00241448.cursorSE != null)
						{
							_0024self__00241448.audio.PlayOneShot(_0024self__00241448.cursorSE, 0.4f);
						}
						if (_0024self__00241448.cursor2 < 0)
						{
							_0024self__00241448.cursor2 = 1;
						}
						goto IL_04ed;
					}
					goto IL_0545;
					IL_02c2:
					result = (Yield(3, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_01b7:
					if (cInput.GetAxisRaw("Vertical") <= -0.1f || cInput.GetAxisRaw("J_Vertical") <= -0.1f || !(cInput.GetAxisRaw("DPad_Vertical") > -0.1f))
					{
						if (_0024self__00241448.channelSE != null)
						{
							_0024self__00241448.audio.PlayOneShot(_0024self__00241448.channelSE, 0.8f);
						}
						if (_0024self__00241448.screenId == 0 && _0024self__00241448.cursor1 == 4)
						{
							_0024self__00241448.cursor1 = 1;
						}
						else if (_0024self__00241448.screenId == 1 && _0024self__00241448.cursor1 == 4)
						{
							_0024self__00241448.cursor1 = 1;
						}
						else
						{
							_0024self__00241448.cursor1++;
						}
						_0024self__00241448.StartCoroutine_Auto(_0024self__00241448.Noise2());
						goto IL_02c2;
					}
					goto IL_0545;
					IL_0545:
					result = (Yield(6, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_04ed:
					result = (Yield(5, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_03f3:
					result = (Yield(4, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_0169:
					result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TitleLoad _0024self__00241449;

		public _0024Cursor_00241447(TitleLoad self_)
		{
			_0024self__00241449 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024self__00241449);
		}
	}

	[Serializable]
	internal sealed class _0024Noise_00241450 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal TitleLoad _0024self__00241451;

			public _0024(TitleLoad self_)
			{
				_0024self__00241451 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241451.j = 0;
					goto IL_0098;
				case 2:
					if (Time.realtimeSinceStartup < _0024self__00241451.noiseEndTime)
					{
						result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
						break;
					}
					_0024self__00241451.j++;
					goto IL_0098;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0098:
					if (_0024self__00241451.j < 4)
					{
						_0024self__00241451.screenPosition = UnityEngine.Random.Range(0f, 1f);
						_0024self__00241451.noiseEndTime = Time.realtimeSinceStartup + 0.04f;
						goto case 2;
					}
					_0024self__00241451.screenPosition = 0f;
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal TitleLoad _0024self__00241452;

		public _0024Noise_00241450(TitleLoad self_)
		{
			_0024self__00241452 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024self__00241452);
		}
	}

	[Serializable]
	internal sealed class _0024Noise2_00241453 : GenericGenerator<YieldInstruction>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<YieldInstruction>, IEnumerator
		{
			internal TitleLoad _0024self__00241454;

			public _0024(TitleLoad self_)
			{
				_0024self__00241454 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241454.nowNoising = true;
					_0024self__00241454.screenObject.mainTexture = _0024self__00241454.screenDefaultTexture;
					result = (Yield(2, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241454.nowNoising = false;
					_0024self__00241454.j = 0;
					goto IL_00e9;
				case 3:
					if (Time.realtimeSinceStartup < _0024self__00241454.noiseEndTime)
					{
						result = (Yield(3, new WaitForEndOfFrame()) ? 1 : 0);
						break;
					}
					_0024self__00241454.j++;
					goto IL_00e9;
				case 4:
					if (_0024self__00241454.screenPosition >= -0.99f)
					{
						_0024self__00241454.screenPosition -= Time.deltaTime * 6f;
						result = (Yield(4, new WaitForEndOfFrame()) ? 1 : 0);
						break;
					}
					_0024self__00241454.screenPosition = 0f;
					YieldDefault(1);
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00e9:
					if (_0024self__00241454.j < 4)
					{
						_0024self__00241454.screenPosition = UnityEngine.Random.Range(0f, 1f);
						_0024self__00241454.noiseEndTime = Time.realtimeSinceStartup + 0.04f;
						goto case 3;
					}
					_0024self__00241454.screenPosition = 0f;
					goto case 4;
				}
				return (byte)result != 0;
			}
		}

		internal TitleLoad _0024self__00241455;

		public _0024Noise2_00241453(TitleLoad self_)
		{
			_0024self__00241455 = self_;
		}

		public override IEnumerator<YieldInstruction> GetEnumerator()
		{
			return new _0024(_0024self__00241455);
		}
	}

	public Texture2D backGroundTex;

	public Texture2D cursorUpTexTrue;

	public Texture2D cursorUpTexFalse;

	public Texture2D cursorDownTexTrue;

	public Texture2D cursorDownTexFalse;

	public Texture2D activeTex;

	public Texture2D yesTexTrueJap;

	public Texture2D yesTexFalseJap;

	public Texture2D noTexTrueJap;

	public Texture2D noTexFalseJap;

	public Texture2D yesTexTrueEng;

	public Texture2D yesTexFalseEng;

	public Texture2D noTexTrueEng;

	public Texture2D noTexFalseEng;

	public AudioClip cursorSE;

	public AudioClip decideSE;

	public AudioClip channelSE;

	public AudioClip continueSE;

	public string[] explainPassageJap;

	public string[] explainPassageEng;

	public Material screenObject;

	public Texture2D screenDefaultTexture;

	private int screenId;

	public int cursor1;

	private int cursor2;

	private int cursorUD;

	private int cursorAC;

	public GUISkin skin;

	[NonSerialized]
	public static int guiDepth = -8;

	private Player_Status status;

	private BlackOutController black;

	private LevelChanger levelChanger;

	private int i;

	private int j;

	private int mouseX;

	private int mouseY;

	private float screenPosition;

	private float noiseEndTime;

	private int random;

	private bool nowNoising;

	private string saveMessageJap;

	private string saveMessageEng;

	private bool nowSaveLoading;

	private bool nowLoading;

	private string filePath;

	private string[] datastageName;

	private int[] datastageNowPlaying;

	private string[] dataSeconds;

	private string[] dataMinutes;

	private string[] dataHours;

	public int[] dataYear;

	public string[] dataMonth;

	public string[] dataDay;

	private string[] dataDisplay;

	public GameObject sequenceLoad;

	public Texture2D loadingTexture;

	public Vector2 textureSize;

	public Vector2 offset;

	public float textureFadeSpeed;

	public float textureFlickSpeed;

	public float textureFlickAmount;

	private bool isLoading;

	private float textureAlpha;

	public TitleLoad()
	{
		cursor2 = 1;
		saveMessageJap = "セーブ中";
		saveMessageEng = "Saving";
	}

	public virtual void Start()
	{
		datastageName = new string[5];
		datastageNowPlaying = new int[5];
		dataSeconds = new string[5];
		dataMinutes = new string[5];
		dataHours = new string[5];
		dataYear = new int[5];
		dataMonth = new string[5];
		dataDay = new string[5];
		dataDisplay = new string[5];
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		black = (BlackOutController)GetComponent(typeof(BlackOutController));
		levelChanger = (LevelChanger)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(LevelChanger));
		levelChanger.enabled = false;
		PrepareData();
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
		if (screenId != 4 && screenId != 5 && !nowNoising)
		{
			switch (cursor1)
			{
			case 0:
				if (status.screenTexture0 != null)
				{
					screenObject.mainTexture = status.screenTexture0;
				}
				else
				{
					screenObject.mainTexture = screenDefaultTexture;
				}
				break;
			case 1:
				if (status.screenTexture1 != null)
				{
					screenObject.mainTexture = status.screenTexture1;
				}
				else
				{
					screenObject.mainTexture = screenDefaultTexture;
				}
				break;
			case 2:
				if (status.screenTexture2 != null)
				{
					screenObject.mainTexture = status.screenTexture2;
				}
				else
				{
					screenObject.mainTexture = screenDefaultTexture;
				}
				break;
			case 3:
				if (status.screenTexture3 != null)
				{
					screenObject.mainTexture = status.screenTexture3;
				}
				else
				{
					screenObject.mainTexture = screenDefaultTexture;
				}
				break;
			case 4:
				if (status.screenTexture4 != null)
				{
					screenObject.mainTexture = status.screenTexture4;
				}
				else
				{
					screenObject.mainTexture = screenDefaultTexture;
				}
				break;
			}
		}
		float y = screenPosition;
		Vector2 mainTextureOffset = screenObject.mainTextureOffset;
		float num = (mainTextureOffset.y = y);
		Vector2 vector = (screenObject.mainTextureOffset = mainTextureOffset);
		random = UnityEngine.Random.Range(0, 10000);
		if (random >= 9990)
		{
			StartCoroutine_Auto(Noise());
		}
		if (!nowSaveLoading)
		{
			return;
		}
		if ((cInput.GetAxis("Mouse X") != 0f || cInput.GetAxis("Mouse Y") != 0f) && !Screen.showCursor && !nowLoading)
		{
			Screen.lockCursor = false;
			Screen.showCursor = true;
		}
		if (screenId == 0 || screenId == 1)
		{
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 8 + 260)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 8 + 260 + 16)) && !(Input.mousePosition.y > 208f) && !(Input.mousePosition.y < 192f))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursorUD != 1)
				{
					cursorUD = 1;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursorUD == 1)
				{
					if (screenId == 0)
					{
						if (cursor1 == 1)
						{
							cursor1 = 4;
						}
						else
						{
							cursor1--;
						}
					}
					else if (screenId == 1)
					{
						if (cursor1 == 1)
						{
							cursor1 = 4;
						}
						else
						{
							cursor1--;
						}
					}
					if (channelSE != null)
					{
						audio.PlayOneShot(channelSE, 0.8f);
					}
					StartCoroutine_Auto(Noise2());
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 8 + 260)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 8 + 260 + 16)) && !(Input.mousePosition.y > 128f) && !(Input.mousePosition.y < 112f))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursorUD != 2)
				{
					cursorUD = 2;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursorUD == 2)
				{
					if (screenId == 0)
					{
						if (cursor1 == 4)
						{
							cursor1 = 1;
						}
						else
						{
							cursor1++;
						}
					}
					else if (screenId == 1)
					{
						if (cursor1 == 4)
						{
							cursor1 = 1;
						}
						else
						{
							cursor1++;
						}
					}
					if (channelSE != null)
					{
						audio.PlayOneShot(channelSE, 0.8f);
					}
					StartCoroutine_Auto(Noise2());
				}
			}
			else
			{
				cursorUD = 0;
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 170)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 170 + 480)) && !(Input.mousePosition.y > 180f) && !(Input.mousePosition.y < 140f))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursorAC != 1)
				{
					cursorAC = 1;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursorAC == 1)
				{
					if (screenId == 0)
					{
						if (dataDisplay[cursor1] != "NO DATA")
						{
							cursor2 = 1;
							screenId = 2;
							if (decideSE != null)
							{
								audio.PlayOneShot(decideSE, 0.6f);
							}
						}
					}
					else if (screenId == 1)
					{
						cursor2 = 1;
						screenId = 3;
						if (decideSE != null)
						{
							audio.PlayOneShot(decideSE, 0.6f);
						}
					}
				}
			}
			else
			{
				cursorAC = 0;
			}
			if (SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Action") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Action"))
			{
				if (screenId == 0)
				{
					if (dataDisplay[cursor1] != "NO DATA")
					{
						cursor2 = 1;
						screenId = 2;
						if (decideSE != null)
						{
							audio.PlayOneShot(decideSE, 0.6f);
						}
					}
				}
				else if (screenId == 1)
				{
					cursor2 = 1;
					screenId = 3;
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			if (SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Sprint") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Sprint") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Pause") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Pause") || SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(1))
			{
				if (decideSE != null)
				{
					audio.PlayOneShot(decideSE, 0.6f);
				}
				StartCoroutine_Auto(EndSaveLoad());
			}
		}
		else if ((screenId == 2 || screenId == 3) && !nowLoading)
		{
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 40 - 80)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 40)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 40 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 40 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor2 != 0)
				{
					cursor2 = 0;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor2 == 0)
				{
					if (screenId == 2)
					{
						StartCoroutine_Auto(LoadGame(cursor1));
						if (decideSE != null)
						{
							audio.PlayOneShot(decideSE, 0.6f);
						}
					}
					else if (screenId == 3 && decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 40 + 80)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 40 + 160)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 40 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 40 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor2 != 1)
				{
					cursor2 = 1;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor2 == 1)
				{
					if (screenId == 2)
					{
						cursorAC = 0;
						screenId = 0;
					}
					else if (screenId == 3)
					{
						cursorAC = 0;
						screenId = 1;
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			if (SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Action") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Action"))
			{
				if (cursor2 == 0)
				{
					if (screenId == 2)
					{
						StartCoroutine_Auto(LoadGame(cursor1));
					}
					else if (screenId != 3)
					{
					}
				}
				else if (cursor2 == 1)
				{
					if (screenId == 2)
					{
						cursorAC = 0;
						screenId = 0;
					}
					else if (screenId == 3)
					{
						cursorAC = 0;
						screenId = 1;
					}
				}
				if (decideSE != null)
				{
					audio.PlayOneShot(decideSE, 0.6f);
				}
			}
			if (SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Sprint") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Sprint") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Pause") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Pause") || SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(1))
			{
				if (screenId == 2)
				{
					cursorAC = 0;
					screenId = 0;
				}
				else if (screenId == 3)
				{
					cursorAC = 0;
					screenId = 1;
				}
				if (decideSE != null)
				{
					audio.PlayOneShot(decideSE, 0.6f);
				}
			}
		}
		else if (screenId == 5 && (SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Action") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Action") || SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) || SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(1) || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Sprint") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Sprint") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Pause") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Pause")))
		{
			cursorAC = 0;
			screenId = 1;
			if (decideSE != null)
			{
				audio.PlayOneShot(decideSE, 0.6f);
			}
			StartCoroutine_Auto(Noise2());
		}
		mouseX = (int)Input.mousePosition.x;
		mouseY = (int)Input.mousePosition.y;
	}

	public virtual IEnumerator StartSaveLoad(int num)
	{
		return new _0024StartSaveLoad_00241425(num, this).GetEnumerator();
	}

	public virtual IEnumerator WaitKeyUp()
	{
		return new _0024WaitKeyUp_00241430(this).GetEnumerator();
	}

	public virtual IEnumerator EndSaveLoad()
	{
		return new _0024EndSaveLoad_00241433(this).GetEnumerator();
	}

	public virtual void PrepareData()
	{
		for (i = 0; i < 5; i++)
		{
			if (ES2.Exists("save/savedata" + i + ".sav"))
			{
				ES2Reader eS2Reader = ES2Reader.Create("save/savedata" + i + ".sav?encrypt=true&encryptiontype=obfuscate&password=fundoshi");
				float num = eS2Reader.Read<float>("playTimeSeconds");
				int num2 = eS2Reader.Read<int>("playTimeMinutes");
				int num3 = eS2Reader.Read<int>("playTimeHours");
				dataYear[i] = eS2Reader.Read<int>("nowYear");
				int num4 = eS2Reader.Read<int>("nowMonth");
				int num5 = eS2Reader.Read<int>("nowDay");
				eS2Reader.Dispose();
				int num6 = (int)num;
				if (num6 < 10)
				{
					dataSeconds[i] = "0" + num6;
				}
				else
				{
					dataSeconds[i] = string.Empty + num6;
				}
				if (num2 < 10)
				{
					dataMinutes[i] = "0" + num2;
				}
				else
				{
					dataMinutes[i] = string.Empty + num2;
				}
				if (num3 < 10)
				{
					dataHours[i] = "00" + num3;
				}
				else if (num3 < 100)
				{
					dataHours[i] = "0" + num3;
				}
				else
				{
					dataHours[i] = string.Empty + num3;
				}
				if (num4 < 10)
				{
					dataMonth[i] = "0" + num4;
				}
				else
				{
					dataMonth[i] = string.Empty + num4;
				}
				if (num5 < 10)
				{
					dataDay[i] = "0" + num5;
				}
				else
				{
					dataDay[i] = string.Empty + num5;
				}
				dataDisplay[i] = "\u3000PlayTime\u3000" + dataHours[i] + ":" + dataMinutes[i] + ":" + dataSeconds[i] + "\u3000Date\t" + dataYear[i] + "/" + dataMonth[i] + "/" + dataDay[i] + "\u3000";
			}
			else
			{
				dataDisplay[i] = "NO DATA";
			}
		}
	}

	public virtual IEnumerator LoadGame(int number)
	{
		return new _0024LoadGame_00241436(number, this).GetEnumerator();
	}

	public virtual IEnumerator NowLoadingMessage()
	{
		return new _0024NowLoadingMessage_00241444(this).GetEnumerator();
	}

	public virtual IEnumerator Cursor()
	{
		return new _0024Cursor_00241447(this).GetEnumerator();
	}

	public virtual IEnumerator Noise()
	{
		return new _0024Noise_00241450(this).GetEnumerator();
	}

	public virtual IEnumerator Noise2()
	{
		return new _0024Noise2_00241453(this).GetEnumerator();
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
		else
		{
			if (!nowSaveLoading)
			{
				return;
			}
			GUI.depth = guiDepth;
			if (screenId == 0 || screenId == 1)
			{
				GUI.DrawTexture(new Rect(0f, Screen.height - 60, Screen.width, 40f), backGroundTex);
				if (screenId == 0)
				{
					if (status.language == 0)
					{
						GUI.Label(new Rect(0f, Screen.height - 60, Screen.width, 40f), explainPassageJap[0], skin.customStyles[0]);
					}
					else
					{
						GUI.Label(new Rect(0f, Screen.height - 60, Screen.width, 40f), explainPassageEng[0], skin.customStyles[0]);
					}
				}
				else if (screenId == 1)
				{
					if (status.language == 0)
					{
						GUI.Label(new Rect(0f, Screen.height - 60, Screen.width, 40f), explainPassageJap[1], skin.customStyles[0]);
					}
					else
					{
						GUI.Label(new Rect(0f, Screen.height - 60, Screen.width, 40f), explainPassageEng[1], skin.customStyles[0]);
					}
				}
				GUI.DrawTexture(new Rect(0f, Screen.height - 220, Screen.width, 120f), backGroundTex);
				if (screenId == 0)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height - 220, 140f, 40f), "[LoadGame]", skin.customStyles[1]);
				}
				else if (screenId == 1)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height - 220, 140f, 40f), "[SaveGame]", skin.customStyles[1]);
				}
				switch (cursor1)
				{
				case 0:
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height - 180, 140f, 40f), "LATEST\u3000|", skin.customStyles[1]);
					break;
				case 1:
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height - 180, 140f, 40f), "FILE 1\u3000|", skin.customStyles[1]);
					break;
				case 2:
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height - 180, 140f, 40f), "FILE 2\u3000|", skin.customStyles[1]);
					break;
				case 3:
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height - 180, 140f, 40f), "FILE 3\u3000|", skin.customStyles[1]);
					break;
				case 4:
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height - 180, 140f, 40f), "FILE 4\u3000|", skin.customStyles[1]);
					break;
				}
				GUI.Label(new Rect(Screen.width / 2 - 180, Screen.height - 180, 500f, 40f), dataDisplay[cursor1], skin.customStyles[0]);
				if (cursorUD == 1)
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 8 + 260, Screen.height - 168 - 40, 16f, 16f), cursorUpTexTrue);
				}
				else
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 8 + 260, Screen.height - 168 - 40, 16f, 16f), cursorUpTexFalse);
				}
				if (cursorUD == 2)
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 8 + 260, Screen.height - 168 + 40, 16f, 16f), cursorDownTexTrue);
				}
				else
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 8 + 260, Screen.height - 168 + 40, 16f, 16f), cursorDownTexFalse);
				}
				if (cursorAC == 1)
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 200, Screen.height - 180, 540f, 40f), activeTex, ScaleMode.StretchToFill, true);
				}
			}
			else if (screenId == 2)
			{
				GUI.DrawTexture(new Rect(0f, Screen.height / 2 - 140, Screen.width, 280f), backGroundTex);
				switch (cursor1)
				{
				case 0:
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 40 - 65, 140f, 26f), "LATEST\u3000|", skin.customStyles[1]);
					break;
				case 1:
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 40 - 65, 140f, 26f), "FILE 1\u3000|", skin.customStyles[1]);
					break;
				case 2:
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 40 - 65, 140f, 26f), "FILE 2\u3000|", skin.customStyles[1]);
					break;
				case 3:
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 40 - 65, 140f, 26f), "FILE 3\u3000|", skin.customStyles[1]);
					break;
				case 4:
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 40 - 65, 140f, 26f), "FILE 4\u3000|", skin.customStyles[1]);
					break;
				}
				GUI.Label(new Rect(Screen.width / 2 - 180, Screen.height / 2 - 40 - 65, 500f, 26f), dataDisplay[cursor1], skin.customStyles[0]);
				if (status.language == 0)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 40 - 13, 640f, 26f), explainPassageJap[4], skin.customStyles[0]);
					if (cursor2 == 0)
					{
						GUI.DrawTexture(new Rect(Screen.width / 2 - 40 - 80, Screen.height / 2 + 40 - 13, 80f, 26f), yesTexTrueJap);
					}
					else
					{
						GUI.DrawTexture(new Rect(Screen.width / 2 - 40 - 80, Screen.height / 2 + 40 - 13, 80f, 26f), yesTexFalseJap);
					}
					if (cursor2 == 1)
					{
						GUI.DrawTexture(new Rect(Screen.width / 2 - 40 + 80, Screen.height / 2 + 40 - 13, 80f, 26f), noTexTrueJap);
					}
					else
					{
						GUI.DrawTexture(new Rect(Screen.width / 2 - 40 + 80, Screen.height / 2 + 40 - 13, 80f, 26f), noTexFalseJap);
					}
				}
				else
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 40 - 13, 640f, 26f), explainPassageEng[4], skin.customStyles[0]);
					if (cursor2 == 0)
					{
						GUI.DrawTexture(new Rect(Screen.width / 2 - 40 - 80, Screen.height / 2 + 40 - 13, 80f, 26f), yesTexTrueEng);
					}
					else
					{
						GUI.DrawTexture(new Rect(Screen.width / 2 - 40 - 80, Screen.height / 2 + 40 - 13, 80f, 26f), yesTexFalseEng);
					}
					if (cursor2 == 1)
					{
						GUI.DrawTexture(new Rect(Screen.width / 2 - 40 + 80, Screen.height / 2 + 40 - 13, 80f, 26f), noTexTrueEng);
					}
					else
					{
						GUI.DrawTexture(new Rect(Screen.width / 2 - 40 + 80, Screen.height / 2 + 40 - 13, 80f, 26f), noTexFalseEng);
					}
				}
			}
			else if (screenId == 3)
			{
				GUI.DrawTexture(new Rect(0f, Screen.height / 2 - 140, Screen.width, 280f), backGroundTex);
				if (dataDisplay[cursor1] != "NO DATA")
				{
					switch (cursor1)
					{
					case 0:
						GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 40 - 65, 140f, 26f), "LATEST\u3000|", skin.customStyles[1]);
						break;
					case 1:
						GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 40 - 65, 140f, 26f), "FILE 1\u3000|", skin.customStyles[1]);
						break;
					case 2:
						GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 40 - 65, 140f, 26f), "FILE 2\u3000|", skin.customStyles[1]);
						break;
					case 3:
						GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 40 - 65, 140f, 26f), "FILE 3\u3000|", skin.customStyles[1]);
						break;
					case 4:
						GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 40 - 65, 140f, 26f), "FILE 4\u3000|", skin.customStyles[1]);
						break;
					}
					GUI.Label(new Rect(Screen.width / 2 - 180, Screen.height / 2 - 40 - 65, 500f, 26f), dataDisplay[cursor1], skin.customStyles[0]);
				}
				else
				{
					switch (cursor1)
					{
					case 0:
						GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 40 - 65, 640f, 26f), "LATEST", skin.customStyles[0]);
						break;
					case 1:
						GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 40 - 65, 640f, 26f), "FILE 1", skin.customStyles[0]);
						break;
					case 2:
						GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 40 - 65, 640f, 26f), "FILE 2", skin.customStyles[0]);
						break;
					case 3:
						GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 40 - 65, 640f, 26f), "FILE 3", skin.customStyles[0]);
						break;
					case 4:
						GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 40 - 65, 640f, 26f), "FILE 4", skin.customStyles[0]);
						break;
					}
				}
				if (status.language == 0)
				{
					if (dataDisplay[cursor1] != "NO DATA")
					{
						GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 40 - 13, 640f, 26f), explainPassageJap[2], skin.customStyles[0]);
					}
					else
					{
						GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 40 - 13, 640f, 26f), explainPassageJap[3], skin.customStyles[0]);
					}
					if (cursor2 == 0)
					{
						GUI.DrawTexture(new Rect(Screen.width / 2 - 40 - 80, Screen.height / 2 + 40 - 13, 80f, 26f), yesTexTrueJap);
					}
					else
					{
						GUI.DrawTexture(new Rect(Screen.width / 2 - 40 - 80, Screen.height / 2 + 40 - 13, 80f, 26f), yesTexFalseJap);
					}
					if (cursor2 == 1)
					{
						GUI.DrawTexture(new Rect(Screen.width / 2 - 40 + 80, Screen.height / 2 + 40 - 13, 80f, 26f), noTexTrueJap);
					}
					else
					{
						GUI.DrawTexture(new Rect(Screen.width / 2 - 40 + 80, Screen.height / 2 + 40 - 13, 80f, 26f), noTexFalseJap);
					}
				}
				else
				{
					if (dataDisplay[cursor1] != "NO DATA")
					{
						GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 40 - 13, 640f, 26f), explainPassageEng[2], skin.customStyles[0]);
					}
					else
					{
						GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 40 - 13, 640f, 26f), explainPassageEng[3], skin.customStyles[0]);
					}
					if (cursor2 == 0)
					{
						GUI.DrawTexture(new Rect(Screen.width / 2 - 40 - 80, Screen.height / 2 + 40 - 13, 80f, 26f), yesTexTrueEng);
					}
					else
					{
						GUI.DrawTexture(new Rect(Screen.width / 2 - 40 - 80, Screen.height / 2 + 40 - 13, 80f, 26f), yesTexFalseEng);
					}
					if (cursor2 == 1)
					{
						GUI.DrawTexture(new Rect(Screen.width / 2 - 40 + 80, Screen.height / 2 + 40 - 13, 80f, 26f), noTexTrueEng);
					}
					else
					{
						GUI.DrawTexture(new Rect(Screen.width / 2 - 40 + 80, Screen.height / 2 + 40 - 13, 80f, 26f), noTexFalseEng);
					}
				}
			}
			else if (screenId == 4)
			{
				GUI.DrawTexture(new Rect(0f, Screen.height / 2 - 140, Screen.width, 280f), backGroundTex);
				if (status.language == 0)
				{
					GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 13, 300f, 26f), saveMessageJap, skin.customStyles[2]);
				}
				else
				{
					GUI.Label(new Rect(Screen.width / 2 - 60, Screen.height / 2 - 13, 300f, 26f), saveMessageEng, skin.customStyles[2]);
				}
			}
			else if (screenId == 5)
			{
				GUI.DrawTexture(new Rect(0f, Screen.height / 2 - 140, Screen.width, 280f), backGroundTex);
				if (status.language == 0)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 13, 640f, 26f), explainPassageJap[5], skin.customStyles[0]);
				}
				else
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 13, 640f, 26f), explainPassageEng[5], skin.customStyles[0]);
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
