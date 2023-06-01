using System;
using wanderconnect_android.Models.Location;

namespace wanderconnect_android.DataServices
{
	public interface IRestDataService
	{
		Task<List<TopPick>> GetTopPicksAsync(string Latitude, string Longitude);
	}
}

