using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class LevelChanger : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024ChangeLevel_00241191 : GenericGenerator<YieldInstruction>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<YieldInstruction>, IEnumerator
		{
			internal AsyncOperation _0024async_00241192;

			internal string _0024NextLevelName_00241193;

			internal float _0024NextPlayer_X_00241194;

			internal float _0024NextPlayer_Y_00241195;

			internal float _0024NextPlayer_Z_00241196;

			internal float _0024NextPlayer_Rotate_00241197;

			internal float _0024NextCameraX_00241198;

			internal float _0024NextCameraY_00241199;

			internal float _0024NextCameraZ_00241200;

			internal float _0024NextCameraRotX_00241201;

			internal float _0024NextCameraRotY_00241202;

			internal int _0024startSEId_00241203;

			internal int _0024endSEId_00241204;

			internal bool _0024fade_00241205;

			internal float _0024fadeSpeed_00241206;

			internal Color _0024fadeColor_00241207;

			internal LevelChanger _0024self__00241208;

			public _0024(string NextLevelName, float NextPlayer_X, float NextPlayer_Y, float NextPlayer_Z, float NextPlayer_Rotate, float NextCameraX, float NextCameraY, float NextCameraZ, float NextCameraRotX, float NextCameraRotY, int startSEId, int endSEId, bool fade, float fadeSpeed, Color fadeColor, LevelChanger self_)
			{
				_0024NextLevelName_00241193 = NextLevelName;
				_0024NextPlayer_X_00241194 = NextPlayer_X;
				_0024NextPlayer_Y_00241195 = NextPlayer_Y;
				_0024NextPlayer_Z_00241196 = NextPlayer_Z;
				_0024NextPlayer_Rotate_00241197 = NextPlayer_Rotate;
				_0024NextCameraX_00241198 = NextCameraX;
				_0024NextCameraY_00241199 = NextCameraY;
				_0024NextCameraZ_00241200 = NextCameraZ;
				_0024NextCameraRotX_00241201 = NextCameraRotX;
				_0024NextCameraRotY_00241202 = NextCameraRotY;
				_0024startSEId_00241203 = startSEId;
				_0024endSEId_00241204 = endSEId;
				_0024fade_00241205 = fade;
				_0024fadeSpeed_00241206 = fadeSpeed;
				_0024fadeColor_00241207 = fadeColor;
				_0024self__00241208 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Debug.Log("LoadingNextLevel...");
					if (RuntimeServices.EqualityOperator(_0024fadeColor_00241207, null))
					{
						_0024fadeColor_00241207 = Color.black;
					}
					_0024self__00241208.textureFadeColor.r = 1f - _0024fadeColor_00241207.r;
					_0024self__00241208.textureFadeColor.g = 1f - _0024fadeColor_00241207.g;
					_0024self__00241208.textureFadeColor.b = 1f - _0024fadeColor_00241207.b;
					_0024self__00241208.NextMapStatus.nowChangeLeveling = true;
					_0024self__00241208.player = null;
					_0024self__00241208.mainCamera = null;
					_0024self__00241208.NextMapStatus.mapName = _0024NextLevelName_00241193;
					_0024self__00241208.NextMapStatus.mapX = _0024NextPlayer_X_00241194;
					_0024self__00241208.NextMapStatus.mapY = _0024NextPlayer_Y_00241195;
					_0024self__00241208.NextMapStatus.mapZ = _0024NextPlayer_Z_00241196;
					_0024self__00241208.NextMapStatus.playerRotation = _0024NextPlayer_Rotate_00241197;
					_0024self__00241208.NextMapStatus.cameraX = _0024NextCameraX_00241198;
					_0024self__00241208.NextMapStatus.cameraY = _0024NextCameraY_00241199;
					_0024self__00241208.NextMapStatus.cameraZ = _0024NextCameraZ_00241200;
					_0024self__00241208.NextMapStatus.cameraRotX = _0024NextCameraRotX_00241201;
					_0024self__00241208.NextMapStatus.cameraRotY = _0024NextCameraRotY_00241202;
					_0024self__00241208.endSEIdTemp = _0024endSEId_00241204;
					_0024self__00241208.black.FadeSpeed = _0024fadeSpeed_00241206;
					if (_0024self__00241208.startSE[_0024startSEId_00241203] != null)
					{
						_0024self__00241208.audio.PlayOneShot(_0024self__00241208.startSE[_0024startSEId_00241203]);
					}
					if (_0024fade_00241205)
					{
						_0024self__00241208.NextMapStatus.fadeFlag = true;
						_0024self__00241208.black.SetFadeColor(_0024fadeColor_00241207);
						_0024self__00241208.NextMapStatus.fadeColor = _0024fadeColor_00241207;
						_0024self__00241208.black.FadeIn();
						result = (Yield(2, new WaitForSeconds(_0024self__00241208.black.FadeSpeed)) ? 1 : 0);
						break;
					}
					_0024self__00241208.NextMapStatus.fadeFlag = false;
					goto case 2;
				case 2:
					_0024self__00241208.isLoading = true;
					_0024async_00241192 = Application.LoadLevelAsync(_0024NextLevelName_00241193);
					_0024async_00241192.allowSceneActivation = false;
					goto case 3;
				case 3:
					if (_0024async_00241192.progress < 0.9f)
					{
						result = (Yield(3, new WaitForEndOfFrame()) ? 1 : 0);
						break;
					}
					_0024self__00241208.isLoading = false;
					goto IL_034c;
				case 4:
					_0024async_00241192.allowSceneActivation = true;
					_0024self__00241208.NextMapStatus.nowChangeLeveling = false;
					_0024self__00241208.NextMapStatus.nowEventing = false;
					goto IL_034c;
				case 1:
					{
						result = 0;
						break;
					}
					IL_034c:
					if (!_0024async_00241192.isDone)
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

		internal string _0024NextLevelName_00241209;

		internal float _0024NextPlayer_X_00241210;

		internal float _0024NextPlayer_Y_00241211;

		internal float _0024NextPlayer_Z_00241212;

		internal float _0024NextPlayer_Rotate_00241213;

		internal float _0024NextCameraX_00241214;

		internal float _0024NextCameraY_00241215;

		internal float _0024NextCameraZ_00241216;

		internal float _0024NextCameraRotX_00241217;

		internal float _0024NextCameraRotY_00241218;

		internal int _0024startSEId_00241219;

		internal int _0024endSEId_00241220;

		internal bool _0024fade_00241221;

		internal float _0024fadeSpeed_00241222;

		internal Color _0024fadeColor_00241223;

		internal LevelChanger _0024self__00241224;

		public _0024ChangeLevel_00241191(string NextLevelName, float NextPlayer_X, float NextPlayer_Y, float NextPlayer_Z, float NextPlayer_Rotate, float NextCameraX, float NextCameraY, float NextCameraZ, float NextCameraRotX, float NextCameraRotY, int startSEId, int endSEId, bool fade, float fadeSpeed, Color fadeColor, LevelChanger self_)
		{
			_0024NextLevelName_00241209 = NextLevelName;
			_0024NextPlayer_X_00241210 = NextPlayer_X;
			_0024NextPlayer_Y_00241211 = NextPlayer_Y;
			_0024NextPlayer_Z_00241212 = NextPlayer_Z;
			_0024NextPlayer_Rotate_00241213 = NextPlayer_Rotate;
			_0024NextCameraX_00241214 = NextCameraX;
			_0024NextCameraY_00241215 = NextCameraY;
			_0024NextCameraZ_00241216 = NextCameraZ;
			_0024NextCameraRotX_00241217 = NextCameraRotX;
			_0024NextCameraRotY_00241218 = NextCameraRotY;
			_0024startSEId_00241219 = startSEId;
			_0024endSEId_00241220 = endSEId;
			_0024fade_00241221 = fade;
			_0024fadeSpeed_00241222 = fadeSpeed;
			_0024fadeColor_00241223 = fadeColor;
			_0024self__00241224 = self_;
		}

		public override IEnumerator<YieldInstruction> GetEnumerator()
		{
			return new _0024(_0024NextLevelName_00241209, _0024NextPlayer_X_00241210, _0024NextPlayer_Y_00241211, _0024NextPlayer_Z_00241212, _0024NextPlayer_Rotate_00241213, _0024NextCameraX_00241214, _0024NextCameraY_00241215, _0024NextCameraZ_00241216, _0024NextCameraRotX_00241217, _0024NextCameraRotY_00241218, _0024startSEId_00241219, _0024endSEId_00241220, _0024fade_00241221, _0024fadeSpeed_00241222, _0024fadeColor_00241223, _0024self__00241224);
		}
	}

	[Serializable]
	internal sealed class _0024PlayEndSE_00241225 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal LevelChanger _0024self__00241226;

			public _0024(LevelChanger self_)
			{
				_0024self__00241226 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(_0024self__00241226.black.firstFadeWaitTime)) ? 1 : 0);
					break;
				case 2:
					if (_0024self__00241226.endSE[_0024self__00241226.endSEIdTemp] != null)
					{
						_0024self__00241226.audio.PlayOneShot(_0024self__00241226.endSE[_0024self__00241226.endSEIdTemp]);
					}
					_0024self__00241226.endSEIdTemp = 0;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal LevelChanger _0024self__00241227;

		public _0024PlayEndSE_00241225(LevelChanger self_)
		{
			_0024self__00241227 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241227);
		}
	}

	public AudioClip[] startSE;

	public AudioClip[] endSE;

	public Texture2D loadingTexture;

	public Vector2 textureSize;

	public Vector2 offset;

	public float textureFadeSpeed;

	public float textureFlickSpeed;

	public float textureFlickAmount;

	private bool isLoading;

	private Player_Controller player;

	private Camera_Controller mainCamera;

	private Player_Status NextMapStatus;

	private BlackOutController black;

	private string nowMapName;

	private int endSEIdTemp;

	private Transform myTransform;

	private Transform playerTransform;

	private float textureAlpha;

	private Color textureFadeColor;

	public LevelChanger()
	{
		nowMapName = string.Empty;
		textureFadeColor = Color.black;
	}

	public virtual void Awake()
	{
		NextMapStatus = (Player_Status)GetComponent(typeof(Player_Status));
		myTransform = transform;
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
		if (Application.loadedLevelName != "[000]title")
		{
			if (Application.loadedLevelName != nowMapName && player == null)
			{
				if (!(player == null))
				{
					return;
				}
				nowMapName = Application.loadedLevelName;
				isLoading = false;
				if (Application.loadedLevelName != "[00-]saveload")
				{
					player = (Player_Controller)GameObject.FindWithTag("Player").GetComponent(typeof(Player_Controller));
					mainCamera = (Camera_Controller)GameObject.FindWithTag("MainCamera").GetComponent(typeof(Camera_Controller));
					black = (BlackOutController)GameObject.Find("SystemObject").GetComponent(typeof(BlackOutController));
					if (player != null)
					{
						playerTransform = player.gameObject.transform;
					}
				}
				if (endSE[endSEIdTemp] != null)
				{
					StartCoroutine_Auto(PlayEndSE());
				}
				if (black != null)
				{
					if (NextMapStatus.fadeFlag)
					{
						StartCoroutine_Auto(black.FirstFadeOut());
						return;
					}
					black.ChangeFadeFlag(false);
					NextMapStatus.fadeFlag = true;
				}
			}
			else if (player != null)
			{
				myTransform.position = playerTransform.position;
			}
		}
		else
		{
			nowMapName = Application.loadedLevelName;
		}
	}

	public virtual IEnumerator ChangeLevel(string NextLevelName, int NextMapId, float NextPlayer_X, float NextPlayer_Y, float NextPlayer_Z, float NextPlayer_Rotate, float NextCameraX, float NextCameraY, float NextCameraZ, float NextCameraRotX, float NextCameraRotY, int startSEId, int endSEId, bool fade, float fadeSpeed, Color fadeColor)
	{
		return new _0024ChangeLevel_00241191(NextLevelName, NextPlayer_X, NextPlayer_Y, NextPlayer_Z, NextPlayer_Rotate, NextCameraX, NextCameraY, NextCameraZ, NextCameraRotX, NextCameraRotY, startSEId, endSEId, fade, fadeSpeed, fadeColor, this).GetEnumerator();
	}

	public virtual IEnumerator PlayEndSE()
	{
		return new _0024PlayEndSE_00241225(this).GetEnumerator();
	}

	public virtual void OnGUI()
	{
		if (!(textureAlpha <= 0f))
		{
			GUI.depth = -16;
			float r = textureFadeColor.r;
			Color color = GUI.color;
			float num = (color.r = r);
			Color color2 = (GUI.color = color);
			float g = textureFadeColor.g;
			Color color4 = GUI.color;
			float num2 = (color4.g = g);
			Color color5 = (GUI.color = color4);
			float b = textureFadeColor.b;
			Color color7 = GUI.color;
			float num3 = (color7.b = b);
			Color color8 = (GUI.color = color7);
			if (!(textureAlpha >= textureFlickAmount))
			{
				float a = textureAlpha;
				Color color10 = GUI.color;
				float num4 = (color10.a = a);
				Color color11 = (GUI.color = color10);
			}
			else
			{
				float a2 = Mathf.Lerp(textureAlpha, textureAlpha + Mathf.Sin(Time.time * textureFlickSpeed) * textureFlickAmount, textureFlickSpeed * Time.deltaTime);
				Color color13 = GUI.color;
				float num5 = (color13.a = a2);
				Color color14 = (GUI.color = color13);
			}
			GUI.DrawTexture(new Rect((float)Screen.width - textureSize.x - offset.x, (float)Screen.height - textureSize.y - offset.y, textureSize.x, textureSize.y), loadingTexture, ScaleMode.ScaleToFit, true);
		}
	}

	public virtual void Main()
	{
	}
}
