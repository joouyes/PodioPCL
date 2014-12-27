using PodioPCL.Models;
using System.Threading.Tasks;

namespace PodioPCL.Services
{
	/// <summary>
	/// Class ActionService.
	/// </summary>
	public class ActionService : ServiceBase<Action>
	{
		/// <summary>
		/// Initializes a new instance of the service.
		/// </summary>
		/// <param name="currentInstance">The current <see cref="T:PodioPCL.Podio"/> instance.</param>
		internal ActionService(Podio currentInstance)
			: base(currentInstance)
		{

		}

		/// <summary>
		/// Returns the action with the given id.
		/// <para>Podio API Reference: https://developers.podio.com/doc/actions/get-action-1701120 </para>
		/// </summary>
		/// <param name="actionId"></param>
		/// <returns></returns>
		public Task<Action> GetAction(int actionId)
		{
			string url = string.Format("/action/{0}", actionId);
			return _Podio.GetAsync<Action>(url);
		}
	}
}
