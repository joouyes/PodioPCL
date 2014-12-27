using PodioPCL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PodioPCL.Services
{
	/// <summary>
	/// Class SpaceService.
	/// </summary>
    public class SpaceService
    {
        private Podio _podio;
		/// <summary>
		/// Initializes a new instance of the <see cref="SpaceService"/> class.
		/// </summary>
		/// <param name="currentInstance">The current instance.</param>
        public SpaceService(Podio currentInstance)
        {
            _podio = currentInstance;
        }

		/// <summary>
		/// Add a new space to an organization.
		/// <para>Podio API Reference: https://developers.podio.com/doc/spaces/create-space-22390 </para>
		/// </summary>
		/// <param name="orgId">The org identifier.</param>
		/// <param name="name">The name of the space</param>
		/// <param name="privacy">The privacy level of the space, either "open" or "closed", defaults to "closed"</param>
		/// <param name="autoJoin">True if new employees should be joined automatically, false otherwise, defaults to false</param>
		/// <param name="postOnNewApp">True if new apps should be announced with a status update, false otherwise</param>
		/// <param name="postOnNewMember">True if new members should be announced with a status update, false otherwise</param>
		/// <returns>Task&lt;System.Int32&gt;.</returns>
		public async Task<int> CreateSpace(int orgId, string name, Space.PrivacyTypes privacy = Space.PrivacyTypes.Closed, bool? autoJoin = null, bool? postOnNewApp = null, bool? postOnNewMember = null)
        {
            string url = "/space/";
            dynamic requestData = new
            {
                org_id = orgId,
                name = name,
                privacy = privacy,
                auto_join = autoJoin,
                post_on_new_app = postOnNewApp,
                post_on_new_member = postOnNewMember
            };
            dynamic respone = await _podio.PostAsync<dynamic>(url, requestData);
            return (int)respone["space_id"];
        }

		/// <summary>
		/// Updates the space with the given id.
		/// <para>Podio API Reference: https://developers.podio.com/doc/spaces/update-space-22391 </para>
		/// </summary>
		/// <param name="spaceId">The space identifier.</param>
		/// <param name="name">The name of the space</param>
		/// <param name="urlLabel">The new URL label, if any changes</param>
		/// <param name="privacy">The privacy level of the space, either "open" or "closed", defaults to "closed"</param>
		/// <param name="autoJoin">True if new employees should be joined automatically, false otherwise, defaults to false</param>
		/// <param name="postOnNewApp">True if new apps should be announced with a status update, false otherwise</param>
		/// <param name="postOnNewMember">True if new members should be announced with a status update, false otherwise</param>
		/// <returns>Task.</returns>
		public async Task UpdateSpace(int spaceId, string name = null, string urlLabel = null, Space.PrivacyTypes privacy = Space.PrivacyTypes.Closed, bool? autoJoin = null, bool? postOnNewApp = null, bool? postOnNewMember = null)
        {
            string url = string.Format("/space/{0}", spaceId);
            dynamic requestData = new
            {
                name = name,
                url_label = urlLabel,
                privacy = privacy,
                auto_join = autoJoin,
                post_on_new_app = postOnNewApp,
                post_on_new_member = postOnNewMember
            };
            await _podio.PutAsync<dynamic>(url, requestData);
        }

		/// <summary>
		/// Deletes the <see cref="T:PodioPCL.Models.Space"/> with the given id.
		/// <para>Podio API Reference: https://developers.podio.com/doc/spaces/delete-space-22417 </para>
		/// </summary>
		/// <param name="spaceId">The space identifier.</param>
		public async Task DeleteSpace(int spaceId)
		{
			string url = string.Format("/space/{0}", spaceId);
			await _podio.DeleteAsync<dynamic>(url);
		}

		/// <summary>
		/// Returns the available spaces for the given organization. This is spaces that are open and available for the user to join.
		/// <para>Podio API Reference: https://developers.podio.com/doc/spaces/get-available-spaces-1911961 </para>
		/// </summary>
		/// <param name="orgId">The org identifier.</param>
		/// <returns>Task&lt;List&lt;SpaceMicro&gt;&gt;.</returns>
		public async Task<List<SpaceMicro>> GetAvailableSpaces(int orgId)
        {
            string url = string.Format("/space/org/{0}/available/", orgId);
            return await _podio.GetAsync<List<SpaceMicro>>(url);
        }

		/// <summary>
		/// Returns the available seats. A null value means there is an unlimited number of available seats.
		/// <para>Podio API Reference: https://developers.podio.com/doc/spaces/get-available-spaces-1911961 </para>
		/// </summary>
		/// <param name="spaceId">The space identifier.</param>
		/// <returns>Task&lt;Seat&gt;.</returns>
        public async Task<Seat> GetAvailableSeats(int spaceId)
        {
            string url = string.Format("/space/{0}/available", spaceId);
            return await _podio.GetAsync<Seat>(url);
        }

		/// <summary>
		/// Get the space with the given id.
		/// <para>Podio API Reference: https://developers.podio.com/doc/spaces/get-space-22389 </para>
		/// </summary>
		/// <param name="spaceId">The space identifier.</param>
		/// <returns>Task&lt;Space&gt;.</returns>
		public async Task<Space> GetSpace(int spaceId)
        {
            string url = string.Format("/space/{0}", spaceId);
            return await _podio.GetAsync<Space>(url);
        }

		/// <summary>
		/// Returns the space in the given org with the given URL label
		/// <para>Podio API Reference: https://developers.podio.com/doc/spaces/get-space-by-org-and-url-label-476929 </para>
		/// </summary>
		/// <param name="orgId">The org identifier.</param>
		/// <param name="urlLabel">The URL label.</param>
		/// <returns>Task&lt;Space&gt;.</returns>
		public async Task<Space> GetSpaceByOrgAndUrlLabel(int orgId, string urlLabel)
        {
            string url = string.Format("/space/org/{0}/{1}", orgId, urlLabel);
            return await _podio.GetAsync<Space>(url);
        }

		/// <summary>
		/// Returns the space and organization with the given full URL.
		/// <para>Podio API Reference: https://developers.podio.com/doc/spaces/get-space-by-url-22481 </para>
		/// </summary>
		/// <param name="orgSlug">The org of the slug to search for</param>
		/// <param name="spaceSlug">The slug of the url to search for</param>
		/// <param name="spaceUrl">The full URL of the space. The URL does not have to be truncated to the space root, it can be the full URL of the resource.</param>
		/// <returns>Task&lt;Space&gt;.</returns>
		public async Task<Space> GetSpaceByUrl(string orgSlug, string spaceSlug, string spaceUrl)
        {
            string url = "/space/url";
            var requestData = new Dictionary<string, string>()
            {
                {"org_slug",orgSlug},
                {"space_slug",spaceSlug},
                {"url",spaceUrl}
            };
            return await _podio.GetAsync<Space>(url, requestData);
        }

		/// <summary>
		/// Returns the top spaces for the user.
		/// <para>Podio API Reference: https://developers.podio.com/doc/spaces/get-top-spaces-22477 </para>
		/// </summary>
		/// <param name="limit">The limit.</param>
		/// <returns>Task&lt;List&lt;Space&gt;&gt;.</returns>
		public async Task<List<Space>> GetTopSpaces(int limit = 6)
        {
            string url = "/space/top/";
            var requestData = new Dictionary<string, string>()
            {
                {"limit",limit.ToString()}
            };
            return await _podio.GetAsync<List<Space>>(url, requestData);
        }
    }
}
