using System.Collections.Generic;
using UnityEngine;

public class cInput : MonoBehaviour
{
	public static GUISkin cSkin;

	public static float gravity = 3f;

	public static float sensitivity = 3f;

	public static float deadzone = 0.001f;

	private static bool _allowDuplicates = false;

	private static string[,] _defaultStrings = new string[99, 3];

	private static string[] _inputName = new string[99];

	private static KeyCode[] _inputPrimary = new KeyCode[99];

	private static KeyCode[] _inputSecondary = new KeyCode[99];

	private static string[] _axisName = new string[99];

	private static string[] _axisPrimary = new string[99];

	private static string[] _axisSecondary = new string[99];

	private static float[] _individualAxisSens = new float[99];

	private static bool[] _invertAxis = new bool[99];

	private static int[,] _makeAxis = new int[99, 3];

	private static int _inputLength = -1;

	private static int _axisLength = -1;

	private static List<KeyCode> _forbiddenKeys = new List<KeyCode>();

	private static bool[] _virtAxis = new bool[99];

	private static bool[] _getKeyArray = new bool[99];

	private static bool[] _getKeyDownArray = new bool[99];

	private static bool[] _getKeyUpArray = new bool[99];

	private static bool[] _axisTriggerArray = new bool[99];

	private static float[] _getAxisArray = new float[99];

	private static float[] _getAxis = new float[99];

	private static float[] _getAxisArrayRaw = new float[99];

	private static float[] _getAxisRaw = new float[99];

	private static bool _allowMouseAxis = false;

	private static bool _allowMouseButtons = true;

	private static bool _allowJoystickButtons = true;

	private static bool _allowJoystickAxis = true;

	private static bool _allowKeyboard = true;

	private static int _numGamepads = 5;

	private static float _builtInAxisDeadzone = 0.5f;

	private static bool _showMenu;

	private Vector2 _scrollPosition;

	private static string _menuHeaderString = "label";

	private static string _menuActionsString = "box";

	private static string _menuInputsString = "box";

	private static string _menuButtonsString = "button";

	private static bool _scanning;

	private static int _cScanIndex;

	private static int _cScanInput;

	private static bool _cObjectOn;

	private static bool _cKeysLoaded;

	private static string _exAllowDuplicates;

	private static string _exAxis;

	private static string _exAxisInverted;

	private static string _exDefaults;

	private static string _exInputs;

	private static string _exCalibrations;

	private static bool _externalSaving = false;

	private Rect windowRect;

	private float mouseTimer = 0.5f;

	private bool showPopUp;

	private static Dictionary<string, KeyCode> _string2Key = new Dictionary<string, KeyCode>();

	private static int[] _axisType = new int[10 * _numGamepads];

	private static string[,] _joyStrings = new string[_numGamepads, 11];

	private static string[,] _joyStringsPos = new string[_numGamepads, 11];

	private static string[,] _joyStringsNeg = new string[_numGamepads, 11];

	public static bool scanning
	{
		get
		{
			return _scanning;
		}
	}

	public static int length
	{
		get
		{
			_CreatecObject();
			return _inputLength + 1;
		}
	}

	public static bool allowDuplicates
	{
		get
		{
			_CreatecObject();
			return _allowDuplicates;
		}
		set
		{
			_allowDuplicates = value;
			PlayerPrefs.SetString("_dubl", value.ToString());
			_exAllowDuplicates = value.ToString();
		}
	}

	public static string externalInputs
	{
		get
		{
			return _exAllowDuplicates + "." + _exAxis + "." + _exAxisInverted + "." + _exDefaults + "." + _exInputs + "." + _exCalibrations;
		}
	}

	private void Awake()
	{
		Object.DontDestroyOnLoad(this);
	}

	private void Start()
	{
		_CreateDictionary();
		if (_externalSaving)
		{
			_LoadExternalInputs();
		}
		else
		{
			_LoadInputs();
		}
	}

	public static void Init()
	{
		_CreatecObject();
	}

	private static void _CreateDictionary()
	{
		if (_string2Key.Count == 0)
		{
			for (int i = 0; i < 430; i++)
			{
				KeyCode keyCode = (KeyCode)i;
				_string2Key.Add(keyCode.ToString(), keyCode);
			}
		}
		for (int j = 1; j < _numGamepads; j++)
		{
			for (int k = 1; k <= 10; k++)
			{
				_joyStrings[j, k] = "Joy" + j + " Axis " + k;
				_joyStringsPos[j, k] = "Joy" + j + " Axis " + k + "+";
				_joyStringsNeg[j, k] = "Joy" + j + " Axis " + k + "-";
			}
		}
	}

	public static void ForbidKey(KeyCode key)
	{
		_CreateDictionary();
		if (!_forbiddenKeys.Contains(key))
		{
			_forbiddenKeys.Add(key);
		}
	}

	public static void ForbidKey(string keyString)
	{
		_CreateDictionary();
		KeyCode key = ConvertString2Key(keyString);
		ForbidKey(key);
	}

