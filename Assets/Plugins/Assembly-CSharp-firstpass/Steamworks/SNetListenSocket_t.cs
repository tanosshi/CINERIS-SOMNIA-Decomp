using System;

namespace Steamworks
{
	[Serializable]
	public struct SNetListenSocket_t : IEquatable<SNetListenSocket_t>, IComparable<SNetListenSocket_t>
	{
		public uint m_SNetListenSocket;

		public SNetListenSocket_t(uint value)
		{
			m_SNetListenSocket = value;
		}

		public override string ToString()
		{
			return m_SNetListenSocket.ToString();
		}

		public override bool Equals(object other)
		{
			return other is SNetListenSocket_t && this == (SNetListenSocket_t)other;
		}

		public override int GetHashCode()
		{
			return m_SNetListenSocket.GetHashCode();
		}

		public bool Equals(SNetListenSocket_t other)
		{
			return m_SNetListenSocket == other.m_SNetListenSocket;
		}

		public int CompareTo(SNetListenSocket_t other)
		{
			return m_SNetListenSocket.CompareTo(other.m_SNetListenSocket);
		}

		public static bool operator ==(SNetListenSocket_t x, SNetListenSocket_t y)
		{
			return x.m_SNetListenSocket == y.m_SNetListenSocket;
		}

		public static bool operator !=(SNetListenSocket_t x, SNetListenSocket_t y)
		{
			return !(x == y);
		}

		public static explicit operator SNetListenSocket_t(uint value)
		{
			return new SNetListenSocket_t(value);
		}

		public static explicit operator uint(SNetListenSocket_t that)
		{
			return that.m_SNetListenSocket;
		}
	}
}
