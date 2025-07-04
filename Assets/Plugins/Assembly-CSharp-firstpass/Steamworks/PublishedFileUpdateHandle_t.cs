using System;

namespace Steamworks
{
	[Serializable]
	public struct PublishedFileUpdateHandle_t : IEquatable<PublishedFileUpdateHandle_t>, IComparable<PublishedFileUpdateHandle_t>
	{
		public static readonly PublishedFileUpdateHandle_t Invalid = new PublishedFileUpdateHandle_t(ulong.MaxValue);

		public ulong m_PublishedFileUpdateHandle;

		public PublishedFileUpdateHandle_t(ulong value)
		{
			m_PublishedFileUpdateHandle = value;
		}

		public override string ToString()
		{
			return m_PublishedFileUpdateHandle.ToString();
		}

		public override bool Equals(object other)
		{
			return other is PublishedFileUpdateHandle_t && this == (PublishedFileUpdateHandle_t)other;
		}

		public override int GetHashCode()
		{
			return m_PublishedFileUpdateHandle.GetHashCode();
		}

		public bool Equals(PublishedFileUpdateHandle_t other)
		{
			return m_PublishedFileUpdateHandle == other.m_PublishedFileUpdateHandle;
		}

		public int CompareTo(PublishedFileUpdateHandle_t other)
		{
			return m_PublishedFileUpdateHandle.CompareTo(other.m_PublishedFileUpdateHandle);
		}

		public static bool operator ==(PublishedFileUpdateHandle_t x, PublishedFileUpdateHandle_t y)
		{
			return x.m_PublishedFileUpdateHandle == y.m_PublishedFileUpdateHandle;
		}

		public static bool operator !=(PublishedFileUpdateHandle_t x, PublishedFileUpdateHandle_t y)
		{
			return !(x == y);
		}

		public static explicit operator PublishedFileUpdateHandle_t(ulong value)
		{
			return new PublishedFileUpdateHandle_t(value);
		}

		public static explicit operator ulong(PublishedFileUpdateHandle_t that)
		{
			return that.m_PublishedFileUpdateHandle;
		}
	}
}
