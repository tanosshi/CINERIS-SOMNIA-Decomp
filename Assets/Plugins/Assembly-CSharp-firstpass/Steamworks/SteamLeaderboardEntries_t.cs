using System;

namespace Steamworks
{
	[Serializable]
	public struct SteamLeaderboardEntries_t : IEquatable<SteamLeaderboardEntries_t>, IComparable<SteamLeaderboardEntries_t>
	{
		public ulong m_SteamLeaderboardEntries;

		public SteamLeaderboardEntries_t(ulong value)
		{
			m_SteamLeaderboardEntries = value;
		}

		public override string ToString()
		{
			return m_SteamLeaderboardEntries.ToString();
		}

		public override bool Equals(object other)
		{
			return other is SteamLeaderboardEntries_t && this == (SteamLeaderboardEntries_t)other;
		}

		public override int GetHashCode()
		{
			return m_SteamLeaderboardEntries.GetHashCode();
		}

		public bool Equals(SteamLeaderboardEntries_t other)
		{
			return m_SteamLeaderboardEntries == other.m_SteamLeaderboardEntries;
		}

		public int CompareTo(SteamLeaderboardEntries_t other)
		{
			return m_SteamLeaderboardEntries.CompareTo(other.m_SteamLeaderboardEntries);
		}

		public static bool operator ==(SteamLeaderboardEntries_t x, SteamLeaderboardEntries_t y)
		{
			return x.m_SteamLeaderboardEntries == y.m_SteamLeaderboardEntries;
		}

		public static bool operator !=(SteamLeaderboardEntries_t x, SteamLeaderboardEntries_t y)
		{
			return !(x == y);
		}

		public static explicit operator SteamLeaderboardEntries_t(ulong value)
		{
			return new SteamLeaderboardEntries_t(value);
		}

		public static explicit operator ulong(SteamLeaderboardEntries_t that)
		{
			return that.m_SteamLeaderboardEntries;
		}
	}
}
