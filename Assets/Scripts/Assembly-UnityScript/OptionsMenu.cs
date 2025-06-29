using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class OptionsMenu : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024WaitKeyUp_00241241 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal OptionsMenu _0024self__00241242;

			public _0024(OptionsMenu self_)
			{
				_0024self__00241242 = self_;
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
					_0024self__00241242.nowOptioning = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal OptionsMenu _0024self__00241243;

		public _0024WaitKeyUp_00241241(OptionsMenu self_)
		{
			_0024self__00241243 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024self__00241243);
		}
	}

	[Serializable]
	internal sealed class _0024EndOption_00241244 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal OptionsMenu _0024self__00241245;

			public _0024(OptionsMenu self_)
			{
				_0024self__00241245 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241245.cursor1 = 0;
					_0024self__00241245.screenId = 0;
					_0024self__00241245.nowOptioning = false;
					result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				case 2:
					_0024self__00241245.SendMessage("ReturnPause", SendMessageOptions.DontRequireReceiver);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal OptionsMenu _0024self__00241246;

		public _0024EndOption_00241244(OptionsMenu self_)
		{
			_0024self__00241246 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024self__00241246);
		}
	}

	[Serializable]
	internal sealed class _0024ChangeKey_00241247 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal string _0024tempText_00241248;

			internal string _0024name_00241249;

			internal int _0024index_00241250;

			internal bool _0024mouseB_00241251;

			internal bool _0024joyB_00241252;

			internal bool _0024keyB_00241253;

			internal OptionsMenu _0024self__00241254;

			public _0024(string name, int index, bool mouseB, bool joyB, bool keyB, OptionsMenu self_)
			{
				_0024name_00241249 = name;
				_0024index_00241250 = index;
				_0024mouseB_00241251 = mouseB;
				_0024joyB_00241252 = joyB;
				_0024keyB_00241253 = keyB;
				_0024self__00241254 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241254.nowKeyChanging = true;
					result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				case 2:
					cInput.ChangeKey(_0024name_00241249, _0024index_00241250, false, _0024mouseB_00241251, false, _0024joyB_00241252, _0024keyB_00241253);
					_0024tempText_00241248 = null;
					goto IL_006d;
				case 3:
					_0024tempText_00241248 = cInput.GetText(_0024name_00241249, _0024index_00241250);
					if (!(_0024tempText_00241248 != ". . ."))
					{
						goto IL_006d;
					}
					if (_0024self__00241254.decideSE != null)
					{
						_0024self__00241254.audio.PlayOneShot(_0024self__00241254.decideSE, 0.6f);
					}
					result = (Yield(4, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				case 4:
					Input.ResetInputAxes();
					_0024self__00241254.nowKeyChanging = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_006d:
					result = (Yield(3, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024name_00241255;

		internal int _0024index_00241256;

		internal bool _0024mouseB_00241257;

		internal bool _0024joyB_00241258;

		internal bool _0024keyB_00241259;

		internal OptionsMenu _0024self__00241260;

		public _0024ChangeKey_00241247(string name, int index, bool mouseB, bool joyB, bool keyB, OptionsMenu self_)
		{
			_0024name_00241255 = name;
			_0024index_00241256 = index;
			_0024mouseB_00241257 = mouseB;
			_0024joyB_00241258 = joyB;
			_0024keyB_00241259 = keyB;
			_0024self__00241260 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024name_00241255, _0024index_00241256, _0024mouseB_00241257, _0024joyB_00241258, _0024keyB_00241259, _0024self__00241260);
		}
	}

	[Serializable]
	internal sealed class _0024Cursor_00241261 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal OptionsMenu _0024self__00241262;

			public _0024(OptionsMenu self_)
			{
				_0024self__00241262 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024self__00241262.nowKeyChanging)
					{
						if (_0024self__00241262.screenId == 0)
						{
							if (cInput.GetAxisRaw("Vertical") >= 0.1f || cInput.GetAxisRaw("J_Vertical") >= 0.1f || !(cInput.GetAxisRaw("DPad_Vertical") < 0.1f))
							{
								_0024self__00241262.cursor1--;
								if (_0024self__00241262.cursorSE != null)
								{
									_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
								}
								if (_0024self__00241262.cursor1 == 3 && Input.GetJoystickNames().Length == 0)
								{
									_0024self__00241262.cursor1--;
								}
								else if (_0024self__00241262.cursor1 == 3 && Input.GetJoystickNames().Length != 0 && Input.GetJoystickNames()[0] == string.Empty)
								{
									_0024self__00241262.cursor1--;
								}
								if (_0024self__00241262.cursor1 < 0)
								{
									_0024self__00241262.cursor1 = 4;
								}
								goto IL_01bb;
							}
							goto IL_0209;
						}
						if (_0024self__00241262.screenId == 1)
						{
							if (cInput.GetAxisRaw("Vertical") >= 0.1f || cInput.GetAxisRaw("J_Vertical") >= 0.1f || !(cInput.GetAxisRaw("DPad_Vertical") < 0.1f))
							{
								_0024self__00241262.cursor2--;
								if (_0024self__00241262.cursorSE != null)
								{
									_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
								}
								if (_0024self__00241262.cursor2 < 0)
								{
									_0024self__00241262.cursor2 = 4;
								}
								if (_0024self__00241262.status.japaneseOnly && _0024self__00241262.cursor2 == 3)
								{
									_0024self__00241262.cursor2 = 2;
								}
								goto IL_0482;
							}
							goto IL_04d0;
						}
						if (_0024self__00241262.screenId == 2)
						{
							if (cInput.GetAxisRaw("Vertical") >= 0.1f || cInput.GetAxisRaw("J_Vertical") >= 0.1f || !(cInput.GetAxisRaw("DPad_Vertical") < 0.1f))
							{
								_0024self__00241262.cursor2--;
								if (_0024self__00241262.cursorSE != null)
								{
									_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
								}
								if (_0024self__00241262.cursor2 < 0)
								{
									_0024self__00241262.cursor2 = 6;
								}
								goto IL_0d1b;
							}
							goto IL_0d69;
						}
						if (_0024self__00241262.screenId == 3)
						{
							if (cInput.GetAxisRaw("Vertical") >= 0.1f || cInput.GetAxisRaw("J_Vertical") >= 0.1f || !(cInput.GetAxisRaw("DPad_Vertical") < 0.1f))
							{
								if (_0024self__00241262.cursor2 >= 9)
								{
									_0024self__00241262.cursor2--;
								}
								else if (_0024self__00241262.cursor2 == 8)
								{
									_0024self__00241262.cursor3 = 0;
									_0024self__00241262.cursor2 = 0;
								}
								else if (_0024self__00241262.cursor2 >= 2)
								{
									_0024self__00241262.cursor2 -= 2;
								}
								else if (_0024self__00241262.cursor3 != 0)
								{
									_0024self__00241262.cursor3--;
								}
								else if (_0024self__00241262.cursor2 == 1)
								{
									_0024self__00241262.cursor2 -= 2;
								}
								else
								{
									_0024self__00241262.cursor2--;
								}
								if (_0024self__00241262.cursorSE != null)
								{
									_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
								}
								if (_0024self__00241262.cursor2 < 0)
								{
									_0024self__00241262.cursor2 = 11;
								}
								goto IL_1763;
							}
							goto IL_17b2;
						}
						if (_0024self__00241262.screenId == 4)
						{
							if (cInput.GetAxisRaw("Vertical") >= 0.1f || cInput.GetAxisRaw("J_Vertical") >= 0.1f || !(cInput.GetAxisRaw("DPad_Vertical") < 0.1f))
							{
								if (_0024self__00241262.cursor2 >= 9)
								{
									_0024self__00241262.cursor2--;
								}
								else if (_0024self__00241262.cursor2 == 8)
								{
									_0024self__00241262.cursor3 = 4;
									_0024self__00241262.cursor2 = 0;
								}
								else if (_0024self__00241262.cursor2 >= 2)
								{
									_0024self__00241262.cursor2 -= 2;
								}
								else if (_0024self__00241262.cursor3 != 4)
								{
									_0024self__00241262.cursor3--;
								}
								else if (_0024self__00241262.cursor2 == 5)
								{
									_0024self__00241262.cursor2 -= 2;
								}
								else
								{
									_0024self__00241262.cursor2--;
								}
								if (_0024self__00241262.cursorSE != null)
								{
									_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
								}
								if (_0024self__00241262.cursor2 < 0)
								{
									_0024self__00241262.cursor2 = 11;
								}
								goto IL_21a7;
							}
							goto IL_21f6;
						}
					}
					goto IL_27e7;
				case 2:
					if (cInput.GetAxisRaw("Vertical") == 0f && cInput.GetAxisRaw("J_Vertical") == 0f && cInput.GetAxisRaw("DPad_Vertical") == 0f)
					{
						goto IL_0209;
					}
					goto IL_01bb;
				case 3:
					if (cInput.GetAxisRaw("Vertical") == 0f && cInput.GetAxisRaw("J_Vertical") == 0f && cInput.GetAxisRaw("DPad_Vertical") == 0f)
					{
						goto IL_27e7;
					}
					goto IL_0340;
				case 4:
					if (cInput.GetAxisRaw("Vertical") == 0f && cInput.GetAxisRaw("J_Vertical") == 0f && cInput.GetAxisRaw("DPad_Vertical") == 0f)
					{
						goto IL_04d0;
					}
					goto IL_0482;
				case 5:
					if (cInput.GetAxisRaw("Vertical") == 0f && cInput.GetAxisRaw("J_Vertical") == 0f && cInput.GetAxisRaw("DPad_Vertical") == 0f)
					{
						goto IL_05fc;
					}
					goto IL_05ae;
				case 6:
					if (cInput.GetAxisRaw("Horizontal") == 0f && cInput.GetAxisRaw("J_Horizontal") == 0f && cInput.GetAxisRaw("DPad_Horizontal") == 0f)
					{
						goto IL_0936;
					}
					goto IL_08e8;
				case 7:
					if (cInput.GetAxisRaw("Horizontal") == 0f && cInput.GetAxisRaw("J_Horizontal") == 0f && cInput.GetAxisRaw("DPad_Horizontal") == 0f)
					{
						goto IL_27e7;
					}
					goto IL_0c0b;
				case 8:
					if (cInput.GetAxisRaw("Vertical") == 0f && cInput.GetAxisRaw("J_Vertical") == 0f && cInput.GetAxisRaw("DPad_Vertical") == 0f)
					{
						goto IL_0d69;
					}
					goto IL_0d1b;
				case 9:
					if (cInput.GetAxisRaw("Vertical") == 0f && cInput.GetAxisRaw("J_Vertical") == 0f && cInput.GetAxisRaw("DPad_Vertical") == 0f)
					{
						goto IL_0e64;
					}
					goto IL_0e15;
				case 10:
					if (cInput.GetAxisRaw("Horizontal") == 0f && cInput.GetAxisRaw("J_Horizontal") == 0f && cInput.GetAxisRaw("DPad_Horizontal") == 0f)
					{
						goto IL_1212;
					}
					goto IL_11c3;
				case 11:
					if (cInput.GetAxisRaw("Horizontal") == 0f && cInput.GetAxisRaw("J_Horizontal") == 0f && cInput.GetAxisRaw("DPad_Horizontal") == 0f)
					{
						goto IL_27e7;
					}
					goto IL_156b;
				case 12:
					if (cInput.GetAxisRaw("Vertical") == 0f && cInput.GetAxisRaw("J_Vertical") == 0f && cInput.GetAxisRaw("DPad_Vertical") == 0f)
					{
						goto IL_17b2;
					}
					goto IL_1763;
				case 13:
					if (cInput.GetAxisRaw("Vertical") == 0f && cInput.GetAxisRaw("J_Vertical") == 0f && cInput.GetAxisRaw("DPad_Vertical") == 0f)
					{
						goto IL_1966;
					}
					goto IL_1917;
				case 14:
					if (cInput.GetAxisRaw("Horizontal") == 0f && cInput.GetAxisRaw("J_Horizontal") == 0f && cInput.GetAxisRaw("DPad_Horizontal") == 0f)
					{
						goto IL_1cb4;
					}
					goto IL_1c65;
				case 15:
					if (cInput.GetAxisRaw("Horizontal") == 0f && cInput.GetAxisRaw("J_Horizontal") == 0f && cInput.GetAxisRaw("DPad_Horizontal") == 0f)
					{
						goto IL_27e7;
					}
					goto IL_1fae;
				case 16:
					if (cInput.GetAxisRaw("Vertical") == 0f && cInput.GetAxisRaw("J_Vertical") == 0f && cInput.GetAxisRaw("DPad_Vertical") == 0f)
					{
						goto IL_21f6;
					}
					goto IL_21a7;
				case 17:
					if (cInput.GetAxisRaw("Vertical") == 0f && cInput.GetAxisRaw("J_Vertical") == 0f && cInput.GetAxisRaw("DPad_Vertical") == 0f)
					{
						goto IL_23aa;
					}
					goto IL_235b;
				case 18:
					if (cInput.GetAxisRaw("Horizontal") == 0f && cInput.GetAxisRaw("J_Horizontal") == 0f && cInput.GetAxisRaw("DPad_Horizontal") == 0f)
					{
						goto IL_25cb;
					}
					goto IL_257c;
				case 19:
					if (cInput.GetAxisRaw("Horizontal") == 0f && cInput.GetAxisRaw("J_Horizontal") == 0f && cInput.GetAxisRaw("DPad_Horizontal") == 0f)
					{
						goto IL_27e7;
					}
					goto IL_2798;
				case 20:
					if (_0024self__00241262.nowOptioning)
					{
						goto default;
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_17b2:
					if (cInput.GetAxisRaw("Vertical") <= -0.1f || cInput.GetAxisRaw("J_Vertical") <= -0.1f || !(cInput.GetAxisRaw("DPad_Vertical") > -0.1f))
					{
						if (_0024self__00241262.cursor2 <= 5)
						{
							_0024self__00241262.cursor2 += 2;
						}
						else if ((_0024self__00241262.cursor2 == 6 || _0024self__00241262.cursor2 == 7) && _0024self__00241262.cursor3 != 6)
						{
							_0024self__00241262.cursor3++;
						}
						else if (_0024self__00241262.cursor2 == 6)
						{
							_0024self__00241262.cursor2 += 2;
						}
						else
						{
							_0024self__00241262.cursor2++;
						}
						if (_0024self__00241262.cursorSE != null)
						{
							_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
						}
						if (_0024self__00241262.cursor2 >= 12)
						{
							_0024self__00241262.cursor3 = 0;
							_0024self__00241262.cursor2 = 0;
						}
						goto IL_1917;
					}
					goto IL_1966;
					IL_01bb:
					result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_1917:
					result = (Yield(13, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_2798:
					result = (Yield(19, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_1966:
					if (cInput.GetAxisRaw("Horizontal") >= 0.1f || cInput.GetAxisRaw("J_Horizontal") >= 0.1f || !(cInput.GetAxisRaw("DPad_Horizontal") < 0.1f))
					{
						if (_0024self__00241262.cursor2 == 0 || _0024self__00241262.cursor2 == 2 || _0024self__00241262.cursor2 == 4 || _0024self__00241262.cursor2 == 6)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							_0024self__00241262.cursor2++;
						}
						else if (_0024self__00241262.cursor2 == 1 || _0024self__00241262.cursor2 == 3 || _0024self__00241262.cursor2 == 5 || _0024self__00241262.cursor2 == 7)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							_0024self__00241262.cursor2--;
						}
						else if (_0024self__00241262.cursor2 == 8)
						{
							if (_0024self__00241262.cursor4 == 16)
							{
								_0024self__00241262.cursor4 = 16;
							}
							else
							{
								_0024self__00241262.cursor4++;
								if (_0024self__00241262.cursorSE != null)
								{
									_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
								}
							}
						}
						else if (_0024self__00241262.cursor2 == 9)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursor5 == 1)
							{
								_0024self__00241262.cursor5 = 0;
							}
							else
							{
								_0024self__00241262.cursor5++;
							}
						}
						else if (_0024self__00241262.cursor2 == 11)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursorAC == 1)
							{
								_0024self__00241262.cursorAC = 0;
							}
							else
							{
								_0024self__00241262.cursorAC++;
							}
						}
						goto IL_1c65;
					}
					goto IL_1cb4;
					IL_23aa:
					if (cInput.GetAxisRaw("Horizontal") >= 0.1f || cInput.GetAxisRaw("J_Horizontal") >= 0.1f || !(cInput.GetAxisRaw("DPad_Horizontal") < 0.1f))
					{
						if (_0024self__00241262.cursor2 == 8)
						{
							if (_0024self__00241262.cursor4 == 16)
							{
								_0024self__00241262.cursor4 = 16;
							}
							else
							{
								_0024self__00241262.cursor4++;
								if (_0024self__00241262.cursorSE != null)
								{
									_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
								}
							}
						}
						else if (_0024self__00241262.cursor2 == 9)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursor5 == 3)
							{
								_0024self__00241262.cursor5 = 0;
							}
							else
							{
								_0024self__00241262.cursor5++;
							}
						}
						else if (_0024self__00241262.cursor2 == 11)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursorAC == 1)
							{
								_0024self__00241262.cursorAC = 0;
							}
							else
							{
								_0024self__00241262.cursorAC++;
							}
						}
						goto IL_257c;
					}
					goto IL_25cb;
					IL_0d1b:
					result = (Yield(8, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_0209:
					if (cInput.GetAxisRaw("Vertical") <= -0.1f || cInput.GetAxisRaw("J_Vertical") <= -0.1f || !(cInput.GetAxisRaw("DPad_Vertical") > -0.1f))
					{
						_0024self__00241262.cursor1++;
						if (_0024self__00241262.cursorSE != null)
						{
							_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
						}
						if (_0024self__00241262.cursor1 == 3 && Input.GetJoystickNames().Length == 0)
						{
							_0024self__00241262.cursor1++;
						}
						else if (_0024self__00241262.cursor1 == 3 && Input.GetJoystickNames().Length != 0 && Input.GetJoystickNames()[0] == string.Empty)
						{
							_0024self__00241262.cursor1++;
						}
						if (_0024self__00241262.cursor1 >= 5)
						{
							_0024self__00241262.cursor1 = 0;
						}
						goto IL_0340;
					}
					goto IL_27e7;
					IL_257c:
					result = (Yield(18, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_08e8:
					result = (Yield(6, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_21f6:
					if (cInput.GetAxisRaw("Vertical") <= -0.1f || cInput.GetAxisRaw("J_Vertical") <= -0.1f || !(cInput.GetAxisRaw("DPad_Vertical") > -0.1f))
					{
						if (_0024self__00241262.cursor2 <= 5)
						{
							_0024self__00241262.cursor2 += 2;
						}
						else if ((_0024self__00241262.cursor2 == 6 || _0024self__00241262.cursor2 == 7) && _0024self__00241262.cursor3 != 6)
						{
							_0024self__00241262.cursor3++;
						}
						else if (_0024self__00241262.cursor2 == 6)
						{
							_0024self__00241262.cursor2 += 2;
						}
						else
						{
							_0024self__00241262.cursor2++;
						}
						if (_0024self__00241262.cursorSE != null)
						{
							_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
						}
						if (_0024self__00241262.cursor2 >= 12)
						{
							_0024self__00241262.cursor3 = 4;
							_0024self__00241262.cursor2 = 0;
						}
						goto IL_235b;
					}
					goto IL_23aa;
					IL_1cb4:
					if (cInput.GetAxisRaw("Horizontal") <= -0.1f || cInput.GetAxisRaw("J_Horizontal") <= -0.1f || !(cInput.GetAxisRaw("DPad_Horizontal") > -0.1f))
					{
						if (_0024self__00241262.cursor2 == 0 || _0024self__00241262.cursor2 == 2 || _0024self__00241262.cursor2 == 4 || _0024self__00241262.cursor2 == 6)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							_0024self__00241262.cursor2++;
						}
						else if (_0024self__00241262.cursor2 == 1 || _0024self__00241262.cursor2 == 3 || _0024self__00241262.cursor2 == 5 || _0024self__00241262.cursor2 == 7)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							_0024self__00241262.cursor2--;
						}
						else if (_0024self__00241262.cursor2 == 8)
						{
							if (_0024self__00241262.cursor4 == 0)
							{
								_0024self__00241262.cursor4 = 0;
							}
							else
							{
								_0024self__00241262.cursor4--;
								if (_0024self__00241262.cursorSE != null)
								{
									_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
								}
							}
						}
						else if (_0024self__00241262.cursor2 == 9)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursor5 == 0)
							{
								_0024self__00241262.cursor5 = 1;
							}
							else
							{
								_0024self__00241262.cursor5--;
							}
						}
						else if (_0024self__00241262.cursor2 == 11)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursorAC == 0)
							{
								_0024self__00241262.cursorAC = 1;
							}
							else
							{
								_0024self__00241262.cursorAC--;
							}
						}
						goto IL_1fae;
					}
					goto IL_27e7;
					IL_27e7:
					result = (Yield(20, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_0482:
					result = (Yield(4, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_1c65:
					result = (Yield(14, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_1212:
					if (cInput.GetAxisRaw("Horizontal") <= -0.1f || cInput.GetAxisRaw("J_Horizontal") <= -0.1f || !(cInput.GetAxisRaw("DPad_Horizontal") > -0.1f))
					{
						if (_0024self__00241262.cursor2 == 0)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursor3 == 0)
							{
								_0024self__00241262.cursor3 = 2;
							}
							else
							{
								_0024self__00241262.cursor3--;
							}
						}
						else if (_0024self__00241262.cursor2 == 1)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursor4 == 0)
							{
								_0024self__00241262.cursor4 = 1;
							}
							else
							{
								_0024self__00241262.cursor4--;
							}
						}
						else if (_0024self__00241262.cursor2 == 2)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursor5 == 0)
							{
								_0024self__00241262.cursor5 = 4;
							}
							else
							{
								_0024self__00241262.cursor5--;
							}
						}
						else if (_0024self__00241262.cursor2 == 3)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursor6 == 0)
							{
								_0024self__00241262.cursor6 = 3;
							}
							else
							{
								_0024self__00241262.cursor6--;
							}
						}
						else if (_0024self__00241262.cursor2 == 4)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursor7 == 0)
							{
								_0024self__00241262.cursor7 = 1;
							}
							else
							{
								_0024self__00241262.cursor7--;
							}
						}
						else if (_0024self__00241262.cursor2 == 6)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursorAC == 0)
							{
								_0024self__00241262.cursorAC = 1;
							}
							else
							{
								_0024self__00241262.cursorAC--;
							}
						}
						goto IL_156b;
					}
					goto IL_27e7;
					IL_0c0b:
					result = (Yield(7, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_05ae:
					result = (Yield(5, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_1fae:
					result = (Yield(15, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_21a7:
					result = (Yield(16, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_156b:
					result = (Yield(11, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_0340:
					result = (Yield(3, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_04d0:
					if (cInput.GetAxisRaw("Vertical") <= -0.1f || cInput.GetAxisRaw("J_Vertical") <= -0.1f || !(cInput.GetAxisRaw("DPad_Vertical") > -0.1f))
					{
						_0024self__00241262.cursor2++;
						if (_0024self__00241262.cursorSE != null)
						{
							_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
						}
						if (_0024self__00241262.cursor2 >= 5)
						{
							_0024self__00241262.cursor2 = 0;
						}
						if (_0024self__00241262.status.japaneseOnly && _0024self__00241262.cursor2 == 3)
						{
							_0024self__00241262.cursor2 = 4;
						}
						goto IL_05ae;
					}
					goto IL_05fc;
					IL_0d69:
					if (cInput.GetAxisRaw("Vertical") <= -0.1f || cInput.GetAxisRaw("J_Vertical") <= -0.1f || !(cInput.GetAxisRaw("DPad_Vertical") > -0.1f))
					{
						_0024self__00241262.cursor2++;
						if (_0024self__00241262.cursorSE != null)
						{
							_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
						}
						if (_0024self__00241262.cursor2 >= 7)
						{
							_0024self__00241262.cursor2 = 0;
						}
						goto IL_0e15;
					}
					goto IL_0e64;
					IL_05fc:
					if (cInput.GetAxisRaw("Horizontal") >= 0.1f || cInput.GetAxisRaw("J_Horizontal") >= 0.1f || !(cInput.GetAxisRaw("DPad_Horizontal") < 0.1f))
					{
						if (_0024self__00241262.cursor2 == 0)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursor3 == 17 || _0024self__00241262.cursor3 == 18)
							{
								_0024self__00241262.cursor3 = 0;
							}
							else
							{
								_0024self__00241262.cursor3++;
							}
						}
						else if (_0024self__00241262.cursor2 == 1)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursor4 == 1)
							{
								_0024self__00241262.cursor4 = 0;
							}
							else
							{
								_0024self__00241262.cursor4++;
							}
						}
						else if (_0024self__00241262.cursor2 == 2)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursor5 == 1)
							{
								_0024self__00241262.cursor5 = 0;
							}
							else
							{
								_0024self__00241262.cursor5++;
							}
						}
						else if (_0024self__00241262.cursor2 == 3)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursor6 == 1)
							{
								_0024self__00241262.cursor6 = 0;
							}
							else
							{
								_0024self__00241262.cursor6++;
							}
						}
						else if (_0024self__00241262.cursor2 == 4)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursorAC == 1)
							{
								_0024self__00241262.cursorAC = 0;
							}
							else
							{
								_0024self__00241262.cursorAC++;
							}
						}
						goto IL_08e8;
					}
					goto IL_0936;
					IL_25cb:
					if (cInput.GetAxisRaw("Horizontal") <= -0.1f || cInput.GetAxisRaw("J_Horizontal") <= -0.1f || !(cInput.GetAxisRaw("DPad_Horizontal") > -0.1f))
					{
						if (_0024self__00241262.cursor2 == 8)
						{
							if (_0024self__00241262.cursor4 == 0)
							{
								_0024self__00241262.cursor4 = 0;
							}
							else
							{
								_0024self__00241262.cursor4--;
								if (_0024self__00241262.cursorSE != null)
								{
									_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
								}
							}
						}
						else if (_0024self__00241262.cursor2 == 9)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursor5 == 0)
							{
								_0024self__00241262.cursor5 = 3;
							}
							else
							{
								_0024self__00241262.cursor5--;
							}
						}
						else if (_0024self__00241262.cursor2 == 11)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursorAC == 0)
							{
								_0024self__00241262.cursorAC = 1;
							}
							else
							{
								_0024self__00241262.cursorAC--;
							}
						}
						goto IL_2798;
					}
					goto IL_27e7;
					IL_235b:
					result = (Yield(17, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_0936:
					if (cInput.GetAxisRaw("Horizontal") <= -0.1f || cInput.GetAxisRaw("J_Horizontal") <= -0.1f || !(cInput.GetAxisRaw("DPad_Horizontal") > -0.1f))
					{
						if (_0024self__00241262.cursor2 == 0)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursor3 == 0)
							{
								_0024self__00241262.cursor3 = 17;
							}
							else
							{
								_0024self__00241262.cursor3--;
							}
						}
						else if (_0024self__00241262.cursor2 == 1)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursor4 == 0)
							{
								_0024self__00241262.cursor4 = 1;
							}
							else
							{
								_0024self__00241262.cursor4--;
							}
						}
						else if (_0024self__00241262.cursor2 == 2)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursor5 == 0)
							{
								_0024self__00241262.cursor5 = 1;
							}
							else
							{
								_0024self__00241262.cursor5--;
							}
						}
						else if (_0024self__00241262.cursor2 == 3)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursor6 == 0)
							{
								_0024self__00241262.cursor6 = 1;
							}
							else
							{
								_0024self__00241262.cursor6--;
							}
						}
						else if (_0024self__00241262.cursor2 == 4)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursorAC == 0)
							{
								_0024self__00241262.cursorAC = 1;
							}
							else
							{
								_0024self__00241262.cursorAC--;
							}
						}
						goto IL_0c0b;
					}
					goto IL_27e7;
					IL_1763:
					result = (Yield(12, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_0e64:
					if (cInput.GetAxisRaw("Horizontal") >= 0.1f || cInput.GetAxisRaw("J_Horizontal") >= 0.1f || !(cInput.GetAxisRaw("DPad_Horizontal") < 0.1f))
					{
						if (_0024self__00241262.cursor2 == 0)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursor3 == 2)
							{
								_0024self__00241262.cursor3 = 0;
							}
							else
							{
								_0024self__00241262.cursor3++;
							}
						}
						else if (_0024self__00241262.cursor2 == 1)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursor4 == 1)
							{
								_0024self__00241262.cursor4 = 0;
							}
							else
							{
								_0024self__00241262.cursor4++;
							}
						}
						else if (_0024self__00241262.cursor2 == 2)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursor5 == 4)
							{
								_0024self__00241262.cursor5 = 0;
							}
							else
							{
								_0024self__00241262.cursor5++;
							}
						}
						else if (_0024self__00241262.cursor2 == 3)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursor6 == 3)
							{
								_0024self__00241262.cursor6 = 0;
							}
							else
							{
								_0024self__00241262.cursor6++;
							}
						}
						else if (_0024self__00241262.cursor2 == 4)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursor7 == 1)
							{
								_0024self__00241262.cursor7 = 0;
							}
							else
							{
								_0024self__00241262.cursor7++;
							}
						}
						else if (_0024self__00241262.cursor2 == 6)
						{
							if (_0024self__00241262.cursorSE != null)
							{
								_0024self__00241262.audio.PlayOneShot(_0024self__00241262.cursorSE, 0.4f);
							}
							if (_0024self__00241262.cursorAC == 1)
							{
								_0024self__00241262.cursorAC = 0;
							}
							else
							{
								_0024self__00241262.cursorAC++;
							}
						}
						goto IL_11c3;
					}
					goto IL_1212;
					IL_11c3:
					result = (Yield(10, new WaitForEndOfFrame()) ? 1 : 0);
					break;
					IL_0e15:
					result = (Yield(9, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				}
				return (byte)result != 0;
			}
		}

		internal OptionsMenu _0024self__00241263;

		public _0024Cursor_00241261(OptionsMenu self_)
		{
			_0024self__00241263 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024self__00241263);
		}
	}

	public Texture2D backGroundTex;

	public Texture2D systemTexTrue;

	public Texture2D systemTexFalse;

	public Texture2D graphicsTexTrue;

	public Texture2D graphicsTexFalse;

	public Texture2D keyTexTrue;

	public Texture2D keyTexFalse;

	public Texture2D padTexTrue;

	public Texture2D padTexFalse;

	public Texture2D padTexDisable;

	public Texture2D backTexTrue;

	public Texture2D backTexFalse;

	public Texture2D activeTex;

	public Texture2D rightTexTrue;

	public Texture2D rightTexFalse;

	public Texture2D leftTexTrue;

	public Texture2D leftTexFalse;

	public Texture2D applyTexTrueJap;

	public Texture2D applyTexFalseJap;

	public Texture2D applyTexTrueEng;

	public Texture2D applyTexFalseEng;

	public Texture2D backTexTrueJap;

	public Texture2D backTexFalseJap;

	public Texture2D backTexTrueEng;

	public Texture2D backTexFalseEng;

	public Texture2D defaultsTexTrueJap;

	public Texture2D defaultsTexFalseJap;

	public Texture2D defaultsTexTrueEng;

	public Texture2D defaultsTexFalseEng;

	public Texture2D keyLineTex;

	public Texture2D scrollBarTex;

	public Texture2D scrollUpTexTrue;

	public Texture2D scrollUpTexFalse;

	public Texture2D scrollDownTexTrue;

	public Texture2D scrollDownTexFalse;

	public Texture2D sensitivitySliderTex;

	public Texture2D sensitivityBarTex;

	public string[] explainPassageJap;

	public string[] explainPassageEng;

	public string[] entryPassageJap;

	public string[] entryPassageEng;

	public string[] booleanPassageJap;

	public string[] booleanPassageEng;

	public string[] systemScreenPassage;

	public string[] systemDisplayPassageJap;

	public string[] systemDisplayPassageEng;

	public string[] systemLanguagePassage;

	public string[] graphicsTexturePassageJap;

	public string[] graphicsTexturePassageEng;

	public string[] graphicsShadowPassageJap;

	public string[] graphicsShadowPassageEng;

	public string[] graphicsAaPassageJap;

	public string[] graphicsAaPassageEng;

	public string[] gamepadAxisPassageJap;

	public string[] gamepadAxisPassageEng;

	private string entryPassageMapJap;

	private string entryPassageMapEng;

	private string entryPassageActionJap;

	private string entryPassageActionEng;

	private string entryPassageCancelJap;

	private string entryPassageCancelEng;

	private string entryPassageWalkJap;

	private string entryPassageWalkEng;

	private string[] systemWalkPassageJap;

	private string[] systemWalkPassageEng;

	private string explainPassageWalkJap;

	private string explainPassageWalkEng;

	private string explainPassageGamepadJap;

	private string explainPassageGamepadEng;

	public AudioClip cursorSE;

	public AudioClip decideSE;

	public bool nowOptioning;

	public GUISkin skin;

	[NonSerialized]
	public static int guiDepth = -8;

	private Player_Status status;

	private int cursor1;

	private int cursor2;

	private int cursor3;

	private int cursor4;

	private int cursor5;

	private int cursor6;

	private int cursor7;

	private int cursorRL;

	private int cursorAC;

	private int screenId;

	private int mouseX;

	private int mouseY;

	private string[] key;

	private bool nowKeyChanging;

	private bool forGamepadSlider;

	public OptionsMenu()
	{
		entryPassageMapJap = "地図を開く";
		entryPassageMapEng = "Open Map";
		entryPassageActionJap = "調べる/決定";
		entryPassageActionEng = "Inspect/Action";
		entryPassageCancelJap = "移動モード変更/取り消し";
		entryPassageCancelEng = "Movement style/Cancel";
		entryPassageWalkJap = "移動モード";
		entryPassageWalkEng = "Movement Style";
		systemWalkPassageJap = new string[2] { "歩く", "走る" };
		systemWalkPassageEng = new string[2] { "Walk", "Run" };
		explainPassageWalkJap = "デフォルトの移動モードを変更します";
		explainPassageWalkEng = "Set default movement style";
		explainPassageGamepadJap = "ゲームパッドの設定を行います";
		explainPassageGamepadEng = "Configure gamepad settings";
		key = new string[20];
	}

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
	}

	public virtual void Update()
	{
		if (!nowOptioning || nowKeyChanging)
		{
			return;
		}
		if ((cInput.GetAxis("Mouse X") != 0f || cInput.GetAxis("Mouse Y") != 0f) && !Screen.showCursor)
		{
			Screen.lockCursor = false;
			Screen.showCursor = true;
		}
		if (screenId == 0)
		{
			if (cursor1 == 3 && (Input.GetJoystickNames().Length == 0 || (Input.GetJoystickNames().Length != 0 && Input.GetJoystickNames()[0] == string.Empty)))
			{
				cursor1 = 0;
				return;
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 41)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 41 + 82)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 100 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 100 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor1 != 0)
				{
					cursor1 = 0;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor1 == 0)
				{
					StartSystem();
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 55)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 55 + 110)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 60 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 60 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor1 != 1)
				{
					cursor1 = 1;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor1 == 1)
				{
					StartGraphics();
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 95)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 95 + 190)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 20 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor1 != 2)
				{
					cursor1 = 2;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor1 == 2)
				{
					StartKeyboard();
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			if (Input.GetJoystickNames().Length != 0 && Input.GetJoystickNames()[0] != string.Empty && !(Input.mousePosition.x < (float)(Screen.width / 2 - 48)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 48 + 96)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor1 != 3)
				{
					cursor1 = 3;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor1 == 3)
				{
					StartGamepad();
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 30)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 30 + 60)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 100 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 100 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor1 != 4)
				{
					cursor1 = 4;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor1 == 4)
				{
					StartCoroutine_Auto(EndOption());
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			if (SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Action") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Action"))
			{
				if (cursor1 == 0)
				{
					StartSystem();
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
				else if (cursor1 == 1)
				{
					StartGraphics();
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
				else if (cursor1 == 2)
				{
					StartKeyboard();
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
				else if (cursor1 == 3)
				{
					StartGamepad();
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
				else if (cursor1 == 4)
				{
					Input.ResetInputAxes();
					StartCoroutine_Auto(EndOption());
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
		}
		else if (screenId == 1)
		{
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 110)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 110 + 220)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 140 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 140 - 26 + 13)) && ((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor2 != 0)
			{
				cursor2 = 0;
				if (cursorSE != null)
				{
					audio.PlayOneShot(cursorSE, 0.4f);
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 110)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 110 + 220)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 100 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 100 - 26 + 13)) && ((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor2 != 1)
			{
				cursor2 = 1;
				if (cursorSE != null)
				{
					audio.PlayOneShot(cursorSE, 0.4f);
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 110)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 110 + 220)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 20 - 26 + 13)) && ((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor2 != 2)
			{
				cursor2 = 2;
				if (cursorSE != null)
				{
					audio.PlayOneShot(cursorSE, 0.4f);
				}
			}
			if (!status.japaneseOnly && !(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 110)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 110 + 220)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 60 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 60 - 26 + 13)) && ((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor2 != 3)
			{
				cursor2 = 3;
				if (cursorSE != null)
				{
					audio.PlayOneShot(cursorSE, 0.4f);
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 40 - 80)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 40)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 140 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 140 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && (cursorAC != 0 || cursor2 != 4))
				{
					cursor2 = 4;
					cursorAC = 0;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor2 == 4 && cursorAC == 0)
				{
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
					ApplySettings(screenId);
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 40 + 80)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 40 + 160)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 140 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 140 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && (cursorAC != 1 || cursor2 != 4))
				{
					cursor2 = 4;
					cursorAC = 1;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor2 == 4 && cursorAC == 1)
				{
					ReturnOptions();
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 80 + 200 - 16 - 120)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 80 + 200 - 16 - 120 + 32)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 140 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 140 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursorRL != 1)
				{
					cursor2 = 0;
					cursorRL = 1;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursorRL == 1)
				{
					if (cursor3 == 0)
					{
						cursor3 = 17;
					}
					else
					{
						cursor3--;
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 80 + 200 - 16 + 120)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 80 + 200 - 16 + 120 + 32)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 140 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 140 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursorRL != 2)
				{
					cursor2 = 0;
					cursorRL = 2;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursorRL == 2)
				{
					if (cursor3 == 17 || cursor3 == 18)
					{
						cursor3 = 0;
					}
					else
					{
						cursor3++;
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 80 + 200 - 16 - 120)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 80 + 200 - 16 - 120 + 32)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 100 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 100 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursorRL != 3)
				{
					cursor2 = 1;
					cursorRL = 3;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursorRL == 3)
				{
					if (cursor4 == 0)
					{
						cursor4 = 1;
					}
					else
					{
						cursor4--;
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 80 + 200 - 16 + 120)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 80 + 200 - 16 + 120 + 32)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 100 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 100 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursorRL != 4)
				{
					cursor2 = 1;
					cursorRL = 4;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursorRL == 4)
				{
					if (cursor4 == 1)
					{
						cursor4 = 0;
					}
					else
					{
						cursor4++;
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 80 + 200 - 16 - 120)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 80 + 200 - 16 - 120 + 32)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 20 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursorRL != 5)
				{
					cursor2 = 2;
					cursorRL = 5;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursorRL == 5)
				{
					if (cursor5 == 0)
					{
						cursor5 = 1;
					}
					else
					{
						cursor5--;
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 80 + 200 - 16 + 120)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 80 + 200 - 16 + 120 + 32)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 20 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursorRL != 6)
				{
					cursor2 = 2;
					cursorRL = 6;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursorRL == 6)
				{
					if (cursor5 == 1)
					{
						cursor5 = 0;
					}
					else
					{
						cursor5++;
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 80 + 200 - 16 - 120)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 80 + 200 - 16 - 120 + 32)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 60 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 60 - 26 + 13)))
			{
				if (!status.japaneseOnly)
				{
					if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursorRL != 7)
					{
						cursor2 = 3;
						cursorRL = 7;
						if (cursorSE != null)
						{
							audio.PlayOneShot(cursorSE, 0.4f);
						}
					}
					if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursorRL == 7)
					{
						if (cursor6 == 0)
						{
							cursor6 = 1;
						}
						else
						{
							cursor6--;
						}
						if (decideSE != null)
						{
							audio.PlayOneShot(decideSE, 0.6f);
						}
					}
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 80 + 200 - 16 + 120)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 80 + 200 - 16 + 120 + 32)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 60 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 60 - 26 + 13)))
			{
				if (!status.japaneseOnly)
				{
					if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursorRL != 8)
					{
						cursor2 = 3;
						cursorRL = 8;
						if (cursorSE != null)
						{
							audio.PlayOneShot(cursorSE, 0.4f);
						}
					}
					if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursorRL == 8)
					{
						if (cursor6 == 1)
						{
							cursor6 = 0;
						}
						else
						{
							cursor6++;
						}
						if (decideSE != null)
						{
							audio.PlayOneShot(decideSE, 0.6f);
						}
					}
				}
			}
			else
			{
				cursorRL = 0;
			}
			if (SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Action") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Action"))
			{
				if (cursor2 == 4 && cursorAC == 0)
				{
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
					ApplySettings(screenId);
				}
				else if (cursor2 == 4 && cursorAC == 1)
				{
					Input.ResetInputAxes();
					ReturnOptions();
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
		}
		else if (screenId == 2)
		{
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 110)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 110 + 220)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 140 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 140 - 26 + 13)) && ((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor2 != 0)
			{
				cursor2 = 0;
				if (cursorSE != null)
				{
					audio.PlayOneShot(cursorSE, 0.4f);
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 110)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 110 + 220)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 100 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 100 - 26 + 13)) && ((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor2 != 1)
			{
				cursor2 = 1;
				if (cursorSE != null)
				{
					audio.PlayOneShot(cursorSE, 0.4f);
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 110)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 110 + 220)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 60 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 60 - 26 + 13)) && ((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor2 != 2)
			{
				cursor2 = 2;
				if (cursorSE != null)
				{
					audio.PlayOneShot(cursorSE, 0.4f);
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 110)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 110 + 220)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 20 - 26 + 13)) && ((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor2 != 3)
			{
				cursor2 = 3;
				if (cursorSE != null)
				{
					audio.PlayOneShot(cursorSE, 0.4f);
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 110)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 110 + 220)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 - 26 + 13)) && ((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor2 != 4)
			{
				cursor2 = 4;
				if (cursorSE != null)
				{
					audio.PlayOneShot(cursorSE, 0.4f);
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 62)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 62 + 124)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 100 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 100 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor2 != 5)
				{
					cursor2 = 5;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor2 == 5)
				{
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
					SetDefaults(screenId);
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 40 - 80)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 40)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 140 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 140 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && (cursorAC != 0 || cursor2 != 6))
				{
					cursor2 = 6;
					cursorAC = 0;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor2 == 6 && cursorAC == 0)
				{
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
					ApplySettings(screenId);
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 40 + 80)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 40 + 160)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 140 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 140 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && (cursorAC != 1 || cursor2 != 6))
				{
					cursor2 = 6;
					cursorAC = 1;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor2 == 6 && cursorAC == 1)
				{
					ReturnOptions();
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 80 + 200 - 16 - 120)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 80 + 200 - 16 - 120 + 32)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 140 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 140 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursorRL != 1)
				{
					cursor2 = 0;
					cursorRL = 1;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursorRL == 1)
				{
					if (cursor3 == 0)
					{
						cursor3 = 2;
					}
					else
					{
						cursor3--;
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 80 + 200 - 16 + 120)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 80 + 200 - 16 + 120 + 32)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 140 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 140 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursorRL != 2)
				{
					cursor2 = 0;
					cursorRL = 2;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursorRL == 2)
				{
					if (cursor3 == 2)
					{
						cursor3 = 0;
					}
					else
					{
						cursor3++;
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 80 + 200 - 16 - 120)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 80 + 200 - 16 - 120 + 32)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 100 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 100 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursorRL != 3)
				{
					cursor2 = 1;
					cursorRL = 3;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursorRL == 3)
				{
					if (cursor4 == 0)
					{
						cursor4 = 1;
					}
					else
					{
						cursor4--;
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 80 + 200 - 16 + 120)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 80 + 200 - 16 + 120 + 32)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 100 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 100 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursorRL != 4)
				{
					cursor2 = 1;
					cursorRL = 4;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursorRL == 4)
				{
					if (cursor4 == 1)
					{
						cursor4 = 0;
					}
					else
					{
						cursor4++;
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 80 + 200 - 16 - 120)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 80 + 200 - 16 - 120 + 32)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 60 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 60 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursorRL != 5)
				{
					cursor2 = 2;
					cursorRL = 5;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursorRL == 5)
				{
					if (cursor5 == 0)
					{
						cursor5 = 4;
					}
					else
					{
						cursor5--;
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 80 + 200 - 16 + 120)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 80 + 200 - 16 + 120 + 32)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 60 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 60 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursorRL != 6)
				{
					cursor2 = 2;
					cursorRL = 6;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursorRL == 6)
				{
					if (cursor5 == 4)
					{
						cursor5 = 0;
					}
					else
					{
						cursor5++;
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 80 + 200 - 16 - 120)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 80 + 200 - 16 - 120 + 32)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 20 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursorRL != 7)
				{
					cursor2 = 3;
					cursorRL = 7;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursorRL == 7)
				{
					if (cursor6 == 0)
					{
						cursor6 = 3;
					}
					else
					{
						cursor6--;
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 80 + 200 - 16 + 120)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 80 + 200 - 16 + 120 + 32)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 20 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursorRL != 8)
				{
					cursor2 = 3;
					cursorRL = 8;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursorRL == 8)
				{
					if (cursor6 == 3)
					{
						cursor6 = 0;
					}
					else
					{
						cursor6++;
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 80 + 200 - 16 - 120)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 80 + 200 - 16 - 120 + 32)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursorRL != 9)
				{
					cursor2 = 4;
					cursorRL = 9;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursorRL == 9)
				{
					if (cursor7 == 0)
					{
						cursor7 = 1;
					}
					else
					{
						cursor7--;
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 80 + 200 - 16 + 120)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 80 + 200 - 16 + 120 + 32)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursorRL != 10)
				{
					cursor2 = 4;
					cursorRL = 10;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursorRL == 10)
				{
					if (cursor7 == 1)
					{
						cursor7 = 0;
					}
					else
					{
						cursor7++;
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			else
			{
				cursorRL = 0;
			}
			if (SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Action") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Action"))
			{
				if (cursor2 == 5)
				{
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
					SetDefaults(screenId);
				}
				else if (cursor2 == 6 && cursorAC == 0)
				{
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
					ApplySettings(screenId);
				}
				else if (cursor2 == 6 && cursorAC == 1)
				{
					ReturnOptions();
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
		}
		else if (screenId == 3)
		{
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 115 - 70 - 55)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 115 - 70 - 55 + 120)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 140 + 15)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 140 + 15 - 35)))
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
					if (cursor3 == 0)
					{
						StartCoroutine_Auto(ChangeKey("Up", 1, true, false, true));
					}
					else if (cursor3 == 1)
					{
						StartCoroutine_Auto(ChangeKey("Down", 1, true, false, true));
					}
					else if (cursor3 == 2)
					{
						StartCoroutine_Auto(ChangeKey("Left", 1, true, false, true));
					}
					else if (cursor3 == 3)
					{
						StartCoroutine_Auto(ChangeKey("Right", 1, true, false, true));
					}
					else if (cursor3 == 4)
					{
						StartCoroutine_Auto(ChangeKey("Action", 1, true, false, true));
					}
					else if (cursor3 == 5)
					{
						StartCoroutine_Auto(ChangeKey("Sprint", 1, true, false, true));
					}
					else if (cursor3 == 6)
					{
						StartCoroutine_Auto(ChangeKey("Camera Reset", 1, true, false, true));
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 115 - 70 + 75)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 115 - 70 + 75 + 120)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 140 + 15)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 140 + 15 - 35)))
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
					if (cursor3 == 0)
					{
						StartCoroutine_Auto(ChangeKey("Up", 2, true, false, true));
					}
					else if (cursor3 == 1)
					{
						StartCoroutine_Auto(ChangeKey("Down", 2, true, false, true));
					}
					else if (cursor3 == 2)
					{
						StartCoroutine_Auto(ChangeKey("Left", 2, true, false, true));
					}
					else if (cursor3 == 3)
					{
						StartCoroutine_Auto(ChangeKey("Right", 2, true, false, true));
					}
					else if (cursor3 == 4)
					{
						StartCoroutine_Auto(ChangeKey("Action", 2, true, false, true));
					}
					else if (cursor3 == 5)
					{
						StartCoroutine_Auto(ChangeKey("Sprint", 2, true, false, true));
					}
					else if (cursor3 == 6)
					{
						StartCoroutine_Auto(ChangeKey("Camera Reset", 2, true, false, true));
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 115 - 70 - 55)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 115 - 70 - 55 + 120)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 100 + 15)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 100 + 15 - 35)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor2 != 2)
				{
					cursor2 = 2;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor2 == 2)
				{
					if (cursor3 == 0)
					{
						StartCoroutine_Auto(ChangeKey("Down", 1, true, false, true));
					}
					else if (cursor3 == 1)
					{
						StartCoroutine_Auto(ChangeKey("Left", 1, true, false, true));
					}
					else if (cursor3 == 2)
					{
						StartCoroutine_Auto(ChangeKey("Right", 1, true, false, true));
					}
					else if (cursor3 == 3)
					{
						StartCoroutine_Auto(ChangeKey("Action", 1, true, false, true));
					}
					else if (cursor3 == 4)
					{
						StartCoroutine_Auto(ChangeKey("Sprint", 1, true, false, true));
					}
					else if (cursor3 == 5)
					{
						StartCoroutine_Auto(ChangeKey("Camera Reset", 1, true, false, true));
					}
					else if (cursor3 == 6)
					{
						StartCoroutine_Auto(ChangeKey("Menu", 1, true, false, true));
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 115 - 70 + 75)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 115 - 70 + 75 + 120)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 100 + 15)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 100 + 15 - 35)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor2 != 3)
				{
					cursor2 = 3;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor2 == 3)
				{
					if (cursor3 == 0)
					{
						StartCoroutine_Auto(ChangeKey("Down", 2, true, false, true));
					}
					else if (cursor3 == 1)
					{
						StartCoroutine_Auto(ChangeKey("Left", 2, true, false, true));
					}
					else if (cursor3 == 2)
					{
						StartCoroutine_Auto(ChangeKey("Right", 2, true, false, true));
					}
					else if (cursor3 == 3)
					{
						StartCoroutine_Auto(ChangeKey("Action", 2, true, false, true));
					}
					else if (cursor3 == 4)
					{
						StartCoroutine_Auto(ChangeKey("Sprint", 2, true, false, true));
					}
					else if (cursor3 == 5)
					{
						StartCoroutine_Auto(ChangeKey("Camera Reset", 2, true, false, true));
					}
					else if (cursor3 == 6)
					{
						StartCoroutine_Auto(ChangeKey("Menu", 2, true, false, true));
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 115 - 70 - 55)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 115 - 70 - 55 + 120)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 60 + 15)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 60 + 15 - 35)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor2 != 4)
				{
					cursor2 = 4;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor2 == 4)
				{
					if (cursor3 == 0)
					{
						StartCoroutine_Auto(ChangeKey("Left", 1, true, false, true));
					}
					else if (cursor3 == 1)
					{
						StartCoroutine_Auto(ChangeKey("Right", 1, true, false, true));
					}
					else if (cursor3 == 2)
					{
						StartCoroutine_Auto(ChangeKey("Action", 1, true, false, true));
					}
					else if (cursor3 == 3)
					{
						StartCoroutine_Auto(ChangeKey("Sprint", 1, true, false, true));
					}
					else if (cursor3 == 4)
					{
						StartCoroutine_Auto(ChangeKey("Camera Reset", 1, true, false, true));
					}
					else if (cursor3 == 5)
					{
						StartCoroutine_Auto(ChangeKey("Menu", 1, true, false, true));
					}
					else if (cursor3 == 6)
					{
						StartCoroutine_Auto(ChangeKey("Pause", 1, true, false, true));
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 115 - 70 + 75)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 115 - 70 + 75 + 120)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 60 + 15)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 60 + 15 - 35)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor2 != 5)
				{
					cursor2 = 5;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor2 == 5)
				{
					if (cursor3 == 0)
					{
						StartCoroutine_Auto(ChangeKey("Left", 2, true, false, true));
					}
					else if (cursor3 == 1)
					{
						StartCoroutine_Auto(ChangeKey("Right", 2, true, false, true));
					}
					else if (cursor3 == 2)
					{
						StartCoroutine_Auto(ChangeKey("Action", 2, true, false, true));
					}
					else if (cursor3 == 3)
					{
						StartCoroutine_Auto(ChangeKey("Sprint", 2, true, false, true));
					}
					else if (cursor3 == 4)
					{
						StartCoroutine_Auto(ChangeKey("Camera Reset", 2, true, false, true));
					}
					else if (cursor3 == 5)
					{
						StartCoroutine_Auto(ChangeKey("Menu", 2, true, false, true));
					}
					else if (cursor3 == 6)
					{
						StartCoroutine_Auto(ChangeKey("Pause", 2, true, false, true));
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 115 - 70 - 55)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 115 - 70 - 55 + 120)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 20 + 15)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 20 + 15 - 35)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor2 != 6)
				{
					cursor2 = 6;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor2 == 6)
				{
					if (cursor3 == 0)
					{
						StartCoroutine_Auto(ChangeKey("Right", 1, true, false, true));
					}
					else if (cursor3 == 1)
					{
						StartCoroutine_Auto(ChangeKey("Action", 1, true, false, true));
					}
					else if (cursor3 == 2)
					{
						StartCoroutine_Auto(ChangeKey("Sprint", 1, true, false, true));
					}
					else if (cursor3 == 3)
					{
						StartCoroutine_Auto(ChangeKey("Camera Reset", 1, true, false, true));
					}
					else if (cursor3 == 4)
					{
						StartCoroutine_Auto(ChangeKey("Menu", 1, true, false, true));
					}
					else if (cursor3 == 5)
					{
						StartCoroutine_Auto(ChangeKey("Pause", 1, true, false, true));
					}
					else if (cursor3 == 6)
					{
						StartCoroutine_Auto(ChangeKey("Map", 1, true, false, true));
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 115 - 70 + 75)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 115 - 70 + 75 + 120)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 20 + 15)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 20 + 15 - 35)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor2 != 7)
				{
					cursor2 = 7;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor2 == 7)
				{
					if (cursor3 == 0)
					{
						StartCoroutine_Auto(ChangeKey("Right", 2, true, false, true));
					}
					else if (cursor3 == 1)
					{
						StartCoroutine_Auto(ChangeKey("Action", 2, true, false, true));
					}
					else if (cursor3 == 2)
					{
						StartCoroutine_Auto(ChangeKey("Sprint", 2, true, false, true));
					}
					else if (cursor3 == 3)
					{
						StartCoroutine_Auto(ChangeKey("Camera Reset", 2, true, false, true));
					}
					else if (cursor3 == 4)
					{
						StartCoroutine_Auto(ChangeKey("Menu", 2, true, false, true));
					}
					else if (cursor3 == 5)
					{
						StartCoroutine_Auto(ChangeKey("Pause", 2, true, false, true));
					}
					else if (cursor3 == 6)
					{
						StartCoroutine_Auto(ChangeKey("Map", 2, true, false, true));
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 110)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 110 + 220)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 - 26 + 13)) && ((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor2 != 8)
			{
				cursor2 = 8;
				if (cursorSE != null)
				{
					audio.PlayOneShot(cursorSE, 0.4f);
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 110)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 110 + 220)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 60 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 60 - 26 + 13)) && ((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor2 != 9)
			{
				cursor2 = 9;
				if (cursorSE != null)
				{
					audio.PlayOneShot(cursorSE, 0.4f);
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 62)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 62 + 124)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 100 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 100 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor2 != 10)
				{
					cursor2 = 10;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor2 == 10)
				{
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
					SetDefaults(screenId);
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 40 - 80)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 40)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 140 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 140 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && (cursorAC != 0 || cursor2 != 11))
				{
					cursor2 = 11;
					cursorAC = 0;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor2 == 11 && cursorAC == 0)
				{
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
					ApplySettings(screenId);
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 40 + 80)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 40 + 160)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 140 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 140 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && (cursorAC != 1 || cursor2 != 11))
				{
					cursor2 = 11;
					cursorAC = 1;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor2 == 11 && cursorAC == 1)
				{
					ReturnOptions();
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 320 - 30)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 320 - 30 + 16)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 140 + 8)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 140 + 8 - 16)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursorRL != 1)
				{
					cursorRL = 1;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursorRL == 1)
				{
					if (cursor3 > 0)
					{
						cursor3--;
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 320 - 30)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 320 - 30 + 16)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 20 + 8)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 20 + 8 - 16)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursorRL != 2)
				{
					cursorRL = 2;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursorRL == 2)
				{
					if (cursor3 < 6)
					{
						cursor3++;
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 80 + 200 - 16 - 120)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 80 + 200 - 16 - 120 + 32)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 60 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 60 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursorRL != 3)
				{
					cursor2 = 9;
					cursorRL = 3;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursorRL == 3)
				{
					if (cursor5 == 0)
					{
						cursor5 = 1;
					}
					else
					{
						cursor5--;
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 80 + 200 - 16 + 120)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 80 + 200 - 16 + 120 + 32)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 60 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 60 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursorRL != 4)
				{
					cursor2 = 9;
					cursorRL = 4;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursorRL == 4)
				{
					if (cursor5 == 1)
					{
						cursor5 = 0;
					}
					else
					{
						cursor5++;
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			else
			{
				cursorRL = 0;
			}
			if (!(Input.mousePosition.y > (float)(Screen.height / 2 + 160)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 160 - 160)))
			{
				if (!(Input.GetAxisRaw("Mouse ScrollWheel") < 0.1f) && cursor3 > 0)
				{
					cursor3--;
				}
				if (!(Input.GetAxisRaw("Mouse ScrollWheel") > -0.1f) && cursor3 < 6)
				{
					cursor3++;
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 320 - 30)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 320 - 30 + 16)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 131)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 131 - 22)) && Input.GetMouseButton(0))
			{
				cursor3 = 0;
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 320 - 30)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 320 - 30 + 16)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 108)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 108 - 10)) && Input.GetMouseButton(0))
			{
				cursor3 = 1;
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 320 - 30)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 320 - 30 + 16)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 97)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 97 - 10)) && Input.GetMouseButton(0))
			{
				cursor3 = 2;
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 320 - 30)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 320 - 30 + 16)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 86)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 86 - 10)) && Input.GetMouseButton(0))
			{
				cursor3 = 3;
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 320 - 30)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 320 - 30 + 16)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 75)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 75 - 10)) && Input.GetMouseButton(0))
			{
				cursor3 = 4;
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 320 - 30)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 320 - 30 + 16)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 64)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 64 - 10)) && Input.GetMouseButton(0))
			{
				cursor3 = 5;
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 320 - 30)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 320 - 30 + 16)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 53)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 53 - 24)) && Input.GetMouseButton(0))
			{
				cursor3 = 6;
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 + 1)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 + 1 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
			{
				if (Input.GetMouseButton(0))
				{
					cursor4 = 8;
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 - 12)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 - 12 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
			{
				if (Input.GetMouseButton(0))
				{
					cursor4 = 7;
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 + 13)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 + 13 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
			{
				if (Input.GetMouseButton(0))
				{
					cursor4 = 9;
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 - 25)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 - 25 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
			{
				if (Input.GetMouseButton(0))
				{
					cursor4 = 6;
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 + 26)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 + 26 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
			{
				if (Input.GetMouseButton(0))
				{
					cursor4 = 10;
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 - 37)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 - 37 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
			{
				if (Input.GetMouseButton(0))
				{
					cursor4 = 5;
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 + 39)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 + 39 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
			{
				if (Input.GetMouseButton(0))
				{
					cursor4 = 11;
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 - 50)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 - 50 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
			{
				if (Input.GetMouseButton(0))
				{
					cursor4 = 4;
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 + 52)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 + 52 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
			{
				if (Input.GetMouseButton(0))
				{
					cursor4 = 12;
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 - 63)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 - 63 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
			{
				if (Input.GetMouseButton(0))
				{
					cursor4 = 3;
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 + 64)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 + 64 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
			{
				if (Input.GetMouseButton(0))
				{
					cursor4 = 13;
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 - 76)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 - 76 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
			{
				if (Input.GetMouseButton(0))
				{
					cursor4 = 2;
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 + 77)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 + 77 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
			{
				if (Input.GetMouseButton(0))
				{
					cursor4 = 14;
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 - 88)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 - 88 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
			{
				if (Input.GetMouseButton(0))
				{
					cursor4 = 1;
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 + 88)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 + 88 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
			{
				if (Input.GetMouseButton(0))
				{
					cursor4 = 15;
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 - 100)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 - 100 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
			{
				if (Input.GetMouseButton(0))
				{
					cursor4 = 0;
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 + 100)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 + 100 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)) && Input.GetMouseButton(0))
			{
				cursor4 = 16;
			}
			if (SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Action") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Action"))
			{
				if (cursor2 == 0)
				{
					if (cursor3 == 0)
					{
						StartCoroutine_Auto(ChangeKey("Up", 1, true, false, true));
					}
					else if (cursor3 == 1)
					{
						StartCoroutine_Auto(ChangeKey("Down", 1, true, false, true));
					}
					else if (cursor3 == 2)
					{
						StartCoroutine_Auto(ChangeKey("Left", 1, true, false, true));
					}
					else if (cursor3 == 3)
					{
						StartCoroutine_Auto(ChangeKey("Right", 1, true, false, true));
					}
					else if (cursor3 == 4)
					{
						StartCoroutine_Auto(ChangeKey("Action", 1, true, false, true));
					}
					else if (cursor3 == 5)
					{
						StartCoroutine_Auto(ChangeKey("Sprint", 1, true, false, true));
					}
					else if (cursor3 == 6)
					{
						StartCoroutine_Auto(ChangeKey("Camera Reset", 1, true, false, true));
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
				else if (cursor2 == 1)
				{
					if (cursor3 == 0)
					{
						StartCoroutine_Auto(ChangeKey("Up", 2, true, false, true));
					}
					else if (cursor3 == 1)
					{
						StartCoroutine_Auto(ChangeKey("Down", 2, true, false, true));
					}
					else if (cursor3 == 2)
					{
						StartCoroutine_Auto(ChangeKey("Left", 2, true, false, true));
					}
					else if (cursor3 == 3)
					{
						StartCoroutine_Auto(ChangeKey("Right", 2, true, false, true));
					}
					else if (cursor3 == 4)
					{
						StartCoroutine_Auto(ChangeKey("Action", 2, true, false, true));
					}
					else if (cursor3 == 5)
					{
						StartCoroutine_Auto(ChangeKey("Sprint", 2, true, false, true));
					}
					else if (cursor3 == 6)
					{
						StartCoroutine_Auto(ChangeKey("Camera Reset", 2, true, false, true));
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
				else if (cursor2 == 2)
				{
					if (cursor3 == 0)
					{
						StartCoroutine_Auto(ChangeKey("Down", 1, true, false, true));
					}
					else if (cursor3 == 1)
					{
						StartCoroutine_Auto(ChangeKey("Left", 1, true, false, true));
					}
					else if (cursor3 == 2)
					{
						StartCoroutine_Auto(ChangeKey("Right", 1, true, false, true));
					}
					else if (cursor3 == 3)
					{
						StartCoroutine_Auto(ChangeKey("Action", 1, true, false, true));
					}
					else if (cursor3 == 4)
					{
						StartCoroutine_Auto(ChangeKey("Sprint", 1, true, false, true));
					}
					else if (cursor3 == 5)
					{
						StartCoroutine_Auto(ChangeKey("Camera Reset", 1, true, false, true));
					}
					else if (cursor3 == 6)
					{
						StartCoroutine_Auto(ChangeKey("Menu", 1, true, false, true));
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
				else if (cursor2 == 3)
				{
					if (cursor3 == 0)
					{
						StartCoroutine_Auto(ChangeKey("Down", 2, true, false, true));
					}
					else if (cursor3 == 1)
					{
						StartCoroutine_Auto(ChangeKey("Left", 2, true, false, true));
					}
					else if (cursor3 == 2)
					{
						StartCoroutine_Auto(ChangeKey("Right", 2, true, false, true));
					}
					else if (cursor3 == 3)
					{
						StartCoroutine_Auto(ChangeKey("Action", 2, true, false, true));
					}
					else if (cursor3 == 4)
					{
						StartCoroutine_Auto(ChangeKey("Sprint", 2, true, false, true));
					}
					else if (cursor3 == 5)
					{
						StartCoroutine_Auto(ChangeKey("Camera Reset", 2, true, false, true));
					}
					else if (cursor3 == 6)
					{
						StartCoroutine_Auto(ChangeKey("Menu", 2, true, false, true));
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
				else if (cursor2 == 4)
				{
					if (cursor3 == 0)
					{
						StartCoroutine_Auto(ChangeKey("Left", 1, true, false, true));
					}
					else if (cursor3 == 1)
					{
						StartCoroutine_Auto(ChangeKey("Right", 1, true, false, true));
					}
					else if (cursor3 == 2)
					{
						StartCoroutine_Auto(ChangeKey("Action", 1, true, false, true));
					}
					else if (cursor3 == 3)
					{
						StartCoroutine_Auto(ChangeKey("Sprint", 1, true, false, true));
					}
					else if (cursor3 == 4)
					{
						StartCoroutine_Auto(ChangeKey("Camera Reset", 1, true, false, true));
					}
					else if (cursor3 == 5)
					{
						StartCoroutine_Auto(ChangeKey("Menu", 1, true, false, true));
					}
					else if (cursor3 == 6)
					{
						StartCoroutine_Auto(ChangeKey("Pause", 1, true, false, true));
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
				else if (cursor2 == 5)
				{
					if (cursor3 == 0)
					{
						StartCoroutine_Auto(ChangeKey("Left", 2, true, false, true));
					}
					else if (cursor3 == 1)
					{
						StartCoroutine_Auto(ChangeKey("Right", 2, true, false, true));
					}
					else if (cursor3 == 2)
					{
						StartCoroutine_Auto(ChangeKey("Action", 2, true, false, true));
					}
					else if (cursor3 == 3)
					{
						StartCoroutine_Auto(ChangeKey("Sprint", 2, true, false, true));
					}
					else if (cursor3 == 4)
					{
						StartCoroutine_Auto(ChangeKey("Camera Reset", 2, true, false, true));
					}
					else if (cursor3 == 5)
					{
						StartCoroutine_Auto(ChangeKey("Menu", 2, true, false, true));
					}
					else if (cursor3 == 6)
					{
						StartCoroutine_Auto(ChangeKey("Pause", 2, true, false, true));
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
				else if (cursor2 == 6)
				{
					if (cursor3 == 0)
					{
						StartCoroutine_Auto(ChangeKey("Right", 1, true, false, true));
					}
					else if (cursor3 == 1)
					{
						StartCoroutine_Auto(ChangeKey("Action", 1, true, false, true));
					}
					else if (cursor3 == 2)
					{
						StartCoroutine_Auto(ChangeKey("Sprint", 1, true, false, true));
					}
					else if (cursor3 == 3)
					{
						StartCoroutine_Auto(ChangeKey("Camera Reset", 1, true, false, true));
					}
					else if (cursor3 == 4)
					{
						StartCoroutine_Auto(ChangeKey("Menu", 1, true, false, true));
					}
					else if (cursor3 == 5)
					{
						StartCoroutine_Auto(ChangeKey("Pause", 1, true, false, true));
					}
					else if (cursor3 == 6)
					{
						StartCoroutine_Auto(ChangeKey("Map", 1, true, false, true));
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
				else if (cursor2 == 7)
				{
					if (cursor3 == 0)
					{
						StartCoroutine_Auto(ChangeKey("Right", 2, true, false, true));
					}
					else if (cursor3 == 1)
					{
						StartCoroutine_Auto(ChangeKey("Action", 2, true, false, true));
					}
					else if (cursor3 == 2)
					{
						StartCoroutine_Auto(ChangeKey("Sprint", 2, true, false, true));
					}
					else if (cursor3 == 3)
					{
						StartCoroutine_Auto(ChangeKey("Camera Reset", 2, true, false, true));
					}
					else if (cursor3 == 4)
					{
						StartCoroutine_Auto(ChangeKey("Menu", 2, true, false, true));
					}
					else if (cursor3 == 5)
					{
						StartCoroutine_Auto(ChangeKey("Pause", 2, true, false, true));
					}
					else if (cursor3 == 6)
					{
						StartCoroutine_Auto(ChangeKey("Map", 2, true, false, true));
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
				else if (cursor2 == 10)
				{
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
					SetDefaults(screenId);
				}
				else if (cursor2 == 11 && cursorAC == 0)
				{
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
					ApplySettings(screenId);
				}
				else if (cursor2 == 11 && cursorAC == 1)
				{
					ReturnOptions();
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
		}
		else if (screenId == 4)
		{
			if (Input.GetJoystickNames().Length == 0 || (Input.GetJoystickNames().Length != 0 && Input.GetJoystickNames()[0] == string.Empty))
			{
				ReturnOptions();
				cursor1 = 0;
				return;
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 100 - 70 + 10)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 100 - 70 + 10 + 145)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 140 + 15)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 140 + 15 - 35)))
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
					if (cursor3 == 4)
					{
						StartCoroutine_Auto(ChangeKey("J_Action", 1, false, true, false));
					}
					else if (cursor3 == 5)
					{
						StartCoroutine_Auto(ChangeKey("J_Sprint", 1, false, true, false));
					}
					else if (cursor3 == 6)
					{
						StartCoroutine_Auto(ChangeKey("J_Camera Reset", 1, false, true, false));
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 100 - 70 + 10)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 100 - 70 + 10 + 145)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 100 + 15)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 100 + 15 - 35)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor2 != 2)
				{
					cursor2 = 2;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor2 == 2)
				{
					if (cursor3 == 4)
					{
						StartCoroutine_Auto(ChangeKey("J_Sprint", 1, false, true, false));
					}
					else if (cursor3 == 5)
					{
						StartCoroutine_Auto(ChangeKey("J_Camera Reset", 1, false, true, false));
					}
					else if (cursor3 == 6)
					{
						StartCoroutine_Auto(ChangeKey("J_Menu", 1, false, true, false));
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 100 - 70 + 10)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 100 - 70 + 10 + 145)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 60 + 15)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 60 + 15 - 35)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor2 != 4)
				{
					cursor2 = 4;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor2 == 4)
				{
					if (cursor3 == 4)
					{
						StartCoroutine_Auto(ChangeKey("J_Camera Reset", 1, false, true, false));
					}
					else if (cursor3 == 5)
					{
						StartCoroutine_Auto(ChangeKey("J_Menu", 1, false, true, false));
					}
					else if (cursor3 == 6)
					{
						StartCoroutine_Auto(ChangeKey("J_Pause", 1, false, true, false));
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 100 - 70 + 10)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 100 - 70 + 10 + 145)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 20 + 15)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 20 + 15 - 35)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor2 != 6)
				{
					cursor2 = 6;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor2 == 6)
				{
					if (cursor3 == 4)
					{
						StartCoroutine_Auto(ChangeKey("J_Menu", 1, false, true, false));
					}
					else if (cursor3 == 5)
					{
						StartCoroutine_Auto(ChangeKey("J_Pause", 1, false, true, false));
					}
					else if (cursor3 == 6)
					{
						StartCoroutine_Auto(ChangeKey("J_Map", 1, false, true, false));
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 110)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 110 + 220)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 - 26 + 13)) && ((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor2 != 8)
			{
				cursor2 = 8;
				if (cursorSE != null)
				{
					audio.PlayOneShot(cursorSE, 0.4f);
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 110)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 110 + 220)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 60 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 60 - 26 + 13)) && ((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor2 != 9)
			{
				cursor2 = 9;
				if (cursorSE != null)
				{
					audio.PlayOneShot(cursorSE, 0.4f);
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 62)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 62 + 124)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 100 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 100 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursor2 != 10)
				{
					cursor2 = 10;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor2 == 10)
				{
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
					SetDefaults(screenId);
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 40 - 80)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 40)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 140 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 140 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && (cursorAC != 0 || cursor2 != 11))
				{
					cursor2 = 11;
					cursorAC = 0;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor2 == 11 && cursorAC == 0)
				{
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
					ApplySettings(screenId);
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 40 + 80)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 40 + 160)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 140 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 140 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && (cursorAC != 1 || cursor2 != 11))
				{
					cursor2 = 11;
					cursorAC = 1;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursor2 == 11 && cursorAC == 1)
				{
					ReturnOptions();
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 320 - 30)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 320 - 30 + 16)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 140 + 8)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 140 + 8 - 16)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursorRL != 1)
				{
					cursorRL = 1;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursorRL == 1)
				{
					cursor3--;
					if (cursor3 < 4)
					{
						cursor3 = 4;
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 320 - 30)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 320 - 30 + 16)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 20 + 8)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 20 + 8 - 16)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursorRL != 2)
				{
					cursorRL = 2;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursorRL == 2)
				{
					cursor3++;
					if (cursor3 > 6)
					{
						cursor3 = 6;
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 80 + 200 - 16 - 120)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 80 + 200 - 16 - 120 + 32)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 60 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 60 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursorRL != 3)
				{
					cursor2 = 9;
					cursorRL = 3;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursorRL == 3)
				{
					if (cursor5 == 0)
					{
						cursor5 = 3;
					}
					else
					{
						cursor5--;
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			else if (!(Input.mousePosition.x < (float)(Screen.width / 2 - 80 + 200 - 16 + 120)) && !(Input.mousePosition.x > (float)(Screen.width / 2 - 80 + 200 - 16 + 120 + 32)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 60 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 60 - 26 + 13)))
			{
				if (((float)mouseX != Input.mousePosition.x || (float)mouseY != Input.mousePosition.y) && cursorRL != 4)
				{
					cursor2 = 9;
					cursorRL = 4;
					if (cursorSE != null)
					{
						audio.PlayOneShot(cursorSE, 0.4f);
					}
				}
				if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(0) && cursorRL == 4)
				{
					if (cursor5 == 3)
					{
						cursor5 = 0;
					}
					else
					{
						cursor5++;
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			else
			{
				cursorRL = 0;
			}
			if (!(Input.mousePosition.y > (float)(Screen.height / 2 + 160)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 160 - 160)))
			{
				if (!(Input.GetAxisRaw("Mouse ScrollWheel") < 0.1f))
				{
					cursor3--;
					if (cursor3 < 4)
					{
						cursor3 = 4;
					}
				}
				if (!(Input.GetAxisRaw("Mouse ScrollWheel") > -0.1f))
				{
					cursor3++;
					if (cursor3 > 6)
					{
						cursor3 = 6;
					}
				}
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 320 - 30)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 320 - 30 + 16)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 131)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 131 - 41)) && Input.GetMouseButton(0))
			{
				cursor3 = 4;
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 320 - 30)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 320 - 30 + 16)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 104)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 104 - 20)) && Input.GetMouseButton(0))
			{
				cursor3 = 5;
			}
			if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 320 - 30)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 320 - 30 + 16)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 77)) && !(Input.mousePosition.y < (float)(Screen.height / 2 + 77 - 41)) && Input.GetMouseButton(0))
			{
				cursor3 = 6;
			}
			if (forGamepadSlider)
			{
				if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 + 1)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 + 1 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
				{
					if (Input.GetMouseButton(0))
					{
						cursor4 = 8;
					}
				}
				else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 - 12)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 - 12 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
				{
					if (Input.GetMouseButton(0))
					{
						cursor4 = 7;
					}
				}
				else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 + 13)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 + 13 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
				{
					if (Input.GetMouseButton(0))
					{
						cursor4 = 9;
					}
				}
				else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 - 25)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 - 25 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
				{
					if (Input.GetMouseButton(0))
					{
						cursor4 = 6;
					}
				}
				else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 + 26)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 + 26 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
				{
					if (Input.GetMouseButton(0))
					{
						cursor4 = 10;
					}
				}
				else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 - 37)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 - 37 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
				{
					if (Input.GetMouseButton(0))
					{
						cursor4 = 5;
					}
				}
				else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 + 39)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 + 39 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
				{
					if (Input.GetMouseButton(0))
					{
						cursor4 = 11;
					}
				}
				else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 - 50)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 - 50 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
				{
					if (Input.GetMouseButton(0))
					{
						cursor4 = 4;
					}
				}
				else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 + 52)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 + 52 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
				{
					if (Input.GetMouseButton(0))
					{
						cursor4 = 12;
					}
				}
				else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 - 63)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 - 63 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
				{
					if (Input.GetMouseButton(0))
					{
						cursor4 = 3;
					}
				}
				else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 + 64)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 + 64 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
				{
					if (Input.GetMouseButton(0))
					{
						cursor4 = 13;
					}
				}
				else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 - 76)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 - 76 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
				{
					if (Input.GetMouseButton(0))
					{
						cursor4 = 2;
					}
				}
				else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 + 77)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 + 77 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
				{
					if (Input.GetMouseButton(0))
					{
						cursor4 = 14;
					}
				}
				else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 - 88)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 - 88 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
				{
					if (Input.GetMouseButton(0))
					{
						cursor4 = 1;
					}
				}
				else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 + 88)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 + 88 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
				{
					if (Input.GetMouseButton(0))
					{
						cursor4 = 15;
					}
				}
				else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 - 100)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 - 100 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)))
				{
					if (Input.GetMouseButton(0))
					{
						cursor4 = 0;
					}
				}
				else if (!(Input.mousePosition.x < (float)(Screen.width / 2 + 120 - 9 + 100)) && !(Input.mousePosition.x > (float)(Screen.width / 2 + 120 - 9 + 100 + 18)) && !(Input.mousePosition.y > (float)(Screen.height / 2 - 20 + 13)) && !(Input.mousePosition.y < (float)(Screen.height / 2 - 20 + 13 - 29)) && Input.GetMouseButton(0))
				{
					cursor4 = 16;
				}
			}
			if (SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Action") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Action"))
			{
				if (cursor2 == 0)
				{
					if (cursor3 == 4)
					{
						StartCoroutine_Auto(ChangeKey("J_Action", 1, false, true, false));
					}
					else if (cursor3 == 5)
					{
						StartCoroutine_Auto(ChangeKey("J_Sprint", 1, false, true, false));
					}
					else if (cursor3 == 6)
					{
						StartCoroutine_Auto(ChangeKey("J_Camera Reset", 1, false, true, false));
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
				else if (cursor2 == 2)
				{
					if (cursor3 == 4)
					{
						StartCoroutine_Auto(ChangeKey("J_Sprint", 1, false, true, false));
					}
					else if (cursor3 == 5)
					{
						StartCoroutine_Auto(ChangeKey("J_Camera Reset", 1, false, true, false));
					}
					else if (cursor3 == 6)
					{
						StartCoroutine_Auto(ChangeKey("J_Menu", 1, false, true, false));
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
				else if (cursor2 == 4)
				{
					if (cursor3 == 4)
					{
						StartCoroutine_Auto(ChangeKey("J_Camera Reset", 1, false, true, false));
					}
					else if (cursor3 == 5)
					{
						StartCoroutine_Auto(ChangeKey("J_Menu", 1, false, true, false));
					}
					else if (cursor3 == 6)
					{
						StartCoroutine_Auto(ChangeKey("J_Pause", 1, false, true, false));
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
				else if (cursor2 == 6)
				{
					if (cursor3 == 4)
					{
						StartCoroutine_Auto(ChangeKey("J_Menu", 1, false, true, false));
					}
					else if (cursor3 == 5)
					{
						StartCoroutine_Auto(ChangeKey("J_Pause", 1, false, true, false));
					}
					else if (cursor3 == 6)
					{
						StartCoroutine_Auto(ChangeKey("J_Map", 1, false, true, false));
					}
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
				else if (cursor2 == 10)
				{
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
					SetDefaults(screenId);
				}
				else if (cursor2 == 11 && cursorAC == 0)
				{
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
					ApplySettings(screenId);
				}
				else if (cursor2 == 11 && cursorAC == 1)
				{
					ReturnOptions();
					if (decideSE != null)
					{
						audio.PlayOneShot(decideSE, 0.6f);
					}
				}
			}
			if (!Input.GetMouseButton(0))
			{
				forGamepadSlider = true;
			}
		}
		if (SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(1) || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Sprint") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Sprint"))
		{
			if (screenId == 0)
			{
				Input.ResetInputAxes();
				StartCoroutine_Auto(EndOption());
			}
			else
			{
				ReturnOptions();
			}
			if (decideSE != null)
			{
				audio.PlayOneShot(decideSE, 0.6f);
			}
		}
		if (SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Pause") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Pause"))
		{
			if (screenId == 0)
			{
				StartCoroutine_Auto(EndOption());
				SendMessage("Resume", SendMessageOptions.DontRequireReceiver);
			}
			else
			{
				ReturnOptions();
				if (decideSE != null)
				{
					audio.PlayOneShot(decideSE, 0.6f);
				}
			}
		}
		mouseX = (int)Input.mousePosition.x;
		mouseY = (int)Input.mousePosition.y;
	}

	public virtual void StartOption()
	{
		mouseX = (int)Input.mousePosition.x;
		mouseY = (int)Input.mousePosition.y;
		StartCoroutine_Auto(WaitKeyUp());
		StartCoroutine_Auto(Cursor());
	}

	public virtual IEnumerator WaitKeyUp()
	{
		return new _0024WaitKeyUp_00241241(this).GetEnumerator();
	}

	public virtual IEnumerator EndOption()
	{
		return new _0024EndOption_00241244(this).GetEnumerator();
	}

	public virtual void StartSystem()
	{
		cursorAC = 0;
		cursor2 = 0;
		if (Screen.width == 640 && Screen.height == 480)
		{
			cursor3 = 0;
		}
		else if (Screen.width == 800 && Screen.height == 600)
		{
			cursor3 = 1;
		}
		else if (Screen.width == 1024 && Screen.height == 768)
		{
			cursor3 = 2;
		}
		else if (Screen.width == 1152 && Screen.height == 864)
		{
			cursor3 = 3;
		}
		else if (Screen.width == 1176 && Screen.height == 664)
		{
			cursor3 = 4;
		}
		else if (Screen.width == 1280 && Screen.height == 720)
		{
			cursor3 = 5;
		}
		else if (Screen.width == 1280 && Screen.height == 800)
		{
			cursor3 = 6;
		}
		else if (Screen.width == 1280 && Screen.height == 960)
		{
			cursor3 = 7;
		}
		else if (Screen.width == 1360 && Screen.height == 765)
		{
			cursor3 = 8;
		}
		else if (Screen.width == 1360 && Screen.height == 768)
		{
			cursor3 = 9;
		}
		else if (Screen.width == 1366 && Screen.height == 768)
		{
			cursor3 = 10;
		}
		else if (Screen.width == 1440 && Screen.height == 810)
		{
			cursor3 = 11;
		}
		else if (Screen.width == 1440 && Screen.height == 900)
		{
			cursor3 = 12;
		}
		else if (Screen.width == 1600 && Screen.height == 900)
		{
			cursor3 = 13;
		}
		else if (Screen.width == 1600 && Screen.height == 1024)
		{
			cursor3 = 14;
		}
		else if (Screen.width == 1680 && Screen.height == 1050)
		{
			cursor3 = 15;
		}
		else if (Screen.width == 1920 && Screen.height == 1080)
		{
			cursor3 = 16;
		}
		else if (Screen.width == 1920 && Screen.height == 1200)
		{
			cursor3 = 17;
		}
		else
		{
			cursor3 = 18;
		}
		if (!Screen.fullScreen)
		{
			cursor4 = 0;
		}
		else
		{
			cursor4 = 1;
		}
		if (status.walkFlag == 0)
		{
			cursor5 = 0;
		}
		else
		{
			cursor5 = 1;
		}
		if (status.language == 0)
		{
			cursor6 = 0;
		}
		else
		{
			cursor6 = 1;
		}
		screenId = 1;
	}

	public virtual void StartGraphics()
	{
		cursorAC = 0;
		cursor2 = 0;
		if (QualitySettings.masterTextureLimit == 2)
		{
			cursor3 = 0;
		}
		else if (QualitySettings.masterTextureLimit == 1)
		{
			cursor3 = 1;
		}
		else if (QualitySettings.masterTextureLimit == 0)
		{
			cursor3 = 2;
		}
		if (QualitySettings.anisotropicFiltering == AnisotropicFiltering.Disable)
		{
			cursor4 = 0;
		}
		else
		{
			cursor4 = 1;
		}
		if (QualitySettings.shadowCascades == 4 && QualitySettings.GetQualityLevel() == 3)
		{
			cursor5 = 4;
		}
		else if (QualitySettings.shadowCascades == 4 && QualitySettings.GetQualityLevel() == 2)
		{
			cursor5 = 3;
		}
		else if (QualitySettings.shadowCascades == 2 && QualitySettings.GetQualityLevel() == 1)
		{
			cursor5 = 2;
		}
		else if (QualitySettings.shadowCascades == 2 && QualitySettings.GetQualityLevel() == 0)
		{
			cursor5 = 1;
		}
		else if (QualitySettings.shadowCascades == 0 && QualitySettings.GetQualityLevel() == 0)
		{
			cursor5 = 0;
		}
		if (QualitySettings.antiAliasing == 0)
		{
			cursor6 = 0;
		}
		else if (QualitySettings.antiAliasing == 2)
		{
			cursor6 = 1;
		}
		else if (QualitySettings.antiAliasing == 4)
		{
			cursor6 = 2;
		}
		else if (QualitySettings.antiAliasing == 8)
		{
			cursor6 = 3;
		}
		if (QualitySettings.vSyncCount == 0)
		{
			cursor7 = 0;
		}
		else
		{
			cursor7 = 1;
		}
		screenId = 2;
	}

	public virtual void StartKeyboard()
	{
		cursorAC = 0;
		cursor2 = 0;
		cursor3 = 0;
		key[0] = cInput.GetText("Up", 1);
		key[1] = cInput.GetText("Up", 2);
		key[2] = cInput.GetText("Down", 1);
		key[3] = cInput.GetText("Down", 2);
		key[4] = cInput.GetText("Left", 1);
		key[5] = cInput.GetText("Left", 2);
		key[6] = cInput.GetText("Right", 1);
		key[7] = cInput.GetText("Right", 2);
		key[8] = cInput.GetText("Action", 1);
		key[9] = cInput.GetText("Action", 2);
		key[10] = cInput.GetText("Sprint", 1);
		key[11] = cInput.GetText("Sprint", 2);
		key[12] = cInput.GetText("Camera Reset", 1);
		key[13] = cInput.GetText("Camera Reset", 2);
		key[14] = cInput.GetText("Menu", 1);
		key[15] = cInput.GetText("Menu", 2);
		key[16] = cInput.GetText("Pause", 1);
		key[17] = cInput.GetText("Pause", 2);
		key[18] = cInput.GetText("Map", 1);
		key[19] = cInput.GetText("Map", 2);
		if (status.mouseSensitivity == 50f)
		{
			cursor4 = 0;
		}
		else if (status.mouseSensitivity == 75f)
		{
			cursor4 = 1;
		}
		else if (status.mouseSensitivity == 100f)
		{
			cursor4 = 2;
		}
		else if (status.mouseSensitivity == 125f)
		{
			cursor4 = 3;
		}
		else if (status.mouseSensitivity == 150f)
		{
			cursor4 = 4;
		}
		else if (status.mouseSensitivity == 175f)
		{
			cursor4 = 5;
		}
		else if (status.mouseSensitivity == 200f)
		{
			cursor4 = 6;
		}
		else if (status.mouseSensitivity == 225f)
		{
			cursor4 = 7;
		}
		else if (status.mouseSensitivity == 250f)
		{
			cursor4 = 8;
		}
		else if (status.mouseSensitivity == 275f)
		{
			cursor4 = 9;
		}
		else if (status.mouseSensitivity == 300f)
		{
			cursor4 = 10;
		}
		else if (status.mouseSensitivity == 325f)
		{
			cursor4 = 11;
		}
		else if (status.mouseSensitivity == 350f)
		{
			cursor4 = 12;
		}
		else if (status.mouseSensitivity == 375f)
		{
			cursor4 = 13;
		}
		else if (status.mouseSensitivity == 400f)
		{
			cursor4 = 14;
		}
		else if (status.mouseSensitivity == 425f)
		{
			cursor4 = 15;
		}
		else
		{
			cursor4 = 16;
		}
		if (status.mouseInverted == 0)
		{
			cursor5 = 0;
		}
		else
		{
			cursor5 = 1;
		}
		screenId = 3;
	}

	public virtual void StartGamepad()
	{
		cursorAC = 0;
		cursor2 = 0;
		cursor3 = 4;
		forGamepadSlider = false;
		key[0] = cInput.GetText("J_Action", 1);
		key[1] = cInput.GetText("J_Sprint", 1);
		key[2] = cInput.GetText("J_Camera Reset", 1);
		key[3] = cInput.GetText("J_Menu", 1);
		key[4] = cInput.GetText("J_Pause", 1);
		key[5] = cInput.GetText("J_Map", 1);
		if (status.stickSensitivity == 20f)
		{
			cursor4 = 0;
		}
		else if (status.stickSensitivity == 40f)
		{
			cursor4 = 1;
		}
		else if (status.stickSensitivity == 60f)
		{
			cursor4 = 2;
		}
		else if (status.stickSensitivity == 80f)
		{
			cursor4 = 3;
		}
		else if (status.stickSensitivity == 100f)
		{
			cursor4 = 4;
		}
		else if (status.stickSensitivity == 120f)
		{
			cursor4 = 5;
		}
		else if (status.stickSensitivity == 140f)
		{
			cursor4 = 6;
		}
		else if (status.stickSensitivity == 160f)
		{
			cursor4 = 7;
		}
		else if (status.stickSensitivity == 180f)
		{
			cursor4 = 8;
		}
		else if (status.stickSensitivity == 200f)
		{
			cursor4 = 9;
		}
		else if (status.stickSensitivity == 220f)
		{
			cursor4 = 10;
		}
		else if (status.stickSensitivity == 240f)
		{
			cursor4 = 11;
		}
		else if (status.stickSensitivity == 260f)
		{
			cursor4 = 12;
		}
		else if (status.stickSensitivity == 280f)
		{
			cursor4 = 13;
		}
		else if (status.stickSensitivity == 300f)
		{
			cursor4 = 14;
		}
		else if (status.stickSensitivity == 320f)
		{
			cursor4 = 15;
		}
		else
		{
			cursor4 = 16;
		}
		if (status.stickInverted == 0)
		{
			cursor5 = 0;
		}
		else if (status.stickInverted == 1)
		{
			cursor5 = 1;
		}
		else if (status.stickInverted == 2)
		{
			cursor5 = 2;
		}
		else
		{
			cursor5 = 3;
		}
		screenId = 4;
	}

	public virtual void ApplySettings(int id)
	{
		switch (id)
		{
		case 1:
			if (cursor5 == 0)
			{
				status.walkFlag = 0;
			}
			else
			{
				status.walkFlag = 1;
			}
			if (cursor6 == 0)
			{
				status.language = 0;
			}
			else
			{
				status.language = 1;
			}
			if (cursor4 == 0)
			{
				if (cursor3 == 0)
				{
					Screen.SetResolution(640, 480, false);
				}
				else if (cursor3 == 1)
				{
					Screen.SetResolution(800, 600, false);
				}
				else if (cursor3 == 2)
				{
					Screen.SetResolution(1024, 768, false);
				}
				else if (cursor3 == 3)
				{
					Screen.SetResolution(1152, 864, false);
				}
				else if (cursor3 == 4)
				{
					Screen.SetResolution(1176, 664, false);
				}
				else if (cursor3 == 5)
				{
					Screen.SetResolution(1280, 720, false);
				}
				else if (cursor3 == 6)
				{
					Screen.SetResolution(1280, 800, false);
				}
				else if (cursor3 == 7)
				{
					Screen.SetResolution(1280, 960, false);
				}
				else if (cursor3 == 8)
				{
					Screen.SetResolution(1360, 765, false);
				}
				else if (cursor3 == 9)
				{
					Screen.SetResolution(1360, 768, false);
				}
				else if (cursor3 == 10)
				{
					Screen.SetResolution(1366, 768, false);
				}
				else if (cursor3 == 11)
				{
					Screen.SetResolution(1440, 810, false);
				}
				else if (cursor3 == 12)
				{
					Screen.SetResolution(1440, 900, false);
				}
				else if (cursor3 == 13)
				{
					Screen.SetResolution(1600, 900, false);
				}
				else if (cursor3 == 14)
				{
					Screen.SetResolution(1600, 1024, false);
				}
				else if (cursor3 == 15)
				{
					Screen.SetResolution(1680, 1050, false);
				}
				else if (cursor3 == 16)
				{
					Screen.SetResolution(1920, 1080, false);
				}
				else if (cursor3 == 17)
				{
					Screen.SetResolution(1920, 1200, false);
				}
			}
			else if (cursor3 == 0)
			{
				Screen.SetResolution(640, 480, true);
			}
			else if (cursor3 == 1)
			{
				Screen.SetResolution(800, 600, true);
			}
			else if (cursor3 == 2)
			{
				Screen.SetResolution(1024, 768, true);
			}
			else if (cursor3 == 3)
			{
				Screen.SetResolution(1152, 864, true);
			}
			else if (cursor3 == 4)
			{
				Screen.SetResolution(1176, 664, true);
			}
			else if (cursor3 == 5)
			{
				Screen.SetResolution(1280, 720, true);
			}
			else if (cursor3 == 6)
			{
				Screen.SetResolution(1280, 800, true);
			}
			else if (cursor3 == 7)
			{
				Screen.SetResolution(1280, 960, true);
			}
			else if (cursor3 == 8)
			{
				Screen.SetResolution(1360, 765, true);
			}
			else if (cursor3 == 9)
			{
				Screen.SetResolution(1360, 768, true);
			}
			else if (cursor3 == 10)
			{
				Screen.SetResolution(1366, 768, true);
			}
			else if (cursor3 == 11)
			{
				Screen.SetResolution(1440, 810, true);
			}
			else if (cursor3 == 12)
			{
				Screen.SetResolution(1440, 900, true);
			}
			else if (cursor3 == 13)
			{
				Screen.SetResolution(1600, 900, true);
			}
			else if (cursor3 == 14)
			{
				Screen.SetResolution(1600, 1024, true);
			}
			else if (cursor3 == 15)
			{
				Screen.SetResolution(1680, 1050, true);
			}
			else if (cursor3 == 16)
			{
				Screen.SetResolution(1920, 1080, true);
			}
			else if (cursor3 == 17)
			{
				Screen.SetResolution(1920, 1200, true);
			}
			break;
		case 2:
			if (cursor5 == 4)
			{
				QualitySettings.SetQualityLevel(3);
				status.shadowQuality = 4;
			}
			else if (cursor5 == 3)
			{
				QualitySettings.SetQualityLevel(2);
				status.shadowQuality = 3;
			}
			else if (cursor5 == 2)
			{
				QualitySettings.SetQualityLevel(1);
				status.shadowQuality = 2;
			}
			else if (cursor5 == 1)
			{
				QualitySettings.SetQualityLevel(0);
				status.shadowQuality = 1;
			}
			else if (cursor5 == 0)
			{
				QualitySettings.SetQualityLevel(0);
				QualitySettings.shadowCascades = 0;
				status.shadowQuality = 0;
			}
			if (cursor3 == 0)
			{
				QualitySettings.masterTextureLimit = 2;
				status.textureQuality = 0;
			}
			else if (cursor3 == 1)
			{
				QualitySettings.masterTextureLimit = 1;
				status.textureQuality = 1;
			}
			else if (cursor3 == 2)
			{
				QualitySettings.masterTextureLimit = 0;
				status.textureQuality = 2;
			}
			if (cursor4 == 0)
			{
				QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
				status.anisotropicFiltering = 0;
			}
			else
			{
				QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
				status.anisotropicFiltering = 1;
			}
			if (cursor6 == 0)
			{
				QualitySettings.antiAliasing = 0;
				status.antialiasing = 0;
			}
			else if (cursor6 == 1)
			{
				QualitySettings.antiAliasing = 2;
				status.antialiasing = 1;
			}
			else if (cursor6 == 2)
			{
				QualitySettings.antiAliasing = 4;
				status.antialiasing = 2;
			}
			else if (cursor6 == 3)
			{
				QualitySettings.antiAliasing = 8;
				status.antialiasing = 3;
			}
			if (cursor7 == 0)
			{
				QualitySettings.vSyncCount = 0;
				status.Vsync = 0;
			}
			else
			{
				QualitySettings.vSyncCount = 1;
				status.Vsync = 1;
			}
			break;
		case 3:
			key[0] = cInput.GetText("Up", 1);
			key[1] = cInput.GetText("Up", 2);
			key[2] = cInput.GetText("Down", 1);
			key[3] = cInput.GetText("Down", 2);
			key[4] = cInput.GetText("Left", 1);
			key[5] = cInput.GetText("Left", 2);
			key[6] = cInput.GetText("Right", 1);
			key[7] = cInput.GetText("Right", 2);
			key[8] = cInput.GetText("Action", 1);
			key[9] = cInput.GetText("Action", 2);
			key[10] = cInput.GetText("Sprint", 1);
			key[11] = cInput.GetText("Sprint", 2);
			key[12] = cInput.GetText("Camera Reset", 1);
			key[13] = cInput.GetText("Camera Reset", 2);
			key[14] = cInput.GetText("Menu", 1);
			key[15] = cInput.GetText("Menu", 2);
			key[16] = cInput.GetText("Pause", 1);
			key[17] = cInput.GetText("Pause", 2);
			key[18] = cInput.GetText("Map", 1);
			key[19] = cInput.GetText("Map", 2);
			if (cursor4 == 0)
			{
				status.mouseSensitivity = 50f;
			}
			else if (cursor4 == 1)
			{
				status.mouseSensitivity = 75f;
			}
			else if (cursor4 == 2)
			{
				status.mouseSensitivity = 100f;
			}
			else if (cursor4 == 3)
			{
				status.mouseSensitivity = 125f;
			}
			else if (cursor4 == 4)
			{
				status.mouseSensitivity = 150f;
			}
			else if (cursor4 == 5)
			{
				status.mouseSensitivity = 175f;
			}
			else if (cursor4 == 6)
			{
				status.mouseSensitivity = 200f;
			}
			else if (cursor4 == 7)
			{
				status.mouseSensitivity = 225f;
			}
			else if (cursor4 == 8)
			{
				status.mouseSensitivity = 250f;
			}
			else if (cursor4 == 9)
			{
				status.mouseSensitivity = 275f;
			}
			else if (cursor4 == 10)
			{
				status.mouseSensitivity = 300f;
			}
			else if (cursor4 == 11)
			{
				status.mouseSensitivity = 325f;
			}
			else if (cursor4 == 12)
			{
				status.mouseSensitivity = 350f;
			}
			else if (cursor4 == 13)
			{
				status.mouseSensitivity = 375f;
			}
			else if (cursor4 == 14)
			{
				status.mouseSensitivity = 400f;
			}
			else if (cursor4 == 15)
			{
				status.mouseSensitivity = 425f;
			}
			else if (cursor4 == 16)
			{
				status.mouseSensitivity = 450f;
			}
			if (cursor5 == 0)
			{
				cInput.AxisInverted("Mouse Y", false);
				status.mouseInverted = 0;
			}
			else
			{
				cInput.AxisInverted("Mouse Y", true);
				status.mouseInverted = 1;
			}
			break;
		case 4:
			key[0] = cInput.GetText("J_Action", 1);
			key[1] = cInput.GetText("J_Sprint", 1);
			key[2] = cInput.GetText("J_Camera Reset", 1);
			key[3] = cInput.GetText("J_Menu", 1);
			key[4] = cInput.GetText("J_Pause", 1);
			key[5] = cInput.GetText("J_Map", 1);
			if (cursor4 == 0)
			{
				status.stickSensitivity = 20f;
			}
			else if (cursor4 == 1)
			{
				status.stickSensitivity = 40f;
			}
			else if (cursor4 == 2)
			{
				status.stickSensitivity = 60f;
			}
			else if (cursor4 == 3)
			{
				status.stickSensitivity = 80f;
			}
			else if (cursor4 == 4)
			{
				status.stickSensitivity = 100f;
			}
			else if (cursor4 == 5)
			{
				status.stickSensitivity = 120f;
			}
			else if (cursor4 == 6)
			{
				status.stickSensitivity = 140f;
			}
			else if (cursor4 == 7)
			{
				status.stickSensitivity = 160f;
			}
			else if (cursor4 == 8)
			{
				status.stickSensitivity = 180f;
			}
			else if (cursor4 == 9)
			{
				status.stickSensitivity = 200f;
			}
			else if (cursor4 == 10)
			{
				status.stickSensitivity = 220f;
			}
			else if (cursor4 == 11)
			{
				status.stickSensitivity = 240f;
			}
			else if (cursor4 == 12)
			{
				status.stickSensitivity = 260f;
			}
			else if (cursor4 == 13)
			{
				status.stickSensitivity = 280f;
			}
			else if (cursor4 == 14)
			{
				status.stickSensitivity = 300f;
			}
			else if (cursor4 == 15)
			{
				status.stickSensitivity = 320f;
			}
			else if (cursor4 == 16)
			{
				status.stickSensitivity = 340f;
			}
			if (cursor5 == 0)
			{
				cInput.AxisInverted("J_Mouse X", false);
				cInput.AxisInverted("J_Mouse Y", false);
				status.stickInverted = 0;
			}
			else if (cursor5 == 1)
			{
				cInput.AxisInverted("J_Mouse X", true);
				cInput.AxisInverted("J_Mouse Y", false);
				status.stickInverted = 1;
			}
			else if (cursor5 == 2)
			{
				cInput.AxisInverted("J_Mouse X", false);
				cInput.AxisInverted("J_Mouse Y", true);
				status.stickInverted = 2;
			}
			else if (cursor5 == 3)
			{
				cInput.AxisInverted("J_Mouse X", true);
				cInput.AxisInverted("J_Mouse Y", true);
				status.stickInverted = 3;
			}
			break;
		}
		status.WriteSystemFile();
	}

	public virtual void SetDefaults(int id)
	{
		switch (id)
		{
		case 2:
			cursor3 = 2;
			cursor4 = 1;
			cursor5 = 3;
			cursor6 = 1;
			cursor7 = 0;
			break;
		case 3:
			cInput.ResetInputs();
			cursor4 = 4;
			cursor5 = 0;
			break;
		case 4:
			cInput.ResetInputs();
			cursor4 = 6;
			cursor5 = 0;
			break;
		}
	}

	public virtual void ReturnOptions()
	{
		if (screenId == 3)
		{
			cInput.ChangeKey("Up", key[0], key[1]);
			cInput.ChangeKey("Down", key[2], key[3]);
			cInput.ChangeKey("Left", key[4], key[5]);
			cInput.ChangeKey("Right", key[6], key[7]);
			cInput.ChangeKey("Action", key[8], key[9]);
			cInput.ChangeKey("Sprint", key[10], key[11]);
			cInput.ChangeKey("Camera Reset", key[12], key[13]);
			cInput.ChangeKey("Menu", key[14], key[15]);
			cInput.ChangeKey("Pause", key[16], key[17]);
			cInput.ChangeKey("Map", key[18], key[19]);
		}
		else if (screenId == 4)
		{
			cInput.ChangeKey("J_Action", key[0]);
			cInput.ChangeKey("J_Sprint", key[1]);
			cInput.ChangeKey("J_Camera Reset", key[2]);
			cInput.ChangeKey("J_Menu", key[3]);
			cInput.ChangeKey("J_Pause", key[4]);
			cInput.ChangeKey("J_Map", key[5]);
		}
		screenId = 0;
	}

	public virtual IEnumerator ChangeKey(string name, int index, bool mouseB, bool joyB, bool keyB)
	{
		return new _0024ChangeKey_00241247(name, index, mouseB, joyB, keyB, this).GetEnumerator();
	}

	public virtual IEnumerator Cursor()
	{
		return new _0024Cursor_00241261(this).GetEnumerator();
	}

	public virtual void OnGUI()
	{
		if (!nowOptioning)
		{
			return;
		}
		GUI.depth = guiDepth;
		GUI.DrawTexture(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), backGroundTex);
		if (screenId == 0)
		{
			GUI.DrawTexture(new Rect(0f, Screen.height / 2 - 140, Screen.width, 280f), backGroundTex);
		}
		else
		{
			GUI.DrawTexture(new Rect(0f, Screen.height / 2 - 180, Screen.width, 340f), backGroundTex);
		}
		if (screenId == 0)
		{
			if (cursor1 == 0)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 41, Screen.height / 2 - 100 - 13, 82f, 26f), systemTexTrue);
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
				GUI.DrawTexture(new Rect(Screen.width / 2 - 41, Screen.height / 2 - 100 - 13, 82f, 26f), systemTexFalse);
			}
			if (cursor1 == 1)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 55, Screen.height / 2 - 60 - 13, 110f, 26f), graphicsTexTrue);
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
				GUI.DrawTexture(new Rect(Screen.width / 2 - 55, Screen.height / 2 - 60 - 13, 110f, 26f), graphicsTexFalse);
			}
			if (cursor1 == 2)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 95, Screen.height / 2 - 20 - 13, 190f, 26f), keyTexTrue);
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
				GUI.DrawTexture(new Rect(Screen.width / 2 - 95, Screen.height / 2 - 20 - 13, 190f, 26f), keyTexFalse);
			}
			if (Input.GetJoystickNames().Length == 0 || (Input.GetJoystickNames().Length != 0 && Input.GetJoystickNames()[0] == string.Empty))
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 48, Screen.height / 2 + 20 - 13, 96f, 26f), padTexDisable);
			}
			else if (cursor1 == 3)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 48, Screen.height / 2 + 20 - 13, 96f, 26f), padTexTrue);
				if (status.language == 0)
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageGamepadJap, skin.customStyles[0]);
				}
				else
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageGamepadEng, skin.customStyles[0]);
				}
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 48, Screen.height / 2 + 20 - 13, 96f, 26f), padTexFalse);
			}
			if (cursor1 == 4)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 100 - 13, 80f, 26f), backTexTrue);
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
				GUI.DrawTexture(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 100 - 13, 80f, 26f), backTexFalse);
			}
		}
		else if (screenId == 1)
		{
			if (status.language == 0)
			{
				GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 140 - 13, 260f, 26f), entryPassageJap[0], skin.customStyles[1]);
				GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 100 - 13, 260f, 26f), entryPassageJap[1], skin.customStyles[1]);
				GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 20 - 13, 260f, 26f), entryPassageWalkJap, skin.customStyles[1]);
				if (!status.japaneseOnly)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 60 - 13, 260f, 26f), entryPassageJap[2], skin.customStyles[1]);
				}
			}
			else
			{
				GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 140 - 13, 260f, 26f), entryPassageEng[0], skin.customStyles[1]);
				GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 100 - 13, 260f, 26f), entryPassageEng[1], skin.customStyles[1]);
				GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 20 - 13, 260f, 26f), entryPassageWalkEng, skin.customStyles[1]);
				GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 60 - 13, 260f, 26f), entryPassageEng[2], skin.customStyles[1]);
			}
			GUI.Label(new Rect(Screen.width / 2 - 80, Screen.height / 2 - 140 - 13, 400f, 26f), systemScreenPassage[cursor3], skin.customStyles[0]);
			if (status.language == 0)
			{
				GUI.Label(new Rect(Screen.width / 2 - 80, Screen.height / 2 - 100 - 13, 400f, 26f), systemDisplayPassageJap[cursor4], skin.customStyles[0]);
			}
			else
			{
				GUI.Label(new Rect(Screen.width / 2 - 80, Screen.height / 2 - 100 - 13, 400f, 26f), systemDisplayPassageEng[cursor4], skin.customStyles[0]);
			}
			if (status.language == 0)
			{
				GUI.Label(new Rect(Screen.width / 2 - 80, Screen.height / 2 - 20 - 13, 400f, 26f), systemWalkPassageJap[cursor5], skin.customStyles[0]);
			}
			else
			{
				GUI.Label(new Rect(Screen.width / 2 - 80, Screen.height / 2 - 20 - 13, 400f, 26f), systemWalkPassageEng[cursor5], skin.customStyles[0]);
			}
			if (!status.japaneseOnly)
			{
				GUI.Label(new Rect(Screen.width / 2 - 80, Screen.height / 2 + 60 - 13, 400f, 26f), systemLanguagePassage[cursor6], skin.customStyles[0]);
			}
			if (cursorRL == 1)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 - 120, Screen.height / 2 - 140 - 13, 32f, 26f), leftTexTrue);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 - 120, Screen.height / 2 - 140 - 13, 32f, 26f), leftTexFalse);
			}
			if (cursorRL == 2)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 + 120, Screen.height / 2 - 140 - 13, 32f, 26f), rightTexTrue);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 + 120, Screen.height / 2 - 140 - 13, 32f, 26f), rightTexFalse);
			}
			if (cursorRL == 3)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 - 120, Screen.height / 2 - 100 - 13, 32f, 26f), leftTexTrue);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 - 120, Screen.height / 2 - 100 - 13, 32f, 26f), leftTexFalse);
			}
			if (cursorRL == 4)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 + 120, Screen.height / 2 - 100 - 13, 32f, 26f), rightTexTrue);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 + 120, Screen.height / 2 - 100 - 13, 32f, 26f), rightTexFalse);
			}
			if (cursorRL == 5)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 - 120, Screen.height / 2 - 20 - 13, 32f, 26f), leftTexTrue);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 - 120, Screen.height / 2 - 20 - 13, 32f, 26f), leftTexFalse);
			}
			if (cursorRL == 6)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 + 120, Screen.height / 2 - 20 - 13, 32f, 26f), rightTexTrue);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 + 120, Screen.height / 2 - 20 - 13, 32f, 26f), rightTexFalse);
			}
			if (!status.japaneseOnly)
			{
				if (cursorRL == 7)
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 - 120, Screen.height / 2 + 60 - 13, 32f, 26f), leftTexTrue);
				}
				else
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 - 120, Screen.height / 2 + 60 - 13, 32f, 26f), leftTexFalse);
				}
				if (cursorRL == 8)
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 + 120, Screen.height / 2 + 60 - 13, 32f, 26f), rightTexTrue);
				}
				else
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 + 120, Screen.height / 2 + 60 - 13, 32f, 26f), rightTexFalse);
				}
			}
			if (cursor2 == 0)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 120, Screen.height / 2 - 140 - 20, 240f, 40f), activeTex, ScaleMode.ScaleToFit, true);
				if (status.language == 0)
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[5], skin.customStyles[0]);
				}
				else
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[5], skin.customStyles[0]);
				}
			}
			else if (cursor2 == 1)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 120, Screen.height / 2 - 100 - 20, 240f, 40f), activeTex, ScaleMode.ScaleToFit, true);
				if (status.language == 0)
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[6], skin.customStyles[0]);
				}
				else
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[6], skin.customStyles[0]);
				}
			}
			else if (cursor2 == 2)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 120, Screen.height / 2 - 20 - 20, 240f, 40f), activeTex, ScaleMode.ScaleToFit, true);
				if (status.language == 0)
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageWalkJap, skin.customStyles[0]);
				}
				else
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageWalkEng, skin.customStyles[0]);
				}
			}
			else if (cursor2 == 3)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 120, Screen.height / 2 + 60 - 20, 240f, 40f), activeTex, ScaleMode.ScaleToFit, true);
				if (status.language == 0)
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[7], skin.customStyles[0]);
				}
				else
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[7], skin.customStyles[0]);
				}
			}
			if (cursor2 == 4 && cursorAC == 0)
			{
				if (status.language == 0)
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 40 - 80, Screen.height / 2 + 140 - 13, 80f, 26f), applyTexTrueJap);
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[8], skin.customStyles[0]);
				}
				else
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 40 - 80, Screen.height / 2 + 140 - 13, 80f, 26f), applyTexTrueEng);
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[8], skin.customStyles[0]);
				}
			}
			else if (status.language == 0)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 40 - 80, Screen.height / 2 + 140 - 13, 80f, 26f), applyTexFalseJap);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 40 - 80, Screen.height / 2 + 140 - 13, 80f, 26f), applyTexFalseEng);
			}
			if (cursor2 == 4 && cursorAC == 1)
			{
				if (status.language == 0)
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 40 + 80, Screen.height / 2 + 140 - 13, 80f, 26f), backTexTrueJap);
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[9], skin.customStyles[0]);
				}
				else
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 40 + 80, Screen.height / 2 + 140 - 13, 80f, 26f), backTexTrueEng);
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[9], skin.customStyles[0]);
				}
			}
			else if (status.language == 0)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 40 + 80, Screen.height / 2 + 140 - 13, 80f, 26f), backTexFalseJap);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 40 + 80, Screen.height / 2 + 140 - 13, 80f, 26f), backTexFalseEng);
			}
		}
		else if (screenId == 2)
		{
			if (status.language == 0)
			{
				GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 140 - 13, 260f, 26f), entryPassageJap[3], skin.customStyles[1]);
				GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 100 - 13, 260f, 26f), entryPassageJap[4], skin.customStyles[1]);
				GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 60 - 13, 260f, 26f), entryPassageJap[5], skin.customStyles[1]);
				GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 20 - 13, 260f, 26f), entryPassageJap[6], skin.customStyles[1]);
				GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 20 - 13, 260f, 26f), entryPassageJap[7], skin.customStyles[1]);
			}
			else
			{
				GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 140 - 13, 260f, 26f), entryPassageEng[3], skin.customStyles[1]);
				GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 100 - 13, 260f, 26f), entryPassageEng[4], skin.customStyles[1]);
				GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 60 - 13, 260f, 26f), entryPassageEng[5], skin.customStyles[1]);
				GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 20 - 13, 260f, 26f), entryPassageEng[6], skin.customStyles[1]);
				GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 20 - 13, 260f, 26f), entryPassageEng[7], skin.customStyles[1]);
			}
			if (status.language == 0)
			{
				GUI.Label(new Rect(Screen.width / 2 - 80, Screen.height / 2 - 140 - 13, 400f, 26f), graphicsTexturePassageJap[cursor3], skin.customStyles[0]);
				GUI.Label(new Rect(Screen.width / 2 - 80, Screen.height / 2 - 100 - 13, 400f, 26f), booleanPassageJap[cursor4], skin.customStyles[0]);
				GUI.Label(new Rect(Screen.width / 2 - 80, Screen.height / 2 - 60 - 13, 400f, 26f), graphicsShadowPassageJap[cursor5], skin.customStyles[0]);
				GUI.Label(new Rect(Screen.width / 2 - 80, Screen.height / 2 - 20 - 13, 400f, 26f), graphicsAaPassageJap[cursor6], skin.customStyles[0]);
				GUI.Label(new Rect(Screen.width / 2 - 80, Screen.height / 2 + 20 - 13, 400f, 26f), booleanPassageJap[cursor7], skin.customStyles[0]);
			}
			else
			{
				GUI.Label(new Rect(Screen.width / 2 - 80, Screen.height / 2 - 140 - 13, 400f, 26f), graphicsTexturePassageEng[cursor3], skin.customStyles[0]);
				GUI.Label(new Rect(Screen.width / 2 - 80, Screen.height / 2 - 100 - 13, 400f, 26f), booleanPassageEng[cursor4], skin.customStyles[0]);
				GUI.Label(new Rect(Screen.width / 2 - 80, Screen.height / 2 - 60 - 13, 400f, 26f), graphicsShadowPassageEng[cursor5], skin.customStyles[0]);
				GUI.Label(new Rect(Screen.width / 2 - 80, Screen.height / 2 - 20 - 13, 400f, 26f), graphicsAaPassageEng[cursor6], skin.customStyles[0]);
				GUI.Label(new Rect(Screen.width / 2 - 80, Screen.height / 2 + 20 - 13, 400f, 26f), booleanPassageEng[cursor7], skin.customStyles[0]);
			}
			if (cursorRL == 1)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 - 120, Screen.height / 2 - 140 - 13, 32f, 26f), leftTexTrue);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 - 120, Screen.height / 2 - 140 - 13, 32f, 26f), leftTexFalse);
			}
			if (cursorRL == 2)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 + 120, Screen.height / 2 - 140 - 13, 32f, 26f), rightTexTrue);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 + 120, Screen.height / 2 - 140 - 13, 32f, 26f), rightTexFalse);
			}
			if (cursorRL == 3)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 - 120, Screen.height / 2 - 100 - 13, 32f, 26f), leftTexTrue);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 - 120, Screen.height / 2 - 100 - 13, 32f, 26f), leftTexFalse);
			}
			if (cursorRL == 4)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 + 120, Screen.height / 2 - 100 - 13, 32f, 26f), rightTexTrue);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 + 120, Screen.height / 2 - 100 - 13, 32f, 26f), rightTexFalse);
			}
			if (cursorRL == 5)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 - 120, Screen.height / 2 - 60 - 13, 32f, 26f), leftTexTrue);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 - 120, Screen.height / 2 - 60 - 13, 32f, 26f), leftTexFalse);
			}
			if (cursorRL == 6)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 + 120, Screen.height / 2 - 60 - 13, 32f, 26f), rightTexTrue);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 + 120, Screen.height / 2 - 60 - 13, 32f, 26f), rightTexFalse);
			}
			if (cursorRL == 7)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 - 120, Screen.height / 2 - 20 - 13, 32f, 26f), leftTexTrue);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 - 120, Screen.height / 2 - 20 - 13, 32f, 26f), leftTexFalse);
			}
			if (cursorRL == 8)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 + 120, Screen.height / 2 - 20 - 13, 32f, 26f), rightTexTrue);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 + 120, Screen.height / 2 - 20 - 13, 32f, 26f), rightTexFalse);
			}
			if (cursorRL == 9)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 - 120, Screen.height / 2 + 20 - 13, 32f, 26f), leftTexTrue);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 - 120, Screen.height / 2 + 20 - 13, 32f, 26f), leftTexFalse);
			}
			if (cursorRL == 10)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 + 120, Screen.height / 2 + 20 - 13, 32f, 26f), rightTexTrue);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 + 120, Screen.height / 2 + 20 - 13, 32f, 26f), rightTexFalse);
			}
			if (cursor2 == 0)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 120, Screen.height / 2 - 140 - 20, 240f, 40f), activeTex, ScaleMode.ScaleToFit, true);
				if (status.language == 0)
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[10], skin.customStyles[0]);
				}
				else
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[10], skin.customStyles[0]);
				}
			}
			else if (cursor2 == 1)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 120, Screen.height / 2 - 100 - 20, 240f, 40f), activeTex, ScaleMode.ScaleToFit, true);
				if (status.language == 0)
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[11], skin.customStyles[0]);
				}
				else
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[11], skin.customStyles[0]);
				}
			}
			else if (cursor2 == 2)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 120, Screen.height / 2 - 60 - 20, 240f, 40f), activeTex, ScaleMode.ScaleToFit, true);
				if (status.language == 0)
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[12], skin.customStyles[0]);
				}
				else
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[12], skin.customStyles[0]);
				}
			}
			else if (cursor2 == 3)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 120, Screen.height / 2 - 20 - 20, 240f, 40f), activeTex, ScaleMode.ScaleToFit, true);
				if (status.language == 0)
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[13], skin.customStyles[0]);
				}
				else
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[13], skin.customStyles[0]);
				}
			}
			else if (cursor2 == 4)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 120, Screen.height / 2 + 20 - 20, 240f, 40f), activeTex, ScaleMode.ScaleToFit, true);
				if (status.language == 0)
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[14], skin.customStyles[0]);
				}
				else
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[14], skin.customStyles[0]);
				}
			}
			if (cursor2 == 5)
			{
				if (status.language == 0)
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 62, Screen.height / 2 + 100 - 13, 124f, 26f), defaultsTexTrueJap);
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[15], skin.customStyles[0]);
				}
				else
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 62, Screen.height / 2 + 100 - 13, 124f, 26f), defaultsTexTrueEng);
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[15], skin.customStyles[0]);
				}
			}
			else if (status.language == 0)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 62, Screen.height / 2 + 100 - 13, 124f, 26f), defaultsTexFalseJap);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 62, Screen.height / 2 + 100 - 13, 124f, 26f), defaultsTexFalseEng);
			}
			if (cursor2 == 6 && cursorAC == 0)
			{
				if (status.language == 0)
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 40 - 80, Screen.height / 2 + 140 - 13, 80f, 26f), applyTexTrueJap);
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[8], skin.customStyles[0]);
				}
				else
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 40 - 80, Screen.height / 2 + 140 - 13, 80f, 26f), applyTexTrueEng);
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[8], skin.customStyles[0]);
				}
			}
			else if (status.language == 0)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 40 - 80, Screen.height / 2 + 140 - 13, 80f, 26f), applyTexFalseJap);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 40 - 80, Screen.height / 2 + 140 - 13, 80f, 26f), applyTexFalseEng);
			}
			if (cursor2 == 6 && cursorAC == 1)
			{
				if (status.language == 0)
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 40 + 80, Screen.height / 2 + 140 - 13, 80f, 26f), backTexTrueJap);
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[9], skin.customStyles[0]);
				}
				else
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 40 + 80, Screen.height / 2 + 140 - 13, 80f, 26f), backTexTrueEng);
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[9], skin.customStyles[0]);
				}
			}
			else if (status.language == 0)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 40 + 80, Screen.height / 2 + 140 - 13, 80f, 26f), backTexFalseJap);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 40 + 80, Screen.height / 2 + 140 - 13, 80f, 26f), backTexFalseEng);
			}
		}
		else if (screenId == 3)
		{
			GUI.DrawTexture(new Rect(0f, Screen.height / 2 - 160, Screen.width, 160f), keyLineTex, ScaleMode.StretchToFill, true);
			if (cursorRL == 1)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 320 - 30, Screen.height / 2 - 140 - 8, 16f, 16f), scrollUpTexTrue, ScaleMode.ScaleToFit, true);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 320 - 30, Screen.height / 2 - 140 - 8, 16f, 16f), scrollUpTexFalse, ScaleMode.ScaleToFit, true);
			}
			if (cursorRL == 2)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 320 - 30, Screen.height / 2 - 20 - 8, 16f, 16f), scrollDownTexTrue, ScaleMode.ScaleToFit, true);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 320 - 30, Screen.height / 2 - 20 - 8, 16f, 16f), scrollDownTexFalse, ScaleMode.ScaleToFit, true);
			}
			if (cursor3 == 0)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 320 - 30, Screen.height / 2 - 131, 16f, 30f), scrollBarTex, ScaleMode.ScaleToFit, true);
			}
			else if (cursor3 == 1)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 320 - 30, Screen.height / 2 - 118, 16f, 30f), scrollBarTex, ScaleMode.ScaleToFit, true);
			}
			else if (cursor3 == 2)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 320 - 30, Screen.height / 2 - 106, 16f, 30f), scrollBarTex, ScaleMode.ScaleToFit, true);
			}
			else if (cursor3 == 3)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 320 - 30, Screen.height / 2 - 93, 16f, 30f), scrollBarTex, ScaleMode.ScaleToFit, true);
			}
			else if (cursor3 == 4)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 320 - 30, Screen.height / 2 - 81, 16f, 30f), scrollBarTex, ScaleMode.ScaleToFit, true);
			}
			else if (cursor3 == 5)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 320 - 30, Screen.height / 2 - 68, 16f, 30f), scrollBarTex, ScaleMode.ScaleToFit, true);
			}
			else if (cursor3 == 6)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 320 - 30, Screen.height / 2 - 58, 16f, 30f), scrollBarTex, ScaleMode.ScaleToFit, true);
			}
			if (status.language == 0)
			{
				GUI.Label(new Rect(Screen.width / 2 - 80, Screen.height / 2 + 60 - 13, 400f, 26f), booleanPassageJap[cursor5], skin.customStyles[0]);
			}
			else
			{
				GUI.Label(new Rect(Screen.width / 2 - 80, Screen.height / 2 + 60 - 13, 400f, 26f), booleanPassageEng[cursor5], skin.customStyles[0]);
			}
			if (cursorRL == 3)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 - 120, Screen.height / 2 + 60 - 13, 32f, 26f), leftTexTrue);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 - 120, Screen.height / 2 + 60 - 13, 32f, 26f), leftTexFalse);
			}
			if (cursorRL == 4)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 + 120, Screen.height / 2 + 60 - 13, 32f, 26f), rightTexTrue);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 + 120, Screen.height / 2 + 60 - 13, 32f, 26f), rightTexFalse);
			}
			if (status.language == 0)
			{
				if (cursor3 <= 0)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 140 - cursor3 * 40 - 13, 260f, 26f), entryPassageJap[8], skin.customStyles[1]);
				}
				if (cursor3 <= 1)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 100 - cursor3 * 40 - 13, 260f, 26f), entryPassageJap[9], skin.customStyles[1]);
				}
				if (cursor3 <= 2)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 60 - cursor3 * 40 - 13, 260f, 26f), entryPassageJap[10], skin.customStyles[1]);
				}
				if (cursor3 <= 3)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 20 - cursor3 * 40 - 13, 260f, 26f), entryPassageJap[11], skin.customStyles[1]);
				}
				if (cursor3 >= 1 && cursor3 <= 4)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 20 - cursor3 * 40 - 13, 260f, 26f), entryPassageActionJap, skin.customStyles[1]);
				}
				if (cursor3 >= 2 && cursor3 <= 5)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 60 - cursor3 * 40 - 13, 260f, 26f), entryPassageCancelJap, skin.customStyles[1]);
				}
				if (cursor3 >= 3)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 100 - cursor3 * 40 - 13, 260f, 26f), entryPassageJap[14], skin.customStyles[1]);
				}
				if (cursor3 >= 4)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 140 - cursor3 * 40 - 13, 260f, 26f), entryPassageJap[15], skin.customStyles[1]);
				}
				if (cursor3 >= 5)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 180 - cursor3 * 40 - 13, 260f, 26f), entryPassageJap[16], skin.customStyles[1]);
				}
				if (cursor3 == 6)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 220 - cursor3 * 40 - 13, 260f, 26f), entryPassageMapJap, skin.customStyles[1]);
				}
				GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 20 - 13, 260f, 26f), entryPassageJap[17], skin.customStyles[1]);
				GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 60 - 13, 260f, 26f), entryPassageJap[18], skin.customStyles[1]);
			}
			else
			{
				if (cursor3 <= 0)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 140 - cursor3 * 40 - 13, 260f, 26f), entryPassageEng[8], skin.customStyles[1]);
				}
				if (cursor3 <= 1)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 100 - cursor3 * 40 - 13, 260f, 26f), entryPassageEng[9], skin.customStyles[1]);
				}
				if (cursor3 <= 2)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 60 - cursor3 * 40 - 13, 260f, 26f), entryPassageEng[10], skin.customStyles[1]);
				}
				if (cursor3 <= 3)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 20 - cursor3 * 40 - 13, 260f, 26f), entryPassageEng[11], skin.customStyles[1]);
				}
				if (cursor3 >= 1 && cursor3 <= 4)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 20 - cursor3 * 40 - 13, 260f, 26f), entryPassageActionEng, skin.customStyles[1]);
				}
				if (cursor3 >= 2 && cursor3 <= 5)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 60 - cursor3 * 40 - 13, 260f, 26f), entryPassageCancelEng, skin.customStyles[1]);
				}
				if (cursor3 >= 3)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 100 - cursor3 * 40 - 13, 260f, 26f), entryPassageEng[14], skin.customStyles[1]);
				}
				if (cursor3 >= 4)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 140 - cursor3 * 40 - 13, 260f, 26f), entryPassageEng[15], skin.customStyles[1]);
				}
				if (cursor3 >= 5)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 180 - cursor3 * 40 - 13, 260f, 26f), entryPassageEng[16], skin.customStyles[1]);
				}
				if (cursor3 == 6)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 220 - cursor3 * 40 - 13, 260f, 26f), entryPassageMapEng, skin.customStyles[1]);
				}
				GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 20 - 13, 260f, 26f), entryPassageEng[17], skin.customStyles[1]);
				GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 60 - 13, 260f, 26f), entryPassageEng[18], skin.customStyles[1]);
			}
			if (cursor3 <= 0)
			{
				GUI.Label(new Rect(Screen.width / 2 + 115 - 70 - 65, Screen.height / 2 - 140 - cursor3 * 40 - 20, 140f, 40f), cInput.GetText("Up", 1), skin.customStyles[0]);
				GUI.Label(new Rect(Screen.width / 2 + 115 - 70 + 65, Screen.height / 2 - 140 - cursor3 * 40 - 20, 140f, 40f), cInput.GetText("Up", 2), skin.customStyles[0]);
			}
			if (cursor3 <= 1)
			{
				GUI.Label(new Rect(Screen.width / 2 + 115 - 70 - 65, Screen.height / 2 - 100 - cursor3 * 40 - 20, 140f, 40f), cInput.GetText("Down", 1), skin.customStyles[0]);
				GUI.Label(new Rect(Screen.width / 2 + 115 - 70 + 65, Screen.height / 2 - 100 - cursor3 * 40 - 20, 140f, 40f), cInput.GetText("Down", 2), skin.customStyles[0]);
			}
			if (cursor3 <= 2)
			{
				GUI.Label(new Rect(Screen.width / 2 + 115 - 70 - 65, Screen.height / 2 - 60 - cursor3 * 40 - 20, 140f, 40f), cInput.GetText("Left", 1), skin.customStyles[0]);
				GUI.Label(new Rect(Screen.width / 2 + 115 - 70 + 65, Screen.height / 2 - 60 - cursor3 * 40 - 20, 140f, 40f), cInput.GetText("Left", 2), skin.customStyles[0]);
			}
			if (cursor3 <= 3)
			{
				GUI.Label(new Rect(Screen.width / 2 + 115 - 70 - 65, Screen.height / 2 - 20 - cursor3 * 40 - 20, 140f, 40f), cInput.GetText("Right", 1), skin.customStyles[0]);
				GUI.Label(new Rect(Screen.width / 2 + 115 - 70 + 65, Screen.height / 2 - 20 - cursor3 * 40 - 20, 140f, 40f), cInput.GetText("Right", 2), skin.customStyles[0]);
			}
			if (cursor3 >= 1 && cursor3 <= 4)
			{
				GUI.Label(new Rect(Screen.width / 2 + 115 - 70 - 65, Screen.height / 2 + 20 - cursor3 * 40 - 20, 140f, 40f), cInput.GetText("Action", 1), skin.customStyles[0]);
				GUI.Label(new Rect(Screen.width / 2 + 115 - 70 + 65, Screen.height / 2 + 20 - cursor3 * 40 - 20, 140f, 40f), cInput.GetText("Action", 2), skin.customStyles[0]);
			}
			if (cursor3 >= 2 && cursor3 <= 5)
			{
				GUI.Label(new Rect(Screen.width / 2 + 115 - 70 - 65, Screen.height / 2 + 60 - cursor3 * 40 - 20, 140f, 40f), cInput.GetText("Sprint", 1), skin.customStyles[0]);
				GUI.Label(new Rect(Screen.width / 2 + 115 - 70 + 65, Screen.height / 2 + 60 - cursor3 * 40 - 20, 140f, 40f), cInput.GetText("Sprint", 2), skin.customStyles[0]);
			}
			if (cursor3 >= 3)
			{
				GUI.Label(new Rect(Screen.width / 2 + 115 - 70 - 65, Screen.height / 2 + 100 - cursor3 * 40 - 20, 140f, 40f), cInput.GetText("Camera Reset", 1), skin.customStyles[0]);
				GUI.Label(new Rect(Screen.width / 2 + 115 - 70 + 65, Screen.height / 2 + 100 - cursor3 * 40 - 20, 140f, 40f), cInput.GetText("Camera Reset", 2), skin.customStyles[0]);
			}
			if (cursor3 >= 4)
			{
				GUI.Label(new Rect(Screen.width / 2 + 115 - 70 - 65, Screen.height / 2 + 140 - cursor3 * 40 - 20, 140f, 40f), cInput.GetText("Menu", 1), skin.customStyles[0]);
				GUI.Label(new Rect(Screen.width / 2 + 115 - 70 + 65, Screen.height / 2 + 140 - cursor3 * 40 - 20, 140f, 40f), cInput.GetText("Menu", 2), skin.customStyles[0]);
			}
			if (cursor3 >= 5)
			{
				GUI.Label(new Rect(Screen.width / 2 + 115 - 70 - 65, Screen.height / 2 + 180 - cursor3 * 40 - 20, 140f, 40f), cInput.GetText("Pause", 1), skin.customStyles[0]);
				GUI.Label(new Rect(Screen.width / 2 + 115 - 70 + 65, Screen.height / 2 + 180 - cursor3 * 40 - 20, 140f, 40f), cInput.GetText("Pause", 2), skin.customStyles[0]);
			}
			if (cursor3 == 6)
			{
				GUI.Label(new Rect(Screen.width / 2 + 115 - 70 - 65, Screen.height / 2 + 220 - cursor3 * 40 - 20, 140f, 40f), cInput.GetText("Map", 1), skin.customStyles[0]);
				GUI.Label(new Rect(Screen.width / 2 + 115 - 70 + 65, Screen.height / 2 + 220 - cursor3 * 40 - 20, 140f, 40f), cInput.GetText("Map", 2), skin.customStyles[0]);
			}
			GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 102, Screen.height / 2 + 20 - 11, 205f, 25f), sensitivitySliderTex, ScaleMode.ScaleToFit, true);
			if (cursor4 == 0)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 - 100, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 1)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 - 88, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 2)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 - 76, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 3)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 - 63, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 4)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 - 50, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 5)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 - 37, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 6)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 - 25, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 7)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 - 12, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 8)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 + 1, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 9)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 + 13, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 10)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 + 26, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 11)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 + 39, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 12)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 + 52, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 13)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 + 64, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 14)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 + 77, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 15)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 + 88, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 16)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 + 100, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			if (cursor2 <= 7)
			{
				if (status.language == 0)
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[18], skin.customStyles[0]);
				}
				else
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[18], skin.customStyles[0]);
				}
			}
			if (cursor2 == 0)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 115 - 70 - 65, Screen.height / 2 - 140 - 20, 140f, 40f), activeTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor2 == 1)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 115 - 70 + 65, Screen.height / 2 - 140 - 20, 140f, 40f), activeTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor2 == 2)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 115 - 70 - 65, Screen.height / 2 - 100 - 20, 140f, 40f), activeTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor2 == 3)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 115 - 70 + 65, Screen.height / 2 - 100 - 20, 140f, 40f), activeTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor2 == 4)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 115 - 70 - 65, Screen.height / 2 - 60 - 20, 140f, 40f), activeTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor2 == 5)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 115 - 70 + 65, Screen.height / 2 - 60 - 20, 140f, 40f), activeTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor2 == 6)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 115 - 70 - 65, Screen.height / 2 - 20 - 20, 140f, 40f), activeTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor2 == 7)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 115 - 70 + 65, Screen.height / 2 - 20 - 20, 140f, 40f), activeTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor2 == 8)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 120, Screen.height / 2 + 20 - 20, 240f, 40f), activeTex, ScaleMode.ScaleToFit, true);
				if (status.language == 0)
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[16], skin.customStyles[0]);
				}
				else
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[16], skin.customStyles[0]);
				}
			}
			else if (cursor2 == 9)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 120, Screen.height / 2 + 60 - 20, 240f, 40f), activeTex, ScaleMode.ScaleToFit, true);
				if (status.language == 0)
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[17], skin.customStyles[0]);
				}
				else
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[17], skin.customStyles[0]);
				}
			}
			if (cursor2 == 10)
			{
				if (status.language == 0)
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 62, Screen.height / 2 + 100 - 13, 124f, 26f), defaultsTexTrueJap);
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[15], skin.customStyles[0]);
				}
				else
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 62, Screen.height / 2 + 100 - 13, 124f, 26f), defaultsTexTrueEng);
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[15], skin.customStyles[0]);
				}
			}
			else if (status.language == 0)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 62, Screen.height / 2 + 100 - 13, 124f, 26f), defaultsTexFalseJap);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 62, Screen.height / 2 + 100 - 13, 124f, 26f), defaultsTexFalseEng);
			}
			if (cursor2 == 11 && cursorAC == 0)
			{
				if (status.language == 0)
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 40 - 80, Screen.height / 2 + 140 - 13, 80f, 26f), applyTexTrueJap);
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[8], skin.customStyles[0]);
				}
				else
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 40 - 80, Screen.height / 2 + 140 - 13, 80f, 26f), applyTexTrueEng);
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[8], skin.customStyles[0]);
				}
			}
			else if (status.language == 0)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 40 - 80, Screen.height / 2 + 140 - 13, 80f, 26f), applyTexFalseJap);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 40 - 80, Screen.height / 2 + 140 - 13, 80f, 26f), applyTexFalseEng);
			}
			if (cursor2 == 11 && cursorAC == 1)
			{
				if (status.language == 0)
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 40 + 80, Screen.height / 2 + 140 - 13, 80f, 26f), backTexTrueJap);
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[9], skin.customStyles[0]);
				}
				else
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 40 + 80, Screen.height / 2 + 140 - 13, 80f, 26f), backTexTrueEng);
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[9], skin.customStyles[0]);
				}
			}
			else if (status.language == 0)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 40 + 80, Screen.height / 2 + 140 - 13, 80f, 26f), backTexFalseJap);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 40 + 80, Screen.height / 2 + 140 - 13, 80f, 26f), backTexFalseEng);
			}
		}
		else
		{
			if (screenId != 4)
			{
				return;
			}
			GUI.DrawTexture(new Rect(0f, Screen.height / 2 - 160, Screen.width, 160f), keyLineTex, ScaleMode.StretchToFill, true);
			if (cursorRL == 1)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 320 - 30, Screen.height / 2 - 140 - 8, 16f, 16f), scrollUpTexTrue, ScaleMode.ScaleToFit, true);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 320 - 30, Screen.height / 2 - 140 - 8, 16f, 16f), scrollUpTexFalse, ScaleMode.ScaleToFit, true);
			}
			if (cursorRL == 2)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 320 - 30, Screen.height / 2 - 20 - 8, 16f, 16f), scrollDownTexTrue, ScaleMode.ScaleToFit, true);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 320 - 30, Screen.height / 2 - 20 - 8, 16f, 16f), scrollDownTexFalse, ScaleMode.ScaleToFit, true);
			}
			if (cursor3 == 4)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 320 - 30, Screen.height / 2 - 131, 16f, 60f), scrollBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor3 == 5)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 320 - 30, Screen.height / 2 - 109, 16f, 60f), scrollBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor3 == 6)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 320 - 30, Screen.height / 2 - 88, 16f, 60f), scrollBarTex, ScaleMode.StretchToFill, true);
			}
			if (status.language == 0)
			{
				GUI.Label(new Rect(Screen.width / 2 - 80, Screen.height / 2 + 60 - 13, 400f, 26f), gamepadAxisPassageJap[cursor5], skin.customStyles[0]);
			}
			else
			{
				GUI.Label(new Rect(Screen.width / 2 - 80, Screen.height / 2 + 60 - 13, 400f, 26f), gamepadAxisPassageEng[cursor5], skin.customStyles[0]);
			}
			if (cursorRL == 3)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 - 120, Screen.height / 2 + 60 - 13, 32f, 26f), leftTexTrue);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 - 120, Screen.height / 2 + 60 - 13, 32f, 26f), leftTexFalse);
			}
			if (cursorRL == 4)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 + 120, Screen.height / 2 + 60 - 13, 32f, 26f), rightTexTrue);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 80 + 200 - 16 + 120, Screen.height / 2 + 60 - 13, 32f, 26f), rightTexFalse);
			}
			if (status.language == 0)
			{
				if (cursor3 <= 0)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 140 - cursor3 * 40 - 13, 260f, 26f), entryPassageJap[8], skin.customStyles[1]);
				}
				if (cursor3 <= 1)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 100 - cursor3 * 40 - 13, 260f, 26f), entryPassageJap[9], skin.customStyles[1]);
				}
				if (cursor3 <= 2)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 60 - cursor3 * 40 - 13, 260f, 26f), entryPassageJap[10], skin.customStyles[1]);
				}
				if (cursor3 <= 3)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 20 - cursor3 * 40 - 13, 260f, 26f), entryPassageJap[11], skin.customStyles[1]);
				}
				if (cursor3 >= 1 && cursor3 <= 4)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 20 - cursor3 * 40 - 13, 260f, 26f), entryPassageActionJap, skin.customStyles[1]);
				}
				if (cursor3 >= 2 && cursor3 <= 5)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 60 - cursor3 * 40 - 13, 260f, 26f), entryPassageCancelJap, skin.customStyles[1]);
				}
				if (cursor3 >= 3)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 100 - cursor3 * 40 - 13, 260f, 26f), entryPassageJap[14], skin.customStyles[1]);
				}
				if (cursor3 >= 4)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 140 - cursor3 * 40 - 13, 260f, 26f), entryPassageJap[15], skin.customStyles[1]);
				}
				if (cursor3 >= 5)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 180 - cursor3 * 40 - 13, 260f, 26f), entryPassageJap[16], skin.customStyles[1]);
				}
				if (cursor3 == 6)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 220 - cursor3 * 40 - 13, 260f, 26f), entryPassageMapJap, skin.customStyles[1]);
				}
				GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 20 - 13, 260f, 26f), entryPassageJap[19], skin.customStyles[1]);
				GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 60 - 13, 260f, 26f), entryPassageJap[20], skin.customStyles[1]);
			}
			else
			{
				if (cursor3 <= 0)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 140 - cursor3 * 40 - 13, 260f, 26f), entryPassageEng[8], skin.customStyles[1]);
				}
				if (cursor3 <= 1)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 100 - cursor3 * 40 - 13, 260f, 26f), entryPassageEng[9], skin.customStyles[1]);
				}
				if (cursor3 <= 2)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 60 - cursor3 * 40 - 13, 260f, 26f), entryPassageEng[10], skin.customStyles[1]);
				}
				if (cursor3 <= 3)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 20 - cursor3 * 40 - 13, 260f, 26f), entryPassageEng[11], skin.customStyles[1]);
				}
				if (cursor3 >= 1 && cursor3 <= 4)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 20 - cursor3 * 40 - 13, 260f, 26f), entryPassageActionEng, skin.customStyles[1]);
				}
				if (cursor3 >= 2 && cursor3 <= 5)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 60 - cursor3 * 40 - 13, 260f, 26f), entryPassageCancelEng, skin.customStyles[1]);
				}
				if (cursor3 >= 3)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 100 - cursor3 * 40 - 13, 260f, 26f), entryPassageEng[14], skin.customStyles[1]);
				}
				if (cursor3 >= 4)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 140 - cursor3 * 40 - 13, 260f, 26f), entryPassageEng[15], skin.customStyles[1]);
				}
				if (cursor3 >= 5)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 180 - cursor3 * 40 - 13, 260f, 26f), entryPassageEng[16], skin.customStyles[1]);
				}
				if (cursor3 == 6)
				{
					GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 220 - cursor3 * 40 - 13, 260f, 26f), entryPassageMapEng, skin.customStyles[1]);
				}
				GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 20 - 13, 260f, 26f), entryPassageEng[19], skin.customStyles[1]);
				GUI.Label(new Rect(Screen.width / 2 - 320, Screen.height / 2 + 60 - 13, 260f, 26f), entryPassageEng[20], skin.customStyles[1]);
			}
			if (cursor3 <= 0)
			{
				GUI.Label(new Rect(Screen.width / 2 + 110 - 70, Screen.height / 2 - 140 - cursor3 * 40 - 20, 150f, 40f), cInput.GetText("J_Up", 1), skin.customStyles[0]);
			}
			if (cursor3 <= 1)
			{
				GUI.Label(new Rect(Screen.width / 2 + 110 - 70, Screen.height / 2 - 100 - cursor3 * 40 - 20, 150f, 40f), cInput.GetText("J_Down", 1), skin.customStyles[0]);
			}
			if (cursor3 <= 2)
			{
				GUI.Label(new Rect(Screen.width / 2 + 110 - 70, Screen.height / 2 - 60 - cursor3 * 40 - 20, 150f, 40f), cInput.GetText("J_Left", 1), skin.customStyles[0]);
			}
			if (cursor3 <= 3)
			{
				GUI.Label(new Rect(Screen.width / 2 + 110 - 70, Screen.height / 2 - 20 - cursor3 * 40 - 20, 150f, 40f), cInput.GetText("J_Right", 1), skin.customStyles[0]);
			}
			if (cursor3 >= 1 && cursor3 <= 4)
			{
				GUI.Label(new Rect(Screen.width / 2 + 110 - 70, Screen.height / 2 + 20 - cursor3 * 40 - 20, 150f, 40f), cInput.GetText("J_Action", 1), skin.customStyles[0]);
			}
			if (cursor3 >= 2 && cursor3 <= 5)
			{
				GUI.Label(new Rect(Screen.width / 2 + 110 - 70, Screen.height / 2 + 60 - cursor3 * 40 - 20, 150f, 40f), cInput.GetText("J_Sprint", 1), skin.customStyles[0]);
			}
			if (cursor3 >= 3)
			{
				GUI.Label(new Rect(Screen.width / 2 + 110 - 70, Screen.height / 2 + 100 - cursor3 * 40 - 20, 150f, 40f), cInput.GetText("J_Camera Reset", 1), skin.customStyles[0]);
			}
			if (cursor3 >= 4)
			{
				GUI.Label(new Rect(Screen.width / 2 + 110 - 70, Screen.height / 2 + 140 - cursor3 * 40 - 20, 150f, 40f), cInput.GetText("J_Menu", 1), skin.customStyles[0]);
			}
			if (cursor3 >= 5)
			{
				GUI.Label(new Rect(Screen.width / 2 + 110 - 70, Screen.height / 2 + 180 - cursor3 * 40 - 20, 150f, 40f), cInput.GetText("J_Pause", 1), skin.customStyles[0]);
			}
			if (cursor3 == 6)
			{
				GUI.Label(new Rect(Screen.width / 2 + 110 - 70, Screen.height / 2 + 220 - cursor3 * 40 - 20, 150f, 40f), cInput.GetText("J_Map", 1), skin.customStyles[0]);
			}
			GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 102, Screen.height / 2 + 20 - 11, 205f, 25f), sensitivitySliderTex, ScaleMode.ScaleToFit, true);
			if (cursor4 == 0)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 - 100, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 1)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 - 88, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 2)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 - 76, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 3)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 - 63, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 4)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 - 50, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 5)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 - 37, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 6)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 - 25, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 7)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 - 12, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 8)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 + 1, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 9)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 + 13, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 10)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 + 26, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 11)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 + 39, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 12)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 + 52, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 13)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 + 64, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 14)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 + 77, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 15)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 + 88, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor4 == 16)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 9 + 100, Screen.height / 2 + 20 - 13, 18f, 29f), sensitivityBarTex, ScaleMode.StretchToFill, true);
			}
			if (cursor2 <= 7)
			{
				if (status.language == 0)
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[19], skin.customStyles[0]);
				}
				else
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[19], skin.customStyles[0]);
				}
			}
			if (cursor2 == 0)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 95 - 70, Screen.height / 2 - 140 - 20, 180f, 40f), activeTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor2 == 2)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 95 - 70, Screen.height / 2 - 100 - 20, 180f, 40f), activeTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor2 == 4)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 95 - 70, Screen.height / 2 - 60 - 20, 180f, 40f), activeTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor2 == 6)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 95 - 70, Screen.height / 2 - 20 - 20, 180f, 40f), activeTex, ScaleMode.StretchToFill, true);
			}
			else if (cursor2 == 8)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 120, Screen.height / 2 + 20 - 20, 240f, 40f), activeTex, ScaleMode.ScaleToFit, true);
				if (status.language == 0)
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[20], skin.customStyles[0]);
				}
				else
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[20], skin.customStyles[0]);
				}
			}
			else if (cursor2 == 9)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 + 120 - 120, Screen.height / 2 + 60 - 20, 240f, 40f), activeTex, ScaleMode.ScaleToFit, true);
				if (status.language == 0)
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[21], skin.customStyles[0]);
				}
				else
				{
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[21], skin.customStyles[0]);
				}
			}
			if (cursor2 == 10)
			{
				if (status.language == 0)
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 62, Screen.height / 2 + 100 - 13, 124f, 26f), defaultsTexTrueJap);
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[15], skin.customStyles[0]);
				}
				else
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 62, Screen.height / 2 + 100 - 13, 124f, 26f), defaultsTexTrueEng);
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[15], skin.customStyles[0]);
				}
			}
			else if (status.language == 0)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 62, Screen.height / 2 + 100 - 13, 124f, 26f), defaultsTexFalseJap);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 62, Screen.height / 2 + 100 - 13, 124f, 26f), defaultsTexFalseEng);
			}
			if (cursor2 == 11 && cursorAC == 0)
			{
				if (status.language == 0)
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 40 - 80, Screen.height / 2 + 140 - 13, 80f, 26f), applyTexTrueJap);
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[8], skin.customStyles[0]);
				}
				else
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 40 - 80, Screen.height / 2 + 140 - 13, 80f, 26f), applyTexTrueEng);
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[8], skin.customStyles[0]);
				}
			}
			else if (status.language == 0)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 40 - 80, Screen.height / 2 + 140 - 13, 80f, 26f), applyTexFalseJap);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 40 - 80, Screen.height / 2 + 140 - 13, 80f, 26f), applyTexFalseEng);
			}
			if (cursor2 == 11 && cursorAC == 1)
			{
				if (status.language == 0)
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 40 + 80, Screen.height / 2 + 140 - 13, 80f, 26f), backTexTrueJap);
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageJap[9], skin.customStyles[0]);
				}
				else
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 40 + 80, Screen.height / 2 + 140 - 13, 80f, 26f), backTexTrueEng);
					GUI.Label(new Rect(0f, Screen.height / 2 + 180, Screen.width, 40f), explainPassageEng[9], skin.customStyles[0]);
				}
			}
			else if (status.language == 0)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 40 + 80, Screen.height / 2 + 140 - 13, 80f, 26f), backTexFalseJap);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 40 + 80, Screen.height / 2 + 140 - 13, 80f, 26f), backTexFalseEng);
			}
		}
	}

	public virtual void Main()
	{
	}
}