	public static KeyCode ConvertString2Key(string _str)
	{
		if (_string2Key.Count == 0)
		{
			return KeyCode.None;
		}
		if (_string2Key.ContainsKey(_str))
		{
			return _string2Key[_str];
		}
		switch (_str)
		{
		case "↑":
			return KeyCode.UpArrow;
		case "↓":
			return KeyCode.DownArrow;
		case "←":
			return KeyCode.LeftArrow;
		case "→":
			return KeyCode.RightArrow;
		case "0":
			return KeyCode.Alpha0;
		case "1":
			return KeyCode.Alpha1;
		case "2":
			return KeyCode.Alpha2;
		case "3":
			return KeyCode.Alpha3;
		case "4":
			return KeyCode.Alpha4;
		case "5":
			return KeyCode.Alpha5;
		case "6":
			return KeyCode.Alpha6;
		case "7":
			return KeyCode.Alpha7;
		case "8":
			return KeyCode.Alpha8;
		case "9":
			return KeyCode.Alpha9;
		case "&":
			return KeyCode.Ampersand;
		case "-":
			return KeyCode.Minus;
		case "+":
			return KeyCode.Equals;
		case "'":
			return KeyCode.Quote;
		case "\\":
			return KeyCode.Backslash;
		case "/":
			return KeyCode.Slash;
		case "[":
			return KeyCode.LeftBracket;
		case "]":
			return KeyCode.RightBracket;
		case "`":
			return KeyCode.BackQuote;
		case ":":
			return KeyCode.Semicolon;
		case ".":
			return KeyCode.Period;
		case ",":
			return KeyCode.Comma;
		case "LeftCtrl":
			return KeyCode.LeftControl;
		case "RightCtrl":
			return KeyCode.RightControl;
		case "Keypad.":
			return KeyCode.KeypadPeriod;
		case "Keypad+":
			return KeyCode.KeypadPlus;
		case "Keypad-":
			return KeyCode.KeypadMinus;
		case "Keypad*":
			return KeyCode.KeypadMultiply;
		case "Keypad/":
			return KeyCode.KeypadDivide;
		case "Pad1Button1":
			return KeyCode.Joystick1Button0;
		case "Pad1Button2":
			return KeyCode.Joystick1Button1;
		case "Pad1Button3":
			return KeyCode.Joystick1Button2;
		case "Pad1Button4":
			return KeyCode.Joystick1Button3;
		case "Pad1Button5":
			return KeyCode.Joystick1Button4;
		case "Pad1Button6":
			return KeyCode.Joystick1Button5;
		case "Pad1Button7":
			return KeyCode.Joystick1Button6;
		case "Pad1Button8":
			return KeyCode.Joystick1Button7;
		case "Pad1Button9":
			return KeyCode.Joystick1Button8;
		case "Pad1Button10":
			return KeyCode.Joystick1Button9;
		case "Pad1Button11":
			return KeyCode.Joystick1Button10;
		case "Pad1Button12":
			return KeyCode.Joystick1Button11;
		case "Pad1Button13":
			return KeyCode.Joystick1Button12;
		case "Pad1Button14":
			return KeyCode.Joystick1Button13;
		case "Pad1Button15":
			return KeyCode.Joystick1Button14;
		case "Pad1Button16":
			return KeyCode.Joystick1Button15;
		case "Pad1Button17":
			return KeyCode.Joystick1Button16;
		case "Pad1Button18":
			return KeyCode.Joystick1Button17;
		case "Pad1Button19":
			return KeyCode.Joystick1Button18;
		case "Pad1Button20":
			return KeyCode.Joystick1Button19;
		case "Pad2Button1":
			return KeyCode.Joystick2Button0;
		case "Pad2Button2":
			return KeyCode.Joystick2Button1;
		case "Pad2Button3":
			return KeyCode.Joystick2Button2;
		case "Pad2Button4":
			return KeyCode.Joystick2Button3;
		case "Pad2Button5":
			return KeyCode.Joystick2Button4;
		case "Pad2Button6":
			return KeyCode.Joystick2Button5;
		case "Pad2Button7":
			return KeyCode.Joystick2Button6;
		case "Pad2Button8":
			return KeyCode.Joystick2Button7;
		case "Pad2Button9":
			return KeyCode.Joystick2Button8;
		case "Pad2Button10":
			return KeyCode.Joystick2Button9;
		case "Pad2Button11":
			return KeyCode.Joystick2Button10;
		case "Pad2Button12":
			return KeyCode.Joystick2Button11;
		case "Pad2Button13":
			return KeyCode.Joystick2Button12;
		case "Pad2Button14":
			return KeyCode.Joystick2Button13;
		case "Pad2Button15":
			return KeyCode.Joystick2Button14;
		case "Pad2Button16":
			return KeyCode.Joystick2Button15;
		case "Pad2Button17":
			return KeyCode.Joystick2Button16;
		case "Pad2Button18":
			return KeyCode.Joystick2Button17;
		case "Pad2Button19":
			return KeyCode.Joystick2Button18;
		case "Pad2Button20":
			return KeyCode.Joystick2Button19;
		case "Pad3Button1":
			return KeyCode.Joystick3Button0;
		case "Pad3Button2":
			return KeyCode.Joystick3Button1;
		case "Pad3Button3":
			return KeyCode.Joystick3Button2;
		case "Pad3Button4":
			return KeyCode.Joystick3Button3;
		case "Pad3Button5":
			return KeyCode.Joystick3Button4;
		case "Pad3Button6":
			return KeyCode.Joystick3Button5;
		case "Pad3Button7":
			return KeyCode.Joystick3Button6;
		case "Pad3Button8":
			return KeyCode.Joystick3Button7;
		case "Pad3Button9":
			return KeyCode.Joystick3Button8;
		case "Pad3Button10":
			return KeyCode.Joystick3Button9;
		case "Pad3Button11":
			return KeyCode.Joystick3Button10;
		case "Pad3Button12":
			return KeyCode.Joystick3Button11;
		case "Pad3Button13":
			return KeyCode.Joystick3Button12;
		case "Pad3Button14":
			return KeyCode.Joystick3Button13;
		case "Pad3Button15":
			return KeyCode.Joystick3Button14;
		case "Pad3Button16":
			return KeyCode.Joystick3Button15;
		case "Pad3Button17":
			return KeyCode.Joystick3Button16;
		case "Pad3Button18":
			return KeyCode.Joystick3Button17;
		case "Pad3Button19":
			return KeyCode.Joystick3Button18;
		case "Pad3Button20":
			return KeyCode.Joystick3Button19;
		case "Pad4Button1":
			return KeyCode.Joystick4Button0;
		case "Pad4Button2":
			return KeyCode.Joystick4Button1;
		case "Pad4Button3":
			return KeyCode.Joystick4Button2;
		case "Pad4Button4":
			return KeyCode.Joystick4Button3;
		case "Pad4Button5":
			return KeyCode.Joystick4Button4;
		case "Pad4Button6":
			return KeyCode.Joystick4Button5;
		case "Pad4Button7":
			return KeyCode.Joystick4Button6;
		case "Pad4Button8":
			return KeyCode.Joystick4Button7;
		case "Pad4Button9":
			return KeyCode.Joystick4Button8;
		case "Pad4Button10":
			return KeyCode.Joystick4Button9;
		case "Pad4Button11":
			return KeyCode.Joystick4Button10;
		case "Pad4Button12":
			return KeyCode.Joystick4Button11;
		case "Pad4Button13":
			return KeyCode.Joystick4Button12;
		case "Pad4Button14":
			return KeyCode.Joystick4Button13;
		case "Pad4Button15":
			return KeyCode.Joystick4Button14;
		case "Pad4Button16":
			return KeyCode.Joystick4Button15;
		case "Pad4Button17":
			return KeyCode.Joystick4Button16;
		case "Pad4Button18":
			return KeyCode.Joystick4Button17;
		case "Pad4Button19":
			return KeyCode.Joystick4Button18;
		case "Pad4Button20":
			return KeyCode.Joystick4Button19;
		default:
			if (!_isAxisValid(_str))
			{
				Debug.Log("cInput error: " + _str + " is not a valid input.");
			}
			return KeyCode.None;
		}
	}

	public static void SetKey(string action, string input1)
	{
		SetKey(action, input1, string.Empty);
	}

	public static void SetKey(string action, string primary, string secondary)
	{
		GameObject gameObject = GameObject.Find("cInput");
		if (!(gameObject != null) || !(gameObject.GetComponent<cInput>() != null))
		{
			if (findKeyByDescription(action) == -1)
			{
				int num = _inputLength + 1;
				_SetDefaultKey(num, action, primary, secondary);
			}
			else if (!_externalSaving)
			{
				Debug.LogWarning("A key with the name of " + action + " already exists. You should use ChangeKey() if you want to change an existing key!");
			}
		}
	}

	private static void _SetDefaultKey(int _num, string _name, string _input1, string _input2)
	{
		_defaultStrings[_num, 0] = _name;
		_defaultStrings[_num, 1] = _input1;
		if (string.IsNullOrEmpty(_input2))
		{
			_defaultStrings[_num, 2] = KeyCode.None.ToString();
		}
		else
		{
			_defaultStrings[_num, 2] = _input2;
		}
		if (_num > _inputLength)
		{
			_inputLength = _num;
		}
		_SetKey(_num, _name, _input1, _input2);
		_SaveDefaults();
	}

	private static void _SetKey(int _num, string _name, string _input1, string _input2)
	{
		_inputName[_num] = _name;
		_axisPrimary[_num] = string.Empty;
		if (_string2Key.Count == 0)
		{
			return;
		}
		if (!string.IsNullOrEmpty(_input1))
		{
			KeyCode keyCode = ConvertString2Key(_input1);
			_inputPrimary[_num] = keyCode;
			string text = _ChangeStringToAxisName(_input1);
			if (_input1 != text)
			{
				_axisPrimary[_num] = _input1;
			}
		}
		_axisSecondary[_num] = string.Empty;
		if (!string.IsNullOrEmpty(_input2))
		{
			KeyCode keyCode2 = ConvertString2Key(_input2);
			_inputSecondary[_num] = keyCode2;
			string text2 = _ChangeStringToAxisName(_input2);
			if (_input2 != text2)
			{
				_axisSecondary[_num] = _input2;
			}
		}
	}

	public static void SetAxis(string description, string negativeInput, string positiveInput)
	{
		SetAxis(description, negativeInput, positiveInput, sensitivity);
	}

	public static void SetAxis(string description, string negativeInput, string positiveInput, float axisSensitivity)
	{
		if (IsKeyDefined(negativeInput))
		{
			int num = _axisLength + 1;
			int positive = -1;
			if (IsKeyDefined(positiveInput))
			{
				positive = findKeyByDescription(positiveInput);
			}
			else if (positiveInput != "-1")
			{
				Debug.LogError("Can't define Axis named: " + description + ". Please define '" + positiveInput + "' with SetKey() first.");
				return;
			}
			_SetAxis(num, description, findKeyByDescription(negativeInput), positive);
			_individualAxisSens[num] = axisSensitivity;
		}
		else
		{
			Debug.LogError("Can't define Axis named: " + description + ". Please define '" + negativeInput + "' with SetKey() first.");
		}
	}

	public static void SetAxis(string description, string input)
	{
		SetAxis(description, input, "-1", sensitivity);
	}

	public static void SetAxis(string description, string input, float axisSensitivity)
	{
		SetAxis(description, input, "-1", axisSensitivity);
	}

	private static void _SetAxis(int _num, string _description, int _negative, int _positive)
	{
		if (_num > _axisLength)
		{
			_axisLength = _num;
		}
		_invertAxis[_num] = false;
		_axisName[_num] = _description;
		_makeAxis[_num, 0] = _negative;
		_makeAxis[_num, 1] = _positive;
		_SaveAxis();
		_SaveAxInverted();
	}

