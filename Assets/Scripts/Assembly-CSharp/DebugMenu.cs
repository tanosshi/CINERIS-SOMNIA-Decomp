using System.Collections.Generic;
using UnityEngine;

public class DebugMenu : MonoBehaviour
{
	private const KeyCode DEBUG_KEY = KeyCode.Home;

	public bool showDebug;

	public Material debugMaterial;

	private string m_isLoadedLevelName = string.Empty;

	private string m_showLevelName = string.Empty;

	private bool m_showEventObject;

	private bool m_prevShowEventObject;

	private bool m_showCheatWindow;

	private Rect m_cheatWindowRect = new Rect(0f, 32f, 320f, 380f);

	private float m_moveSpeedMultiply = 1f;

	private bool m_showAchivementWindow;

	private Rect m_achivementWindowRect = new Rect(320f, 32f, 320f, 500f);

	private List<GameObject> m_debugObject;

	private void Awake()
	{
		m_debugObject = new List<GameObject>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Home))
		{
			showDebug = !showDebug;
			if (showDebug)
			{
				Screen.lockCursor = false;
				Screen.showCursor = true;
			}
			else
			{
				Screen.lockCursor = true;
				Screen.showCursor = false;
			}
		}
		if (showDebug && m_isLoadedLevelName != Application.loadedLevelName)
		{
			m_isLoadedLevelName = Application.loadedLevelName;
			m_showLevelName = m_isLoadedLevelName;
			m_showLevelName = m_showLevelName.Replace("[00-]", string.Empty);
			if (m_showEventObject)
			{
				_GenerateEventObject();
			}
		}
		if (m_showEventObject != m_prevShowEventObject)
		{
			if (m_showEventObject)
			{
				_GenerateEventObject();
			}
			else
			{
				_DeleteEventObject();
			}
			m_prevShowEventObject = m_showEventObject;
		}
	}

	private void OnGUI()
	{
		if (showDebug)
		{
			GUILayout.BeginHorizontal(GUI.skin.box);
			m_showCheatWindow = GUILayout.Toggle(m_showCheatWindow, "チート");
			m_showAchivementWindow = GUILayout.Toggle(m_showAchivementWindow, "実績");
			GUILayout.EndHorizontal();
			GUILayout.Label((1f / Time.deltaTime).ToString("0.00000") + " FPS");
			GUILayout.Label("Loaded Scene : " + m_showLevelName);
			if (m_showCheatWindow)
			{
				m_cheatWindowRect = GUI.Window(0, m_cheatWindowRect, ShowCheatWindow, "チートコマンド一覧");
			}
			if (m_showAchivementWindow)
			{
				m_achivementWindowRect = GUI.Window(1, m_achivementWindowRect, ShowAchievementWindow, "実績一覧");
			}
		}
	}

	private void ShowCheatWindow(int windowID)
	{
		GUI.DragWindow(new Rect(0f, 0f, 320f, 20f));
		GUILayout.Space(16f);
		GUILayout.Label("▼移動速度倍率");
		GUILayout.Label("x" + m_moveSpeedMultiply);
		m_moveSpeedMultiply = GUILayout.HorizontalSlider(m_moveSpeedMultiply, 1f, 30f);
		if (GUILayout.Button("移動速度を適用"))
		{
			SendMessage("SetMoveSpeedMultiply", m_moveSpeedMultiply, SendMessageOptions.DontRequireReceiver);
		}
		GUILayout.Space(16f);
		if (GUILayout.Button("全アイテム・ファイル入手"))
		{
			SendMessage("GetAllItemsAndFiles", SendMessageOptions.DontRequireReceiver);
		}
		GUILayout.Space(16f);
		if (GUILayout.Button("イベントの可視化切り替え"))
		{
			m_showEventObject = !m_showEventObject;
		}
		GUILayout.Space(32f);
		if (GUILayout.Button("オフィーリアが次の部屋で待ち伏せ"))
		{
			SendMessage("WaitOphelia", SendMessageOptions.DontRequireReceiver);
		}
		if (GUILayout.Button("今いる部屋にオフィーリアを召喚"))
		{
			SendMessage("SummonOphelia", SendMessageOptions.DontRequireReceiver);
		}
		GUILayout.Space(32f);
		if (GUILayout.Button("5秒後にランダム再生BGMを再生/停止"))
		{
			SendMessage("ToggleRandomBgm", SendMessageOptions.DontRequireReceiver);
		}
	}

	private void ShowAchievementWindow(int windowID)
	{
		GUI.DragWindow(new Rect(0f, 0f, 320f, 20f));
		GUILayout.Space(16f);
		GUILayout.Label("少女と魚");
		GUILayout.BeginHorizontal();
		if (GUILayout.Button("解除"))
		{
			ControlAchievement(true, 0);
		}
		if (GUILayout.Button("ロック"))
		{
			ControlAchievement(false, 0);
		}
		GUILayout.EndHorizontal();
		GUILayout.Label("薔薇園");
		GUILayout.BeginHorizontal();
		if (GUILayout.Button("解除"))
		{
			ControlAchievement(true, 1);
		}
		if (GUILayout.Button("ロック"))
		{
			ControlAchievement(false, 1);
		}
		GUILayout.EndHorizontal();
		GUILayout.Label("青い鳥");
		GUILayout.BeginHorizontal();
		if (GUILayout.Button("解除"))
		{
			ControlAchievement(true, 2);
		}
		if (GUILayout.Button("ロック"))
		{
			ControlAchievement(false, 2);
		}
		GUILayout.EndHorizontal();
		GUILayout.Label("告解");
		GUILayout.BeginHorizontal();
		if (GUILayout.Button("解除"))
		{
			ControlAchievement(true, 3);
		}
		if (GUILayout.Button("ロック"))
		{
			ControlAchievement(false, 3);
		}
		GUILayout.EndHorizontal();
		GUILayout.Label("悪夢");
		GUILayout.BeginHorizontal();
		if (GUILayout.Button("解除"))
		{
			ControlAchievement(true, 4);
		}
		if (GUILayout.Button("ロック"))
		{
			ControlAchievement(false, 4);
		}
		GUILayout.EndHorizontal();
		GUILayout.Label("白昼夢");
		GUILayout.BeginHorizontal();
		if (GUILayout.Button("解除"))
		{
			ControlAchievement(true, 5);
		}
		if (GUILayout.Button("ロック"))
		{
			ControlAchievement(false, 5);
		}
		GUILayout.EndHorizontal();
		GUILayout.Label("灰の鍵");
		GUILayout.BeginHorizontal();
		if (GUILayout.Button("解除"))
		{
			ControlAchievement(true, 6);
		}
		if (GUILayout.Button("ロック"))
		{
			ControlAchievement(false, 6);
		}
		GUILayout.EndHorizontal();
		GUILayout.Label("見果てぬ夢");
		GUILayout.BeginHorizontal();
		if (GUILayout.Button("解除"))
		{
			ControlAchievement(true, 7);
		}
		if (GUILayout.Button("ロック"))
		{
			ControlAchievement(false, 7);
		}
		GUILayout.EndHorizontal();
		GUILayout.Label("亡骸の街");
		GUILayout.BeginHorizontal();
		if (GUILayout.Button("解除"))
		{
			ControlAchievement(true, 8);
		}
		if (GUILayout.Button("ロック"))
		{
			ControlAchievement(false, 8);
		}
		GUILayout.EndHorizontal();
	}

	private void ControlAchievement(bool isSet, int id)
	{
		GameObject gameObject = GameObject.FindWithTag("SteamManager");
		if ((bool)gameObject)
		{
			if (isSet)
			{
				gameObject.SendMessage("UnlockSteamAchievement", id, SendMessageOptions.DontRequireReceiver);
			}
			else
			{
				gameObject.SendMessage("LockSteamAchievement", id, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	private void _GenerateEventObject()
	{
		m_debugObject.Clear();
		GameObject[] array = GameObject.FindGameObjectsWithTag("Event");
		for (int i = 0; i < array.Length; i++)
		{
			if (!(array[i].GetComponent("Event_00_ShowText") != null))
			{
				continue;
			}
			BoxCollider component = array[i].GetComponent<BoxCollider>();
			if (component != null)
			{
				GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
				gameObject.transform.parent = array[i].transform;
				gameObject.transform.localPosition = component.center;
				gameObject.transform.localRotation = Quaternion.identity;
				gameObject.transform.localScale = component.size;
				gameObject.GetComponent<Renderer>().material = debugMaterial;
				Object.Destroy(gameObject.GetComponent<BoxCollider>());
				m_debugObject.Add(gameObject);
			}
			SphereCollider component2 = array[i].GetComponent<SphereCollider>();
			if (component2 != null)
			{
				GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				gameObject2.transform.parent = array[i].transform;
				gameObject2.transform.localPosition = component2.center;
				gameObject2.transform.localRotation = Quaternion.identity;
				gameObject2.transform.localScale = new Vector3(component2.radius * 2f, component2.radius * 2f, component2.radius * 2f);
				gameObject2.GetComponent<Renderer>().material = debugMaterial;
				Object.Destroy(gameObject2.GetComponent<SphereCollider>());
				m_debugObject.Add(gameObject2);
			}
			CapsuleCollider component3 = array[i].GetComponent<CapsuleCollider>();
			if (component3 != null)
			{
				GameObject gameObject3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
				gameObject3.transform.parent = array[i].transform;
				gameObject3.transform.localPosition = component3.center;
				switch (component3.direction)
				{
				case 0:
					gameObject3.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));
					break;
				case 1:
					gameObject3.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
					break;
				case 2:
					gameObject3.transform.localRotation = Quaternion.Euler(new Vector3(90f, 0f, 0f));
					break;
				}
				gameObject3.transform.localScale = new Vector3(component3.radius * 2f, component3.height, component3.radius * 2f);
				gameObject3.GetComponent<Renderer>().material = debugMaterial;
				Object.Destroy(gameObject3.GetComponent<BoxCollider>());
				m_debugObject.Add(gameObject3);
			}
		}
	}

	private void _DeleteEventObject()
	{
		for (int i = 0; i < m_debugObject.Count; i++)
		{
			Object.Destroy(m_debugObject[i]);
		}
		m_debugObject.Clear();
	}
}
