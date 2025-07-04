using System;

namespace Steamworks
{
	[Serializable]
	public struct ClientUnifiedMessageHandle : IEquatable<ClientUnifiedMessageHandle>, IComparable<ClientUnifiedMessageHandle>
	{
		public static readonly ClientUnifiedMessageHandle Invalid = new ClientUnifiedMessageHandle(0uL);

		public ulong m_ClientUnifiedMessageHandle;

		public ClientUnifiedMessageHandle(ulong value)
		{
			m_ClientUnifiedMessageHandle = value;
		}

		public override string ToString()
		{
			return m_ClientUnifiedMessageHandle.ToString();
		}

		public override bool Equals(object other)
		{
			return other is ClientUnifiedMessageHandle && this == (ClientUnifiedMessageHandle)other;
		}

		public override int GetHashCode()
		{
			return m_ClientUnifiedMessageHandle.GetHashCode();
		}

		public bool Equals(ClientUnifiedMessageHandle other)
		{
			return m_ClientUnifiedMessageHandle == other.m_ClientUnifiedMessageHandle;
		}

		public int CompareTo(ClientUnifiedMessageHandle other)
		{
			return m_ClientUnifiedMessageHandle.CompareTo(other.m_ClientUnifiedMessageHandle);
		}

		public static bool operator ==(ClientUnifiedMessageHandle x, ClientUnifiedMessageHandle y)
		{
			return x.m_ClientUnifiedMessageHandle == y.m_ClientUnifiedMessageHandle;
		}

		public static bool operator !=(ClientUnifiedMessageHandle x, ClientUnifiedMessageHandle y)
		{
			return !(x == y);
		}

		public static explicit operator ClientUnifiedMessageHandle(ulong value)
		{
			return new ClientUnifiedMessageHandle(value);
		}

		public static explicit operator ulong(ClientUnifiedMessageHandle that)
		{
			return that.m_ClientUnifiedMessageHandle;
		}
	}
}
