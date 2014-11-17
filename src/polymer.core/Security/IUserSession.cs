using polymer.core.Geospatial;

namespace polymer.core.Security
{
	public interface IUserSession
	{
		string UserId { get; }
		string Username { get; }
		string IpAddress { get; set; }
		string DeviceName { get; set; }
		IGeoPoint GeoPoint { get; set; }
	}
}