	public static void SetAxisSensitivity(string axisName, float sensitivity)
	{
		int num = _FindAxisByDescription(axisName);
		if (num == -1)
		{
			Debug.LogError("Cannot set sensitivity of " + axisName + ". Have you defined this axis with SetAxis() yet?");
		}
		else
		{
			_individualAxisSens[num] = sensitivity;
		}
	}

	public static float ShowAxisSensitivity(string axisName)
	{
		int num = _FindAxisByDescription(axisName);
		if (num == -1)
		{
			Debug.LogError("Cannot set sensitivity of " + axisName + ". Have you defined this axis with SetAxis() yet?");
			return 0f;
		}
		return _individualAxisSens[num];
	}

	public static void Calibrate()
	{
		string text = string.Empty;
		for (int i = 1; i <= _numGamepads; i++)
		{
			for (int j = 1; j < 11; j++)
			{
				int num = 10 * (i - 1) + (j - 1);
				string axisName = _joyStrings[i, j];
				float axisRaw = Input.GetAxisRaw(axisName);
				_axisType[num] = ((axisRaw < 0f - _builtInAxisDeadzone) ? 1 : ((axisRaw > _builtInAxisDeadzone) ? (-1) : 0));
				text = text + _axisType[num] + "*";
				PlayerPrefs.SetString("_saveCals", text);
				_exCalibrations = text;
			}
		}
	}

	private static float _GetCalibratedAxisInput(string description)
	{
		float axis = Input.GetAxis(_ChangeStringToAxisName(description));
		for (int i = 1; i < _numGamepads; i++)
		{
			for (int j = 1; j < 10; j++)
			{
				string text = _joyStringsPos[i, j];
				string text2 = _joyStringsNeg[i, j];
				if (description == text || description == text2)
				{
					int num = 10 * (i - 1) + (j - 1);
					switch (_axisType[num])
					{
					case 0:
						return axis;
					case 1:
						return (axis + 1f) / 2f;
					case -1:
						return (axis - 1f) / 2f;
					}
				}
			}
		}
		return axis;
	}

	public static void ChangeKey(string action, int input, bool mouseAx, bool mouseBut, bool joyAx, bool joyBut, bool keyb)
	{
		_CreatecObject();
		int num = findKeyByDescription(action);
		_ScanForNewKey(num, input, mouseAx, mouseBut, joyAx, joyBut, keyb);
	}

	public static void ChangeKey(string action)
	{
		ChangeKey(action, 1, _allowMouseAxis, _allowMouseButtons, _allowJoystickAxis, _allowJoystickButtons, _allowKeyboard);
	}

	public static void ChangeKey(string action, int input)
	{
		ChangeKey(action, input, _allowMouseAxis, _allowMouseButtons, _allowJoystickAxis, _allowJoystickButtons, _allowKeyboard);
	}

	public static void ChangeKey(string action, int input, bool mouseAx)
	{
		ChangeKey(action, input, mouseAx, _allowMouseButtons, _allowJoystickAxis, _allowJoystickButtons, _allowKeyboard);
	}

	public static void ChangeKey(string action, int input, bool mouseAx, bool mouseBut)
	{
		ChangeKey(action, input, mouseAx, mouseBut, _allowJoystickAxis, _allowJoystickButtons, _allowKeyboard);
	}

	public static void ChangeKey(string action, int input, bool mouseAx, bool mouseBut, bool joyAx)
	{
		ChangeKey(action, input, mouseAx, mouseBut, joyAx, _allowJoystickButtons, _allowKeyboard);
	}

	public static void ChangeKey(string action, int input, bool mouseAx, bool mouseBut, bool joyAx, bool joyBut)
	{
		ChangeKey(action, input, mouseAx, mouseBut, joyAx, joyBut, _allowKeyboard);
	}

	public static void ChangeKey(int index, int input, bool mouseAx, bool mouseBut, bool joyAx, bool joyBut, bool keyb)
	{
		_CreatecObject();
		_ScanForNewKey(index, input, mouseAx, mouseBut, joyAx, joyBut, keyb);
	}

	public static void ChangeKey(int index)
	{
		ChangeKey(index, 1, false, true, true, true, true);
	}

	public static void ChangeKey(int index, int input)
	{
		ChangeKey(index, input, false, true, true, true, true);
	}

	public static void ChangeKey(int index, int input, bool mouseAx)
	{
		ChangeKey(index, input, mouseAx, true, true, true, true);
	}

	public static void ChangeKey(int index, int input, bool mouseAx, bool mouseBut)
	{
		ChangeKey(index, input, mouseAx, mouseBut, true, true, true);
	}

	public static void ChangeKey(int index, int input, bool mouseAx, bool mouseBut, bool joyAx)
	{
		ChangeKey(index, input, mouseAx, mouseBut, joyAx, true, true);
	}

	public static void ChangeKey(int index, int input, bool mouseAx, bool mouseBut, bool joyAx, bool joyBut)
	{
		ChangeKey(index, input, mouseAx, mouseBut, joyAx, joyBut, true);
	}

	public static void ChangeKey(string action, string primary, string secondary)
	{
		_CreatecObject();
		int num = findKeyByDescription(action);
		_ChangeKey(num, action, primary, secondary);
	}

	public static void ChangeKey(string action, string primary)
	{
		ChangeKey(action, primary, string.Empty);
	}

	private static void _ScanForNewKey(int num, int input, bool mouseAx, bool mouseBut, bool joyAx, bool joyBut, bool keyb)
	{
		_allowMouseAxis = mouseAx;
		_allowMouseButtons = mouseBut;
		_allowJoystickButtons = joyBut;
		_allowJoystickAxis = joyAx;
		_allowKeyboard = keyb;
		_cScanInput = input;
		_cScanIndex = num;
		_scanning = true;
	}

	private static void _ChangeKey(int num, string action, string primary, string secondary)
	{
		_SetKey(num, action, primary, secondary);
		_SaveInputs();
	}

	public static bool IsKeyDefined(string keyName)
	{
		if (findKeyByDescription(keyName) >= 0)
		{
			return true;
		}
		return false;
	}

	public static bool IsAxisDefined(string axisName)
	{
		if (_FindAxisByDescription(axisName) >= 0)
		{
			return true;
		}
		return false;
	}

