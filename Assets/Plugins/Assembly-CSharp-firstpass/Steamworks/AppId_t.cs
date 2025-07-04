using System;

namespace Steamworks
{
	[Serializable]
	public struct AppId_t : IEquatable<AppId_t>, IComparable<AppId_t>
	{
		public static readonly AppId_t Invalid = new AppId_t(0u);

		public uint m_AppId;

		public AppId_t(uint value)
		{
			m_AppId = value;
		}

		public override string ToString()
		{
			return m_AppId.ToString();
		}

		public override bool Equals(object other)
		{
			return other is AppId_t && this == (AppId_t)other;
		}

		public override int GetHashCode()
		{
			return m_AppId.GetHashCode();
		}

		public bool Equals(AppId_t other)
		{
			return m_AppId == other.m_AppId;
		}

		public int CompareTo(AppId_t other)
		{
			return m_AppId.CompareTo(other.m_AppId);
		}

		public static bool operator ==(AppId_t x, AppId_t y)
		{
			return x.m_AppId == y.m_AppId;
		}

		public static bool operator !=(AppId_t x, AppId_t y)
		{
			return !(x == y);
		}

		public static explicit operator AppId_t(uint value)
		{
			return new AppId_t(value);
		}

		public static explicit operator uint(AppId_t that)
		{
			return that.m_AppId;
		}
	}
}
