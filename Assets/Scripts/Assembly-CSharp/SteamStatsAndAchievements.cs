using Steamworks;
using UnityEngine;

internal class SteamStatsAndAchievements : MonoBehaviour
{
	private enum Achievement
	{
		ACH_FISH = 0,
		ACH_ROSE = 1,
		ACH_BLUEBIRD = 2,
		ACH_CAT = 3,
		ACH_NIGHTMARE = 4,
		ACH_DAYDREAM = 5,
		ACH_ASHKEY = 6,
		ACH_NORMAL = 7,
		ACH_TRUE = 8
	}

	private class Achievement_t
	{
		public Achievement m_eAchievementID;

		public string m_strName;

		public string m_strDescription;

		public bool m_bAchieved;

		public Achievement_t(Achievement achievementID, string name, string desc)
		{
			m_eAchievementID = achievementID;
			m_strName = name;
			m_strDescription = desc;
			m_bAchieved = false;
		}
	}

	private Achievement_t[] m_Achievements = new Achievement_t[9]
	{
		new Achievement_t(Achievement.ACH_FISH, string.Empty, string.Empty),
		new Achievement_t(Achievement.ACH_ROSE, string.Empty, string.Empty),
		new Achievement_t(Achievement.ACH_BLUEBIRD, string.Empty, string.Empty),
		new Achievement_t(Achievement.ACH_CAT, string.Empty, string.Empty),
		new Achievement_t(Achievement.ACH_NIGHTMARE, string.Empty, string.Empty),
		new Achievement_t(Achievement.ACH_DAYDREAM, string.Empty, string.Empty),
		new Achievement_t(Achievement.ACH_ASHKEY, string.Empty, string.Empty),
		new Achievement_t(Achievement.ACH_NORMAL, string.Empty, string.Empty),
		new Achievement_t(Achievement.ACH_TRUE, string.Empty, string.Empty)
	};

	private CGameID m_GameID;

	private bool m_bRequestedStats;

	private bool m_bStatsValid;

	private bool m_bStoreStats;

	protected Callback<UserStatsReceived_t> m_UserStatsReceived;

	protected Callback<UserStatsStored_t> m_UserStatsStored;

	protected Callback<UserAchievementStored_t> m_UserAchievementStored;

	private void Start()
	{
		m_GameID = new CGameID(SteamUtils.GetAppID());
		m_UserStatsReceived = Callback<UserStatsReceived_t>.Create(OnUserStatsReceived);
		m_UserStatsStored = Callback<UserStatsStored_t>.Create(OnUserStatsStored);
		m_UserAchievementStored = Callback<UserAchievementStored_t>.Create(OnAchievementStored);
		m_bRequestedStats = false;
		m_bStatsValid = false;
	}

	public void UnlockSteamAchievement(int id)
	{
		if (!m_Achievements[id].m_bAchieved)
		{
			UnlockAchievement(m_Achievements[id]);
		}
	}

	public void LockSteamAchievement(int id)
	{
		LockAchievement(m_Achievements[id]);
	}

	private void Update()
	{
		if (!SteamManager.Initialized)
		{
			return;
		}
		if (!m_bRequestedStats)
		{
			if (!SteamManager.Initialized)
			{
				m_bRequestedStats = true;
				return;
			}
			bool bRequestedStats = SteamUserStats.RequestCurrentStats();
			m_bRequestedStats = bRequestedStats;
		}
		if (m_bStatsValid && m_bStoreStats)
		{
			bool flag = SteamUserStats.StoreStats();
			m_bStoreStats = !flag;
		}
	}

	private void UnlockAchievement(Achievement_t achievement)
	{
		achievement.m_bAchieved = true;
		SteamUserStats.SetAchievement(achievement.m_eAchievementID.ToString());
		m_bStoreStats = true;
	}

	private void LockAchievement(Achievement_t achievement)
	{
		achievement.m_bAchieved = false;
		SteamUserStats.ClearAchievement(achievement.m_eAchievementID.ToString());
		m_bStoreStats = true;
	}

	private void OnUserStatsReceived(UserStatsReceived_t pCallback)
	{
		if (!SteamManager.Initialized || (ulong)m_GameID != pCallback.m_nGameID)
		{
			return;
		}
		if (pCallback.m_eResult == EResult.k_EResultOK)
		{
			Debug.Log("Received stats and achievements from Steam\n");
			m_bStatsValid = true;
			Achievement_t[] achievements = m_Achievements;
			foreach (Achievement_t achievement_t in achievements)
			{
				if (SteamUserStats.GetAchievement(achievement_t.m_eAchievementID.ToString(), out achievement_t.m_bAchieved))
				{
					achievement_t.m_strName = SteamUserStats.GetAchievementDisplayAttribute(achievement_t.m_eAchievementID.ToString(), "name");
					achievement_t.m_strDescription = SteamUserStats.GetAchievementDisplayAttribute(achievement_t.m_eAchievementID.ToString(), "desc");
				}
				else
				{
					Debug.LogWarning(string.Concat("SteamUserStats.GetAchievement failed for Achievement ", achievement_t.m_eAchievementID, "\nIs it registered in the Steam Partner site?"));
				}
			}
		}
		else
		{
			Debug.Log("RequestStats - failed, " + pCallback.m_eResult);
		}
	}

	private void OnUserStatsStored(UserStatsStored_t pCallback)
	{
		if ((ulong)m_GameID == pCallback.m_nGameID)
		{
			if (pCallback.m_eResult == EResult.k_EResultOK)
			{
				Debug.Log("StoreStats - success");
			}
			else if (pCallback.m_eResult == EResult.k_EResultInvalidParam)
			{
				Debug.Log("StoreStats - some failed to validate");
				OnUserStatsReceived(new UserStatsReceived_t
				{
					m_eResult = EResult.k_EResultOK,
					m_nGameID = (ulong)m_GameID
				});
			}
			else
			{
				Debug.Log("StoreStats - failed, " + pCallback.m_eResult);
			}
		}
	}

	private void OnAchievementStored(UserAchievementStored_t pCallback)
	{
		if ((ulong)m_GameID == pCallback.m_nGameID)
		{
			if (pCallback.m_nMaxProgress == 0)
			{
				Debug.Log("Achievement '" + pCallback.m_rgchAchievementName + "' unlocked!");
				return;
			}
			Debug.Log("Achievement '" + pCallback.m_rgchAchievementName + "' progress callback, (" + pCallback.m_nCurProgress + "," + pCallback.m_nMaxProgress + ")");
		}
	}
}