	private void CheckInputs()
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		float num = 0f;
		float num2 = 0f;
		for (int i = 0; i < _inputLength + 1; i++)
		{
			flag = Input.GetKey(_inputPrimary[i]);
			flag2 = Input.GetKey(_inputSecondary[i]);
			if (!string.IsNullOrEmpty(_axisPrimary[i]))
			{
				flag3 = true;
				num = _GetCalibratedAxisInput(_axisPrimary[i]) * (float)_PosOrNeg(_axisPrimary[i]);
			}
			else
			{
				flag3 = false;
				num = 0f;
			}
			if (!string.IsNullOrEmpty(_axisSecondary[i]))
			{
				flag4 = true;
				num2 = _GetCalibratedAxisInput(_axisSecondary[i]) * (float)_PosOrNeg(_axisSecondary[i]);
			}
			else
			{
				flag4 = false;
				num2 = 0f;
			}
			if (flag || flag2 || (flag3 && num > 0.1f) || (flag4 && num2 > 0.1f))
			{
				_getKeyArray[i] = true;
			}
			else
			{
				_getKeyArray[i] = false;
			}
			if (Input.GetKeyDown(_inputPrimary[i]) || Input.GetKeyDown(_inputSecondary[i]))
			{
				_getKeyDownArray[i] = true;
			}
			else if ((flag3 && num > _builtInAxisDeadzone && !_axisTriggerArray[i]) || (flag4 && num2 > _builtInAxisDeadzone && !_axisTriggerArray[i]))
			{
				_axisTriggerArray[i] = true;
				_getKeyDownArray[i] = true;
			}
			else
			{
				_getKeyDownArray[i] = false;
			}
			if (Input.GetKeyUp(_inputPrimary[i]) || Input.GetKeyUp(_inputSecondary[i]))
			{
				_getKeyUpArray[i] = true;
			}
			else if ((flag3 && num <= _builtInAxisDeadzone && _axisTriggerArray[i]) || (flag4 && num2 <= _builtInAxisDeadzone && _axisTriggerArray[i]))
			{
				_axisTriggerArray[i] = false;
				_getKeyUpArray[i] = true;
			}
			else
			{
				_getKeyUpArray[i] = false;
			}
			if (flag3 && !_virtAxis[i])
			{
				_getAxis[i] = num;
				_getAxisRaw[i] = num;
			}
			if (flag4 && !_virtAxis[i])
			{
				_getAxis[i] = num2;
				_getAxisRaw[i] = num2;
			}
			if (flag3 && flag4 && !_virtAxis[i])
			{
				if (num > 0f)
				{
					_getAxis[i] = num;
					_getAxisRaw[i] = num;
				}
				if (num2 > 0f)
				{
					_getAxis[i] = num2;
					_getAxisRaw[i] = num2;
				}
				if (num > 0f && num2 > 0f)
				{
					_getAxis[i] = (num + num2) / 2f;
					_getAxisRaw[i] = (num + num2) / 2f;
				}
			}
			if (flag || flag2)
			{
				_virtAxis[i] = true;
				_getAxis[i] += sensitivity * Time.deltaTime;
				_getAxisRaw[i] = 1f;
				if (_getAxis[i] > 1f)
				{
					_getAxis[i] = 1f;
				}
				if ((flag3 && num < deadzone) || (flag4 && num2 < deadzone))
				{
					_getAxisRaw[i] = 1f;
				}
			}
			if (!flag && !flag2 && ((flag3 && num < deadzone) || (flag4 && num2 < deadzone) || (!flag3 && !flag4)))
			{
				_getAxis[i] -= gravity * Time.deltaTime;
				_getAxisRaw[i] = 0f;
				if (_getAxis[i] < 0f)
				{
					_getAxis[i] = 0f;
				}
			}
			if (_getAxis[i] == 0f)
			{
				_virtAxis[i] = false;
			}
		}
		for (int j = 0; j < _axisLength + 1; j++)
		{
			int num3 = _makeAxis[j, 0];
			int num4 = _makeAxis[j, 1];
			if (_makeAxis[j, 1] == -1)
			{
				_getAxisArray[j] = _getAxis[num3];
				_getAxisArrayRaw[j] = _getAxisRaw[num3];
			}
			else
			{
				_getAxisArray[j] = _getAxis[num4] - _getAxis[num3];
				_getAxisArrayRaw[j] = _getAxisRaw[num4] - _getAxisRaw[num3];
			}
		}
	}

	private static int findKeyByDescription(string description)
	{
		for (int i = 0; i < _inputName.Length; i++)
		{
			if (_inputName[i] == description)
			{
				return i;
			}
		}
		return -1;
	}

	public static bool GetKey(string description)
	{
		if (!PlayerPrefs.HasKey("_count"))
		{
			Debug.LogWarning("No default inputs found. Please setup your default inputs with SetKey first.");
			return false;
		}
		_CreatecObject();
		if (!_cKeysLoaded)
		{
			return false;
		}
		int num = findKeyByDescription(description);
		if (num > -1)
		{
			return _getKeyArray[num];
		}
		Debug.LogWarning("Couldn't find a key match for " + description + ". Is it possible you typed it wrong or forgot to setup your defaults after making changes?");
		return false;
	}

	public static bool GetKeyDown(string description)
	{
		if (!PlayerPrefs.HasKey("_count"))
		{
			Debug.LogWarning("No default inputs found. Please setup your default inputs with SetKey first.");
			return false;
		}
		_CreatecObject();
		if (!_cKeysLoaded)
		{
			return false;
		}
		int num = findKeyByDescription(description);
		if (num > -1)
		{
			return _getKeyDownArray[findKeyByDescription(description)];
		}
		Debug.LogWarning("Couldn't find a key match for " + description + ". Is it possible you typed it wrong or forgot to setup your defaults after making changes?");
		return false;
	}

	public static bool GetKeyUp(string description)
	{
		if (!PlayerPrefs.HasKey("_count"))
		{
			Debug.LogWarning("No default inputs found. Please setup your default inputs with SetKey first.");
			return false;
		}
		_CreatecObject();
		if (!_cKeysLoaded)
		{
			return false;
		}
		int num = findKeyByDescription(description);
		if (num > -1)
		{
			return _getKeyUpArray[findKeyByDescription(description)];
		}
		Debug.LogWarning("Couldn't find a key match for " + description + ". Is it possible you typed it wrong or forgot to setup your defaults after making changes?");
		return false;
	}

	public static bool GetButton(string description)
	{
		return GetKey(description);
	}

	public static bool GetButtonDown(string description)
	{
		return GetKeyDown(description);
	}

	public static bool GetButtonUp(string description)
	{
		return GetKeyUp(description);
	}

	private static int _FindAxisByDescription(string axisName)
	{
		for (int i = 0; i < _axisName.Length; i++)
		{
			if (_axisName[i] == axisName)
			{
				return i;
			}
		}
		return -1;
	}

	public static float GetAxis(string axisName)
	{
		_CreatecObject();
		if (!PlayerPrefs.HasKey("_count"))
		{
			Debug.LogWarning("No default inputs found. Please setup your default inputs with SetKey first.");
			return 0f;
		}
		int num = _FindAxisByDescription(axisName);
		if (num > -1)
		{
			if (_invertAxis[num])
			{
				sensitivity = _individualAxisSens[num];
				return _getAxisArray[num] * -1f;
			}
			sensitivity = _individualAxisSens[num];
			return _getAxisArray[num];
		}
		Debug.LogWarning("Couldn't find an axis match for " + axisName + ". Is it possible you typed it wrong?");
		return 0f;
	}

	public static float GetAxisRaw(string axisName)
	{
		_CreatecObject();
		if (!PlayerPrefs.HasKey("_count"))
		{
			Debug.LogWarning("No default inputs found. Please setup your default inputs with SetKey first.");
			return 0f;
		}
		int num = _FindAxisByDescription(axisName);
		if (num > -1)
		{
			if (_invertAxis[num])
			{
				return _getAxisArrayRaw[num] * -1f;
			}
			return _getAxisArrayRaw[num];
		}
		Debug.LogWarning("Couldn't find an axis match for " + axisName + ". Is it possible you typed it wrong?");
		return 0f;
	}

	public static string GetText(string action, int input)
	{
		_CreatecObject();
		if (input < 0 && input > 2)
		{
			input = 1;
			Debug.LogWarning("Can't look for text #" + input + " for " + action + " input. Only 0, 1, or 2 is acceptable. Defaulting to " + input + ".");
		}
		int index = findKeyByDescription(action);
		return GetText(index, input);
	}

	public static string GetText(string action)
	{
		return GetText(action, 1);
	}

	public static string GetText(int index)
	{
		return GetText(index, 0);
	}

	public static string GetText(int index, int input)
	{
		_CreatecObject();
		if (input < 0 && input > 2)
		{
			input = 0;
			Debug.LogWarning("Can't look for text #" + input + " for " + _inputName[index] + " input. Only 0, 1, or 2 is acceptable. Defaulting to " + input + ".");
		}
		string text;
		switch (input)
		{
		case 1:
			text = (string.IsNullOrEmpty(_axisPrimary[index]) ? _inputPrimary[index].ToString() : _axisPrimary[index]);
			break;
		case 2:
			text = (string.IsNullOrEmpty(_axisSecondary[index]) ? _inputSecondary[index].ToString() : _axisSecondary[index]);
			break;
		default:
			text = _inputName[index];
			break;
		}
		if (_scanning && index == _cScanIndex && input == _cScanInput)
		{
			text = ". . .";
		}
		switch (text)
		{
		case "UpArrow":
			return "↑";
		case "DownArrow":
			return "↓";
		case "LeftArrow":
			return "←";
		case "RightArrow":
			return "→";
		case "Alpha0":
			return "0";
		case "Alpha1":
			return "1";
		case "Alpha2":
			return "2";
		case "Alpha3":
			return "3";
		case "Alpha4":
			return "4";
		case "Alpha5":
			return "5";
		case "Alpha6":
			return "6";
		case "Alpha7":
			return "7";
		case "Alpha8":
			return "8";
		case "Alpha9":
			return "9";
		case "Minus":
			return "-";
		case "Equals":
			return "+";
		case "Quote":
			return "'";
		case "Backslash":
			return "\\";
		case "Slash":
			return "/";
		case "LeftBracket":
			return "[";
		case "RightBracket":
			return "]";
		case "BackQuote":
			return "`";
		case "Semicolon":
			return ":";
		case "Period":
			return ".";
		case "Comma":
			return ",";
		case "LeftControl":
			return "LeftCtrl";
		case "RightControl":
			return "RightCtrl";
		case "KeypadPeriod":
			return "Keypad.";
		case "KeypadPlus":
			return "Keypad+";
		case "KeypadMinus":
			return "Keypad-";
		case "KeypadMultiply":
			return "Keypad*";
		case "KeypadDivide":
			return "Keypad/";
		case "Joystick1Button0":
			return "Pad1Button1";
		case "Joystick1Button1":
			return "Pad1Button2";
		case "Joystick1Button2":
			return "Pad1Button3";
		case "Joystick1Button3":
			return "Pad1Button4";
		case "Joystick1Button4":
			return "Pad1Button5";
		case "Joystick1Button5":
			return "Pad1Button6";
		case "Joystick1Button6":
			return "Pad1Button7";
		case "Joystick1Button7":
			return "Pad1Button8";
		case "Joystick1Button8":
			return "Pad1Button9";
		case "Joystick1Button9":
			return "Pad1Button10";
		case "Joystick1Button10":
			return "Pad1Button11";
		case "Joystick1Button11":
			return "Pad1Button12";
		case "Joystick1Button12":
			return "Pad1Button13";
		case "Joystick1Button13":
			return "Pad1Button14";
		case "Joystick1Button14":
			return "Pad1Button15";
		case "Joystick1Button15":
			return "Pad1Button16";
		case "Joystick1Button16":
			return "Pad1Button17";
		case "Joystick1Button17":
			return "Pad1Button18";
		case "Joystick1Button18":
			return "Pad1Button19";
		case "Joystick1Button19":
			return "Pad1Button20";
		case "Joystick2Button0":
			return "Pad2Button1";
		case "Joystick2Button1":
			return "Pad2Button2";
		case "Joystick2Button2":
			return "Pad2Button3";
		case "Joystick2Button3":
			return "Pad2Button4";
		case "Joystick2Button4":
			return "Pad2Button5";
		case "Joystick2Button5":
			return "Pad2Button6";
		case "Joystick2Button6":
			return "Pad2Button7";
		case "Joystick2Button7":
			return "Pad2Button8";
		case "Joystick2Button8":
			return "Pad2Button9";
		case "Joystick2Button9":
			return "Pad2Button10";
		case "Joystick2Button10":
			return "Pad2Button11";
		case "Joystick2Button11":
			return "Pad2Button12";
		case "Joystick2Button12":
			return "Pad2Button13";
		case "Joystick2Button13":
			return "Pad2Button14";
		case "Joystick2Button14":
			return "Pad2Button15";
		case "Joystick2Button15":
			return "Pad2Button16";
		case "Joystick2Button16":
			return "Pad2Button17";
		case "Joystick2Button17":
			return "Pad2Button18";
		case "Joystick2Button18":
			return "Pad2Button19";
		case "Joystick2Button19":
			return "Pad2Button20";
		case "Joystick3Button0":
			return "Pad3Button1";
		case "Joystick3Button1":
			return "Pad3Button2";
		case "Joystick3Button2":
			return "Pad3Button3";
		case "Joystick3Button3":
			return "Pad3Button4";
		case "Joystick3Button4":
			return "Pad3Button5";
		case "Joystick3Button5":
			return "Pad3Button6";
		case "Joystick3Button6":
			return "Pad3Button7";
		case "Joystick3Button7":
			return "Pad3Button8";
		case "Joystick3Button8":
			return "Pad3Button9";
		case "Joystick3Button9":
			return "Pad3Button10";
		case "Joystick3Button10":
			return "Pad3Button11";
		case "Joystick3Button11":
			return "Pad3Button12";
		case "Joystick3Button12":
			return "Pad3Button13";
		case "Joystick3Button13":
			return "Pad3Button14";
		case "Joystick3Button14":
			return "Pad3Button15";
		case "Joystick3Button15":
			return "Pad3Button16";
		case "Joystick3Button16":
			return "Pad3Button17";
		case "Joystick3Button17":
			return "Pad3Button18";
		case "Joystick3Button18":
			return "Pad3Button19";
		case "Joystick3Button19":
			return "Pad3Button20";
		case "Joystick4Button0":
			return "Pad4Button1";
		case "Joystick4Button1":
			return "Pad4Button2";
		case "Joystick4Button2":
			return "Pad4Button3";
		case "Joystick4Button3":
			return "Pad4Button4";
		case "Joystick4Button4":
			return "Pad4Button5";
		case "Joystick4Button5":
			return "Pad4Button6";
		case "Joystick4Button6":
			return "Pad4Button7";
		case "Joystick4Button7":
			return "Pad4Button8";
		case "Joystick4Button8":
			return "Pad4Button9";
		case "Joystick4Button9":
			return "Pad4Button10";
		case "Joystick4Button10":
			return "Pad4Button11";
		case "Joystick4Button11":
			return "Pad4Button12";
		case "Joystick4Button12":
			return "Pad4Button13";
		case "Joystick4Button13":
			return "Pad4Button14";
		case "Joystick4Button14":
			return "Pad4Button15";
		case "Joystick4Button15":
			return "Pad4Button16";
		case "Joystick4Button16":
			return "Pad4Button17";
		case "Joystick4Button17":
			return "Pad4Button18";
		case "Joystick4Button18":
			return "Pad4Button19";
		case "Joystick4Button19":
			return "Pad4Button20";
		default:
			return text;
		}
	}

	private static string _ChangeStringToAxisName(string description)
	{
		switch (description)
		{
		case "Mouse Left":
			return "Mouse Horizontal";
		case "Mouse Right":
			return "Mouse Horizontal";
		case "Mouse Up":
			return "Mouse Vertical";
		case "Mouse Down":
			return "Mouse Vertical";
		case "Mouse Wheel Up":
			return "Mouse Wheel";
		case "Mouse Wheel Down":
			return "Mouse Wheel";
		default:
		{
			string text = _FindJoystringByDescription(description);
			if (text != null)
			{
				return text;
			}
			return description;
		}
		}
	}

	private static string _FindJoystringByDescription(string desc)
	{
		for (int i = 1; i < _numGamepads; i++)
		{
			for (int j = 1; j <= 10; j++)
			{
				string text = _joyStringsPos[i, j];
				string text2 = _joyStringsNeg[i, j];
				if (desc == text || desc == text2)
				{
					return _joyStrings[i, j];
				}
			}
		}
		return null;
	}

	private static bool _isAxisValid(string _ax)
	{
		switch (_ax)
		{
		case "Mouse Left":
			return true;
		case "Mouse Right":
			return true;
		case "Mouse Up":
			return true;
		case "Mouse Down":
			return true;
		case "Mouse Wheel Up":
			return true;
		case "Mouse Wheel Down":
			return true;
		default:
		{
			bool result = false;
			for (int i = 1; i < _numGamepads; i++)
			{
				for (int j = 1; j <= 10; j++)
				{
					string text = _joyStringsPos[i, j];
					string text2 = _joyStringsNeg[i, j];
					if (_ax == text || _ax == text2)
					{
						result = true;
					}
				}
			}
			return result;
		}
		}
	}

	private static int _PosOrNeg(string description)
	{
		int result = 1;
		switch (description)
		{
		case "Mouse Left":
			return -1;
		case "Mouse Right":
			return 1;
		case "Mouse Up":
			return 1;
		case "Mouse Down":
			return -1;
		case "Mouse Wheel Up":
			return 1;
		case "Mouse Wheel Down":
			return -1;
		default:
		{
			for (int i = 1; i <= _numGamepads; i++)
			{
				for (int j = 1; j < 10; j++)
				{
					string text = _joyStringsPos[i, j];
					string text2 = _joyStringsNeg[i, j];
					if (description == text)
					{
						return 1;
					}
					if (description == text2)
					{
						return -1;
					}
				}
			}
			return result;
		}
		}
	}

	private static void _SaveAxis()
	{
		int num = _axisLength + 1;
		string text = string.Empty;
		string text2 = string.Empty;
		string text3 = string.Empty;
		string text4 = string.Empty;
		for (int i = 0; i < num; i++)
		{
			text = text + _axisName[i] + "*";
			text2 = text2 + _makeAxis[i, 0] + "*";
			text3 = text3 + _makeAxis[i, 1] + "*";
			text4 = text4 + _individualAxisSens[i] + "*";
		}
		string text5 = text + "#" + text2 + "#" + text3 + "#" + num;
		PlayerPrefs.SetString("_axis", text5);
		PlayerPrefs.SetString("_indAxSens", text4);
		_exAxis = text5 + "¿" + text4;
	}

	private static void _SaveAxInverted()
	{
		int num = _axisLength + 1;
		string text = string.Empty;
		for (int i = 0; i < num; i++)
		{
			text = text + _invertAxis[i] + "*";
		}
		PlayerPrefs.SetString("_axInv", text);
		_exAxisInverted = text;
	}

	private static void _SaveDefaults()
	{
		int num = _inputLength + 1;
		string text = string.Empty;
		string text2 = string.Empty;
		string text3 = string.Empty;
		for (int i = 0; i < num; i++)
		{
			text = text + _defaultStrings[i, 0] + "*";
			text2 = text2 + _defaultStrings[i, 1] + "*";
			text3 = text3 + _defaultStrings[i, 2] + "*";
		}
		string text4 = text + "#" + text2 + "#" + text3;
		PlayerPrefs.SetInt("_count", num);
		PlayerPrefs.SetString("_defaults", text4);
		_exDefaults = num + "¿" + text4;
	}

	private static void _SaveInputs()
	{
		int num = _inputLength + 1;
		string text = string.Empty;
		string text2 = string.Empty;
		string text3 = string.Empty;
		string text4 = string.Empty;
		string text5 = string.Empty;
		for (int i = 0; i < num; i++)
		{
			text = text + _inputName[i] + "*";
			text2 = string.Concat(text2, _inputPrimary[i], "*");
			text3 = string.Concat(text3, _inputSecondary[i], "*");
			text4 = text4 + _axisPrimary[i] + "*";
			text5 = text5 + _axisSecondary[i] + "*";
		}
		PlayerPrefs.SetString("_descr", text);
		PlayerPrefs.SetString("_inp", text2);
		PlayerPrefs.SetString("_alt_inp", text3);
		PlayerPrefs.SetString("_inpStr", text4);
		PlayerPrefs.SetString("_alt_inpStr", text5);
		_exInputs = text + "¿" + text2 + "¿" + text3 + "¿" + text4 + "¿" + text5;
	}

	public static void LoadExternal(string externString)
	{
		string[] array = externString.Split('.');
		_exAllowDuplicates = array[0];
		_exAxis = array[1];
		_exAxisInverted = array[2];
		_exDefaults = array[3];
		_exInputs = array[4];
		_exCalibrations = array[5];
		_LoadExternalInputs();
	}

	private static void _LoadInputs()
	{
		if (PlayerPrefs.HasKey("_dubl"))
		{
			if (PlayerPrefs.GetString("_dubl") == "True")
			{
				allowDuplicates = true;
			}
			else
			{
				allowDuplicates = false;
			}
		}
		int num = PlayerPrefs.GetInt("_count");
		_inputLength = num - 1;
		string text = PlayerPrefs.GetString("_defaults");
		string[] array = text.Split('#');
		string[] array2 = array[0].Split('*');
		string[] array3 = array[1].Split('*');
		string[] array4 = array[2].Split('*');
		for (int i = 0; i < array2.Length - 1; i++)
		{
			_SetDefaultKey(i, array2[i], array3[i], array4[i]);
		}
		if (PlayerPrefs.HasKey("_inp"))
		{
			string text2 = PlayerPrefs.GetString("_descr");
			string text3 = PlayerPrefs.GetString("_inp");
			string text4 = PlayerPrefs.GetString("_alt_inp");
			string text5 = PlayerPrefs.GetString("_inpStr");
			string text6 = PlayerPrefs.GetString("_alt_inpStr");
			string[] array5 = text2.Split('*');
			string[] array6 = text3.Split('*');
			string[] array7 = text4.Split('*');
			string[] array8 = text5.Split('*');
			string[] array9 = text6.Split('*');
			for (int j = 0; j < array5.Length - 1; j++)
			{
				if (array5[j] == _defaultStrings[j, 0])
				{
					_inputName[j] = array5[j];
					_inputPrimary[j] = ConvertString2Key(array6[j]);
					_inputSecondary[j] = ConvertString2Key(array7[j]);
					_axisPrimary[j] = array8[j];
					_axisSecondary[j] = array9[j];
				}
			}
			for (int k = 0; k < array2.Length - 1; k++)
			{
				for (int l = 0; l < array5.Length - 1; l++)
				{
					if (array5[l] == _defaultStrings[k, 0])
					{
						_inputName[k] = array5[l];
						_inputPrimary[k] = ConvertString2Key(array6[l]);
						_inputSecondary[k] = ConvertString2Key(array7[l]);
						_axisPrimary[k] = array8[l];
						_axisSecondary[k] = array9[l];
					}
				}
			}
		}
		if (PlayerPrefs.HasKey("_axis"))
		{
			string text7 = PlayerPrefs.GetString("_axInv");
			string[] array10 = text7.Split('*');
			string text8 = PlayerPrefs.GetString("_axis");
			string[] array11 = text8.Split('#');
			string[] array12 = array11[0].Split('*');
			string[] array13 = array11[1].Split('*');
			string[] array14 = array11[2].Split('*');
			int num2 = int.Parse(array11[3]);
			for (int m = 0; m < num2; m++)
			{
				int negative = int.Parse(array13[m]);
				int positive = int.Parse(array14[m]);
				_SetAxis(m, array12[m], negative, positive);
				if (array10[m] == "True")
				{
					_invertAxis[m] = true;
				}
				else
				{
					_invertAxis[m] = false;
				}
			}
		}
		if (PlayerPrefs.HasKey("_indAxSens"))
		{
			string text9 = PlayerPrefs.GetString("_indAxSens");
			string[] array15 = text9.Split('*');
			for (int n = 0; n < array15.Length - 1; n++)
			{
				_individualAxisSens[n] = float.Parse(array15[n]);
			}
		}
		if (PlayerPrefs.HasKey("_saveCals"))
		{
			string text10 = PlayerPrefs.GetString("_saveCals");
			string[] array16 = text10.Split('*');
			for (int num3 = 1; num3 <= array16.Length - 2; num3++)
			{
				_axisType[num3] = int.Parse(array16[num3]);
			}
		}
		_cKeysLoaded = true;
	}

	private static void _LoadExternalInputs()
	{
		_externalSaving = true;
		string[] array = _exAxis.Split('¿');
		string[] array2 = _exDefaults.Split('¿');
		string[] array3 = _exInputs.Split('¿');
		if (_exAllowDuplicates == "True")
		{
			allowDuplicates = true;
		}
		else
		{
			allowDuplicates = false;
		}
		int num = int.Parse(array2[0]);
		_inputLength = num - 1;
		string text = array2[1];
		string[] array4 = text.Split('#');
		string[] array5 = array4[0].Split('*');
		string[] array6 = array4[1].Split('*');
		string[] array7 = array4[2].Split('*');
		for (int i = 0; i < array5.Length - 1; i++)
		{
			_SetDefaultKey(i, array5[i], array6[i], array7[i]);
		}
		if (!string.IsNullOrEmpty(array3[0]))
		{
			string text2 = array3[0];
			string text3 = array3[1];
			string text4 = array3[2];
			string text5 = array3[3];
			string text6 = array3[4];
			string[] array8 = text2.Split('*');
			string[] array9 = text3.Split('*');
			string[] array10 = text4.Split('*');
			string[] array11 = text5.Split('*');
			string[] array12 = text6.Split('*');
			for (int j = 0; j < array8.Length - 1; j++)
			{
				if (array8[j] == _defaultStrings[j, 0])
				{
					_inputName[j] = array8[j];
					_inputPrimary[j] = ConvertString2Key(array9[j]);
					_inputSecondary[j] = ConvertString2Key(array10[j]);
					_axisPrimary[j] = array11[j];
					_axisSecondary[j] = array12[j];
				}
			}
			for (int k = 0; k < array5.Length - 1; k++)
			{
				for (int l = 0; l < array8.Length - 1; l++)
				{
					if (array8[l] == _defaultStrings[k, 0])
					{
						_inputName[k] = array8[l];
						_inputPrimary[k] = ConvertString2Key(array9[l]);
						_inputSecondary[k] = ConvertString2Key(array10[l]);
						_axisPrimary[k] = array11[l];
						_axisSecondary[k] = array12[l];
					}
				}
			}
		}
		if (!string.IsNullOrEmpty(array[0]))
		{
			string exAxisInverted = _exAxisInverted;
			string[] array13 = exAxisInverted.Split('*');
			string text7 = array[0];
			string[] array14 = text7.Split('#');
			string[] array15 = array14[0].Split('*');
			string[] array16 = array14[1].Split('*');
			string[] array17 = array14[2].Split('*');
			int num2 = int.Parse(array14[3]);
			for (int m = 0; m < num2; m++)
			{
				int negative = int.Parse(array16[m]);
				int positive = int.Parse(array17[m]);
				_SetAxis(m, array15[m], negative, positive);
				if (array13[m] == "true")
				{
					_invertAxis[m] = true;
				}
				else
				{
					_invertAxis[m] = false;
				}
			}
		}
		if (!string.IsNullOrEmpty(array[1]))
		{
			string text8 = array[1];
			string[] array18 = text8.Split('*');
			for (int n = 0; n < array18.Length - 1; n++)
			{
				_individualAxisSens[n] = float.Parse(array18[n]);
			}
		}
		if (!string.IsNullOrEmpty(_exCalibrations))
		{
			string exCalibrations = _exCalibrations;
			string[] array19 = exCalibrations.Split('*');
			for (int num3 = 1; num3 <= array19.Length - 2; num3++)
			{
				_axisType[num3] = int.Parse(array19[num3]);
			}
		}
		_cKeysLoaded = true;
	}

	public static void ResetInputs()
	{
		_CreatecObject();
		for (int i = 0; i < _inputLength + 1; i++)
		{
			_SetKey(i, _defaultStrings[i, 0], _defaultStrings[i, 1], _defaultStrings[i, 2]);
		}
		for (int j = 0; j < _axisLength; j++)
		{
			_invertAxis[j] = false;
		}
		Clear();
		_SaveDefaults();
		_SaveInputs();
		_SaveAxInverted();
	}

	public static void Clear()
	{
		PlayerPrefs.DeleteKey("_axInv");
		PlayerPrefs.DeleteKey("_axis");
		PlayerPrefs.DeleteKey("_indAxSens");
		PlayerPrefs.DeleteKey("_count");
		PlayerPrefs.DeleteKey("_defaults");
		PlayerPrefs.DeleteKey("_descr");
		PlayerPrefs.DeleteKey("_inp");
		PlayerPrefs.DeleteKey("_alt_inp");
		PlayerPrefs.DeleteKey("_inpStr");
		PlayerPrefs.DeleteKey("_alt_inpStr");
		PlayerPrefs.DeleteKey("_dubl");
		PlayerPrefs.DeleteKey("_saveCals");
	}

	public static bool AxisInverted(string axisName, bool invertedStatus)
	{
		_CreatecObject();
		int num = _FindAxisByDescription(axisName);
		if (num > -1)
		{
			_invertAxis[num] = invertedStatus;
			_SaveAxInverted();
			return invertedStatus;
		}
		Debug.LogWarning("Couldn't find an axis match for " + axisName + " while trying to set inversion status. Is it possible you typed it wrong?");
		return false;
	}

	public static bool AxisInverted(string axisName)
	{
		_CreatecObject();
		int num = _FindAxisByDescription(axisName);
		if (num > -1)
		{
			return _invertAxis[num];
		}
		Debug.LogWarning("Couldn't find an axis match for " + axisName + " while trying to get inversion status. Is it possible you typed it wrong?");
		return false;
	}

	private void OnGUI()
	{
		if (_showMenu)
		{
			GUI.skin = cSkin;
			int num = Mathf.Clamp(_inputLength, 2, 10) * 15;
			windowRect = new Rect(50f, num / 2, Screen.width - 100, Screen.height - num);
			windowRect = GUILayout.Window(0, windowRect, MenuWindow, string.Empty);
			if (showPopUp)
			{
				GUI.Window(0, new Rect(Screen.width / 2 - 200, Screen.height / 2 - 150, 400f, 300f), popUp, string.Empty);
			}
		}
	}

	private void popUp(int windowID)
	{
		GUILayout.Space(50f);
		GUILayout.Box("Please leave all analog inputs in their neutral positions.");
		GUILayout.Space(30f);
		if (GUILayout.Button("Click here when ready.", _menuButtonsString))
		{
			Calibrate();
			showPopUp = false;
		}
	}

	private void MenuWindow(int windowID)
	{
		GUILayout.BeginHorizontal("box");
		float num = windowRect.width / 3f - 50f;
		GUILayout.Label("Action", _menuHeaderString, GUILayout.Width(num + 8f));
		GUILayout.Label("Primary", _menuHeaderString, GUILayout.Width(num + 8f));
		GUILayout.Label("Secondary", _menuHeaderString, GUILayout.Width(num + 8f));
		GUILayout.EndHorizontal();
		_scrollPosition = GUILayout.BeginScrollView(_scrollPosition);
		GUILayout.BeginHorizontal();
		GUILayout.BeginVertical();
		for (int i = 0; i < length; i++)
		{
			GUILayout.BeginHorizontal();
			GUILayout.Label(GetText(i, 0), _menuActionsString, GUILayout.Width(num));
			if (GUILayout.Button(GetText(i, 1), _menuInputsString, GUILayout.Width(num)) && Input.GetMouseButtonUp(0) && Time.realtimeSinceStartup > mouseTimer)
			{
				ChangeKey(i, 1);
			}
			if (GUILayout.Button(GetText(i, 2), _menuInputsString, GUILayout.Width(num)) && Input.GetMouseButtonUp(0) && Time.realtimeSinceStartup > mouseTimer)
			{
				ChangeKey(i, 2);
			}
			GUILayout.EndHorizontal();
		}
		GUILayout.EndVertical();
		GUILayout.EndHorizontal();
		GUILayout.EndScrollView();
		GUILayout.Space(20f);
		GUILayout.BeginHorizontal("textfield");
		if (GUILayout.Button("Reset to defaults", _menuButtonsString, GUILayout.Width(num + 10f)) && Input.GetMouseButtonUp(0))
		{
			ResetInputs();
		}
		if (GUILayout.Button("Calibrate joysticks", _menuButtonsString, GUILayout.Width(num + 10f)) && Input.GetMouseButtonUp(0))
		{
			showPopUp = true;
		}
		if (GUILayout.Button("Close", _menuButtonsString, GUILayout.Width(num + 10f)) && Input.GetMouseButtonUp(0))
		{
			_showMenu = false;
		}
		GUILayout.EndHorizontal();
	}

	private void Update()
	{
		if (_scanning && _cScanInput == 0)
		{
			_ChangeKey(primary: (!string.IsNullOrEmpty(_axisPrimary[_cScanIndex])) ? _axisPrimary[_cScanIndex] : _inputPrimary[_cScanIndex].ToString(), secondary: (!string.IsNullOrEmpty(_axisSecondary[_cScanIndex])) ? _axisSecondary[_cScanIndex] : _inputSecondary[_cScanIndex].ToString(), num: _cScanIndex, action: _inputName[_cScanIndex]);
			_scanning = false;
		}
		if (!_scanning)
		{
			CheckInputs();
		}
		if (_cScanInput != 0)
		{
			_InputScans();
		}
	}

	public static bool ShowMenu()
	{
		_CreatecObject();
		return _showMenu;
	}

	public static void ShowMenu(bool state)
	{
		ShowMenu(state, _menuHeaderString, _menuActionsString, _menuInputsString, _menuButtonsString);
	}

	public static void ShowMenu(bool state, string menuHeader)
	{
		ShowMenu(state, menuHeader, _menuActionsString, _menuInputsString, _menuButtonsString);
	}

	public static void ShowMenu(bool state, string menuHeader, string menuActions)
	{
		ShowMenu(state, menuHeader, menuActions, _menuInputsString, _menuButtonsString);
	}

	public static void ShowMenu(bool state, string menuHeader, string menuActions, string menuInputs)
	{
		ShowMenu(state, menuHeader, menuActions, menuInputs, _menuButtonsString);
	}

	public static void ShowMenu(bool state, string menuHeader, string menuActions, string menuInputs, string menuButtons)
	{
		_CreatecObject();
		_menuHeaderString = menuHeader;
		_menuActionsString = menuActions;
		_menuInputsString = menuInputs;
		_menuButtonsString = menuButtons;
		_showMenu = state;
	}

	private static void _CreatecObject()
	{
		if (!_cObjectOn)
		{
			GameObject gameObject = (GameObject.Find("cInput") ? GameObject.Find("cInput") : new GameObject());
			gameObject.name = "cInput";
			gameObject.AddComponent<cInput>();
			_cObjectOn = true;
		}
	}

	private void _CheckingDuplicates(int _num, int _count)
	{
		if (allowDuplicates)
		{
			return;
		}
		for (int i = 0; i < length; i++)
		{
			if (_count == 1)
			{
				if (_num != i && _inputPrimary[_num] == _inputPrimary[i])
				{
					_inputPrimary[i] = KeyCode.None;
				}
				if (_inputPrimary[_num] == _inputSecondary[i])
				{
					_inputSecondary[i] = KeyCode.None;
				}
			}
			if (_count == 2)
			{
				if (_inputSecondary[_num] == _inputPrimary[i])
				{
					_inputPrimary[i] = KeyCode.None;
				}
				if (_num != i && _inputSecondary[_num] == _inputSecondary[i])
				{
					_inputSecondary[i] = KeyCode.None;
				}
			}
		}
	}

	private void _CheckingDuplicateStrings(int _num, int _count)
	{
		if (allowDuplicates)
		{
			return;
		}
		for (int i = 0; i < length; i++)
		{
			if (_count == 1)
			{
				if (_num != i && _axisPrimary[_num] == _axisPrimary[i])
				{
					_axisPrimary[i] = string.Empty;
					_inputPrimary[i] = KeyCode.None;
				}
				if (_axisPrimary[_num] == _axisSecondary[i])
				{
					_axisSecondary[i] = string.Empty;
					_inputSecondary[i] = KeyCode.None;
				}
			}
			if (_count == 2)
			{
				if (_axisSecondary[_num] == _axisPrimary[i])
				{
					_axisPrimary[i] = string.Empty;
					_inputPrimary[i] = KeyCode.None;
				}
				if (_num != i && _axisSecondary[_num] == _axisSecondary[i])
				{
					_axisSecondary[i] = string.Empty;
					_inputSecondary[i] = KeyCode.None;
				}
			}
		}
	}

	private void _InputScans()
	{
		if (_scanning && Input.anyKeyDown)
		{
			KeyCode keyCode = KeyCode.None;
			for (int i = 0; i < 450; i++)
			{
				KeyCode keyCode2 = (KeyCode)i;
				if (keyCode2.ToString().StartsWith("Mouse"))
				{
					if (!_allowMouseButtons)
					{
						continue;
					}
				}
				else if (keyCode2.ToString().StartsWith("Joystick"))
				{
					if (!_allowJoystickButtons)
					{
						continue;
					}
				}
				else if (!_allowKeyboard)
				{
					continue;
				}
				if (Input.GetKeyDown(keyCode2))
				{
					keyCode = keyCode2;
				}
			}
			if (keyCode != KeyCode.None)
			{
				bool flag = true;
				for (int j = 0; j < _forbiddenKeys.Count; j++)
				{
					if (keyCode == _forbiddenKeys[j])
					{
						flag = false;
					}
				}
				if (flag)
				{
					if (_cScanInput == 1)
					{
						_inputPrimary[_cScanIndex] = keyCode;
						_axisPrimary[_cScanIndex] = string.Empty;
						_CheckingDuplicates(_cScanIndex, _cScanInput);
					}
					if (_cScanInput == 2)
					{
						_inputSecondary[_cScanIndex] = keyCode;
						_axisSecondary[_cScanIndex] = string.Empty;
						_CheckingDuplicates(_cScanIndex, _cScanInput);
					}
				}
				_cScanInput = 0;
			}
		}
		if (_allowMouseButtons)
		{
			if (Input.GetAxis("Mouse Wheel") > 0f && !Input.GetKey(KeyCode.Escape))
			{
				if (_cScanInput == 1)
				{
					_axisPrimary[_cScanIndex] = "Mouse Wheel Up";
				}
				if (_cScanInput == 2)
				{
					_axisSecondary[_cScanIndex] = "Mouse Wheel Up";
				}
				_CheckingDuplicateStrings(_cScanIndex, _cScanInput);
				_cScanInput = 0;
			}
			else if (Input.GetAxis("Mouse Wheel") < 0f && !Input.GetKey(KeyCode.Escape))
			{
				if (_cScanInput == 1)
				{
					_axisPrimary[_cScanIndex] = "Mouse Wheel Down";
				}
				if (_cScanInput == 2)
				{
					_axisSecondary[_cScanIndex] = "Mouse Wheel Down";
				}
				_CheckingDuplicateStrings(_cScanIndex, _cScanInput);
				_cScanInput = 0;
			}
		}
		if (_allowMouseAxis)
		{
			if (Input.GetAxis("Mouse Horizontal") < 0f - _builtInAxisDeadzone && !Input.GetKey(KeyCode.Escape))
			{
				if (_cScanInput == 1)
				{
					_axisPrimary[_cScanIndex] = "Mouse Left";
				}
				if (_cScanInput == 2)
				{
					_axisSecondary[_cScanIndex] = "Mouse Left";
				}
				_CheckingDuplicateStrings(_cScanIndex, _cScanInput);
				_cScanInput = 0;
			}
			else if (Input.GetAxis("Mouse Horizontal") > _builtInAxisDeadzone && !Input.GetKey(KeyCode.Escape))
			{
				if (_cScanInput == 1)
				{
					_axisPrimary[_cScanIndex] = "Mouse Right";
				}
				if (_cScanInput == 2)
				{
					_axisSecondary[_cScanIndex] = "Mouse Right";
				}
				_CheckingDuplicateStrings(_cScanIndex, _cScanInput);
				_cScanInput = 0;
			}
			if (Input.GetAxis("Mouse Vertical") > _builtInAxisDeadzone && !Input.GetKey(KeyCode.Escape))
			{
				if (_cScanInput == 1)
				{
					_axisPrimary[_cScanIndex] = "Mouse Up";
				}
				if (_cScanInput == 2)
				{
					_axisSecondary[_cScanIndex] = "Mouse Up";
				}
				_CheckingDuplicateStrings(_cScanIndex, _cScanInput);
				_cScanInput = 0;
			}
			else if (Input.GetAxis("Mouse Vertical") < 0f - _builtInAxisDeadzone && !Input.GetKey(KeyCode.Escape))
			{
				if (_cScanInput == 1)
				{
					_axisPrimary[_cScanIndex] = "Mouse Down";
				}
				if (_cScanInput == 2)
				{
					_axisSecondary[_cScanIndex] = "Mouse Down";
				}
				_CheckingDuplicateStrings(_cScanIndex, _cScanInput);
				_cScanInput = 0;
			}
		}
		if (!_allowJoystickAxis)
		{
			return;
		}
		for (int k = 1; k < _numGamepads; k++)
		{
			for (int l = 1; l <= 10; l++)
			{
				string description = _joyStrings[k, l];
				string text = _joyStringsPos[k, l];
				string text2 = _joyStringsNeg[k, l];
				float num = _GetCalibratedAxisInput(description);
				if (!_scanning || !(Mathf.Abs(num) > _builtInAxisDeadzone) || Input.GetKey(KeyCode.Escape))
				{
					continue;
				}
				if (_cScanInput == 1)
				{
					if (num > _builtInAxisDeadzone)
					{
						_axisPrimary[_cScanIndex] = text;
					}
					else if (num < 0f - _builtInAxisDeadzone)
					{
						_axisPrimary[_cScanIndex] = text2;
					}
					_CheckingDuplicateStrings(_cScanIndex, _cScanInput);
					_cScanInput = 0;
					break;
				}
				if (_cScanInput == 2)
				{
					if (num > _builtInAxisDeadzone)
					{
						_axisSecondary[_cScanIndex] = text;
					}
					else if (num < 0f - _builtInAxisDeadzone)
					{
						_axisSecondary[_cScanIndex] = text2;
					}
					_CheckingDuplicateStrings(_cScanIndex, _cScanInput);
					_cScanInput = 0;
					break;
				}
			}
		}
	}
}
