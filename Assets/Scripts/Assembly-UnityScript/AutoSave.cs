using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class AutoSave : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024WriteFile_0024929 : GenericGenerator<YieldInstruction>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<YieldInstruction>, IEnumerator
		{
			internal ES2Writer _0024writer_0024930;

			internal AutoSave _0024self__0024931;

			public _0024(AutoSave self_)
			{
				_0024self__0024931 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(1.1f)) ? 1 : 0);
					break;
				case 2:
					if (_0024self__0024931.saveInfo.nowEventing || !_0024self__0024931.saveInfo.savePermission || _0024self__0024931.saveInfo.nowPausing || _0024self__0024931.saveInfo.switches[390] == 1 || _0024self__0024931.saveInfo.switches[411] == 1)
					{
						goto case 1;
					}
					result = (Yield(3, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				case 3:
					_0024self__0024931.mainCamera.enabled = true;
					_0024self__0024931.rt = new RenderTexture(_0024self__0024931.resWidth, _0024self__0024931.resHeight, 24);
					_0024self__0024931.mainCamera.targetTexture = _0024self__0024931.rt;
					_0024self__0024931.screenShot = new Texture2D(_0024self__0024931.resWidth, _0024self__0024931.resHeight, TextureFormat.RGB24, false);
					_0024self__0024931.mainCamera.Render();
					RenderTexture.active = _0024self__0024931.rt;
					_0024self__0024931.screenShot.ReadPixels(new Rect(0f, 0f, _0024self__0024931.resWidth, _0024self__0024931.resHeight), 0, 0);
					_0024self__0024931.MakeGrayscale(_0024self__0024931.screenShot);
					_0024self__0024931.rtTemp = new RenderTexture(Screen.width, Screen.height, 24);
					_0024self__0024931.mainCamera.targetTexture = _0024self__0024931.rtTemp;
					_0024self__0024931.mainCamera.Render();
					RenderTexture.active = _0024self__0024931.rtTemp;
					_0024self__0024931.mainCamera.gameObject.camera.targetTexture = null;
					RenderTexture.active = null;
					UnityEngine.Object.Destroy(_0024self__0024931.rt);
					UnityEngine.Object.Destroy(_0024self__0024931.rtTemp);
					_0024self__0024931.saveInfo.screenTexture0 = _0024self__0024931.screenShot;
					_0024writer_0024930 = ES2Writer.Create("save/savedata0.sav?encrypt=true&encryptiontype=obfuscate&password=fundoshi");
					_0024writer_0024930.Write(_0024self__0024931.saveInfo.playTimeSeconds, "playTimeSeconds");
					_0024writer_0024930.Write(_0024self__0024931.saveInfo.playTimeMinutes, "playTimeMinutes");
					_0024writer_0024930.Write(_0024self__0024931.saveInfo.playTimeHours, "playTimeHours");
					_0024writer_0024930.Write(DateTime.Now.Year, "nowYear");
					_0024writer_0024930.Write(DateTime.Now.Month, "nowMonth");
					_0024writer_0024930.Write(DateTime.Now.Day, "nowDay");
					_0024writer_0024930.Write(_0024self__0024931.saveInfo.mapName, "mapName");
					_0024writer_0024930.Write(_0024self__0024931.saveInfo.mapX, "mapX");
					_0024writer_0024930.Write(_0024self__0024931.saveInfo.mapY, "mapY");
					_0024writer_0024930.Write(_0024self__0024931.saveInfo.mapZ, "mapZ");
					_0024writer_0024930.Write(_0024self__0024931.saveInfo.playerRotation, "playerRotation");
					_0024writer_0024930.Write(_0024self__0024931.saveInfo.footStepId, "footStepId");
					_0024writer_0024930.Write(_0024self__0024931.saveInfo.footEffectId, "footEffectId");
					_0024self__0024931.i = 0;
					while (_0024self__0024931.i < _0024self__0024931.saveInfo.switches.Length)
					{
						_0024writer_0024930.Write(_0024self__0024931.saveInfo.switches[_0024self__0024931.i], "switches" + _0024self__0024931.i);
						_0024self__0024931.i++;
					}
					_0024self__0024931.i = 0;
					while (_0024self__0024931.i < _0024self__0024931.saveInfo.variables.Length)
					{
						_0024writer_0024930.Write(_0024self__0024931.saveInfo.variables[_0024self__0024931.i], "variables" + _0024self__0024931.i);
						_0024self__0024931.i++;
					}
					_0024writer_0024930.Write(_0024self__0024931.saveInfo.cameraX, "cameraX");
					_0024writer_0024930.Write(_0024self__0024931.saveInfo.cameraY, "cameraY");
					_0024writer_0024930.Write(_0024self__0024931.saveInfo.cameraZ, "cameraZ");
					_0024writer_0024930.Write(_0024self__0024931.saveInfo.cameraRotX, "cameraRotX");
					_0024writer_0024930.Write(_0024self__0024931.saveInfo.cameraRotY, "cameraRotY");
					_0024self__0024931.i = 0;
					while (_0024self__0024931.i < _0024self__0024931.saveInfo.item.Length)
					{
						_0024writer_0024930.Write(_0024self__0024931.saveInfo.item[_0024self__0024931.i], "item" + _0024self__0024931.i);
						_0024self__0024931.i++;
					}
					_0024self__0024931.i = 0;
					while (_0024self__0024931.i < _0024self__0024931.saveInfo.file.Length)
					{
						_0024writer_0024930.Write(_0024self__0024931.saveInfo.file[_0024self__0024931.i], "file" + _0024self__0024931.i);
						_0024self__0024931.i++;
					}
					_0024writer_0024930.Write(_0024self__0024931.saveInfo.screenTexture0, "thumbnail");
					_0024writer_0024930.Save();
					_0024writer_0024930.Dispose();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AutoSave _0024self__0024932;

		public _0024WriteFile_0024929(AutoSave self_)
		{
			_0024self__0024932 = self_;
		}

		public override IEnumerator<YieldInstruction> GetEnumerator()
		{
			return new _0024(_0024self__0024932);
		}
	}

	private Player_Status saveInfo;

	private int i;

	private BlackOutController blackout;

	private int resWidth;

	private int resHeight;

	private RenderTexture rt;

	private RenderTexture rtTemp;

	private Texture2D screenShot;

	private Camera mainCamera;

	private Camera_Controller cameraStatus;

	public AutoSave()
	{
		resWidth = 256;
		resHeight = 256;
	}

	public virtual void Start()
	{
		saveInfo = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent("Player_Status");
		blackout = (BlackOutController)GetComponent(typeof(BlackOutController));
		mainCamera = (Camera)GameObject.FindWithTag("MainCamera").GetComponent(typeof(Camera));
		cameraStatus = (Camera_Controller)GameObject.FindWithTag("MainCamera").GetComponent(typeof(Camera_Controller));
		if (saveInfo.saveLoadFlag != 2 && saveInfo.saveLoadFlag != 3 && saveInfo.savePermission && !saveInfo.nowPausing && saveInfo.switches[390] != 1 && saveInfo.switches[411] != 1)
		{
			StartCoroutine_Auto(WriteFile());
		}
	}

	public virtual IEnumerator WriteFile()
	{
		return new _0024WriteFile_0024929(this).GetEnumerator();
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

	public virtual void Main()
	{
	}
}
