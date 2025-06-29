using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class PocketBookMenu : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Cursor_00241311 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal PocketBookMenu _0024self__00241312;

			public _0024(PocketBookMenu self_)
			{
				_0024self__00241312 = self_;
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
					if ((cInput.GetAxisRaw("Vertical") == 0f && cInput.GetAxisRaw("Horizontal") == 0f && cInput.GetAxisRaw("J_Vertical") == 0f && cInput.GetAxisRaw("J_Horizontal") == 0f && cInput.GetAxisRaw("DPad_Vertical") == 0f && cInput.GetAxisRaw("DPad_Horizontal") == 0f) || !_0024self__00241312.nowMenu)
					{
						goto IL_00e3;
					}
					goto default;
				case 3:
					if (_0024self__00241312.nowMenu)
					{
						if (_0024self__00241312.screenId == 2)
						{
							if (cInput.GetAxisRaw("Vertical") >= 0.1f || cInput.GetAxisRaw("J_Vertical") >= 0.1f || !(cInput.GetAxisRaw("DPad_Vertical") < 0.1f))
							{
								_0024self__00241312.cursorLabel--;
								if (_0024self__00241312.cursorLabel < 0)
								{
									_0024self__00241312.cursorLabel = 3;
								}
								if (_0024self__00241312.cursorLabel != 2)
								{
									_0024self__00241312.pageNow = 1;
									_0024self__00241312.cursor1 = 0;
								}
								else
								{
									_0024self__00241312.pageNow = 1;
									_0024self__00241312.cursor1 = 0;
									_0024self__00241312.purposeFlag = true;
									_0024self__00241312.Update();
								}
								if (_0024self__00241312.labelChangeSE != null)
								{
									_0024self__00241312.audio.PlayOneShot(_0024self__00241312.labelChangeSE, 0.6f);
								}
								goto IL_0223;
							}
							goto IL_0286;
						}
						if (_0024self__00241312.screenId == 0 || _0024self__00241312.screenId == 1 || _0024self__00241312.screenId == 5 || _0024self__00241312.screenId == 6)
						{
							if (_0024self__00241312.stock >= 2)
							{
								if (cInput.GetAxisRaw("Vertical") >= 0.1f || cInput.GetAxisRaw("J_Vertical") >= 0.1f || !(cInput.GetAxisRaw("DPad_Vertical") < 0.1f))
								{
									if (_0024self__00241312.cursor1 == 0)
									{
										_0024self__00241312.cursor1 = 9;
										while (_0024self__00241312.contentsName[_0024self__00241312.cursor1] == string.Empty)
										{
											_0024self__00241312.cursor1--;
										}
									}
									else
									{
										_0024self__00241312.cursor1--;
									}
									if (_0024self__00241312.screenId == 5)
									{
										_0024self__00241312.purposeCursorFlag = true;
									}
									if (_0024self__00241312.cursorSE != null)
									{
										_0024self__00241312.audio.PlayOneShot(_0024self__00241312.cursorSE, 0.4f);
									}
									goto IL_056b;
								}
								goto IL_05ce;
							}
							goto IL_0728;
						}
						if (_0024self__00241312.screenId == 3)
						{
							if (cInput.GetAxisRaw("Horizontal") >= 0.1f || cInput.GetAxisRaw("J_Horizontal") >= 0.1f || !(cInput.GetAxisRaw("DPad_Horizontal") < 0.1f))
							{
								if (_0024self__00241312.cursor2 == 0)
								{
									_0024self__00241312.cursor2 = 1;
								}
								else
								{
									_0024self__00241312.cursor2 = 0;
								}
								if (_0024self__00241312.cursorSE != null)
								{
									_0024self__00241312.audio.PlayOneShot(_0024self__00241312.cursorSE, 0.4f);
								}
								goto IL_0aa2;
							}
							goto IL_0b06;
						}
						if (_0024self__00241312.screenId == 4)
						{
							if ((cInput.GetAxisRaw("Horizontal") >= 0.1f || cInput.GetAxisRaw("J_Horizontal") >= 0.1f || !(cInput.GetAxisRaw("DPad_Horizontal") < 0.1f)) && _0024self__00241312.filePageNow < _0024self__00241312.filePageMax)
							{
								_0024self__00241312.filePageNow++;
								if (_0024self__00241312.status.fileDatabase[_0024self__00241312.contentsId[_0024self__00241312.cursor1]].showSE != null)
								{
									_0024self__00241312.audio.Stop();
									_0024self__00241312.audio.PlayOneShot(_0024self__00241312.status.fileDatabase[_0024self__00241312.contentsId[_0024self__00241312.cursor1]].showSE, 1f);
								}
								goto IL_0d22;
							}
							goto IL_0d86;
						}
						goto IL_00e3;
					}
					YieldDefault(1);
					goto case 1;
				case 4:
					if ((cInput.GetAxisRaw("Vertical") == 0f && cInput.GetAxisRaw("J_Vertical") == 0f && cInput.GetAxisRaw("DPad_Vertical") == 0f) || !_0024self__00241312.nowMenu)
					{
						goto IL_0286;
					}
					goto IL_0223;
				case 5:
					if ((cInput.GetAxisRaw("Vertical") == 0f && cInput.GetAxisRaw("J_Vertical") == 0f && cInput.GetAxisRaw("DPad_Vertical") == 0f) || !_0024self__00241312.nowMenu)
					{
						goto IL_00e3;
					}
					goto IL_038f;
				case 6:
					if ((cInput.GetAxisRaw("Vertical") == 0f && cInput.GetAxisRaw("J_Vertical") == 0f && cInput.GetAxisRaw("DPad_Vertical") == 0f) || !_0024self__00241312.nowMenu)
					{
						goto IL_05ce;
					}
					goto IL_056b;
				case 7:
					if ((cInput.GetAxisRaw("Vertical") == 0f && cInput.GetAxisRaw("J_Vertical") == 0f && cInput.GetAxisRaw("DPad_Vertical") == 0f) || !_0024self__00241312.nowMenu)
					{
						goto IL_0728;
					}
					goto IL_06c5;
				case 8:
					if ((cInput.GetAxisRaw("Horizontal") == 0f && cInput.GetAxisRaw("J_Horizontal") == 0f && cInput.GetAxisRaw("DPad_Horizontal") == 0f) || !_0024self__00241312.nowMenu)
					{
						goto IL_0890;
					}
					goto IL_082d;
				case 9:
					if ((cInput.GetAxisRaw("Horizontal") == 0f && cInput.GetAxisRaw("J_Horizontal") == 0f && cInput.GetAxisRaw("DPad_Horizontal") == 0f) || !_0024self__00241312.nowMenu)
					{
						goto IL_00e3;
					}
					goto IL_0984;
				case 10:
					if ((cInput.GetAxisRaw("Horizontal") == 0f && cInput.GetAxisRaw("J_Horizontal") == 0f && cInput.GetAxisRaw("DPad_Horizontal") == 0f) || !_0024self__00241312.nowMenu)
					{
						goto IL_0b06;
					}
					goto IL_0aa2;
				case 11:
					if ((cInput.GetAxisRaw("Horizontal") == 0f && cInput.GetAxisRaw("J_Horizontal") == 0f && cInput.GetAxisRaw("DPad_Horizontal") == 0f) || !_0024self__00241312.nowMenu)
					{
						goto IL_00e3;
					}
					goto IL_0baa;
				case 12:
					if ((cInput.GetAxisRaw("Horizontal") == 0f && cInput.GetAxisRaw("J_Horizontal") == 0f && cInput.GetAxisRaw("DPad_Horizontal") == 0f) || !_0024self__00241312.nowMenu)
					{
						goto IL_0d86;
					}
					goto IL_0d22;
				case 13:
					if ((cInput.GetAxisRaw("Horizontal") == 0f && cInput.GetAxisRaw("J_Horizontal") == 0f && cInput.GetAxisRaw("DPad_Horizontal") == 0f) || !_0024self__00241312.nowMenu)
					{
						goto IL_00e3;
					}
					goto IL_0e7a;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0984:
					result = (Yield(9, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_05ce:
					if (cInput.GetAxisRaw("Vertical") <= -0.1f || cInput.GetAxisRaw("J_Vertical") <= -0.1f || !(cInput.GetAxisRaw("DPad_Vertical") > -0.1f))
					{
						if (_0024self__00241312.cursor1 == 9 || _0024self__00241312.contentsName[_0024self__00241312.cursor1 + 1] == string.Empty)
						{
							_0024self__00241312.cursor1 = 0;
						}
						else
						{
							_0024self__00241312.cursor1++;
						}
						if (_0024self__00241312.screenId == 5)
						{
							_0024self__00241312.purposeCursorFlag = true;
						}
						if (_0024self__00241312.cursorSE != null)
						{
							_0024self__00241312.audio.PlayOneShot(_0024self__00241312.cursorSE, 0.4f);
						}
						goto IL_06c5;
					}
					goto IL_0728;
					IL_056b:
					result = (Yield(6, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_038f:
					result = (Yield(5, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_00e3:
					result = (Yield(3, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_0223:
					result = (Yield(4, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_06c5:
					result = (Yield(7, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_0890:
					if (cInput.GetAxisRaw("Horizontal") <= -0.1f || cInput.GetAxisRaw("J_Horizontal") <= -0.1f || !(cInput.GetAxisRaw("DPad_Horizontal") > -0.1f))
					{
						if (_0024self__00241312.pageNow == 1)
						{
							_0024self__00241312.pageNow = _0024self__00241312.pageMax;
						}
						else
						{
							_0024self__00241312.pageNow--;
						}
						_0024self__00241312.cursor1 = 0;
						if (_0024self__00241312.screenId == 5)
						{
							_0024self__00241312.purposeCursorFlag = true;
						}
						if (_0024self__00241312.pageChangeSE != null)
						{
							_0024self__00241312.audio.Stop();
							_0024self__00241312.audio.PlayOneShot(_0024self__00241312.pageChangeSE, 1.4f);
						}
						goto IL_0984;
					}
					goto IL_00e3;
					IL_0baa:
					result = (Yield(11, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_0286:
					if (cInput.GetAxisRaw("Vertical") <= -0.1f || cInput.GetAxisRaw("J_Vertical") <= -0.1f || !(cInput.GetAxisRaw("DPad_Vertical") > -0.1f))
					{
						_0024self__00241312.cursorLabel++;
						if (_0024self__00241312.cursorLabel > 3)
						{
							_0024self__00241312.cursorLabel = 0;
						}
						if (_0024self__00241312.cursorLabel != 2)
						{
							_0024self__00241312.pageNow = 1;
							_0024self__00241312.cursor1 = 0;
						}
						else
						{
							_0024self__00241312.pageNow = 1;
							_0024self__00241312.cursor1 = 0;
							_0024self__00241312.purposeFlag = true;
							_0024self__00241312.Update();
						}
						if (_0024self__00241312.labelChangeSE != null)
						{
							_0024self__00241312.audio.PlayOneShot(_0024self__00241312.labelChangeSE, 0.6f);
						}
						goto IL_038f;
					}
					goto IL_00e3;
					IL_0d22:
					result = (Yield(12, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_0728:
					if (_0024self__00241312.pageMax != 1)
					{
						if (cInput.GetAxisRaw("Horizontal") >= 0.1f || cInput.GetAxisRaw("J_Horizontal") >= 0.1f || !(cInput.GetAxisRaw("DPad_Horizontal") < 0.1f))
						{
							if (_0024self__00241312.pageNow == _0024self__00241312.pageMax)
							{
								_0024self__00241312.pageNow = 1;
							}
							else
							{
								_0024self__00241312.pageNow++;
							}
							_0024self__00241312.cursor1 = 0;
							if (_0024self__00241312.screenId == 5)
							{
								_0024self__00241312.purposeCursorFlag = true;
							}
							if (_0024self__00241312.pageChangeSE != null)
							{
								_0024self__00241312.audio.Stop();
								_0024self__00241312.audio.PlayOneShot(_0024self__00241312.pageChangeSE, 1.4f);
							}
							goto IL_082d;
						}
						goto IL_0890;
					}
					goto IL_00e3;
					IL_0aa2:
					result = (Yield(10, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_0b06:
					if (cInput.GetAxisRaw("Horizontal") <= -0.1f || cInput.GetAxisRaw("J_Horizontal") <= -0.1f || !(cInput.GetAxisRaw("DPad_Horizontal") > -0.1f))
					{
						if (_0024self__00241312.cursor2 == 0)
						{
							_0024self__00241312.cursor2 = 1;
						}
						else
						{
							_0024self__00241312.cursor2 = 0;
						}
						if (_0024self__00241312.cursorSE != null)
						{
							_0024self__00241312.audio.PlayOneShot(_0024self__00241312.cursorSE, 0.4f);
						}
						goto IL_0baa;
					}
					goto IL_00e3;
					IL_0d86:
					if ((cInput.GetAxisRaw("Horizontal") <= -0.1f || cInput.GetAxisRaw("J_Horizontal") <= -0.1f || !(cInput.GetAxisRaw("DPad_Horizontal") > -0.1f)) && _0024self__00241312.filePageNow > 1)
					{
						_0024self__00241312.filePageNow--;
						if (_0024self__00241312.status.fileDatabase[_0024self__00241312.contentsId[_0024self__00241312.cursor1]].showSE != null)
						{
							_0024self__00241312.audio.Stop();
							_0024self__00241312.audio.PlayOneShot(_0024self__00241312.status.fileDatabase[_0024self__00241312.contentsId[_0024self__00241312.cursor1]].showSE, 1f);
						}
						goto IL_0e7a;
					}
					goto IL_00e3;
					IL_0e7a:
					result = (Yield(13, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_082d:
					result = (Yield(8, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PocketBookMenu _0024self__00241313;

		public _0024Cursor_00241311(PocketBookMenu self_)
		{
			_0024self__00241313 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024self__00241313);
		}
	}

	[Serializable]
	internal sealed class _0024StartMenu_00241314 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal PocketBookMenu _0024self__00241315;

			public _0024(PocketBookMenu self_)
			{
				_0024self__00241315 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241315.status.nowMenuing = true;
					result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				case 2:
					if (!_0024self__00241315.player.isControllable)
					{
						_0024self__00241315.status.nowMenuing = false;
						goto case 1;
					}
					_0024self__00241315.player.Controllable(false);
					result = (Yield(3, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				case 3:
					if (_0024self__00241315.iCloth != null)
					{
						_0024self__00241315.iCloth.SetActive(false);
					}
					_0024self__00241315.captureScreen = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
					_0024self__00241315.captureScreen.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height), 0, 0, false);
					_0024self__00241315.captureScreen.Apply();
					_0024self__00241315.MakeGrayscale(_0024self__00241315.captureScreen);
					_0024self__00241315.backGroundObject.SetActive(true);
					_0024self__00241315.backGroundObject.guiTexture.texture = _0024self__00241315.captureScreen;
					if (_0024self__00241315.openSE != null)
					{
						_0024self__00241315.audio.Stop();
						_0024self__00241315.audio.PlayOneShot(_0024self__00241315.openSE, 1.2f);
					}
					Time.timeScale = 0f;
					_0024self__00241315.screenId = 2;
					_0024self__00241315.cursorLabel = 0;
					_0024self__00241315.cursor1 = 0;
					_0024self__00241315.pageNow = 1;
					_0024self__00241315.nowMenu = true;
					_0024self__00241315.guiObject.SetActive(true);
					_0024self__00241315.bookUseCantObject.guiText.text = string.Empty;
					_0024self__00241315.StartCoroutine_Auto(_0024self__00241315.Cursor());
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PocketBookMenu _0024self__00241316;

		public _0024StartMenu_00241314(PocketBookMenu self_)
		{
			_0024self__00241316 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024self__00241316);
		}
	}

	[Serializable]
	internal sealed class _0024StartMap_00241317 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal int _0024_0024617_00241318;

			internal Vector3 _0024_0024618_00241319;

			internal int _0024_0024619_00241320;

			internal Vector3 _0024_0024620_00241321;

			internal int _0024_0024621_00241322;

			internal Vector3 _0024_0024622_00241323;

			internal int _0024_0024623_00241324;

			internal Vector3 _0024_0024624_00241325;

			internal PocketBookMenu _0024self__00241326;

			public _0024(PocketBookMenu self_)
			{
				_0024self__00241326 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241326.status.nowMenuing = true;
					result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				case 2:
					if (!_0024self__00241326.player.isControllable)
					{
						_0024self__00241326.status.nowMenuing = false;
						goto case 1;
					}
					_0024self__00241326.player.Controllable(false);
					result = (Yield(3, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				case 3:
				{
					if (_0024self__00241326.iCloth != null)
					{
						_0024self__00241326.iCloth.SetActive(false);
					}
					_0024self__00241326.captureScreen = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
					_0024self__00241326.captureScreen.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height), 0, 0, false);
					_0024self__00241326.captureScreen.Apply();
					_0024self__00241326.MakeGrayscale(_0024self__00241326.captureScreen);
					_0024self__00241326.backGroundObject.SetActive(true);
					_0024self__00241326.backGroundObject.guiTexture.texture = _0024self__00241326.captureScreen;
					if (_0024self__00241326.openSE != null)
					{
						_0024self__00241326.audio.Stop();
						_0024self__00241326.audio.PlayOneShot(_0024self__00241326.openSE, 1.2f);
					}
					Time.timeScale = 0f;
					_0024self__00241326.screenId = 6;
					_0024self__00241326.cursorLabel = 3;
					_0024self__00241326.cursor1 = 0;
					_0024self__00241326.pageNow = 1;
					_0024self__00241326.nowMenu = true;
					_0024self__00241326.guiObject.SetActive(true);
					_0024self__00241326.bookUseCantObject.guiText.text = string.Empty;
					_0024self__00241326.StartCoroutine_Auto(_0024self__00241326.Cursor());
					int num = (_0024_0024617_00241318 = 2);
					Vector3 vector = (_0024_0024618_00241319 = _0024self__00241326.bookItemObject.transform.localPosition);
					float num2 = (_0024_0024618_00241319.z = _0024_0024617_00241318);
					Vector3 vector2 = (_0024self__00241326.bookItemObject.transform.localPosition = _0024_0024618_00241319);
					int num3 = (_0024_0024619_00241320 = 2);
					Vector3 vector4 = (_0024_0024620_00241321 = _0024self__00241326.bookFileObject.transform.localPosition);
					float num4 = (_0024_0024620_00241321.z = _0024_0024619_00241320);
					Vector3 vector5 = (_0024self__00241326.bookFileObject.transform.localPosition = _0024_0024620_00241321);
					int num5 = (_0024_0024621_00241322 = 2);
					Vector3 vector7 = (_0024_0024622_00241323 = _0024self__00241326.bookPurposeObject.transform.localPosition);
					float num6 = (_0024_0024622_00241323.z = _0024_0024621_00241322);
					Vector3 vector8 = (_0024self__00241326.bookPurposeObject.transform.localPosition = _0024_0024622_00241323);
					int num7 = (_0024_0024623_00241324 = 4);
					Vector3 vector10 = (_0024_0024624_00241325 = _0024self__00241326.bookMapObject.transform.localPosition);
					float num8 = (_0024_0024624_00241325.z = _0024_0024623_00241324);
					Vector3 vector11 = (_0024self__00241326.bookMapObject.transform.localPosition = _0024_0024624_00241325);
					_0024self__00241326.bookItemObject.guiTexture.color = new Color(0.4f, 0.4f, 0.4f, 0.5f);
					_0024self__00241326.bookFileObject.guiTexture.color = new Color(0.4f, 0.4f, 0.4f, 0.5f);
					_0024self__00241326.bookPurposeObject.guiTexture.color = new Color(0.4f, 0.4f, 0.4f, 0.5f);
					_0024self__00241326.bookMapObject.guiTexture.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
					_0024self__00241326.bookTitleObject.guiText.text = "- MAP -";
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

		internal PocketBookMenu _0024self__00241327;

		public _0024StartMap_00241317(PocketBookMenu self_)
		{
			_0024self__00241327 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024self__00241327);
		}
	}

	[Serializable]
	internal sealed class _0024EndMenu_00241328 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal PocketBookMenu _0024self__00241329;

			public _0024(PocketBookMenu self_)
			{
				_0024self__00241329 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241329.screenId = 2;
					Time.timeScale = 1f;
					_0024self__00241329.nowMenu = false;
					result = (Yield(2, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 2:
					if (_0024self__00241329.closeSE != null)
					{
						_0024self__00241329.audio.Stop();
						_0024self__00241329.audio.PlayOneShot(_0024self__00241329.closeSE, 1f);
					}
					result = (Yield(3, new WaitForSeconds(0.3f)) ? 1 : 0);
					break;
				case 3:
					_0024self__00241329.player.Controllable(true);
					_0024self__00241329.guiObject.SetActive(false);
					_0024self__00241329.backGroundObject.guiTexture.texture = null;
					_0024self__00241329.backGroundObject.SetActive(false);
					if (_0024self__00241329.iCloth != null)
					{
						_0024self__00241329.iCloth.SetActive(true);
					}
					_0024self__00241329.status.nowMenuing = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PocketBookMenu _0024self__00241330;

		public _0024EndMenu_00241328(PocketBookMenu self_)
		{
			_0024self__00241330 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241330);
		}
	}

	[Serializable]
	internal sealed class _0024ItemUse_00241331 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal PocketBookMenu _0024self__00241332;

			public _0024(PocketBookMenu self_)
			{
				_0024self__00241332 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241332.bookUseCantObject.guiText.text = string.Empty;
					Time.timeScale = 1f;
					_0024self__00241332.nowMenu = false;
					result = (Yield(2, new WaitForSeconds(0.4f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241332.player.Controllable(false);
					_0024self__00241332.mainCamera.DontControllCamera(false);
					_0024self__00241332.guiObject.SetActive(false);
					_0024self__00241332.backGroundObject.guiTexture.texture = null;
					_0024self__00241332.backGroundObject.SetActive(false);
					_0024self__00241332.status.switches[_0024self__00241332.status.itemDatabase[_0024self__00241332.contentsId[_0024self__00241332.cursor1]].switchId] = 1;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PocketBookMenu _0024self__00241333;

		public _0024ItemUse_00241331(PocketBookMenu self_)
		{
			_0024self__00241333 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241333);
		}
	}

	[Serializable]
	internal sealed class _0024ItemCommon_00241334 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal PocketBookMenu _0024self__00241335;

			public _0024(PocketBookMenu self_)
			{
				_0024self__00241335 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Time.timeScale = 1f;
					_0024self__00241335.nowMenu = false;
					result = (Yield(2, new WaitForSeconds(0.2f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241335.player.Controllable(true);
					_0024self__00241335.mainCamera.DontControllCamera(false);
					_0024self__00241335.guiObject.SetActive(false);
					_0024self__00241335.backGroundObject.guiTexture.texture = null;
					_0024self__00241335.backGroundObject.SetActive(false);
					_0024self__00241335.status.SendMessage("CommonAction", _0024self__00241335.status.itemDatabase[_0024self__00241335.contentsId[_0024self__00241335.cursor1]].commonId);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PocketBookMenu _0024self__00241336;

		public _0024ItemCommon_00241334(PocketBookMenu self_)
		{
			_0024self__00241336 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241336);
		}
	}

	[Serializable]
	internal sealed class _0024FileCommon_00241337 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal PocketBookMenu _0024self__00241338;

			public _0024(PocketBookMenu self_)
			{
				_0024self__00241338 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Time.timeScale = 1f;
					_0024self__00241338.nowMenu = false;
					result = (Yield(2, new WaitForSeconds(0.2f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241338.player.Controllable(true);
					_0024self__00241338.mainCamera.DontControllCamera(false);
					_0024self__00241338.guiObject.SetActive(false);
					_0024self__00241338.backGroundObject.guiTexture.texture = null;
					_0024self__00241338.backGroundObject.SetActive(false);
					_0024self__00241338.status.SendMessage("CommonAction", _0024self__00241338.status.fileDatabase[_0024self__00241338.contentsId[_0024self__00241338.cursor1]].commonId);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PocketBookMenu _0024self__00241339;

		public _0024FileCommon_00241337(PocketBookMenu self_)
		{
			_0024self__00241339 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241339);
		}
	}

	public GUISkin guiSkin;

	public Texture2D blackTexture;

	public AudioClip openSE;

	public AudioClip closeSE;

	public AudioClip labelChangeSE;

	public AudioClip pageChangeSE;

	public AudioClip cursorSE;

	public AudioClip decideSE;

	public string noItemMessageJap;

	public string noItemMessageEng;

	public string noFileMessageJap;

	public string noFileMessageEng;

	public string useMessageYesJap;

	public string useMessageNoJap;

	public string useMessageYesEng;

	public string useMessageNoEng;

	public bool nowMenu;

	[NonSerialized]
	public static int guiDepth = -8;

	private Player_Controller player;

	private Camera_Controller mainCamera;

	private Player_Status status;

	private ActionTrigger actionTrigger;

	private GameObject guiObject;

	private GameObject backGroundObject;

	private GameObject bookCoverObject;

	private GameObject bookPaperObject;

	private GameObject bookItemObject;

	private GameObject bookFileObject;

	private GameObject bookTitleObject;

	private GameObject[] bookContentsObject;

	private GameObject bookItemExplainObject;

	private GameObject bookFileExplainObject;

	private GameObject bookPageObject;

	private GameObject bookThumbObject;

	private GameObject bookUseObject;

	private GameObject bookUseYesObject;

	private GameObject bookUseNoObject;

	private GameObject bookUseCantObject;

	private GameObject bookPurposeObject;

	private GameObject bookMapObject;

	private GameObject[] bookLineObject;

	private GameObject bookMapPicture;

	private GameObject bookPhotoObject;

	private Texture2D captureScreen;

	private int[] contentsId;

	private string[] contentsName;

	private int pageNow;

	private int pageMax;

	private int stock;

	private string[] fileText;

	private int filePageNow;

	private int filePageMax;

	private int aspectId;

	private int screenId;

	private int cursorLabel;

	private int cursor1;

	private int cursor2;

	private int i;

	private int j;

	private int k;

	private int l;

	private int m;

	private int temp1;

	private int temp2;

	private float aspectTemp;

	private PurposeDatabase purposeDatabase;

	private bool purposeFlag;

	private Texture2D purposePicture;

	private bool purposeCursorFlag;

	private MapDatabase mapDatabase;

	private string noPurposeMessageJap;

	private string noPurposeMessageEng;

	private string noMapMessageJap;

	private string noMapMessageEng;

	private purposeParams[] purposeParamsArray;

	private GameObject iCloth;

	public PocketBookMenu()
	{
		bookContentsObject = new GameObject[10];
		bookLineObject = new GameObject[10];
		contentsId = new int[10];
		contentsName = new string[10];
		pageNow = 1;
		pageMax = 1;
		noPurposeMessageJap = "目的はない";
		noPurposeMessageEng = "No Objective";
		noMapMessageJap = "地図を持っていない";
		noMapMessageEng = "No Map";
	}

	public virtual void Start()
	{
		player = (Player_Controller)GetComponent(typeof(Player_Controller));
		mainCamera = (Camera_Controller)GameObject.FindWithTag("MainCamera").GetComponent(typeof(Camera_Controller));
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		actionTrigger = (ActionTrigger)GameObject.FindWithTag("ActionTrigger").GetComponent(typeof(ActionTrigger));
		guiObject = GameObject.Find("SystemObject").transform.Find("MenuGUI").gameObject;
		backGroundObject = GameObject.Find("SystemObject").transform.Find("MenuBackGround").gameObject;
		bookCoverObject = guiObject.transform.Find("bookCover").gameObject;
		bookPaperObject = guiObject.transform.Find("bookPaper").gameObject;
		bookItemObject = guiObject.transform.Find("bookLabelItem").gameObject;
		bookFileObject = guiObject.transform.Find("bookLabelFile").gameObject;
		bookTitleObject = guiObject.transform.Find("bookTitle").gameObject;
		bookContentsObject[0] = guiObject.transform.Find("contents01").gameObject;
		bookContentsObject[1] = guiObject.transform.Find("contents02").gameObject;
		bookContentsObject[2] = guiObject.transform.Find("contents03").gameObject;
		bookContentsObject[3] = guiObject.transform.Find("contents04").gameObject;
		bookContentsObject[4] = guiObject.transform.Find("contents05").gameObject;
		bookContentsObject[5] = guiObject.transform.Find("contents06").gameObject;
		bookContentsObject[6] = guiObject.transform.Find("contents07").gameObject;
		bookContentsObject[7] = guiObject.transform.Find("contents08").gameObject;
		bookContentsObject[8] = guiObject.transform.Find("contents09").gameObject;
		bookContentsObject[9] = guiObject.transform.Find("contents10").gameObject;
		bookItemExplainObject = guiObject.transform.Find("itemExplain").gameObject;
		bookFileExplainObject = guiObject.transform.Find("fileExplain").gameObject;
		bookPageObject = guiObject.transform.Find("bookPageCount").gameObject;
		bookThumbObject = guiObject.transform.Find("itemThumb").gameObject;
		bookUseObject = guiObject.transform.Find("itemUse").gameObject;
		bookUseYesObject = guiObject.transform.Find("itemUseYes").gameObject;
		bookUseNoObject = guiObject.transform.Find("itemUseNo").gameObject;
		bookUseCantObject = guiObject.transform.Find("itemUseCant").gameObject;
		bookPurposeObject = guiObject.transform.Find("bookLabelPurpose").gameObject;
		bookMapObject = guiObject.transform.Find("bookLabelMap").gameObject;
		bookLineObject[0] = guiObject.transform.Find("line01").gameObject;
		bookLineObject[1] = guiObject.transform.Find("line02").gameObject;
		bookLineObject[2] = guiObject.transform.Find("line03").gameObject;
		bookLineObject[3] = guiObject.transform.Find("line04").gameObject;
		bookLineObject[4] = guiObject.transform.Find("line05").gameObject;
		bookLineObject[5] = guiObject.transform.Find("line06").gameObject;
		bookLineObject[6] = guiObject.transform.Find("line07").gameObject;
		bookLineObject[7] = guiObject.transform.Find("line08").gameObject;
		bookLineObject[8] = guiObject.transform.Find("line09").gameObject;
		bookLineObject[9] = guiObject.transform.Find("line10").gameObject;
		bookMapPicture = guiObject.transform.Find("mapPicture").gameObject;
		bookPhotoObject = guiObject.transform.Find("photoFrame").gameObject;
		if (GameObject.Find("ICloth") != null)
		{
			iCloth = GameObject.Find("ICloth");
		}
		purposeDatabase = Resources.Load("PurposeDatabase") as PurposeDatabase;
		purposeParamsArray = new purposeParams[purposeDatabase.purposes.Length];
		for (i = 0; i < purposeParamsArray.Length; i++)
		{
			purposeParamsArray[i] = new purposeParams();
			purposeParamsArray[i].enableSwitchId = purposeDatabase.purposes[i].enableSwitchId;
			purposeParamsArray[i].appearSwitchId = purposeDatabase.purposes[i].appearSwitchId;
			if (status.switches[purposeParamsArray[i].enableSwitchId] == 1 && status.switches[purposeParamsArray[i].appearSwitchId] == 1)
			{
				purposeParamsArray[i].completeFlag = true;
			}
			else
			{
				purposeParamsArray[i].completeFlag = false;
			}
		}
		purposeDatabase = null;
		Resources.UnloadUnusedAssets();
	}

	public virtual void Update()
	{
		if (nowMenu)
		{
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
				float x = 1f;
				Vector3 localScale = guiObject.transform.localScale;
				float num = (localScale.x = x);
				Vector3 vector = (guiObject.transform.localScale = localScale);
			}
			else if (aspectId == 2)
			{
				float x2 = 5f / 6f;
				Vector3 localScale2 = guiObject.transform.localScale;
				float num2 = (localScale2.x = x2);
				Vector3 vector3 = (guiObject.transform.localScale = localScale2);
			}
			else
			{
				float x3 = 0.75f;
				Vector3 localScale3 = guiObject.transform.localScale;
				float num3 = (localScale3.x = x3);
				Vector3 vector5 = (guiObject.transform.localScale = localScale3);
			}
			for (i = 0; i < 10; i++)
			{
				contentsName[i] = string.Empty;
			}
			if (cursorLabel != 2 && purposeDatabase != null)
			{
				purposeDatabase = null;
				Resources.UnloadUnusedAssets();
			}
			if (cursorLabel != 3 && mapDatabase != null)
			{
				bookMapPicture.guiTexture.texture = null;
				mapDatabase = null;
				Resources.UnloadUnusedAssets();
			}
			if (cursorLabel == 0)
			{
				j = 0;
				for (i = 0; i < Extensions.get_length((System.Array)status.item); i++)
				{
					if (status.item[i] == 1)
					{
						j++;
					}
				}
				stock = j;
				pageMax = j / 10;
				if (j % 10 != 0 || pageMax == 0)
				{
					pageMax++;
				}
				for (i = 0; i < 10; i++)
				{
					contentsId[i] = 0;
				}
				if (status.language == 0)
				{
					contentsName[0] = noItemMessageJap;
				}
				else
				{
					contentsName[0] = noItemMessageEng;
				}
				temp1 = (pageNow - 1) * 10;
				temp2 = 0;
				for (i = 0; i < Extensions.get_length((System.Array)status.itemSortNumber); i++)
				{
					if (status.item[status.itemSortNumber[i]] == 1)
					{
						if (temp1 == 0)
						{
							contentsId[temp2] = status.itemSortNumber[i];
							if (status.language == 0)
							{
								contentsName[temp2] = status.itemDatabase[status.itemSortNumber[i]].itemNameJap;
							}
							else
							{
								contentsName[temp2] = status.itemDatabase[status.itemSortNumber[i]].itemNameEng;
							}
							temp2++;
							if (temp2 >= 10)
							{
								break;
							}
						}
						else
						{
							temp1--;
						}
					}
				}
				SortId(0);
			}
			else if (cursorLabel == 1)
			{
				j = 0;
				for (i = 0; i < Extensions.get_length((System.Array)status.file); i++)
				{
					if (status.file[i] == 1)
					{
						j++;
					}
				}
				stock = j;
				pageMax = j / 10;
				if (j % 10 != 0 || pageMax == 0)
				{
					pageMax++;
				}
				for (i = 0; i < 10; i++)
				{
					contentsId[i] = 0;
				}
				if (status.language == 0)
				{
					contentsName[0] = noFileMessageJap;
				}
				else
				{
					contentsName[0] = noFileMessageEng;
				}
				temp1 = (pageNow - 1) * 10;
				temp2 = 0;
				for (i = 0; i < Extensions.get_length((System.Array)status.fileSortNumber); i++)
				{
					if (status.file[status.fileSortNumber[i]] == 1)
					{
						if (temp1 == 0)
						{
							contentsId[temp2] = status.fileSortNumber[i];
							if (status.language == 0)
							{
								contentsName[temp2] = status.fileDatabase[status.fileSortNumber[i]].fileNameJap;
							}
							else
							{
								contentsName[temp2] = status.fileDatabase[status.fileSortNumber[i]].fileNameEng;
							}
							temp2++;
							if (temp2 >= 10)
							{
								break;
							}
						}
						else
						{
							temp1--;
						}
					}
				}
				SortId(1);
			}
			else if (cursorLabel == 2)
			{
				if (purposeDatabase == null)
				{
					purposeDatabase = Resources.Load("PurposeDatabase") as PurposeDatabase;
				}
				j = 0;
				for (i = 0; i < purposeDatabase.purposes.Length; i++)
				{
					if (status.switches[purposeDatabase.purposes[i].enableSwitchId] == 1 && status.switches[purposeDatabase.purposes[i].appearSwitchId] == 1 && (status.switches[purposeDatabase.purposes[i].disappearSwitchId] != 1 || !purposeDatabase.purposes[i].deleteFlag))
					{
						j++;
					}
				}
				stock = j;
				pageMax = j / 10;
				if (j % 10 != 0 || pageMax == 0)
				{
					pageMax++;
				}
				if (Application.loadedLevelName != "[00-]specimenroom1_player")
				{
					if (status.language == 0)
					{
						contentsName[0] = noPurposeMessageJap;
					}
					else
					{
						contentsName[0] = noPurposeMessageEng;
					}
				}
				else
				{
					contentsName[0] = string.Empty;
				}
				while (true)
				{
					for (i = 0; i < 10; i++)
					{
						contentsId[i] = 0;
					}
					temp1 = (pageNow - 1) * 10;
					temp2 = 0;
					for (i = 0; i < Extensions.get_length((System.Array)purposeDatabase.purposeSortNumber); i++)
					{
						if (status.switches[purposeDatabase.purposes[purposeDatabase.purposeSortNumber[i]].enableSwitchId] == 1 && status.switches[purposeDatabase.purposes[purposeDatabase.purposeSortNumber[i]].appearSwitchId] == 1 && (status.switches[purposeDatabase.purposes[purposeDatabase.purposeSortNumber[i]].disappearSwitchId] != 1 || !purposeDatabase.purposes[purposeDatabase.purposeSortNumber[i]].deleteFlag))
						{
							if (temp1 == 0)
							{
								contentsId[temp2] = purposeDatabase.purposeSortNumber[i];
								if (status.language == 0)
								{
									contentsName[temp2] = purposeDatabase.purposes[purposeDatabase.purposeSortNumber[i]].purposeNameJap;
								}
								else
								{
									contentsName[temp2] = purposeDatabase.purposes[purposeDatabase.purposeSortNumber[i]].purposeNameEng;
								}
								temp2++;
								if (temp2 >= 10)
								{
									break;
								}
							}
							else
							{
								temp1--;
							}
						}
					}
					SortId(2);
					if (!purposeFlag)
					{
						break;
					}
					if (pageNow >= pageMax)
					{
						if (stock != 0)
						{
							if (stock % 10 == 0)
							{
								cursor1 = 9;
							}
							else
							{
								cursor1 = stock % 10 - 1;
							}
							for (i = cursor1; i >= 0; i--)
							{
								if (!purposeDatabase.purposes[contentsId[i]].subPurposeFlag)
								{
									cursor1 = i;
									break;
								}
							}
						}
						else
						{
							cursor1 = 0;
						}
					}
					else
					{
						cursor1 = 10;
					}
					int num4 = 0;
					for (i = 9; i >= 0; i--)
					{
						if (status.switches[purposeDatabase.purposes[contentsId[i]].disappearSwitchId] == 1 || purposeDatabase.purposes[contentsId[i]].subPurposeFlag || contentsId[i] == 0)
						{
							num4++;
						}
						else
						{
							cursor1 = i;
						}
					}
					if (num4 >= 10 && pageNow < pageMax)
					{
						pageNow++;
					}
					else
					{
						purposeFlag = false;
					}
				}
			}
			else if (cursorLabel == 3)
			{
				if (mapDatabase == null)
				{
					mapDatabase = Resources.Load("MapDatabase") as MapDatabase;
				}
				stock = 0;
				for (i = 0; i < mapDatabase.maps.Length; i++)
				{
					int num5 = 0;
					for (j = 0; j < mapDatabase.maps[i].getSwitchId.Length; j++)
					{
						if (status.switches[mapDatabase.maps[i].getSwitchId[j]] == 1)
						{
							num5++;
						}
					}
					if (status.switches[mapDatabase.maps[i].enableSwitchId] == 1 && num5 >= mapDatabase.maps[i].getSwitchId.Length)
					{
						pageMax = mapDatabase.maps[i].mapPicture.Length;
						bookMapPicture.guiTexture.texture = mapDatabase.maps[i].mapPicture[pageNow - 1];
						contentsName[0] = string.Empty;
						break;
					}
					pageMax = 1;
					if (status.language == 0)
					{
						contentsName[0] = noMapMessageJap;
					}
					else
					{
						contentsName[0] = noMapMessageEng;
					}
				}
			}
			for (i = 0; i < 10; i++)
			{
				bookContentsObject[i].guiText.text = contentsName[i];
				bookContentsObject[i].guiText.color = new Color(0f, 0f, 0f, 1f);
				if (cursorLabel != 2)
				{
					bookLineObject[i].SetActive(false);
				}
				else
				{
					bookLineObject[i].guiTexture.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
					if (status.switches[purposeDatabase.purposes[contentsId[i]].disappearSwitchId] == 1)
					{
						bookLineObject[i].SetActive(true);
					}
					else
					{
						bookLineObject[i].SetActive(false);
					}
				}
			}
			bookItemExplainObject.guiText.text = string.Empty;
			bookFileExplainObject.guiText.text = string.Empty;
			bookPhotoObject.SetActive(false);
			bookThumbObject.guiTexture.texture = null;
			bookUseObject.guiText.text = string.Empty;
			bookUseYesObject.guiText.text = string.Empty;
			bookUseNoObject.guiText.text = string.Empty;
			bookUseYesObject.guiText.color = new Color(0f, 0f, 0f, 1f);
			bookUseNoObject.guiText.color = new Color(0f, 0f, 0f, 1f);
			bookPageObject.guiText.text = pageNow.ToString() + "/" + pageMax.ToString();
			if (screenId == 2)
			{
				bookCoverObject.guiTexture.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
				bookPaperObject.guiTexture.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
				bookMapPicture.guiTexture.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
				if (cursorLabel == 0)
				{
					int num6 = 4;
					Vector3 localPosition = bookItemObject.transform.localPosition;
					float num7 = (localPosition.z = num6);
					Vector3 vector7 = (bookItemObject.transform.localPosition = localPosition);
					int num8 = 2;
					Vector3 localPosition2 = bookFileObject.transform.localPosition;
					float num9 = (localPosition2.z = num8);
					Vector3 vector9 = (bookFileObject.transform.localPosition = localPosition2);
					int num10 = 2;
					Vector3 localPosition3 = bookPurposeObject.transform.localPosition;
					float num11 = (localPosition3.z = num10);
					Vector3 vector11 = (bookPurposeObject.transform.localPosition = localPosition3);
					int num12 = 2;
					Vector3 localPosition4 = bookMapObject.transform.localPosition;
					float num13 = (localPosition4.z = num12);
					Vector3 vector13 = (bookMapObject.transform.localPosition = localPosition4);
					bookItemObject.guiTexture.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
					bookFileObject.guiTexture.color = new Color(0.4f, 0.4f, 0.4f, 0.5f);
					bookPurposeObject.guiTexture.color = new Color(0.4f, 0.4f, 0.4f, 0.5f);
					bookMapObject.guiTexture.color = new Color(0.4f, 0.4f, 0.4f, 0.5f);
					bookTitleObject.guiText.text = "- ITEM -";
				}
				else if (cursorLabel == 1)
				{
					int num14 = 2;
					Vector3 localPosition5 = bookItemObject.transform.localPosition;
					float num15 = (localPosition5.z = num14);
					Vector3 vector15 = (bookItemObject.transform.localPosition = localPosition5);
					int num16 = 4;
					Vector3 localPosition6 = bookFileObject.transform.localPosition;
					float num17 = (localPosition6.z = num16);
					Vector3 vector17 = (bookFileObject.transform.localPosition = localPosition6);
					int num18 = 2;
					Vector3 localPosition7 = bookPurposeObject.transform.localPosition;
					float num19 = (localPosition7.z = num18);
					Vector3 vector19 = (bookPurposeObject.transform.localPosition = localPosition7);
					int num20 = 2;
					Vector3 localPosition8 = bookMapObject.transform.localPosition;
					float num21 = (localPosition8.z = num20);
					Vector3 vector21 = (bookMapObject.transform.localPosition = localPosition8);
					bookItemObject.guiTexture.color = new Color(0.4f, 0.4f, 0.4f, 0.5f);
					bookFileObject.guiTexture.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
					bookPurposeObject.guiTexture.color = new Color(0.4f, 0.4f, 0.4f, 0.5f);
					bookMapObject.guiTexture.color = new Color(0.4f, 0.4f, 0.4f, 0.5f);
					bookTitleObject.guiText.text = "- FILE -";
				}
				else if (cursorLabel == 2)
				{
					int num22 = 2;
					Vector3 localPosition9 = bookItemObject.transform.localPosition;
					float num23 = (localPosition9.z = num22);
					Vector3 vector23 = (bookItemObject.transform.localPosition = localPosition9);
					int num24 = 2;
					Vector3 localPosition10 = bookFileObject.transform.localPosition;
					float num25 = (localPosition10.z = num24);
					Vector3 vector25 = (bookFileObject.transform.localPosition = localPosition10);
					int num26 = 4;
					Vector3 localPosition11 = bookPurposeObject.transform.localPosition;
					float num27 = (localPosition11.z = num26);
					Vector3 vector27 = (bookPurposeObject.transform.localPosition = localPosition11);
					int num28 = 2;
					Vector3 localPosition12 = bookMapObject.transform.localPosition;
					float num29 = (localPosition12.z = num28);
					Vector3 vector29 = (bookMapObject.transform.localPosition = localPosition12);
					bookItemObject.guiTexture.color = new Color(0.4f, 0.4f, 0.4f, 0.5f);
					bookFileObject.guiTexture.color = new Color(0.4f, 0.4f, 0.4f, 0.5f);
					bookPurposeObject.guiTexture.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
					bookMapObject.guiTexture.color = new Color(0.4f, 0.4f, 0.4f, 0.5f);
					bookTitleObject.guiText.text = "- OBJECTIVE -";
				}
				else if (cursorLabel == 3)
				{
					int num30 = 2;
					Vector3 localPosition13 = bookItemObject.transform.localPosition;
					float num31 = (localPosition13.z = num30);
					Vector3 vector31 = (bookItemObject.transform.localPosition = localPosition13);
					int num32 = 2;
					Vector3 localPosition14 = bookFileObject.transform.localPosition;
					float num33 = (localPosition14.z = num32);
					Vector3 vector33 = (bookFileObject.transform.localPosition = localPosition14);
					int num34 = 2;
					Vector3 localPosition15 = bookPurposeObject.transform.localPosition;
					float num35 = (localPosition15.z = num34);
					Vector3 vector35 = (bookPurposeObject.transform.localPosition = localPosition15);
					int num36 = 4;
					Vector3 localPosition16 = bookMapObject.transform.localPosition;
					float num37 = (localPosition16.z = num36);
					Vector3 vector37 = (bookMapObject.transform.localPosition = localPosition16);
					bookItemObject.guiTexture.color = new Color(0.4f, 0.4f, 0.4f, 0.5f);
					bookFileObject.guiTexture.color = new Color(0.4f, 0.4f, 0.4f, 0.5f);
					bookPurposeObject.guiTexture.color = new Color(0.4f, 0.4f, 0.4f, 0.5f);
					bookMapObject.guiTexture.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
					bookTitleObject.guiText.text = "- MAP -";
				}
			}
			else
			{
				bookCoverObject.guiTexture.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
				bookPaperObject.guiTexture.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
				bookMapPicture.guiTexture.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
				bookItemObject.guiTexture.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
				bookFileObject.guiTexture.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
				bookPurposeObject.guiTexture.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
				bookMapObject.guiTexture.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
				if (stock != 0)
				{
					bookContentsObject[cursor1].guiText.color = new Color(0.23f, 0.53f, 0.83f, 1f);
					if (cursorLabel == 2)
					{
						bookLineObject[cursor1].guiTexture.color = new Color(0.5f, 0.5f, 0.5f, 0.25f);
					}
				}
				if (screenId == 0 || screenId == 3)
				{
					if (screenId == 0)
					{
						if (status.language == 0)
						{
							for (i = 0; i < Extensions.get_length((System.Array)status.itemDatabase[contentsId[cursor1]].itemExplainJap); i++)
							{
								bookItemExplainObject.guiText.text = bookItemExplainObject.guiText.text + status.itemDatabase[contentsId[cursor1]].itemExplainJap[i];
								bookItemExplainObject.guiText.text = bookItemExplainObject.guiText.text + "\n";
							}
						}
						else
						{
							for (i = 0; i < Extensions.get_length((System.Array)status.itemDatabase[contentsId[cursor1]].itemExplainEng); i++)
							{
								bookItemExplainObject.guiText.text = bookItemExplainObject.guiText.text + status.itemDatabase[contentsId[cursor1]].itemExplainEng[i];
								bookItemExplainObject.guiText.text = bookItemExplainObject.guiText.text + "\n";
							}
						}
					}
					else
					{
						if (status.language == 0)
						{
							bookUseObject.guiText.text = contentsName[cursor1] + "を使用しますか？";
						}
						else
						{
							bookUseObject.guiText.text = "Do you want to use this?";
						}
						if (status.language == 0)
						{
							bookUseYesObject.guiText.text = useMessageYesJap;
							bookUseNoObject.guiText.text = useMessageNoJap;
						}
						else
						{
							bookUseYesObject.guiText.text = useMessageYesEng;
							bookUseNoObject.guiText.text = useMessageNoEng;
						}
						if (cursor2 == 0)
						{
							bookUseYesObject.guiText.color = new Color(0.23f, 0.53f, 0.83f, 1f);
						}
						else
						{
							bookUseNoObject.guiText.color = new Color(0.23f, 0.53f, 0.83f, 1f);
						}
					}
					bookThumbObject.guiTexture.texture = status.itemDatabase[contentsId[cursor1]].picture;
				}
				else if (screenId == 1 || screenId == 4)
				{
					if (status.language == 0)
					{
						for (i = 0; i < Extensions.get_length((System.Array)status.fileDatabase[contentsId[cursor1]].fileExplainJap); i++)
						{
							bookFileExplainObject.guiText.text = bookFileExplainObject.guiText.text + status.fileDatabase[contentsId[cursor1]].fileExplainJap[i];
							bookFileExplainObject.guiText.text = bookFileExplainObject.guiText.text + "\n";
						}
					}
					else
					{
						for (i = 0; i < Extensions.get_length((System.Array)status.fileDatabase[contentsId[cursor1]].fileExplainEng); i++)
						{
							bookFileExplainObject.guiText.text = bookFileExplainObject.guiText.text + status.fileDatabase[contentsId[cursor1]].fileExplainEng[i];
							bookFileExplainObject.guiText.text = bookFileExplainObject.guiText.text + "\n";
						}
					}
				}
				else if (screenId == 5)
				{
					if (status.language == 0)
					{
						for (i = 0; i < purposeDatabase.purposes[contentsId[cursor1]].purposeExplainJap.Length; i++)
						{
							bookItemExplainObject.guiText.text = bookItemExplainObject.guiText.text + purposeDatabase.purposes[contentsId[cursor1]].purposeExplainJap[i];
							bookItemExplainObject.guiText.text = bookItemExplainObject.guiText.text + "\n";
						}
					}
					else
					{
						for (i = 0; i < purposeDatabase.purposes[contentsId[cursor1]].purposeExplainEng.Length; i++)
						{
							bookItemExplainObject.guiText.text = bookItemExplainObject.guiText.text + purposeDatabase.purposes[contentsId[cursor1]].purposeExplainEng[i];
							bookItemExplainObject.guiText.text = bookItemExplainObject.guiText.text + "\n";
						}
					}
					if (purposeDatabase.purposes[contentsId[cursor1]].purposePicture != null)
					{
						bookPhotoObject.SetActive(true);
						if (purposeCursorFlag)
						{
							if (bookLineObject[cursor1].activeInHierarchy)
							{
								Color[] pixels = purposeDatabase.purposes[contentsId[cursor1]].purposePicture.GetPixels();
								purposePicture = new Texture2D(256, 256, TextureFormat.RGB24, false);
								purposePicture.SetPixels(pixels);
								purposePicture.Apply();
								MakeGrayscale(purposePicture);
							}
							else
							{
								purposePicture = purposeDatabase.purposes[contentsId[cursor1]].purposePicture;
							}
							purposeCursorFlag = false;
						}
					}
					bookThumbObject.guiTexture.texture = purposePicture;
				}
			}
			if (SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Action") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Action"))
			{
				if (screenId == 2)
				{
					if (cursorLabel < 2)
					{
						screenId = cursorLabel;
					}
					else
					{
						screenId = cursorLabel + 3;
					}
					if (cursorLabel == 2)
					{
						purposeCursorFlag = true;
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
				else if (screenId == 0 && stock != 0)
				{
					screenId = 3;
					cursor2 = 1;
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
				else if (screenId == 1 && stock != 0)
				{
					if (status.fileDatabase[contentsId[cursor1]].showSE != null)
					{
						audio.Stop();
						audio.PlayOneShot(status.fileDatabase[contentsId[cursor1]].showSE, 1f);
					}
					else if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
					if (status.fileDatabase[contentsId[cursor1]].callCommon)
					{
						StartCoroutine_Auto(FileCommon());
					}
					else
					{
						filePageNow = 1;
						if (status.language == 0)
						{
							fileText = new string[Extensions.get_length((System.Array)status.fileDatabase[contentsId[cursor1]].fileTextJap)];
							for (l = 0; l < Extensions.get_length((System.Array)fileText); l++)
							{
								for (m = 0; m < Extensions.get_length((System.Array)status.fileDatabase[contentsId[cursor1]].fileTextJap[l].text); m++)
								{
									fileText[l] += status.fileDatabase[contentsId[cursor1]].fileTextJap[l].text[m];
									if (m != Extensions.get_length((System.Array)status.fileDatabase[contentsId[cursor1]].fileTextJap[l].text) - 1)
									{
										fileText[l] += "\n";
									}
								}
							}
						}
						else
						{
							fileText = new string[Extensions.get_length((System.Array)status.fileDatabase[contentsId[cursor1]].fileTextEng)];
							for (l = 0; l < Extensions.get_length((System.Array)fileText); l++)
							{
								for (m = 0; m < Extensions.get_length((System.Array)status.fileDatabase[contentsId[cursor1]].fileTextEng[l].text); m++)
								{
									fileText[l] += status.fileDatabase[contentsId[cursor1]].fileTextEng[l].text[m];
									if (m != Extensions.get_length((System.Array)status.fileDatabase[contentsId[cursor1]].fileTextEng[l].text) - 1)
									{
										fileText[l] += "\n";
									}
								}
							}
						}
						filePageMax = Extensions.get_length((System.Array)fileText);
						screenId = 4;
					}
				}
				else if (screenId == 3)
				{
					if (cursor2 == 0)
					{
						if (decideSE != null)
						{
							audio.PlayOneShot(decideSE, 0.6f);
						}
						if (status.itemDatabase[contentsId[cursor1]].callCommon)
						{
							StartCoroutine_Auto(ItemCommon());
						}
						else if (actionTrigger.itemFlag && Extensions.get_length((System.Array)actionTrigger.itemId) != 0)
						{
							for (l = 0; l < Extensions.get_length((System.Array)actionTrigger.itemId); l++)
							{
								if (actionTrigger.itemId[l] == contentsId[cursor1])
								{
									StartCoroutine_Auto(ItemUse());
									break;
								}
								if (status.language == 0)
								{
									bookUseCantObject.guiText.text = "ここでは使えない";
								}
								else
								{
									bookUseCantObject.guiText.text = "This can't be used here";
								}
							}
						}
						else if (status.language == 0)
						{
							bookUseCantObject.guiText.text = "ここでは使えない";
						}
						else
						{
							bookUseCantObject.guiText.text = "This can't be used here";
						}
					}
					else
					{
						screenId = 0;
						bookUseCantObject.guiText.text = string.Empty;
						if (decideSE != null)
						{
							audio.PlayOneShot(decideSE, 0.6f);
						}
					}
				}
			}
			if (SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Sprint") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Sprint") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Pause") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Pause"))
			{
				if (screenId == 2)
				{
					StartCoroutine_Auto(EndMenu());
				}
				else if (screenId == 0 || screenId == 1 || screenId == 5 || screenId == 6)
				{
					screenId = 2;
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
				else if (screenId == 3)
				{
					screenId = 0;
					bookUseCantObject.guiText.text = string.Empty;
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
				else if (screenId == 4)
				{
					screenId = 1;
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			if (screenId == 6 && (SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Map") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Map")))
			{
				StartCoroutine_Auto(EndMenu());
			}
			if (SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Menu") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Menu"))
			{
				StartCoroutine_Auto(EndMenu());
			}
			return;
		}
		if (player.isControllable && status.menuPermission)
		{
			for (i = 0; i < purposeParamsArray.Length; i++)
			{
				if (!purposeParamsArray[i].completeFlag && status.switches[purposeParamsArray[i].enableSwitchId] == 1 && status.switches[purposeParamsArray[i].appearSwitchId] == 1)
				{
					purposeParamsArray[i].completeFlag = true;
					status.ShowPurpose(true);
				}
			}
		}
		if ((SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Menu") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Menu")) && player.isControllable && status.menuPermission)
		{
			StartCoroutine_Auto(StartMenu());
		}
		else if ((SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Map") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Map")) && player.isControllable && status.menuPermission)
		{
			StartCoroutine_Auto(StartMap());
		}
	}

	public virtual IEnumerator Cursor()
	{
		return new _0024Cursor_00241311(this).GetEnumerator();
	}

	public virtual void MakeGrayscale(Texture2D tex)
	{
		Color[] pixels = tex.GetPixels();
		for (i = 0; i < pixels.Length; i++)
		{
			float grayscale = pixels[i].grayscale;
			pixels[i] = new Color(grayscale, grayscale, grayscale, 1f);
		}
		tex.SetPixels(pixels);
		tex.Apply();
	}

	public virtual IEnumerator StartMenu()
	{
		return new _0024StartMenu_00241314(this).GetEnumerator();
	}

	public virtual IEnumerator StartMap()
	{
		return new _0024StartMap_00241317(this).GetEnumerator();
	}

	public virtual IEnumerator EndMenu()
	{
		return new _0024EndMenu_00241328(this).GetEnumerator();
	}

	public virtual IEnumerator ItemUse()
	{
		return new _0024ItemUse_00241331(this).GetEnumerator();
	}

	public virtual IEnumerator ItemCommon()
	{
		return new _0024ItemCommon_00241334(this).GetEnumerator();
	}

	public virtual IEnumerator FileCommon()
	{
		return new _0024FileCommon_00241337(this).GetEnumerator();
	}

	public virtual void SortId(int sortId)
	{
		int num = default(int);
		int num2 = default(int);
		int num3 = default(int);
		int num4 = default(int);
		string text = null;
		switch (sortId)
		{
		case 0:
			for (num = 9; num > 0; num--)
			{
				if (num > 9)
				{
					num = 9;
				}
				num3 = 10000;
				num4 = 9999;
				for (num2 = 0; num2 < status.itemSortNumber.Length; num2++)
				{
					if (contentsId[num] == status.itemSortNumber[num2])
					{
						num3 = num2;
					}
					if (contentsId[num - 1] == status.itemSortNumber[num2])
					{
						num4 = num2;
					}
				}
				if (num3 < num4)
				{
					num3 = contentsId[num - 1];
					contentsId[num - 1] = contentsId[num];
					contentsId[num] = num3;
					text = contentsName[num - 1];
					contentsName[num - 1] = contentsName[num];
					contentsName[num] = text;
					num += 2;
				}
			}
			break;
		case 1:
			for (num = 9; num > 0; num--)
			{
				if (num > 9)
				{
					num = 9;
				}
				num3 = 10000;
				num4 = 9999;
				for (num2 = 0; num2 < status.fileSortNumber.Length; num2++)
				{
					if (contentsId[num] == status.fileSortNumber[num2])
					{
						num3 = num2;
					}
					if (contentsId[num - 1] == status.fileSortNumber[num2])
					{
						num4 = num2;
					}
				}
				if (num3 < num4)
				{
					num3 = contentsId[num - 1];
					contentsId[num - 1] = contentsId[num];
					contentsId[num] = num3;
					text = contentsName[num - 1];
					contentsName[num - 1] = contentsName[num];
					contentsName[num] = text;
					num += 2;
				}
			}
			break;
		case 2:
			for (num = 9; num > 0; num--)
			{
				if (num > 9)
				{
					num = 9;
				}
				num3 = 10000;
				num4 = 9999;
				for (num2 = 0; num2 < purposeDatabase.purposeSortNumber.Length; num2++)
				{
					if (contentsId[num] == purposeDatabase.purposeSortNumber[num2])
					{
						num3 = num2;
					}
					if (contentsId[num - 1] == purposeDatabase.purposeSortNumber[num2])
					{
						num4 = num2;
					}
				}
				if (num3 < num4)
				{
					num3 = contentsId[num - 1];
					contentsId[num - 1] = contentsId[num];
					contentsId[num] = num3;
					text = contentsName[num - 1];
					contentsName[num - 1] = contentsName[num];
					contentsName[num] = text;
					num += 2;
				}
			}
			break;
		}
	}

	public virtual void OnGUI()
	{
		if (screenId != 4)
		{
			return;
		}
		float a = 0.8f;
		Color color = GUI.color;
		float num = (color.a = a);
		Color color2 = (GUI.color = color);
		if (!status.fileDatabase[contentsId[cursor1]].pictureFlag || (status.fileDatabase[contentsId[cursor1]].pictureFlag && filePageNow == 1))
		{
			GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), blackTexture);
		}
		float a2 = 1f;
		Color color4 = GUI.color;
		float num2 = (color4.a = a2);
		Color color5 = (GUI.color = color4);
		if (!status.fileDatabase[contentsId[cursor1]].pictureFlag)
		{
			GUI.Label(new Rect(Screen.width / 2 - 320, 0f, Screen.width / 2 + 320, Screen.height), fileText[filePageNow - 1], guiSkin.customStyles[2]);
			GUI.Label(new Rect(0f, 0f, Screen.width, Screen.height), "< " + filePageNow.ToString() + " / " + filePageMax.ToString() + " >\n", guiSkin.customStyles[3]);
			return;
		}
		GUI.DrawTexture(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 240, 640f, 480f), status.fileDatabase[contentsId[cursor1]].picture, ScaleMode.StretchToFill);
		if (filePageNow != 1)
		{
			float a3 = 0.8f;
			Color color7 = GUI.color;
			float num3 = (color7.a = a3);
			Color color8 = (GUI.color = color7);
			GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), blackTexture);
			float a4 = 1f;
			Color color10 = GUI.color;
			float num4 = (color10.a = a4);
			Color color11 = (GUI.color = color10);
		}
		GUI.Label(new Rect(Screen.width / 2 - 320, 0f, Screen.width / 2 + 320, Screen.height), fileText[filePageNow - 1], guiSkin.customStyles[2]);
		GUI.Label(new Rect(0f, 0f, Screen.width, Screen.height), "< " + filePageNow.ToString() + " / " + filePageMax.ToString() + " >\n", guiSkin.customStyles[3]);
	}

	public virtual void Main()
	{
	}
}
