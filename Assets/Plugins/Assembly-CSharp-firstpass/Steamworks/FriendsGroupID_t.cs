using System;

namespace Steamworks
{
	[Serializable]
	public struct FriendsGroupID_t : IEquatable<FriendsGroupID_t>, IComparable<FriendsGroupID_t>
	{
		public static readonly FriendsGroupID_t Invalid = new FriendsGroupID_t(-1);

		public short m_FriendsGroupID;

		public FriendsGroupID_t(short value)
		{
			m_FriendsGroupID = value;
		}

		public override string ToString()
		{
			return m_FriendsGroupID.ToString();
		}

		public override bool Equals(object other)
		{
			return other is FriendsGroupID_t && this == (FriendsGroupID_t)other;
		}

		public override int GetHashCode()
		{
			return m_FriendsGroupID.GetHashCode();
		}

		public bool Equals(FriendsGroupID_t other)
		{
			return m_FriendsGroupID == other.m_FriendsGroupID;
		}

		public int CompareTo(FriendsGroupID_t other)
		{
			return m_FriendsGroupID.CompareTo(other.m_FriendsGroupID);
		}

		public static bool operator ==(FriendsGroupID_t x, FriendsGroupID_t y)
		{
			return x.m_FriendsGroupID == y.m_FriendsGroupID;
		}

		public static bool operator !=(FriendsGroupID_t x, FriendsGroupID_t y)
		{
			return !(x == y);
		}

		public static explicit operator FriendsGroupID_t(short value)
		{
			return new FriendsGroupID_t(value);
		}

		public static explicit operator short(FriendsGroupID_t that)
		{
			return that.m_FriendsGroupID;
		}
	}
}
