using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class LevelChanger_0028SaveLoad_0029 : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024ChangeLevel_00241168 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal AsyncOperation _0024async_00241169;

			internal string _0024NextLevelName_00241170;

			internal float _0024NextPlayer_X_00241171;

			internal float _0024NextPlayer_Y_00241172;

			internal float _0024NextPlayer_Z_00241173;

			internal float _0024NextPlayer_Rotate_00241174;

			internal int _0024startSEId_00241175;

			internal int _0024endSEId_00241176;

			internal float _0024fadeSpeed_00241177;

			internal LevelChanger_0028SaveLoad_0029 _0024self__00241178;

			public _0024(string NextLevelName, float NextPlayer_X, float NextPlayer_Y, float NextPlayer_Z, float NextPlayer_Rotate, int startSEId, int endSEId, float fadeSpeed, LevelChanger_0028SaveLoad_0029 self_)
			{
				_0024NextLevelName_00241170 = NextLevelName;
				_0024NextPlayer_X_00241171 = NextPlayer_X;
				_0024NextPlayer_Y_00241172 = NextPlayer_Y;
				_0024NextPlayer_Z_00241173 = NextPlayer_Z;
				_0024NextPlayer_Rotate_00241174 = NextPlayer_Rotate;
				_0024startSEId_00241175 = startSEId;
				_0024endSEId_00241176 = endSEId;
				_0024fadeSpeed_00241177 = fadeSpeed;
				_0024self__00241178 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Debug.Log("LoadingNextLevel...");
					_0024self__00241178.isLoading = true;
					_0024self__00241178.NextMapStatus.mapName = _0024NextLevelName_00241170;
					_0024self__00241178.NextMapStatus.mapX = _0024NextPlayer_X_00241171;
					_0024self__00241178.NextMapStatus.mapY = _0024NextPlayer_Y_00241172;
					_0024self__00241178.NextMapStatus.mapZ = _0024NextPlayer_Z_00241173;
					_0024self__00241178.NextMapStatus.playerRotation = _0024NextPlayer_Rotate_00241174;
					_0024self__00241178.endSEIdTemp = _0024endSEId_00241176;
					_0024self__00241178.black.FadeSpeed = _0024fadeSpeed_00241177;
					if (_0024self__00241178.startSE[_0024startSEId_00241175] != null)
					{
						_0024self__00241178.audio.PlayOneShot(_0024self__00241178.startSE[_0024startSEId_00241175]);
					}
					_0024self__00241178.black.FadeIn();
					result = (Yield(2, new WaitForSeconds(_0024self__00241178.black.FadeSpeed)) ? 1 : 0);
					break;
				case 2:
					_0024async_00241169 = Application.LoadLevelAsync(_0024NextLevelName_00241170);
					_0024async_00241169.allowSceneActivation = false;
					_0024self__00241178.levelChanger.enabled = true;
					_0024self__00241178.NextMapStatus.nowEventing = false;
					Application.LoadLevel(_0024NextLevelName_00241170);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024NextLevelName_00241179;

		internal float _0024NextPlayer_X_00241180;

		internal float _0024NextPlayer_Y_00241181;

		internal float _0024NextPlayer_Z_00241182;

		internal float _0024NextPlayer_Rotate_00241183;

		internal int _0024startSEId_00241184;

		internal int _0024endSEId_00241185;

		internal float _0024fadeSpeed_00241186;

		internal LevelChanger_0028SaveLoad_0029 _0024self__00241187;

		public _0024ChangeLevel_00241168(string NextLevelName, float NextPlayer_X, float NextPlayer_Y, float NextPlayer_Z, float NextPlayer_Rotate, int startSEId, int endSEId, float fadeSpeed, LevelChanger_0028SaveLoad_0029 self_)
		{
			_0024NextLevelName_00241179 = NextLevelName;
			_0024NextPlayer_X_00241180 = NextPlayer_X;
			_0024NextPlayer_Y_00241181 = NextPlayer_Y;
			_0024NextPlayer_Z_00241182 = NextPlayer_Z;
			_0024NextPlayer_Rotate_00241183 = NextPlayer_Rotate;
			_0024startSEId_00241184 = startSEId;
			_0024endSEId_00241185 = endSEId;
			_0024fadeSpeed_00241186 = fadeSpeed;
			_0024self__00241187 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024NextLevelName_00241179, _0024NextPlayer_X_00241180, _0024NextPlayer_Y_00241181, _0024NextPlayer_Z_00241182, _0024NextPlayer_Rotate_00241183, _0024startSEId_00241184, _0024endSEId_00241185, _0024fadeSpeed_00241186, _0024self__00241187);
		}
	}

	[Serializable]
	internal sealed class _0024PlayEndSE_00241188 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal LevelChanger_0028SaveLoad_0029 _0024self__00241189;

			public _0024(LevelChanger_0028SaveLoad_0029 self_)
			{
				_0024self__00241189 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(_0024self__00241189.black.firstFadeWaitTime)) ? 1 : 0);
					break;
				case 2:
					if (_0024self__00241189.endSE[_0024self__00241189.endSEIdTemp] != null)
					{
						_0024self__00241189.audio.PlayOneShot(_0024self__00241189.endSE[_0024self__00241189.endSEIdTemp]);
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

		internal LevelChanger_0028SaveLoad_0029 _0024self__00241190;

		public _0024PlayEndSE_00241188(LevelChanger_0028SaveLoad_0029 self_)
		{
			_0024self__00241190 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241190);
		}
	}

	public AudioClip[] startSE;

	public AudioClip[] endSE;

	private bool isLoading;

	private Player_Status NextMapStatus;

	private BlackOutController black;

	private string nowMapName;

	private int endSEIdTemp;

	private Transform myTransform;

	private LevelChanger levelChanger;

	public LevelChanger_0028SaveLoad_0029()
	{
		nowMapName = string.Empty;
	}

	public virtual void Start()
	{
		NextMapStatus = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		myTransform = transform;
		levelChanger = (LevelChanger)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(LevelChanger));
		levelChanger.enabled = false;
	}

	public virtual void Update()
	{
		if (Application.loadedLevelName != "[000]title")
		{
			if (Application.loadedLevelName != nowMapName)
			{
				nowMapName = Application.loadedLevelName;
				isLoading = false;
				black = (BlackOutController)GetComponent(typeof(BlackOutController));
				if (endSE[endSEIdTemp] != null)
				{
					StartCoroutine_Auto(PlayEndSE());
				}
				StartCoroutine_Auto(black.FirstFadeOut());
			}
		}
		else
		{
			nowMapName = Application.loadedLevelName;
		}
	}

	public virtual IEnumerator ChangeLevel(string NextLevelName, int NextMapId, float NextPlayer_X, float NextPlayer_Y, float NextPlayer_Z, float NextPlayer_Rotate, int startSEId, int endSEId, float fadeSpeed)
	{
		return new _0024ChangeLevel_00241168(NextLevelName, NextPlayer_X, NextPlayer_Y, NextPlayer_Z, NextPlayer_Rotate, startSEId, endSEId, fadeSpeed, this).GetEnumerator();
	}

	public virtual IEnumerator PlayEndSE()
	{
		return new _0024PlayEndSE_00241188(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
