using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class SaveLoadMenu : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024WaitKeyUp_00241356 : GenericGenerator<YieldInstruction>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<YieldInstruction>, IEnumerator
		{
			internal SaveLoadMenu _0024self__00241357;

			public _0024(SaveLoadMenu self_)
			{
				_0024self__00241357 = self_;
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
					result = (Yield(3, new WaitForSeconds(_0024self__00241357.black.firstFadeWaitTime + _0024self__00241357.black.FadeSpeed)) ? 1 : 0);
					break;
				case 3:
					_0024self__00241357.nowSaveLoading = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal SaveLoadMenu _0024self__00241358;

		public _0024WaitKeyUp_00241356(SaveLoadMenu self_)
		{
			_0024self__00241358 = self_;
		}

		public override IEnumerator<YieldInstruction> GetEnumerator()
		{
			return new _0024(_0024self__00241358);
		}
	}

	[Serializable]
	internal sealed class _0024EndSaveLoad_00241359 : GenericGenerator<YieldInstruction>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<YieldInstruction>, IEnumerator
		{
			internal AsyncOperation _0024async_00241360;

			internal SaveLoadMenu _0024self__00241361;

			public _0024(SaveLoadMenu self_)
			{
				_0024self__00241361 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Screen.lockCursor = true;
					Screen.showCursor = false;
					_0024self__00241361.nowSaveLoading = false;
					_0024self__00241361.nowLoading = true;
					if (_0024self__00241361.screenId == 0)
					{
						_0024self__00241361.status.saveLoadFlag = 2;
					}
					else
					{
						_0024self__00241361.status.saveLoadFlag = 3;
					}
					_0024self__00241361.black.FadeIn();
					_0024self__00241361.audioManager.AudioFadeOut(_0024self__00241361.black.FadeSpeed - 0.22f);
					_0024self__00241361.levelChanger.enabled = true;
					result = (Yield(2, new WaitForSeconds(_0024self__00241361.black.FadeSpeed)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241361.isLoading = true;
					_0024async_00241360 = Application.LoadLevelAsync(_0024self__00241361.status.mapName);
					_0024async_00241360.allowSceneActivation = false;
					goto case 3;
				case 3:
					if (_0024async_00241360.progress < 0.9f)
					{
						result = (Yield(3, new WaitForEndOfFrame()) ? 1 : 0);
						break;
					}
					_0024self__00241361.isLoading = false;
					goto IL_0180;
				case 4:
					if (!(_0024self__00241361.textureAlpha > 0f))
					{
						_0024async_00241360.allowSceneActivation = true;
					}
					goto IL_0180;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0180:
					if (!_0024async_00241360.isDone)
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

		internal SaveLoadMenu _0024self__00241362;

		public _0024EndSaveLoad_00241359(SaveLoadMenu self_)
		{
			_0024self__00241362 = self_;
		}

		public override IEnumerator<YieldInstruction> GetEnumerator()
		{
			return new _0024(_0024self__00241362);
		}
	}

	[Serializable]
	internal sealed class _0024LoadGame_00241363 : GenericGenerator<YieldInstruction>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<YieldInstruction>, IEnumerator
		{
			internal ES2Reader _0024reader_00241364;

			internal AsyncOperation _0024async_00241365;

			internal int _0024number_00241366;

			internal SaveLoadMenu _0024self__00241367;

			public _0024(int number, SaveLoadMenu self_)
			{
				_0024number_00241366 = number;
				_0024self__00241367 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Screen.lockCursor = true;
					Screen.showCursor = false;
					Debug.Log("LoadingFile...");
					_0024self__00241367.nowLoading = true;
					_0024self__00241367.screenId = 4;
					_0024self__00241367.saveMessageJap = "ロード中";
					_0024self__00241367.saveMessageEng = "Loading";
					result = (Yield(2, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241367.saveMessageJap = "ロード中.";
					_0024self__00241367.saveMessageEng = "Loading.";
					result = (Yield(3, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 3:
					_0024self__00241367.saveMessageJap = "ロード中..";
					_0024self__00241367.saveMessageEng = "Loading..";
					result = (Yield(4, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 4:
					_0024self__00241367.saveMessageJap = "ロード中...";
					_0024self__00241367.saveMessageEng = "Loading...";
					result = (Yield(5, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 5:
					_0024self__00241367.saveMessageJap = "ロード中";
					_0024self__00241367.saveMessageEng = "Loading";
					result = (Yield(6, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 6:
					_0024self__00241367.saveMessageJap = "ロード中.";
					_0024self__00241367.saveMessageEng = "Loading.";
					result = (Yield(7, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 7:
					_0024self__00241367.saveMessageJap = "ロード中..";
					_0024self__00241367.saveMessageEng = "Loading..";
					result = (Yield(8, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 8:
					_0024self__00241367.saveMessageJap = "ロード中...";
					_0024self__00241367.saveMessageEng = "Loading...";
					result = (Yield(9, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 9:
					_0024reader_00241364 = ES2Reader.Create("save/savedata" + _0024number_00241366 + ".sav?encrypt=true&encryptiontype=obfuscate&password=fundoshi");
					_0024self__00241367.status.playTimeSeconds = _0024reader_00241364.Read<float>("playTimeSeconds");
					_0024self__00241367.status.playTimeMinutes = _0024reader_00241364.Read<int>("playTimeMinutes");
					_0024self__00241367.status.playTimeHours = _0024reader_00241364.Read<int>("playTimeHours");
					_0024self__00241367.status.nowYear = _0024reader_00241364.Read<int>("nowYear");
					_0024self__00241367.status.nowMonth = _0024reader_00241364.Read<int>("nowMonth");
					_0024self__00241367.status.nowDay = _0024reader_00241364.Read<int>("nowDay");
					_0024self__00241367.status.mapName = _0024reader_00241364.Read<string>("mapName");
					_0024self__00241367.status.mapX = _0024reader_00241364.Read<float>("mapX");
					_0024self__00241367.status.mapY = _0024reader_00241364.Read<float>("mapY");
					_0024self__00241367.status.mapZ = _0024reader_00241364.Read<float>("mapZ");
					_0024self__00241367.status.playerRotation = _0024reader_00241364.Read<float>("playerRotation");
					_0024self__00241367.status.footStepId = _0024reader_00241364.Read<int>("footStepId");
					_0024self__00241367.status.footEffectId = _0024reader_00241364.Read<int>("footEffectId");
					_0024self__00241367.i = 0;
					while (_0024self__00241367.i < _0024self__00241367.status.switches.Length)
					{
						_0024self__00241367.status.switches[_0024self__00241367.i] = _0024reader_00241364.Read<int>("switches" + _0024self__00241367.i);
						_0024self__00241367.i++;
					}
					_0024self__00241367.i = 0;
					while (_0024self__00241367.i < _0024self__00241367.status.variables.Length)
					{
						_0024self__00241367.status.variables[_0024self__00241367.i] = _0024reader_00241364.Read<float>("variables" + _0024self__00241367.i);
						_0024self__00241367.i++;
					}
					_0024self__00241367.status.cameraX = _0024reader_00241364.Read<float>("cameraX");
					_0024self__00241367.status.cameraY = _0024reader_00241364.Read<float>("cameraY");
					_0024self__00241367.status.cameraZ = _0024reader_00241364.Read<float>("cameraZ");
					_0024self__00241367.status.cameraRotX = _0024reader_00241364.Read<float>("cameraRotX");
					_0024self__00241367.status.cameraRotY = _0024reader_00241364.Read<float>("cameraRotY");
					_0024self__00241367.i = 0;
					while (_0024self__00241367.i < _0024self__00241367.status.item.Length)
					{
						_0024self__00241367.status.item[_0024self__00241367.i] = _0024reader_00241364.Read<int>("item" + _0024self__00241367.i);
						_0024self__00241367.i++;
					}
					_0024self__00241367.i = 0;
					while (_0024self__00241367.i < _0024self__00241367.status.file.Length)
					{
						_0024self__00241367.status.file[_0024self__00241367.i] = _0024reader_00241364.Read<int>("file" + _0024self__00241367.i);
						_0024self__00241367.i++;
					}
					_0024reader_00241364.Dispose();
					Debug.Log("LoadingLevel...");
					_0024self__00241367.status.nowPausing = false;
					_0024self__00241367.black.FadeIn();
					_0024self__00241367.audioManager.AudioFadeOut(_0024self__00241367.black.FadeSpeed - 0.22f);
					_0024self__00241367.levelChanger.enabled = true;
					_0024self__00241367.status.audioFadeFlag = true;
					result = (Yield(10, new WaitForSeconds(_0024self__00241367.black.FadeSpeed)) ? 1 : 0);
					break;
				case 10:
					_0024self__00241367.status.loadPermission = true;
					_0024self__00241367.status.savePermission = true;
					_0024self__00241367.isLoading = true;
					_0024async_00241365 = Application.LoadLevelAsync(_0024self__00241367.status.mapName);
					_0024async_00241365.allowSceneActivation = false;
					goto case 11;
				case 11:
					if (_0024async_00241365.progress < 0.9f)
					{
						result = (Yield(11, new WaitForEndOfFrame()) ? 1 : 0);
						break;
					}
					_0024self__00241367.isLoading = false;
					goto IL_0826;
				case 12:
					if (!(_0024self__00241367.textureAlpha > 0f))
					{
						_0024async_00241365.allowSceneActivation = true;
					}
					goto IL_0826;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0826:
					if (!_0024async_00241365.isDone)
					{
						result = (Yield(12, new WaitForEndOfFrame()) ? 1 : 0);
						break;
					}
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024number_00241368;

		internal SaveLoadMenu _0024self__00241369;

		public _0024LoadGame_00241363(int number, SaveLoadMenu self_)
		{
			_0024number_00241368 = number;
			_0024self__00241369 = self_;
		}

		public override IEnumerator<YieldInstruction> GetEnumerator()
		{
			return new _0024(_0024number_00241368, _0024self__00241369);
		}
	}

	[Serializable]
	internal sealed class _0024StartSave_00241370 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal SaveLoadMenu _0024self__00241371;

			public _0024(SaveLoadMenu self_)
			{
				_0024self__00241371 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241371.screenId = 4;
					_0024self__00241371.saveMessageJap = "セーブ中";
					_0024self__00241371.saveMessageEng = "Saving";
					_0024self__00241371.screenObject.mainTexture = _0024self__00241371.screenDefaultTexture;
					result = (Yield(2, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241371.saveMessageJap = "セーブ中.";
					_0024self__00241371.saveMessageEng = "Saving.";
					result = (Yield(3, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 3:
					_0024self__00241371.saveMessageJap = "セーブ中..";
					_0024self__00241371.saveMessageEng = "Saving..";
					result = (Yield(4, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 4:
					_0024self__00241371.saveMessageJap = "セーブ中...";
					_0024self__00241371.saveMessageEng = "Saving...";
					result = (Yield(5, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 5:
					_0024self__00241371.saveMessageJap = "セーブ中";
					_0024self__00241371.saveMessageEng = "Saving";
					result = (Yield(6, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 6:
					_0024self__00241371.saveMessageJap = "セーブ中.";
					_0024self__00241371.saveMessageEng = "Saving.";
					result = (Yield(7, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 7:
					_0024self__00241371.saveMessageJap = "セーブ中..";
					_0024self__00241371.saveMessageEng = "Saving..";
					result = (Yield(8, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 8:
					_0024self__00241371.saveMessageJap = "セーブ中...";
					_0024self__00241371.saveMessageEng = "Saving...";
					result = (Yield(9, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 9:
					_0024self__00241371.status.latestId = _0024self__00241371.cursor1;
					_0024self__00241371.status.WriteSystemFile();
					_0024self__00241371.SaveGame(0);
					_0024self__00241371.SaveGame(_0024self__00241371.cursor1);
					_0024self__00241371.PrepareData();
					_0024self__00241371.screenId = 5;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal SaveLoadMenu _0024self__00241372;

		public _0024StartSave_00241370(SaveLoadMenu self_)
		{
			_0024self__00241372 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241372);
		}
	}

	[Serializable]
	internal sealed class _0024Cursor_00241373 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal SaveLoadMenu _0024self__00241374;

			public _0024(SaveLoadMenu self_)
			{
				_0024self__00241374 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00241374.nowSaveLoading)
					{
						if (_0024self__00241374.screenId == 0 || _0024self__00241374.screenId == 1)
						{
							if (cInput.GetAxisRaw("Vertical") >= 0.1f || cInput.GetAxisRaw("J_Vertical") >= 0.1f || !(cInput.GetAxisRaw("DPad_Vertical") < 0.1f))
							{
								if (_0024self__00241374.channelSE != null)
								{
									_0024self__00241374.audio.PlayOneShot(_0024self__00241374.channelSE, 0.8f);
								}
								if (_0024self__00241374.screenId == 0 && _0024self__00241374.cursor1 == 0)
								{
									_0024self__00241374.cursor1 = 4;
								}
								else if (_0024self__00241374.screenId == 1 && _0024self__00241374.cursor1 == 1)
								{
									_0024self__00241374.cursor1 = 4;
								}
								else
								{
									_0024self__00241374.cursor1--;
								}
								_0024self__00241374.StartCoroutine_Auto(_0024self__00241374.Noise2());
								goto IL_0168;
							}
							goto IL_01b6;
						}
						if ((_0024self__00241374.screenId == 2 || _0024self__00241374.screenId == 3) && !_0024self__00241374.nowLoading)
						{
							if (cInput.GetAxisRaw("Horizontal") >= 0.1f || cInput.GetAxisRaw("J_Horizontal") >= 0.1f || !(cInput.GetAxisRaw("DPad_Horizontal") < 0.1f))
							{
								_0024self__00241374.cursor2++;
								if (_0024self__00241374.cursorSE != null)
								{
									_0024self__00241374.audio.PlayOneShot(_0024self__00241374.cursorSE, 0.4f);
								}
								if (_0024self__00241374.cursor2 >= 2)
								{
									_0024self__00241374.cursor2 = 0;
								}
								goto IL_03f2;
							}
							goto IL_0440;
						}
					}
					goto IL_053a;
				case 2:
					if (cInput.GetAxisRaw("Vertical") == 0f && cInput.GetAxisRaw("J_Vertical") == 0f && cInput.GetAxisRaw("DPad_Vertical") == 0f)
					{
						goto IL_01b6;
					}
					goto IL_0168;
				case 3:
					if (cInput.GetAxisRaw("Vertical") == 0f && cInput.GetAxisRaw("J_Vertical") == 0f && cInput.GetAxisRaw("DPad_Vertical") == 0f)
					{
						goto IL_053a;
					}
					goto IL_02c1;
				case 4:
					if (cInput.GetAxisRaw("Horizontal") == 0f && cInput.GetAxisRaw("J_Horizontal") == 0f && cInput.GetAxisRaw("DPad_Horizontal") == 0f)
					{
						goto IL_0440;
					}
					goto IL_03f2;
				case 5:
					if (cInput.GetAxisRaw("Horizontal") == 0f && cInput.GetAxisRaw("J_Horizontal") == 0f && cInput.GetAxisRaw("DPad_Horizontal") == 0f)
					{
						goto IL_053a;
					}
					goto IL_04ec;
				case 1:
					{
						result = 0;
						break;
					}
					IL_02c1:
					result = (Yield(3, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_0168:
					result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_053a:
					result = (Yield(6, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_0440:
					if (cInput.GetAxisRaw("Horizontal") <= -0.1f || cInput.GetAxisRaw("J_Horizontal") <= -0.1f || !(cInput.GetAxisRaw("DPad_Horizontal") > -0.1f))
					{
						_0024self__00241374.cursor2--;
						if (_0024self__00241374.cursorSE != null)
						{
							_0024self__00241374.audio.PlayOneShot(_0024self__00241374.cursorSE, 0.4f);
						}
						if (_0024self__00241374.cursor2 < 0)
						{
							_0024self__00241374.cursor2 = 1;
						}
						goto IL_04ec;
					}
					goto IL_053a;
					IL_03f2:
					result = (Yield(4, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_01b6:
					if (cInput.GetAxisRaw("Vertical") <= -0.1f || cInput.GetAxisRaw("J_Vertical") <= -0.1f || !(cInput.GetAxisRaw("DPad_Vertical") > -0.1f))
					{
						if (_0024self__00241374.channelSE != null)
						{
							_0024self__00241374.audio.PlayOneShot(_0024self__00241374.channelSE, 0.8f);
						}
						if (_0024self__00241374.screenId == 0 && _0024self__00241374.cursor1 == 4)
						{
							_0024self__00241374.cursor1 = 0;
						}
						else if (_0024self__00241374.screenId == 1 && _0024self__00241374.cursor1 == 4)
						{
							_0024self__00241374.cursor1 = 1;
						}
						else
						{
							_0024self__00241374.cursor1++;
						}
						_0024self__00241374.StartCoroutine_Auto(_0024self__00241374.Noise2());
						goto IL_02c1;
					}
					goto IL_053a;
					IL_04ec:
					result = (Yield(5, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				}
				return (byte)result != 0;
			}
		}

		internal SaveLoadMenu _0024self__00241375;

		public _0024Cursor_00241373(SaveLoadMenu self_)
		{
			_0024self__00241375 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024self__00241375);
		}
	}

	[Serializable]
	internal sealed class _0024Noise_00241376 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal SaveLoadMenu _0024self__00241377;

			public _0024(SaveLoadMenu self_)
			{
				_0024self__00241377 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241377.j = 0;
					goto IL_0098;
				case 2:
					if (Time.realtimeSinceStartup < _0024self__00241377.noiseEndTime)
					{
						result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
						break;
					}
					_0024self__00241377.j++;
					goto IL_0098;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0098:
					if (_0024self__00241377.j < 4)
					{
						_0024self__00241377.screenPosition = UnityEngine.Random.Range(0f, 1f);
						_0024self__00241377.noiseEndTime = Time.realtimeSinceStartup + 0.04f;
						goto case 2;
					}
					_0024self__00241377.screenPosition = 0f;
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal SaveLoadMenu _0024self__00241378;

		public _0024Noise_00241376(SaveLoadMenu self_)
		{
			_0024self__00241378 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024self__00241378);
		}
	}

	[Serializable]
	internal sealed class _0024Noise2_00241379 : GenericGenerator<YieldInstruction>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<YieldInstruction>, IEnumerator
		{
			internal SaveLoadMenu _0024self__00241380;

			public _0024(SaveLoadMenu self_)
			{
				_0024self__00241380 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241380.nowNoising = true;
					_0024self__00241380.screenObject.mainTexture = _0024self__00241380.screenDefaultTexture;
					_0024self__00241380.lightObject.SetActive(false);
					result = (Yield(2, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241380.lightObject.SetActive(true);
					_0024self__00241380.nowNoising = false;
					_0024self__00241380.j = 0;
					goto IL_010b;
				case 3:
					if (Time.realtimeSinceStartup < _0024self__00241380.noiseEndTime)
					{
						result = (Yield(3, new WaitForEndOfFrame()) ? 1 : 0);
						break;
					}
					_0024self__00241380.j++;
					goto IL_010b;
				case 4:
					if (_0024self__00241380.screenPosition >= -0.99f)
					{
						_0024self__00241380.screenPosition -= Time.deltaTime * 6f;
						result = (Yield(4, new WaitForEndOfFrame()) ? 1 : 0);
						break;
					}
					_0024self__00241380.screenPosition = 0f;
					YieldDefault(1);
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_010b:
					if (_0024self__00241380.j < 4)
					{
						_0024self__00241380.screenPosition = UnityEngine.Random.Range(0f, 1f);
						_0024self__00241380.noiseEndTime = Time.realtimeSinceStartup + 0.04f;
						goto case 3;
					}
					_0024self__00241380.screenPosition = 0f;
					goto case 4;
				}
				return (byte)result != 0;
			}
		}

		internal SaveLoadMenu _0024self__00241381;

		public _0024Noise2_00241379(SaveLoadMenu self_)
		{
			_0024self__00241381 = self_;
		}

		public override IEnumerator<YieldInstruction> GetEnumerator()
		{
			return new _0024(_0024self__00241381);
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

	public string[] explainPassageJap;

	public string[] explainPassageEng;

	public Material screenObject;

	public Texture2D screenDefaultTexture;

	public GameObject channelObject1;

	public GameObject channelObject2;

	public GameObject lightObject;

	private int screenId;

	private int cursor1;

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

	private int[] dataYear;

	private string[] dataMonth;

	private string[] dataDay;

	private string[] dataDisplay;

	public Texture2D loadingTexture;

	public Vector2 textureSize;

	public Vector2 offset;

	public float textureFadeSpeed;

	public float textureFlickSpeed;

	public float textureFlickAmount;

	private bool isLoading;

	private float textureAlpha;

	private AudioManager audioManager;

	public SaveLoadMenu()
	{
		cursor2 = 1;
		saveMessageJap = "セーブ中";
		saveMessageEng = "Saving";
	}

	public virtual void Start()
	{
		dataSeconds = new string[5];
		dataMinutes = new string[5];
		dataHours = new string[5];
		dataYear = new int[5];
		dataMonth = new string[5];
		dataDay = new string[5];
		dataDisplay = new string[5];
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		status.nowEventing = false;
		black = (BlackOutController)GetComponent(typeof(BlackOutController));
		levelChanger = (LevelChanger)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(LevelChanger));
		levelChanger.enabled = false;
		PrepareData();
		StartSaveLoad(status.saveLoadFlag);
		if (screenId == 0)
		{
			float z = 0f;
			Vector3 localEulerAngles = channelObject1.transform.localEulerAngles;
			float num = (localEulerAngles.z = z);
			Vector3 vector = (channelObject1.transform.localEulerAngles = localEulerAngles);
		}
		else if (screenId == 1)
		{
			float z2 = 45f;
			Vector3 localEulerAngles2 = channelObject1.transform.localEulerAngles;
			float num2 = (localEulerAngles2.z = z2);
			Vector3 vector3 = (channelObject1.transform.localEulerAngles = localEulerAngles2);
		}
		audioManager = (AudioManager)GetComponent(typeof(AudioManager));
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
			{
				if (status.screenTexture0 != null)
				{
					screenObject.mainTexture = status.screenTexture0;
				}
				else
				{
					screenObject.mainTexture = screenDefaultTexture;
				}
				float z2 = Mathf.Lerp(channelObject2.transform.localEulerAngles.z, 0f, 0.4f);
				Vector3 localEulerAngles2 = channelObject2.transform.localEulerAngles;
				float num2 = (localEulerAngles2.z = z2);
				Vector3 vector3 = (channelObject2.transform.localEulerAngles = localEulerAngles2);
				break;
			}
			case 1:
			{
				if (status.screenTexture1 != null)
				{
					screenObject.mainTexture = status.screenTexture1;
				}
				else
				{
					screenObject.mainTexture = screenDefaultTexture;
				}
				float z4 = Mathf.Lerp(channelObject2.transform.localEulerAngles.z, 36f, 0.4f);
				Vector3 localEulerAngles4 = channelObject2.transform.localEulerAngles;
				float num4 = (localEulerAngles4.z = z4);
				Vector3 vector7 = (channelObject2.transform.localEulerAngles = localEulerAngles4);
				break;
			}
			case 2:
			{
				if (status.screenTexture2 != null)
				{
					screenObject.mainTexture = status.screenTexture2;
				}
				else
				{
					screenObject.mainTexture = screenDefaultTexture;
				}
				float z3 = Mathf.Lerp(channelObject2.transform.localEulerAngles.z, 72f, 0.4f);
				Vector3 localEulerAngles3 = channelObject2.transform.localEulerAngles;
				float num3 = (localEulerAngles3.z = z3);
				Vector3 vector5 = (channelObject2.transform.localEulerAngles = localEulerAngles3);
				break;
			}
			case 3:
			{
				if (status.screenTexture3 != null)
				{
					screenObject.mainTexture = status.screenTexture3;
				}
				else
				{
					screenObject.mainTexture = screenDefaultTexture;
				}
				float z5 = Mathf.Lerp(channelObject2.transform.localEulerAngles.z, 108f, 0.4f);
				Vector3 localEulerAngles5 = channelObject2.transform.localEulerAngles;
				float num5 = (localEulerAngles5.z = z5);
				Vector3 vector9 = (channelObject2.transform.localEulerAngles = localEulerAngles5);
				break;
			}
			case 4:
			{
				if (status.screenTexture4 != null)
				{
					screenObject.mainTexture = status.screenTexture4;
				}
				else
				{
					screenObject.mainTexture = screenDefaultTexture;
				}
				float z = Mathf.Lerp(channelObject2.transform.localEulerAngles.z, 144f, 0.4f);
				Vector3 localEulerAngles = channelObject2.transform.localEulerAngles;
				float num = (localEulerAngles.z = z);
				Vector3 vector = (channelObject2.transform.localEulerAngles = localEulerAngles);
				break;
			}
			}
		}
		float y = screenPosition;
		Vector2 mainTextureOffset = screenObject.mainTextureOffset;
		float num6 = (mainTextureOffset.y = y);
		Vector2 vector11 = (screenObject.mainTextureOffset = mainTextureOffset);
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
						if (cursor1 == 0)
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
							cursor1 = 0;
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
					else if (screenId == 3)
					{
						StartCoroutine_Auto(StartSave());
						if (decideSE != null)
						{
							audio.PlayOneShot(decideSE, 0.6f);
						}
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
					else if (screenId == 3)
					{
						StartCoroutine_Auto(StartSave());
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

	public virtual void StartSaveLoad(int num)
	{
		mouseX = (int)Input.mousePosition.x;
		mouseY = (int)Input.mousePosition.y;
		screenId = num;
		cursor1 = status.latestId;
		if (cursor1 == 0)
		{
			cursor1 = 1;
		}
		StartCoroutine_Auto(WaitKeyUp());
		StartCoroutine_Auto(Cursor());
	}

	public virtual IEnumerator WaitKeyUp()
	{
		return new _0024WaitKeyUp_00241356(this).GetEnumerator();
	}

	public virtual IEnumerator EndSaveLoad()
	{
		return new _0024EndSaveLoad_00241359(this).GetEnumerator();
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
		return new _0024LoadGame_00241363(number, this).GetEnumerator();
	}

	public virtual IEnumerator StartSave()
	{
		return new _0024StartSave_00241370(this).GetEnumerator();
	}

	public virtual void SaveGame(int number)
	{
		ES2Writer eS2Writer = ES2Writer.Create("save/savedata" + number + ".sav?encrypt=true&encryptiontype=obfuscate&password=fundoshi");
		eS2Writer.Write(status.playTimeSeconds, "playTimeSeconds");
		eS2Writer.Write(status.playTimeMinutes, "playTimeMinutes");
		eS2Writer.Write(status.playTimeHours, "playTimeHours");
		eS2Writer.Write(DateTime.Now.Year, "nowYear");
		eS2Writer.Write(DateTime.Now.Month, "nowMonth");
		eS2Writer.Write(DateTime.Now.Day, "nowDay");
		eS2Writer.Write(status.mapName, "mapName");
		eS2Writer.Write(status.mapX, "mapX");
		eS2Writer.Write(status.mapY, "mapY");
		eS2Writer.Write(status.mapZ, "mapZ");
		eS2Writer.Write(status.playerRotation, "playerRotation");
		eS2Writer.Write(status.footStepId, "footStepId");
		eS2Writer.Write(status.footEffectId, "footEffectId");
		for (i = 0; i < status.switches.Length; i++)
		{
			eS2Writer.Write(status.switches[i], "switches" + i);
		}
		for (i = 0; i < status.variables.Length; i++)
		{
			eS2Writer.Write(status.variables[i], "variables" + i);
		}
		eS2Writer.Write(status.cameraX, "cameraX");
		eS2Writer.Write(status.cameraY, "cameraY");
		eS2Writer.Write(status.cameraZ, "cameraZ");
		eS2Writer.Write(status.cameraRotX, "cameraRotX");
		eS2Writer.Write(status.cameraRotY, "cameraRotY");
		for (i = 0; i < status.item.Length; i++)
		{
			eS2Writer.Write(status.item[i], "item" + i);
		}
		for (i = 0; i < status.file.Length; i++)
		{
			eS2Writer.Write(status.file[i], "file" + i);
		}
		eS2Writer.Write(status.saveCaptureScreen, "thumbnail");
		eS2Writer.Save();
		eS2Writer.Dispose();
		switch (number)
		{
		case 0:
			status.screenTexture0 = status.saveCaptureScreen;
			break;
		case 1:
			status.screenTexture1 = status.saveCaptureScreen;
			break;
		case 2:
			status.screenTexture2 = status.saveCaptureScreen;
			break;
		case 3:
			status.screenTexture3 = status.saveCaptureScreen;
			break;
		case 4:
			status.screenTexture4 = status.saveCaptureScreen;
			break;
		}
	}

	public virtual IEnumerator Cursor()
	{
		return new _0024Cursor_00241373(this).GetEnumerator();
	}

	public virtual IEnumerator Noise()
	{
		return new _0024Noise_00241376(this).GetEnumerator();
	}

	public virtual IEnumerator Noise2()
	{
		return new _0024Noise2_00241379(this).GetEnumerator();
	}

	public virtual void SetAudioVolume(float audioVolume)
	{
		AudioListener.volume = audioVolume;
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
