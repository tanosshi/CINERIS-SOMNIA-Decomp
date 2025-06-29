using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using DG.Tweening;
using UnityEngine;

[Serializable]
public class PauseMenu : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Cursor_00241264 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal PauseMenu _0024self__00241265;

			public _0024(PauseMenu self_)
			{
				_0024self__00241265 = self_;
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
					if (cInput.GetAxisRaw("Vertical") == 0f && cInput.GetAxisRaw("Horizontal") == 0f && cInput.GetAxisRaw("J_Vertical") == 0f && cInput.GetAxisRaw("J_Horizontal") == 0f && cInput.GetAxisRaw("DPad_Vertical") == 0f && cInput.GetAxisRaw("DPad_Horizontal") == 0f)
					{
						goto IL_00cb;
					}
					if (!_0024self__00241265.nowPausing)
					{
						goto case 1;
					}
					goto default;
				case 3:
					if ((cInput.GetAxisRaw("Vertical") == 0f && cInput.GetAxisRaw("J_Vertical") == 0f && cInput.GetAxisRaw("DPad_Vertical") == 0f) || !_0024self__00241265.nowPausing)
					{
						goto IL_0276;
					}
					goto IL_0213;
				case 4:
					if ((cInput.GetAxisRaw("Vertical") == 0f && cInput.GetAxisRaw("J_Vertical") == 0f && cInput.GetAxisRaw("DPad_Vertical") == 0f) || !_0024self__00241265.nowPausing)
					{
						goto IL_0666;
					}
					goto IL_039e;
				case 5:
					if ((cInput.GetAxisRaw("Horizontal") == 0f && cInput.GetAxisRaw("J_Horizontal") == 0f && cInput.GetAxisRaw("DPad_Horizontal") == 0f) || !_0024self__00241265.nowPausing)
					{
						goto IL_0557;
					}
					goto IL_04f4;
				case 6:
					if ((cInput.GetAxisRaw("Horizontal") == 0f && cInput.GetAxisRaw("J_Horizontal") == 0f && cInput.GetAxisRaw("DPad_Horizontal") == 0f) || !_0024self__00241265.nowPausing)
					{
						goto IL_0666;
					}
					goto IL_0603;
				case 7:
					if (_0024self__00241265.nowPausing)
					{
						goto IL_00cb;
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0213:
					result = (Yield(3, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_0557:
					if (cInput.GetAxisRaw("Horizontal") <= -0.1f || cInput.GetAxisRaw("J_Horizontal") <= -0.1f || !(cInput.GetAxisRaw("DPad_Horizontal") > -0.1f))
					{
						_0024self__00241265.cursor2--;
						if (_0024self__00241265.cursorSE != null)
						{
							_0024self__00241265.audio.PlayOneShot(_0024self__00241265.cursorSE, 0.4f);
						}
						if (_0024self__00241265.cursor2 < 0)
						{
							_0024self__00241265.cursor2 = 1;
						}
						goto IL_0603;
					}
					goto IL_0666;
					IL_0603:
					result = (Yield(6, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_0276:
					if (cInput.GetAxisRaw("Vertical") <= -0.1f || cInput.GetAxisRaw("J_Vertical") <= -0.1f || !(cInput.GetAxisRaw("DPad_Vertical") > -0.1f))
					{
						_0024self__00241265.cursor++;
						if (_0024self__00241265.cursorSE != null)
						{
							_0024self__00241265.audio.PlayOneShot(_0024self__00241265.cursorSE, 0.4f);
						}
						if (_0024self__00241265.cursor >= 6)
						{
							_0024self__00241265.cursor = 0;
						}
						if (_0024self__00241265.cursor == 1 && !_0024self__00241265.status.loadPermission)
						{
							_0024self__00241265.cursor++;
						}
						if (_0024self__00241265.cursor == 2 && !_0024self__00241265.status.savePermission)
						{
							_0024self__00241265.cursor++;
						}
						goto IL_039e;
					}
					goto IL_0666;
					IL_039e:
					result = (Yield(4, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_04f4:
					result = (Yield(5, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_00cb:
					if (_0024self__00241265.screenId == 0 && !_0024self__00241265.nowSaveLoading)
					{
						if (cInput.GetAxisRaw("Vertical") >= 0.1f || cInput.GetAxisRaw("J_Vertical") >= 0.1f || !(cInput.GetAxisRaw("DPad_Vertical") < 0.1f))
						{
							_0024self__00241265.cursor--;
							if (_0024self__00241265.cursorSE != null)
							{
								_0024self__00241265.audio.PlayOneShot(_0024self__00241265.cursorSE, 0.4f);
							}
							if (_0024self__00241265.cursor < 0)
							{
								_0024self__00241265.cursor = 5;
							}
							if (_0024self__00241265.cursor == 2 && !_0024self__00241265.status.savePermission)
							{
								_0024self__00241265.cursor--;
							}
							if (_0024self__00241265.cursor == 1 && !_0024self__00241265.status.loadPermission)
							{
								_0024self__00241265.cursor--;
							}
							goto IL_0213;
						}
						goto IL_0276;
					}
					if ((_0024self__00241265.screenId == 4 || _0024self__00241265.screenId == 5) && !_0024self__00241265.nowReturning && !_0024self__00241265.nowQuitting)
					{
						if (cInput.GetAxisRaw("Horizontal") >= 0.1f || cInput.GetAxisRaw("J_Horizontal") >= 0.1f || !(cInput.GetAxisRaw("DPad_Horizontal") < 0.1f))
						{
							_0024self__00241265.cursor2++;
							if (_0024self__00241265.cursorSE != null)
							{
								_0024self__00241265.audio.PlayOneShot(_0024self__00241265.cursorSE, 0.4f);
							}
							if (_0024self__00241265.cursor2 >= 2)
							{
								_0024self__00241265.cursor2 = 0;
							}
							goto IL_04f4;
						}
						goto IL_0557;
					}
					goto IL_0666;
					IL_0666:
					result = (Yield(7, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PauseMenu _0024self__00241266;

		public _0024Cursor_00241264(PauseMenu self_)
		{
			_0024self__00241266 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024self__00241266);
		}
	}

	[Serializable]
	internal sealed class _0024Noise_00241267 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal PauseMenu _0024self__00241268;

			public _0024(PauseMenu self_)
			{
				_0024self__00241268 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241268.nowNoising = true;
					_0024self__00241268.noiseEndTime = Time.realtimeSinceStartup + 0.06f;
					goto case 2;
				case 2:
					if (Time.realtimeSinceStartup < _0024self__00241268.noiseEndTime)
					{
						result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
						break;
					}
					if (_0024self__00241268.noiseId == _0024self__00241268.noiseTex.Length - 1)
					{
						_0024self__00241268.noiseId = 0;
					}
					else
					{
						_0024self__00241268.noiseId++;
					}
					_0024self__00241268.nowNoising = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PauseMenu _0024self__00241269;

		public _0024Noise_00241267(PauseMenu self_)
		{
			_0024self__00241269 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024self__00241269);
		}
	}

	[Serializable]
	internal sealed class _0024Noise2_00241270 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal PauseMenu _0024self__00241271;

			public _0024(PauseMenu self_)
			{
				_0024self__00241271 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241271.i = 0;
					goto IL_009c;
				case 2:
					if (Time.realtimeSinceStartup < _0024self__00241271.noiseEndTime)
					{
						result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
						break;
					}
					_0024self__00241271.i++;
					goto IL_009c;
				case 1:
					{
						result = 0;
						break;
					}
					IL_009c:
					if (_0024self__00241271.i < 4)
					{
						_0024self__00241271.screenPosition = UnityEngine.Random.Range(-Screen.height, Screen.height);
						_0024self__00241271.noiseEndTime = Time.realtimeSinceStartup + 0.06f;
						goto case 2;
					}
					_0024self__00241271.screenPosition = 0;
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal PauseMenu _0024self__00241272;

		public _0024Noise2_00241270(PauseMenu self_)
		{
			_0024self__00241272 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024self__00241272);
		}
	}

	[Serializable]
	internal sealed class _0024Noise3_00241273 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal PauseMenu _0024self__00241274;

			public _0024(PauseMenu self_)
			{
				_0024self__00241274 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241274.i = 0;
					goto IL_009c;
				case 2:
					if (Time.realtimeSinceStartup < _0024self__00241274.noiseEndTime)
					{
						result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
						break;
					}
					_0024self__00241274.i++;
					goto IL_009c;
				case 1:
					{
						result = 0;
						break;
					}
					IL_009c:
					if (_0024self__00241274.i < 8)
					{
						_0024self__00241274.screenPosition = UnityEngine.Random.Range(-Screen.height, Screen.height);
						_0024self__00241274.noiseEndTime = Time.realtimeSinceStartup + 0.06f;
						goto case 2;
					}
					_0024self__00241274.screenPosition = 0;
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal PauseMenu _0024self__00241275;

		public _0024Noise3_00241273(PauseMenu self_)
		{
			_0024self__00241275 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024self__00241275);
		}
	}

	[Serializable]
	internal sealed class _0024StartPause_00241276 : GenericGenerator<YieldInstruction>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<YieldInstruction>, IEnumerator
		{
			internal PauseMenu _0024self__00241277;

			public _0024(PauseMenu self_)
			{
				_0024self__00241277 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024self__00241277.player.isControllable && _0024self__00241277.status.saveLoadFlag != 2 && _0024self__00241277.status.saveLoadFlag != 3)
					{
						goto case 1;
					}
					_0024self__00241277.status.nowPausing = true;
					_0024self__00241277.player.Controllable(false);
					_0024self__00241277.cameraContrable = _0024self__00241277.mainCamera.dontControll;
					_0024self__00241277.mainCamera.dontControll = true;
					result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				case 2:
					result = (Yield(3, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				case 3:
					if (!Application.isEditor)
					{
						_0024self__00241277.mainCamera.gameObject.camera.enabled = false;
						if (_0024self__00241277.mainCamera.ShowSwitching())
						{
							_0024self__00241277.mainCamera.subCameraNow.enabled = true;
						}
					}
					if (_0024self__00241277.status.saveLoadFlag != 2 && _0024self__00241277.status.saveLoadFlag != 3)
					{
						_0024self__00241277.StartCoroutine_Auto(_0024self__00241277.Capture());
					}
					result = (Yield(4, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				case 4:
					if (_0024self__00241277.iCloth != null)
					{
						_0024self__00241277.iCloth.SetActive(false);
					}
					if (_0024self__00241277.status.saveLoadFlag == 2 || _0024self__00241277.status.saveLoadFlag == 3)
					{
						_0024self__00241277.captureScreen = _0024self__00241277.status.captureScreen;
						if (_0024self__00241277.status.saveLoadFlag == 2)
						{
							_0024self__00241277.cursor = 1;
						}
						else
						{
							_0024self__00241277.cursor = 2;
						}
						_0024self__00241277.nowSaveLoading = true;
						_0024self__00241277.cameraContrable = false;
					}
					else
					{
						_0024self__00241277.captureScreen = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
						_0024self__00241277.captureScreen.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height), 0, 0, false);
						_0024self__00241277.MakeGrayscale(_0024self__00241277.captureScreen);
						_0024self__00241277.cursor = 0;
					}
					_0024self__00241277.cursor2 = 0;
					_0024self__00241277.screenId = 0;
					_0024self__00241277.nowScreening = true;
					_0024self__00241277.nowPausing = true;
					_0024self__00241277.myAudioSource.bypassReverbZones = true;
					Time.timeScale = 0f;
					_0024self__00241277.StartCoroutine_Auto(_0024self__00241277.Cursor());
					_0024self__00241277.mouseX = (int)Input.mousePosition.x;
					_0024self__00241277.mouseY = (int)Input.mousePosition.y;
					if (Application.isEditor)
					{
						_0024self__00241277.mainCamera.gameObject.camera.enabled = false;
						if (_0024self__00241277.mainCamera.ShowSwitching())
						{
							_0024self__00241277.mainCamera.subCameraNow.enabled = true;
						}
					}
					if (_0024self__00241277.status.saveLoadFlag == 2 || _0024self__00241277.status.saveLoadFlag == 3)
					{
						Time.timeScale = 1f;
						result = (Yield(5, new WaitForSeconds(_0024self__00241277.black.FadeSpeed)) ? 1 : 0);
						break;
					}
					goto IL_03fd;
				case 5:
					Time.timeScale = 0f;
					_0024self__00241277.status.saveLoadFlag = 0;
					_0024self__00241277.nowSaveLoading = false;
					goto IL_03fd;
				case 1:
					{
						result = 0;
						break;
					}
					IL_03fd:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal PauseMenu _0024self__00241278;

		public _0024StartPause_00241276(PauseMenu self_)
		{
			_0024self__00241278 = self_;
		}

		public override IEnumerator<YieldInstruction> GetEnumerator()
		{
			return new _0024(_0024self__00241278);
		}
	}

	[Serializable]
	internal sealed class _0024Resume_00241279 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal PauseMenu _0024self__00241280;

			public _0024(PauseMenu self_)
			{
				_0024self__00241280 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00241280.canResume)
					{
						Screen.lockCursor = true;
						Screen.showCursor = false;
						_0024self__00241280.mainCamera.gameObject.camera.enabled = true;
						if (_0024self__00241280.mainCamera.ShowSwitching())
						{
							_0024self__00241280.mainCamera.subCameraNow.enabled = true;
							_0024self__00241280.mainCamera.gameObject.camera.enabled = false;
						}
						_0024self__00241280.cursor = 0;
						_0024self__00241280.cursor2 = 0;
						_0024self__00241280.screenId = 0;
						_0024self__00241280.nowPausing = false;
						_0024self__00241280.status.nowPausing = false;
						_0024self__00241280.myAudioSource.bypassReverbZones = false;
						Time.timeScale = 1f;
						_0024self__00241280.StartCoroutine_Auto(_0024self__00241280.Noise3());
						_0024self__00241280.StartCoroutine_Auto(_0024self__00241280.DeleteScreen());
						result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
						break;
					}
					goto IL_0157;
				case 2:
					if (_0024self__00241280.iCloth != null)
					{
						_0024self__00241280.iCloth.SetActive(true);
					}
					goto IL_0157;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0157:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal PauseMenu _0024self__00241281;

		public _0024Resume_00241279(PauseMenu self_)
		{
			_0024self__00241281 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024self__00241281);
		}
	}

	[Serializable]
	internal sealed class _0024SaveLoad_00241282 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024num_00241283;

			internal PauseMenu _0024self__00241284;

			public _0024(int num, PauseMenu self_)
			{
				_0024num_00241283 = num;
				_0024self__00241284 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Screen.lockCursor = true;
					Screen.showCursor = false;
					_0024self__00241284.status.mapName = Application.loadedLevelName;
					_0024self__00241284.status.mapX = _0024self__00241284.transform.position.x;
					_0024self__00241284.status.mapY = _0024self__00241284.transform.position.y;
					_0024self__00241284.status.mapZ = _0024self__00241284.transform.position.z;
					_0024self__00241284.status.playerRotation = _0024self__00241284.transform.eulerAngles.y;
					_0024self__00241284.status.footStepId = _0024self__00241284.player.ShowFootstepId();
					_0024self__00241284.status.footEffectId = _0024self__00241284.player.ShowFootEffectId();
					_0024self__00241284.status.cameraX = _0024self__00241284.mainCamera.gameObject.transform.position.x;
					_0024self__00241284.status.cameraY = _0024self__00241284.mainCamera.gameObject.transform.position.y;
					_0024self__00241284.status.cameraZ = _0024self__00241284.mainCamera.gameObject.transform.position.z;
					_0024self__00241284.status.cameraRotX = _0024self__00241284.mainCamera.ShowRotX();
					_0024self__00241284.status.cameraRotY = _0024self__00241284.mainCamera.ShowRotY();
					_0024self__00241284.status.captureScreen = _0024self__00241284.captureScreen;
					_0024self__00241284.status.saveLoadFlag = _0024num_00241283;
					_0024self__00241284.nowSaveLoading = true;
					_0024self__00241284.StartCoroutine_Auto(_0024self__00241284.player.AnimationManager(0));
					_0024self__00241284.player.Controllable(false);
					_0024self__00241284.mainCamera.DontControllCamera(true);
					Time.timeScale = 1f;
					_0024self__00241284.black.FadeSpeed = _0024self__00241284.fadeSpeed;
					_0024self__00241284.black.SetFadeColor(Color.black);
					_0024self__00241284.status.fadeColor = Color.black;
					_0024self__00241284.status.audioFadeFlag = true;
					_0024self__00241284.black.FadeIn();
					_0024self__00241284.bgm.DOFade(0f, _0024self__00241284.black.FadeSpeed - 0.22f).OnComplete(_0024self__00241284.StopBgm);
					_0024self__00241284.audioManager.AudioFadeOut(_0024self__00241284.black.FadeSpeed - 0.22f);
					if (_0024self__00241284.status.switches[408] == 1)
					{
						_0024self__00241284.status.switches[408] = 0;
					}
					result = (Yield(2, new WaitForSeconds(_0024self__00241284.black.FadeSpeed)) ? 1 : 0);
					break;
				case 2:
					Application.LoadLevel("[00-]saveload");
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024num_00241285;

		internal PauseMenu _0024self__00241286;

		public _0024SaveLoad_00241282(int num, PauseMenu self_)
		{
			_0024num_00241285 = num;
			_0024self__00241286 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024num_00241285, _0024self__00241286);
		}
	}

	[Serializable]
	internal sealed class _0024ReturnToTitle_00241287 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal PauseMenu _0024self__00241288;

			public _0024(PauseMenu self_)
			{
				_0024self__00241288 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Screen.lockCursor = true;
					Screen.showCursor = false;
					_0024self__00241288.nowReturning = true;
					_0024self__00241288.StartCoroutine_Auto(_0024self__00241288.player.AnimationManager(0));
					_0024self__00241288.player.Controllable(false);
					_0024self__00241288.mainCamera.DontControllCamera(true);
					Time.timeScale = 1f;
					_0024self__00241288.black.FadeSpeed = _0024self__00241288.fadeSpeed;
					_0024self__00241288.black.SetFadeColor(Color.black);
					_0024self__00241288.status.fadeColor = Color.black;
					_0024self__00241288.black.FadeIn();
					_0024self__00241288.bgm.DOFade(0f, _0024self__00241288.black.FadeSpeed - 0.22f).OnComplete(_0024self__00241288.StopBgm);
					_0024self__00241288.audioManager.AudioFadeOut(_0024self__00241288.black.FadeSpeed - 0.22f);
					result = (Yield(2, new WaitForSeconds(_0024self__00241288.black.FadeSpeed)) ? 1 : 0);
					break;
				case 2:
					Application.LoadLevel("[000]title");
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PauseMenu _0024self__00241289;

		public _0024ReturnToTitle_00241287(PauseMenu self_)
		{
			_0024self__00241289 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241289);
		}
	}

	[Serializable]
	internal sealed class _0024Quit_00241290 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal PauseMenu _0024self__00241291;

			public _0024(PauseMenu self_)
			{
				_0024self__00241291 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Screen.lockCursor = true;
					Screen.showCursor = false;
					_0024self__00241291.nowQuitting = true;
					_0024self__00241291.StartCoroutine_Auto(_0024self__00241291.player.AnimationManager(0));
					_0024self__00241291.player.Controllable(false);
					_0024self__00241291.mainCamera.DontControllCamera(true);
					Time.timeScale = 1f;
					_0024self__00241291.black.FadeSpeed = _0024self__00241291.fadeSpeed;
					_0024self__00241291.black.FadeIn();
					_0024self__00241291.bgm.DOFade(0f, _0024self__00241291.black.FadeSpeed - 0.22f).OnComplete(_0024self__00241291.StopBgm);
					_0024self__00241291.audioManager.AudioFadeOut(_0024self__00241291.black.FadeSpeed - 0.22f);
					result = (Yield(2, new WaitForSeconds(_0024self__00241291.black.FadeSpeed + 0.2f)) ? 1 : 0);
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

		internal PauseMenu _0024self__00241292;

		public _0024Quit_00241290(PauseMenu self_)
		{
			_0024self__00241292 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241292);
		}
	}

	[Serializable]
	internal sealed class _0024DeleteScreen_00241293 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal bool _0024tempFlag_00241294;

			internal PauseMenu _0024self__00241295;

			public _0024(PauseMenu self_)
			{
				_0024self__00241295 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024tempFlag_00241294 = _0024self__00241295.mainCamera.dontControll;
					result = (Yield(2, new WaitForSeconds(0.4f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241295.nowScreening = false;
					_0024self__00241295.player.Controllable(true);
					if (_0024tempFlag_00241294 == _0024self__00241295.mainCamera.dontControll)
					{
						_0024self__00241295.mainCamera.dontControll = _0024self__00241295.cameraContrable;
						YieldDefault(1);
					}
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PauseMenu _0024self__00241296;

		public _0024DeleteScreen_00241293(PauseMenu self_)
		{
			_0024self__00241296 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241296);
		}
	}

	[Serializable]
	internal sealed class _0024CanResume_00241297 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal PauseMenu _0024self__00241298;

			public _0024(PauseMenu self_)
			{
				_0024self__00241298 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241298.black.FadeOut();
					result = (Yield(3, new WaitForSeconds(_0024self__00241298.black.FadeSpeed - 0.1f)) ? 1 : 0);
					break;
				case 3:
					_0024self__00241298.canResume = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PauseMenu _0024self__00241299;

		public _0024CanResume_00241297(PauseMenu self_)
		{
			_0024self__00241299 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241299);
		}
	}

	[Serializable]
	internal sealed class _0024Capture_00241300 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal PauseMenu _0024self__00241301;

			public _0024(PauseMenu self_)
			{
				_0024self__00241301 = self_;
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
					_0024self__00241301.mainCamera.gameObject.camera.enabled = true;
					_0024self__00241301.rt = new RenderTexture(_0024self__00241301.resWidth, _0024self__00241301.resHeight, 24);
					_0024self__00241301.mainCamera.gameObject.camera.targetTexture = _0024self__00241301.rt;
					_0024self__00241301.screenShot = new Texture2D(_0024self__00241301.resWidth, _0024self__00241301.resHeight, TextureFormat.RGB24, false);
					_0024self__00241301.mainCamera.gameObject.camera.Render();
					RenderTexture.active = _0024self__00241301.rt;
					_0024self__00241301.screenShot.ReadPixels(new Rect(0f, 0f, _0024self__00241301.resWidth, _0024self__00241301.resHeight), 0, 0);
					_0024self__00241301.MakeGrayscale(_0024self__00241301.screenShot);
					_0024self__00241301.mainCamera.gameObject.camera.targetTexture = null;
					RenderTexture.active = null;
					UnityEngine.Object.Destroy(_0024self__00241301.rt);
					_0024self__00241301.status.saveCaptureScreen = _0024self__00241301.screenShot;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PauseMenu _0024self__00241302;

		public _0024Capture_00241300(PauseMenu self_)
		{
			_0024self__00241302 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024self__00241302);
		}
	}

	public Texture2D blackTex;

	public Texture2D backGroundTex;

	public Texture2D[] noiseTex;

	public Texture2D resumeTexTrue;

	public Texture2D resumeTexFalse;

	public Texture2D loadTexTrue;

	public Texture2D loadTexFalse;

	public Texture2D loadTexDisable;

	public Texture2D saveTexTrue;

	public Texture2D saveTexFalse;

	public Texture2D saveTexDisable;

	public Texture2D optionTexTrue;

	public Texture2D optionTexFalse;

	public Texture2D titleTexTrue;

	public Texture2D titleTexFalse;

	public Texture2D quitTexTrue;

	public Texture2D quitTexFalse;

	public Texture2D yesTexTrueJap;

	public Texture2D yesTexFalseJap;

	public Texture2D yesTexTrueEng;

	public Texture2D yesTexFalseEng;

	public Texture2D noTexTrueJap;

	public Texture2D noTexFalseJap;

	public Texture2D noTexTrueEng;

	public Texture2D noTexFalseEng;

	public Texture2D titleMessageTexJap;

	public Texture2D titleMessageTexEng;

	public Texture2D quitMessageTexJap;

	public Texture2D quitMessageTexEng;

	public string[] explainPassageJap;

	public string[] explainPassageEng;

	public AudioClip cursorSE;

	public AudioClip decideSE;

	public float fadeSpeed;

	public bool nowPausing;

	public GUISkin skin;

	[NonSerialized]
	public static int guiDepth = -7;

	private int i;

	private int random;

	private bool nowScreening;

	private bool nowReturning;

	private bool nowQuitting;

	private bool nowSaveLoading;

	private Player_Controller player;

	private Camera_Controller mainCamera;

	private Player_Status status;

	private BlackOutController black;

	private int cursor;

	private int cursor2;

	private int screenId;

	private Texture2D captureScreen;

	private int mouseX;

	private int mouseY;

	private int noiseId;

	private bool nowNoising;

	private int screenPosition;

	private float noiseEndTime;

	private int resWidth;

	private int resHeight;

	private RenderTexture rt;

	private Texture2D screenShot;

	private bool cameraContrable;

	public bool canResume;

	private AudioSource myAudioSource;

	private float firstCount;

	private AudioSource bgm;

	private AudioManager audioManager;

	private GameObject iCloth;

	public PauseMenu()
	{
		resWidth = 256;
		resHeight = 256;
	}

	public virtual void Start()
	{
		player = (Player_Controller)GetComponent(typeof(Player_Controller));
		mainCamera = (Camera_Controller)GameObject.FindWithTag("MainCamera").GetComponent(typeof(Camera_Controller));
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		black = (BlackOutController)GameObject.Find("SystemObject").GetComponent(typeof(BlackOutController));
		myAudioSource = (AudioSource)GetComponent(typeof(AudioSource));
		if (status.saveLoadFlag == 2 || status.saveLoadFlag == 3)
		{
			StartCoroutine_Auto(StartPause());
			canResume = false;
			StartCoroutine_Auto(CanResume());
		}
		else
		{
			canResume = true;
		}
		if (GameObject.Find("ICloth") != null)
		{
			iCloth = GameObject.Find("ICloth");
		}
		firstCount = 0f;
		bgm = (AudioSource)GameObject.Find("BGM").GetComponent(typeof(AudioSource));
		audioManager = (AudioManager)GameObject.Find("SystemObject").GetComponent(typeof(AudioManager));
	}

	public virtual void Update()
	{
		if (nowPausing)
		{
			firstCount += Time.unscaledDeltaTime;
			if (!(firstCount < black.FadeSpeed + 0.5f))
			{
				canResume = true;
			}
			if (!nowNoising)
			{
				StartCoroutine_Auto(Noise());
			}
			random = UnityEngine.Random.Range(0, 10000);
			if (random >= 9990)
			{
				StartCoroutine_Auto(Noise2());
			}
			if (nowReturning || nowQuitting || nowSaveLoading)
			{
				return;
			}
			if ((cInput.GetAxis("Mouse X") != 0f || cInput.GetAxis("Mouse Y") != 0f) && !Screen.showCursor)
			{
				Screen.lockCursor = false;
				Screen.showCursor = true;
			}
			if (screenId == 0 && !nowSaveLoading)
			{
				if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 40)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 40 + 80)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 100 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 100 - 26 + 13)))
				{
					if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor != 0)
					{
						cursor = 0;
						if (cursorSE != null)
						{
							audio.PlayOneShot(cursorSE, 0.4f);
						}
					}
					if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor == 0)
					{
						StartCoroutine_Auto(Resume());
						if (decideSE != null)
						{
							audio.PlayOneShot(decideSE, 0.6f);
						}
					}
				}
				if (status.loadPermission && !(Input.mousePosition.x < (float)(Screen.width / 2 - 58)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 58 + 116)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 60 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 60 - 26 + 13)))
				{
					if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor != 1)
					{
						cursor = 1;
						if (cursorSE != null)
						{
							audio.PlayOneShot(cursorSE, 0.4f);
						}
					}
					if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor == 1)
					{
						StartCoroutine_Auto(SaveLoad(0));
						if (decideSE != null)
						{
							audio.PlayOneShot(decideSE, 0.6f);
						}
					}
				}
				if (status.savePermission && !(Input.mousePosition.x < (float)(Screen.width / 2 - 58)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 58 + 116)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 20 - 26 + 13)))
				{
					if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor != 2)
					{
						cursor = 2;
						if (cursorSE != null)
						{
							audio.PlayOneShot(cursorSE, 0.4f);
						}
					}
					if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor == 2)
					{
						StartCoroutine_Auto(SaveLoad(1));
						if (decideSE != null)
						{
							audio.PlayOneShot(decideSE, 0.6f);
						}
					}
				}
				if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 46)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 46 + 92)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 - 26 + 13)))
				{
					if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor != 3)
					{
						cursor = 3;
						if (cursorSE != null)
						{
							audio.PlayOneShot(cursorSE, 0.4f);
						}
					}
					if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor == 3)
					{
						SendMessage("StartOption");
						screenId = 3;
						if (decideSE != null)
						{
							audio.PlayOneShot(decideSE, 0.6f);
						}
					}
				}
				if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 95)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 95 + 190)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 60 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 60 - 26 + 13)))
				{
					if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor != 4)
					{
						cursor = 4;
						if (cursorSE != null)
						{
							audio.PlayOneShot(cursorSE, 0.4f);
						}
					}
					if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor == 4)
					{
						cursor2 = 1;
						screenId = 4;
						if (decideSE != null)
						{
							audio.PlayOneShot(decideSE, 0.6f);
						}
					}
				}
				if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 30)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 30 + 60)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 100 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 100 - 26 + 13)))
				{
					if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor != 5)
					{
						cursor = 5;
						if (cursorSE != null)
						{
							audio.PlayOneShot(cursorSE, 0.4f);
						}
					}
					if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor == 5)
					{
						cursor2 = 1;
						screenId = 5;
						if (decideSE != null)
						{
							audio.PlayOneShot(decideSE, 0.6f);
						}
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Action") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Action"))
				{
					if (cursor == 0)
					{
						Input.ResetInputAxes();
						StartCoroutine_Auto(Resume());
						if (decideSE != null)
						{
							audio.PlayOneShot(decideSE, 0.6f);
						}
					}
					else if (cursor == 1)
					{
						StartCoroutine_Auto(SaveLoad(0));
						if (decideSE != null)
						{
							audio.PlayOneShot(decideSE, 0.6f);
						}
					}
					else if (cursor == 2)
					{
						StartCoroutine_Auto(SaveLoad(1));
						if (decideSE != null)
						{
							audio.PlayOneShot(decideSE, 0.6f);
						}
					}
					else if (cursor == 3)
					{
						SendMessage("StartOption");
						screenId = 3;
						if (decideSE != null)
						{
							audio.PlayOneShot(decideSE, 0.6f);
						}
					}
					else if (cursor == 4)
					{
						cursor2 = 1;
						screenId = 4;
						if (decideSE != null)
						{
							audio.PlayOneShot(decideSE, 0.6f);
						}
					}
					else if (cursor == 5)
					{
						cursor2 = 1;
						screenId = 5;
						if (decideSE != null)
						{
							audio.PlayOneShot(decideSE, 0.6f);
						}
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(1) || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Sprint") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Sprint"))
				{
					StartCoroutine_Auto(Resume());
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			else if (screenId == 4 || screenId == 5)
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
						if (screenId == 4)
						{
							StartCoroutine_Auto(ReturnToTitle());
							if (decideSE != null)
							{
								audio.PlayOneShot(decideSE, 0.6f);
							}
						}
						else if (screenId == 5)
						{
							StartCoroutine_Auto(Quit());
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
						screenId = 0;
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
						if (screenId == 4)
						{
							StartCoroutine_Auto(ReturnToTitle());
							if (decideSE != null)
							{
								audio.PlayOneShot(decideSE, 0.6f);
							}
						}
						else if (screenId == 5)
						{
							StartCoroutine_Auto(Quit());
							if (decideSE != null)
							{
								audio.PlayOneShot(decideSE, 0.6f);
							}
						}
					}
					else if (cursor2 == 1)
					{
						screenId = 0;
						if (decideSE != null)
						{
							audio.PlayOneShot(decideSE, 0.6f);
						}
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(1) || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Sprint") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Sprint"))
				{
					screenId = 0;
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			if ((SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Pause") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Pause")) && screenId != 3)
			{
				StartCoroutine_Auto(Resume());
			}
			mouseX = (int)Input.mousePosition.x;
			mouseY = (int)Input.mousePosition.y;
		}
		else if ((SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Pause") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Pause")) && player.isControllable && status.pausePermission)
		{
			StartCoroutine_Auto(StartPause());
		}
	}

	public virtual IEnumerator Cursor()
	{
		return new _0024Cursor_00241264(this).GetEnumerator();
	}

	public virtual IEnumerator Noise()
	{
		return new _0024Noise_00241267(this).GetEnumerator();
	}

	public virtual IEnumerator Noise2()
	{
		return new _0024Noise2_00241270(this).GetEnumerator();
	}

	public virtual IEnumerator Noise3()
	{
		return new _0024Noise3_00241273(this).GetEnumerator();
	}

	public virtual IEnumerator StartPause()
	{
		return new _0024StartPause_00241276(this).GetEnumerator();
	}

	public virtual IEnumerator Resume()
	{
		return new _0024Resume_00241279(this).GetEnumerator();
	}

	public virtual IEnumerator SaveLoad(int num)
	{
		return new _0024SaveLoad_00241282(num, this).GetEnumerator();
	}

	public virtual IEnumerator ReturnToTitle()
	{
		return new _0024ReturnToTitle_00241287(this).GetEnumerator();
	}

	public virtual IEnumerator Quit()
	{
		return new _0024Quit_00241290(this).GetEnumerator();
	}

	public virtual IEnumerator DeleteScreen()
	{
		return new _0024DeleteScreen_00241293(this).GetEnumerator();
	}

	public virtual void ReturnPause()
	{
		screenId = 0;
	}

	public virtual IEnumerator CanResume()
	{
		return new _0024CanResume_00241297(this).GetEnumerator();
	}

	public virtual IEnumerator Capture()
	{
		return new _0024Capture_00241300(this).GetEnumerator();
	}

	public virtual void MakeGrayscale(Texture2D tex)
	{
		float num = 0f;
		float num2 = 0f;
		Color[] pixels = tex.GetPixels();
		for (i = 0; i < pixels.Length; i++)
		{
			float grayscale = pixels[i].grayscale;
			grayscale *= 1f;
			if (!(grayscale < 1f))
			{
				grayscale = 1f;
			}
			pixels[i] = new Color(grayscale, grayscale, grayscale, 1f);
			num += grayscale;
		}
		num /= (float)pixels.Length;
		num2 = ((1f - num) / 6f + num) / num;
		for (i = 0; i < pixels.Length; i++)
		{
			pixels[i] *= num2;
		}
		tex.SetPixels(pixels);
		tex.Apply();
	}

	public virtual void MakeCaptureScreen(Texture2D tex)
	{
		Color[] pixels = tex.GetPixels();
		for (i = 0; i < pixels.Length; i++)
		{
			float r = pixels[i].r;
			float g = pixels[i].g;
			float b = pixels[i].b;
			r -= r * 0.2f;
			g -= g * 0.2f;
			b -= b * 0.2f;
			if (!(r > 0f))
			{
				r = 0f;
			}
			if (!(g > 0f))
			{
				g = 0f;
			}
			if (!(b > 0f))
			{
				b = 0f;
			}
			pixels[i] = new Color(r, g, b, pixels[i].a);
		}
		tex.SetPixels(pixels);
		tex.Apply();
	}

	public virtual void SetAudioVolume(float audioVolume)
	{
		AudioListener.volume = audioVolume;
	}

	public virtual void OnGUI()
	{
		if (nowScreening)
		{
			float a = 1f;
			Color color = GUI.color;
			float num = (color.a = a);
			Color color2 = (GUI.color = color);
			GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), blackTex);
			GUI.DrawTexture(new Rect(Screen.width / 2 - captureScreen.width / 2 * Screen.height / captureScreen.height, screenPosition, captureScreen.width * Screen.height / captureScreen.height, Screen.height), captureScreen, ScaleMode.StretchToFill, false);
			float a2 = 0.8f;
			Color color4 = GUI.color;
			float num2 = (color4.a = a2);
			Color color5 = (GUI.color = color4);
			GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), noiseTex[noiseId], ScaleMode.StretchToFill, true);
			float a3 = 1f;
			Color color7 = GUI.color;
			float num3 = (color7.a = a3);
			Color color8 = (GUI.color = color7);
		}
		if (!nowPausing)
		{
			return;
		}
		GUI.depth = guiDepth;
		if (screenId == 0 || screenId == 4 || screenId == 5)
		{
			GUI.DrawTexture(new Rect(0f, Screen.height / 2 - 140, Screen.width, 280f), backGroundTex);
		}
		if (screenId == 0)
		{
			GUI.DrawTexture(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), backGroundTex);
		}
		if (screenId == 0)
		{
			if (cursor == 0)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 40, Screen.height / 2 - 100 - 13, 80f, 26f), resumeTexTrue);
				if (status.language == 0)
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[0], skin.customStyles[0]);
				}
				else
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[0], skin.customStyles[0]);
				}
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 40, Screen.height / 2 - 100 - 13, 80f, 26f), resumeTexFalse);
			}
			if (status.loadPermission)
			{
				if (cursor == 1)
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 58, Screen.height / 2 - 60 - 13, 116f, 26f), loadTexTrue);
					if (status.language == 0)
					{
						GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[1], skin.customStyles[0]);
					}
					else
					{
						GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[1], skin.customStyles[0]);
					}
				}
				else
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 58, Screen.height / 2 - 60 - 13, 116f, 26f), loadTexFalse);
				}
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 58, Screen.height / 2 - 60 - 13, 116f, 26f), loadTexDisable);
			}
			if (status.savePermission)
			{
				if (cursor == 2)
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 58, Screen.height / 2 - 20 - 13, 116f, 26f), saveTexTrue);
					if (status.language == 0)
					{
						GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[2], skin.customStyles[0]);
					}
					else
					{
						GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[2], skin.customStyles[0]);
					}
				}
				else
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 58, Screen.height / 2 - 20 - 13, 116f, 26f), saveTexFalse);
				}
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 58, Screen.height / 2 - 20 - 13, 116f, 26f), saveTexDisable);
			}
			if (cursor == 3)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 46, Screen.height / 2 + 20 - 13, 92f, 26f), optionTexTrue);
				if (status.language == 0)
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[3], skin.customStyles[0]);
				}
				else
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[3], skin.customStyles[0]);
				}
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 46, Screen.height / 2 + 20 - 13, 92f, 26f), optionTexFalse);
			}
			if (cursor == 4)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 95, Screen.height / 2 + 60 - 13, 190f, 26f), titleTexTrue);
				if (status.language == 0)
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[4], skin.customStyles[0]);
				}
				else
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[4], skin.customStyles[0]);
				}
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 95, Screen.height / 2 + 60 - 13, 190f, 26f), titleTexFalse);
			}
			if (cursor == 5)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 30, Screen.height / 2 + 100 - 13, 60f, 26f), quitTexTrue);
				if (status.language == 0)
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[5], skin.customStyles[0]);
				}
				else
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[5], skin.customStyles[0]);
				}
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 30, Screen.height / 2 + 100 - 13, 60f, 26f), quitTexFalse);
			}
		}
		else
		{
			if (screenId != 4 && screenId != 5)
			{
				return;
			}
			if (status.language == 0)
			{
				if (screenId == 4)
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 40 - 13, 640f, 26f), titleMessageTexJap);
				}
				else if (screenId == 5)
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 40 - 13, 640f, 26f), quitMessageTexJap);
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
				if (screenId == 4)
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 40 - 13, 640f, 26f), titleMessageTexEng);
				}
				else if (screenId == 5)
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 40 - 13, 640f, 26f), quitMessageTexEng);
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
	}

	public virtual void StopBgm()
	{
		bgm.clip = null;
		bgm.audio.Stop();
	}

	public virtual void Main()
	{
	}
}
