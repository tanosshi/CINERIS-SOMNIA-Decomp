using System;

namespace Steamworks
{
	[Serializable]
	public struct SteamItemInstanceID_t : IEquatable<SteamItemInstanceID_t>, IComparable<SteamItemInstanceID_t>
	{
		public static readonly SteamItemInstanceID_t Invalid = new SteamItemInstanceID_t(ulong.MaxValue);

		public ulong m_SteamItemInstanceID;

		public SteamItemInstanceID_t(ulong value)
		{
			m_SteamItemInstanceID = value;
		}

		public override string ToString()
		{
			return m_SteamItemInstanceID.ToString();
		}

		public override bool Equals(object other)
		{
			return other is SteamItemInstanceID_t && this == (SteamItemInstanceID_t)other;
		}

		public override int GetHashCode()
		{
			return m_SteamItemInstanceID.GetHashCode();
		}

		public bool Equals(SteamItemInstanceID_t other)
		{
			return m_SteamItemInstanceID == other.m_SteamItemInstanceID;
		}

		public int CompareTo(SteamItemInstanceID_t other)
		{
			return m_SteamItemInstanceID.CompareTo(other.m_SteamItemInstanceID);
		}

		public static bool operator ==(SteamItemInstanceID_t x, SteamItemInstanceID_t y)
		{
			return x.m_SteamItemInstanceID == y.m_SteamItemInstanceID;
		}

		public static bool operator !=(SteamItemInstanceID_t x, SteamItemInstanceID_t y)
		{
			return !(x == y);
		}

		public static explicit operator SteamItemInstanceID_t(ulong value)
		{
			return new SteamItemInstanceID_t(value);
		}

		public static explicit operator ulong(SteamItemInstanceID_t that)
		{
			return that.m_SteamItemInstanceID;
		}
	}
}
