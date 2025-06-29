using System;
using System.IO;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class Player_Status : MonoBehaviour
{
	public string mapName;

	public float mapX;

	public float mapY;

	public float mapZ;

	public float playerRotation;

	public float cameraX;

	public float cameraY;

	public float cameraZ;

	public float cameraRotX;

	public float cameraRotY;

	public int footStepId;

	public int footEffectId;

	public int[] switches;

	public float[] variables;

	public int[] tempSwitches;

	public float playTimeSeconds;

	public int playTimeMinutes;

	public int playTimeHours;

	public int nowYear;

	public int nowMonth;

	public int nowDay;

	public int[] item;

	public int[] file;

	public int language;

	public int textureQuality;

	public int anisotropicFiltering;

	public int shadowQuality;

	public int antialiasing;

	public int Vsync;

	public float mouseSensitivity;

	public int mouseInverted;

	public float stickSensitivity;

	public int stickInverted;

	public int clearFlag;

	public int walkFlag;

	public int latestId;

	private string filename;

	private string extension;

	private int i;

	public Font defaultFont;

	public Item[] itemDatabase;

	public FileItem[] fileDatabase;

	public int[] itemSortNumber;

	public int[] fileSortNumber;

	public bool nowEventing;

	public bool nowPausing;

	public bool nowMenuing;

	public bool nowChangeLeveling;

	public bool pausePermission;

	public bool loadPermission;

	public bool savePermission;

	public bool menuPermission;

	public int saveLoadFlag;

	public bool fadeFlag;

	public bool audioFadeFlag;

	public Texture2D captureScreen;

	public Texture2D saveCaptureScreen;

	public Texture2D screenTexture0;

	public Texture2D screenTexture1;

	public Texture2D screenTexture2;

	public Texture2D screenTexture3;

	public Texture2D screenTexture4;

	public Color fadeColor;

	public bool bootFlag;

	public Texture2D purposeIcon;

	public bool japaneseOnly;

	public bool isDebugRom;

	private float moveSpeedMultiply;

	private string prevMapName;

	private Player_Controller playerControl;

	private bool showPurposeFlag;

	private float showPurposeCount;

	public Player_Status()
	{
		mapName = string.Empty;
		textureQuality = 2;
		anisotropicFiltering = 1;
		shadowQuality = 3;
		antialiasing = 1;
		mouseSensitivity = 200f;
		stickSensitivity = 140f;
		filename = "system";
		extension = ".sav";
		pausePermission = true;
		loadPermission = true;
		savePermission = true;
		menuPermission = true;
		fadeFlag = true;
		fadeColor = Color.black;
		japaneseOnly = true;
		moveSpeedMultiply = 1f;
		prevMapName = string.Empty;
	}

	public virtual void Awake()
	{
		switches = new int[999];
		for (i = 0; i < switches.Length; i++)
		{
			switches[i] = 0;
		}
		variables = new float[999];
		for (i = 0; i < variables.Length; i++)
		{
			variables[i] = 0f;
		}
		cInput.SetKey("Left", "A", Keys.LeftArrow);
		cInput.SetKey("Right", "D", Keys.RightArrow);
		cInput.SetKey("Up", "W", Keys.UpArrow);
		cInput.SetKey("Down", "S", Keys.DownArrow);
		cInput.SetKey("Mouse Left", Keys.MouseLeft);
		cInput.SetKey("Mouse Right", Keys.MouseRight);
		cInput.SetKey("Mouse Up", Keys.MouseUp);
		cInput.SetKey("Mouse Down", Keys.MouseDown);
		cInput.SetKey("Action", "E", Keys.Mouse0);
		cInput.SetKey("Sprint", "C", Keys.LeftShift);
		cInput.SetKey("Camera Reset", "Q", Keys.Mouse2);
		cInput.SetKey("Menu", "J", Keys.Tab);
		cInput.SetKey("Pause", "P", Keys.Escape);
		cInput.SetAxis("Horizontal", "Left", "Right");
		cInput.SetAxis("Vertical", "Down", "Up");
		cInput.SetAxis("Mouse X", "Mouse Left", "Mouse Right");
		cInput.SetAxis("Mouse Y", "Mouse Down", "Mouse Up");
		cInput.SetKey("Map", "M", "X");
		cInput.SetKey("J_Left", "Joy1 Axis 1-");
		cInput.SetKey("J_Right", "Joy1 Axis 1+");
		cInput.SetKey("J_Up", "Joy1 Axis 2-");
		cInput.SetKey("J_Down", "Joy1 Axis 2+");
		cInput.SetKey("J_Mouse Left", "Joy1 Axis 4-");
		cInput.SetKey("J_Mouse Right", "Joy1 Axis 4+");
		cInput.SetKey("J_Mouse Up", "Joy1 Axis 5-");
		cInput.SetKey("J_Mouse Down", "Joy1 Axis 5+");
		cInput.SetKey("J_Action", "Joystick1Button0");
		cInput.SetKey("J_Sprint", "Joystick1Button1");
		cInput.SetKey("J_Camera Reset", "Joystick1Button9");
		cInput.SetKey("J_Menu", "Joystick1Button7");
		cInput.SetKey("J_Pause", "Joystick1Button6");
		cInput.SetAxis("J_Horizontal", "J_Left", "J_Right");
		cInput.SetAxis("J_Vertical", "J_Down", "J_Up");
		cInput.SetAxis("J_Mouse X", "J_Mouse Left", "J_Mouse Right");
		cInput.SetAxis("J_Mouse Y", "J_Mouse Down", "J_Mouse Up");
		cInput.SetKey("J_Map", "Joystick1Button3");
		cInput.SetKey("DPad_Left", "Joy1 Axis 6-");
		cInput.SetKey("DPad_Right", "Joy1 Axis 6+");
		cInput.SetKey("DPad_Up", "Joy1 Axis 7+");
		cInput.SetKey("DPad_Down", "Joy1 Axis 7-");
		cInput.SetAxis("DPad_Horizontal", "DPad_Left", "DPad_Right");
		cInput.SetAxis("DPad_Vertical", "DPad_Down", "DPad_Up");
		if (!ES2.Exists(filename + extension))
		{
			if (!japaneseOnly)
			{
				if (Application.systemLanguage.ToString() == "Japanese")
				{
					language = 0;
				}
				else
				{
					language = 1;
				}
			}
			else
			{
				language = 0;
			}
			WriteSystemFile();
		}
		ReadSystemFile();
		Application.targetFrameRate = 60;
		UnityEngine.Object.DontDestroyOnLoad(this);
	}

	public virtual void Start()
	{
		if (shadowQuality == 0)
		{
			QualitySettings.SetQualityLevel(0);
			QualitySettings.shadowCascades = 0;
		}
		else if (shadowQuality == 1)
		{
			QualitySettings.SetQualityLevel(0);
		}
		else if (shadowQuality == 2)
		{
			QualitySettings.SetQualityLevel(1);
		}
		else if (shadowQuality == 3)
		{
			QualitySettings.SetQualityLevel(2);
		}
		else
		{
			QualitySettings.SetQualityLevel(3);
		}
		if (textureQuality == 0)
		{
			QualitySettings.masterTextureLimit = 2;
		}
		else if (textureQuality == 1)
		{
			QualitySettings.masterTextureLimit = 1;
		}
		else
		{
			QualitySettings.masterTextureLimit = 0;
		}
		if (anisotropicFiltering == 0)
		{
			QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
		}
		else
		{
			QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
		}
		if (antialiasing == 0)
		{
			QualitySettings.antiAliasing = 0;
		}
		else if (antialiasing == 1)
		{
			QualitySettings.antiAliasing = 2;
		}
		else if (antialiasing == 2)
		{
			QualitySettings.antiAliasing = 4;
		}
		else
		{
			QualitySettings.antiAliasing = 8;
		}
		if (Vsync == 0)
		{
			QualitySettings.vSyncCount = 0;
		}
		else
		{
			QualitySettings.vSyncCount = 1;
		}
		if (mouseInverted == 0)
		{
			cInput.AxisInverted("Mouse Y", false);
		}
		else
		{
			cInput.AxisInverted("Mouse Y", true);
		}
		if (stickInverted == 0)
		{
			cInput.AxisInverted("J_Mouse X", false);
			cInput.AxisInverted("J_Mouse Y", false);
		}
		else if (stickInverted == 1)
		{
			cInput.AxisInverted("J_Mouse X", true);
			cInput.AxisInverted("J_Mouse Y", false);
		}
		else if (stickInverted == 2)
		{
			cInput.AxisInverted("J_Mouse X", false);
			cInput.AxisInverted("J_Mouse Y", true);
		}
		else if (stickInverted == 3)
		{
			cInput.AxisInverted("J_Mouse X", true);
			cInput.AxisInverted("J_Mouse Y", true);
		}
		LoadThumbTexture();
	}

	public virtual void Update()
	{
		if (showPurposeFlag && (nowPausing || nowMenuing || Mathf.Approximately(Time.timeScale, 0f)))
		{
			ShowPurpose(false);
		}
		if (!(playTimeSeconds < 60f))
		{
			playTimeMinutes++;
			playTimeSeconds = 0f;
		}
		if (playTimeMinutes >= 60)
		{
			playTimeHours++;
			playTimeMinutes = 0;
		}
		if (Application.loadedLevelName != "[000]title")
		{
			playTimeSeconds += Time.unscaledDeltaTime;
		}
		if (showPurposeFlag && (Application.loadedLevelName == "[000]title" || Application.loadedLevelName == "[00-]saveload" || Mathf.Approximately(Time.timeScale, 0f)))
		{
			ShowPurpose(false);
		}
		if (!isDebugRom)
		{
			return;
		}
		if (prevMapName != Application.loadedLevelName)
		{
			prevMapName = Application.loadedLevelName;
			GameObject gameObject = null;
			gameObject = GameObject.FindWithTag("Player");
			if (gameObject != null)
			{
				playerControl = (Player_Controller)gameObject.GetComponent(typeof(Player_Controller));
			}
		}
		if (playerControl != null)
		{
			playerControl.moveSpeedMultiply = moveSpeedMultiply;
		}
	}

	public virtual void WriteSystemFile()
	{
		ES2Writer eS2Writer = ES2Writer.Create(filename + extension + "?encrypt=true&encryptiontype=obfuscate&password=fundoshi");
		eS2Writer.Write(language, "language");
		eS2Writer.Write(textureQuality, "textureQuality");
		eS2Writer.Write(anisotropicFiltering, "anisotropicFiltering");
		eS2Writer.Write(shadowQuality, "shadowQuality");
		eS2Writer.Write(antialiasing, "antialiasing");
		eS2Writer.Write(Vsync, "Vsync");
		eS2Writer.Write(mouseSensitivity, "mouseSensitivity");
		eS2Writer.Write(mouseInverted, "mouseInverted");
		eS2Writer.Write(stickSensitivity, "stickSensitivity");
		eS2Writer.Write(stickInverted, "stickInverted");
		eS2Writer.Write(clearFlag, "clearFlag");
		eS2Writer.Write(walkFlag, "walkFlag");
		eS2Writer.Write(latestId, "latestId");
		eS2Writer.Save();
		eS2Writer.Dispose();
	}

	public virtual void ReadSystemFile()
	{
		if (ES2.Exists(filename + extension))
		{
			ES2Reader eS2Reader = ES2Reader.Create(filename + extension + "?encrypt=true&encryptiontype=obfuscate&password=fundoshi");
			language = eS2Reader.Read<int>("language");
			textureQuality = eS2Reader.Read<int>("textureQuality");
			anisotropicFiltering = eS2Reader.Read<int>("anisotropicFiltering");
			shadowQuality = eS2Reader.Read<int>("shadowQuality");
			antialiasing = eS2Reader.Read<int>("antialiasing");
			Vsync = eS2Reader.Read<int>("Vsync");
			mouseSensitivity = eS2Reader.Read<float>("mouseSensitivity");
			mouseInverted = eS2Reader.Read<int>("mouseInverted");
			stickSensitivity = eS2Reader.Read<float>("stickSensitivity");
			stickInverted = eS2Reader.Read<int>("stickInverted");
			clearFlag = eS2Reader.Read<int>("clearFlag");
			walkFlag = eS2Reader.Read<int>("walkFlag");
			latestId = eS2Reader.Read<int>("latestId");
			eS2Reader.Dispose();
		}
	}

	public virtual void LoadThumbTexture()
	{
		if (ES2.Exists("save/savedata0.sav"))
		{
			screenTexture0 = ES2.Load<Texture2D>("save/savedata0.sav?tag=thumbnail&encrypt=true&encryptiontype=obfuscate&password=fundoshi");
		}
		if (ES2.Exists("save/savedata1.sav"))
		{
			screenTexture1 = ES2.Load<Texture2D>("save/savedata1.sav?tag=thumbnail&encrypt=true&encryptiontype=obfuscate&password=fundoshi");
		}
		if (ES2.Exists("save/savedata2.sav"))
		{
			screenTexture2 = ES2.Load<Texture2D>("save/savedata2.sav?tag=thumbnail&encrypt=true&encryptiontype=obfuscate&password=fundoshi");
		}
		if (ES2.Exists("save/savedata3.sav"))
		{
			screenTexture3 = ES2.Load<Texture2D>("save/savedata3.sav?tag=thumbnail&encrypt=true&encryptiontype=obfuscate&password=fundoshi");
		}
		if (ES2.Exists("save/savedata4.sav"))
		{
			screenTexture4 = ES2.Load<Texture2D>("save/savedata4.sav?tag=thumbnail&encrypt=true&encryptiontype=obfuscate&password=fundoshi");
		}
	}

	public virtual byte[] ReadPngFile(string path)
	{
		FileStream input = new FileStream(path, FileMode.Open, FileAccess.Read);
		BinaryReader binaryReader = new BinaryReader(input);
		byte[] result = binaryReader.ReadBytes(RuntimeServices.UnboxInt32(UnityRuntimeServices.Invoke(typeof(UnityBuiltins), "parseInt", new object[1] { binaryReader.BaseStream.Length }, typeof(MonoBehaviour))));
		binaryReader.Close();
		return result;
	}

	public virtual Texture2D ReadTexture(string path, int width, int height)
	{
		byte[] array = null;
		array = ReadPngFile(path);
		Texture2D texture2D = null;
		texture2D = new Texture2D(width, height);
		texture2D.LoadImage(array);
		return texture2D;
	}

	public virtual void ChangeFadeFlag(int id)
	{
		if (id == 0)
		{
			fadeFlag = false;
		}
		else
		{
			fadeFlag = true;
		}
	}

	public virtual void ChangeAudioFadeFlag(bool flag)
	{
		if (flag)
		{
			audioFadeFlag = true;
		}
		else
		{
			audioFadeFlag = false;
		}
	}

	public virtual void ChangeClearFlag(int num)
	{
		clearFlag = num;
		WriteSystemFile();
	}

	public virtual void ShowPurpose(bool flag)
	{
		if (!(Application.loadedLevelName == "[00-]specimenroom1_player") && showPurposeFlag != flag)
		{
			showPurposeFlag = flag;
			showPurposeCount = 0f;
		}
	}

	public virtual void OnGUI()
	{
		if (!showPurposeFlag)
		{
			return;
		}
		GUI.depth = -16;
		float r = Mathf.Clamp(Mathf.Sin(showPurposeCount * 3f) * 0.1f + 0.9f, 0f, 1f);
		Color color = GUI.color;
		float num = (color.r = r);
		Color color2 = (GUI.color = color);
		float g = Mathf.Clamp(Mathf.Sin(showPurposeCount * 3f) * 0.1f + 0.9f, 0f, 1f);
		Color color4 = GUI.color;
		float num2 = (color4.g = g);
		Color color5 = (GUI.color = color4);
		float b = Mathf.Clamp(Mathf.Sin(showPurposeCount * 3f) * 0.1f + 0.9f, 0f, 1f);
		Color color7 = GUI.color;
		float num3 = (color7.b = b);
		Color color8 = (GUI.color = color7);
		if (!(showPurposeCount >= 4f))
		{
			float a = Mathf.Clamp(showPurposeCount * 1.5f + Mathf.Sin(showPurposeCount * 2f) * 0.5f, 0f, 1f);
			Color color10 = GUI.color;
			float num4 = (color10.a = a);
			Color color11 = (GUI.color = color10);
			GUI.DrawTexture(new Rect(Screen.width - purposeIcon.width - 8, 8f, purposeIcon.width, purposeIcon.height), purposeIcon, ScaleMode.ScaleToFit, true);
			showPurposeCount += Time.deltaTime;
			return;
		}
		float a2 = Mathf.Clamp(showPurposeCount * 1.5f + Mathf.Sin(showPurposeCount * 2f) * 0.5f, 0f, 1f) * (1f - (showPurposeCount - 4f));
		Color color13 = GUI.color;
		float num5 = (color13.a = a2);
		Color color14 = (GUI.color = color13);
		GUI.DrawTexture(new Rect(Screen.width - purposeIcon.width - 8, 8f, purposeIcon.width, purposeIcon.height), purposeIcon, ScaleMode.ScaleToFit, true);
		showPurposeCount += Time.deltaTime;
		if (!(1f - (showPurposeCount - 4f) > 0f))
		{
			ShowPurpose(false);
		}
	}

	public virtual void GetAllItemsAndFiles()
	{
		for (i = 15; i < itemDatabase.Length; i++)
		{
			if (itemDatabase[i].itemNameJap != string.Empty)
			{
				item[i] = 1;
			}
		}
		for (i = 15; i < fileDatabase.Length; i++)
		{
			if (fileDatabase[i].fileNameJap != string.Empty)
			{
				file[i] = 1;
			}
		}
	}

	public virtual void SetMoveSpeedMultiply(float amount)
	{
		moveSpeedMultiply = amount;
	}

	public virtual void WaitOphelia()
	{
		if (switches[802] != 0)
		{
			switches[408] = 1;
			variables[61] = 2f;
		}
	}

	public virtual void SummonOphelia()
	{
		if (switches[802] != 0)
		{
			switches[408] = 0;
			variables[61] = 2f;
			GameObject gameObject = null;
			gameObject = GameObject.FindWithTag("NPC");
			if (gameObject != null)
			{
				gameObject.SendMessage("SpawnEnter", SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	public virtual void ToggleRandomBgm()
	{
		variables[113] = 5f;
	}

	public virtual void Main()
	{
	}
}
