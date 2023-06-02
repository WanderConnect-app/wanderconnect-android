using System;
using wanderconnect_android.Models.Location;
using wanderconnect_android.Models.User;

namespace wanderconnect_android.DataServices
{
	public interface IRestDataService
	{
		Task<List<TopPick>> GetTopPicksAsync(string Latitude, string Longitude);

		// reset user account password
		Task ResetUserPassword(string emailAddress);

		// login user response
		Task<int> LoginUser(string emailAddress, string password);
    }
}

