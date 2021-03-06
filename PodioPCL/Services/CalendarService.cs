﻿using PodioPCL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PodioPCL.Services
{
	/// <summary>
	/// Class CalendarService.
	/// </summary>
	public class CalendarService
	{
		private Podio _podio;
		/// <summary>
		/// Initializes a new instance of the <see cref="CalendarService"/> class.
		/// </summary>
		/// <param name="currentInstance">The current instance.</param>
		public CalendarService(Podio currentInstance)
		{
			_podio = currentInstance;
		}

		/// <summary>
		/// Returns the items and tasks that are related to the given app.
		/// <para>Podio API Reference: https://developers.podio.com/doc/calendar/get-app-calendar-22460 </para>
		/// </summary>
		/// <param name="appId">The application identifier.</param>
		/// <param name="dateFrom">The date to return events from</param>
		/// <param name="dateTo">The date to search to</param>
		/// <param name="priority">The minimum priority for the events to return Default value: 1</param>
		/// <returns>Task&lt;List&lt;CalendarEvent&gt;&gt;.</returns>
		public Task<List<CalendarEvent>> GetAppCalendar(int appId, DateTime dateFrom, DateTime dateTo, int? priority = null)
		{
			string url = string.Format("/calendar/app/{0}/", appId);
			var requestData = new Dictionary<string, string>();
			requestData["date_from"] = dateFrom.ToString("yyyy-MM-dd");
			requestData["date_to"] = dateTo.ToString("yyyy-MM-dd");
			if (priority.HasValue)
				requestData["priority"] = priority.Value.ToString();

			return _podio.GetAsync<List<CalendarEvent>>(url, requestData);
		}

		/// <summary>
		/// Returns all items that the user have access to and all tasks that are assigned to the user.
		/// <para>Podio API Reference: https://developers.podio.com/doc/calendar/get-global-calendar-22458 </para>
		/// </summary>
		/// <param name="dateFrom">The date to return events from</param>
		/// <param name="dateTo">The date to search to</param>
		/// <param name="priority">The minimum priority for the events to return Default value: 1</param>
		/// <returns>Task&lt;List&lt;CalendarEvent&gt;&gt;.</returns>
		public Task<List<CalendarEvent>> GetGlobalCalendar(DateTime dateFrom, DateTime dateTo, int? priority = null)
		{
			string url = "/calendar/";
			var requestData = new Dictionary<string, string>();
			requestData["date_from"] = dateFrom.ToString("yyyy-MM-dd");
			requestData["date_to"] = dateTo.ToString("yyyy-MM-dd");
			if (priority.HasValue)
				requestData["priority"] = priority.Value.ToString();

			return _podio.GetAsync<List<CalendarEvent>>(url, requestData);
		}

		/// <summary>
		/// Returns the app calendar in the iCal format 90 days into the future. The CalendarCode / Token can retrieved by getting the user status.
		/// <para>Podio API Reference: https://developers.podio.com/doc/calendar/get-app-calendar-as-ical-22515 </para>
		/// </summary>
		/// <param name="appId">The application identifier.</param>
		/// <param name="userId">The user identifier.</param>
		/// <param name="token">The token.</param>
		/// <returns>Task&lt;System.String&gt;.</returns>
		public async Task<string> GetAppCalendarAsiCal(int appId, int userId, string token)
		{
			string url = string.Format("/calendar/app/{0}/ics/{1}/{2}/", appId, userId, token);
			var options = new Dictionary<string, bool>()
            {
                {"return_raw",true}
            };

			return await _podio.GetAsync<dynamic>(url: url, options: options);
		}

		/// <summary>
		/// Returns the users global calendar in the iCal format 90 days into the future. The CalendarCode / Token can retrieved by getting the user status.
		/// <para>Podio API Reference: https://developers.podio.com/doc/calendar/get-global-calendar-as-ical-22513 </para>
		/// </summary>
		/// <param name="userId">The user identifier.</param>
		/// <param name="token">The token.</param>
		/// <returns>Task&lt;System.String&gt;.</returns>
		public async Task<string> GetGlobalCalendarAsiCal(int userId, string token)
		{
			string url = string.Format("/calendar/ics/{0}/{1}/", userId, token);
			var options = new Dictionary<string, bool>()
            {
                {"return_raw",true}
            };

			return await _podio.GetAsync<dynamic>(url: url, options: options);
		}

		/// <summary>
		/// Returns all items and tasks that the user have access to in the given space. Tasks with reference to other spaces are not returned or tasks with no reference.
		/// <para>Podio API Reference: https://developers.podio.com/doc/calendar/get-space-calendar-22459 </para>
		/// </summary>
		/// <param name="spaceId">The space identifier.</param>
		/// <param name="dateFrom">The date to return events from</param>
		/// <param name="dateTo">The date to search to</param>
		/// <param name="priority">The minimum priority for the events to return Default value: 1</param>
		/// <returns>Task&lt;List&lt;CalendarEvent&gt;&gt;.</returns>
		public Task<List<CalendarEvent>> GetSpaceCalendar(int spaceId, DateTime dateFrom, DateTime dateTo, int? priority = null)
		{
			string url = string.Format("/calendar/space/{0}/", spaceId);
			var requestData = new Dictionary<string, string>();
			requestData["date_from"] = dateFrom.ToString("yyyy-MM-dd");
			requestData["date_to"] = dateTo.ToString("yyyy-MM-dd");
			if (priority.HasValue)
				requestData["priority"] = priority.Value.ToString();

			return _podio.GetAsync<List<CalendarEvent>>(url, requestData);
		}

		/// <summary>
		/// Returns the space calendar in the iCal format 90 days into the future. The CalendarCode / Token can retrieved by getting the user status.
		/// <para>Podio API Reference: https://developers.podio.com/doc/calendar/get-space-calendar-as-ical-22514 </para>
		/// </summary>
		/// <param name="spaceId">The space identifier.</param>
		/// <param name="userId">The user identifier.</param>
		/// <param name="token">The token.</param>
		/// <returns>Task&lt;System.String&gt;.</returns>
		public async Task<string> GetSpaceCalendarAsiCal(int spaceId, int userId, string token)
		{
			string url = string.Format("/calendar/space/{0}/ics/{1}/{2}/", spaceId, userId, token);
			var options = new Dictionary<string, bool>()
            {
                {"return_raw",true}
            };

			return await _podio.GetAsync<dynamic>(url: url, options: options);
		}

		/// <summary>
		/// Returns the calendar for the given task in the iCal format.
		/// <para>Podio API Reference: https://developers.podio.com/doc/calendar/get-task-calendar-as-ical-10195650 </para>
		/// </summary>
		/// <param name="taskId">The task identifier.</param>
		/// <returns>System.String.</returns>
		public async Task<string> GetTaskCalendarAsiCal(int taskId)
		{
			string url = string.Format("/calendar/task/{0}/ics/", taskId);
			var options = new Dictionary<string, bool>()
            {
                {"return_raw",true}
            };

			return await _podio.GetAsync<dynamic>(url: url, options: options);
		}

		/// <summary>
		/// Returns the calendar summary for the active user.
		/// <para>Podio API Reference: https://developers.podio.com/doc/calendar/get-calendar-summary-1609256 </para>
		/// </summary>
		/// <param name="limit">The maximum number of events to return in each group Default value: 5</param>
		/// <param name="priority">The minimum priority for the events to return Default value: 1</param>
		/// <returns>Task&lt;CalendarSummary&gt;.</returns>
		public Task<CalendarSummary> GetCalendarSummary(int limit = 5, int priority = 1)
		{
			string url = "/calendar/summary";
			var requestData = new Dictionary<string, string>
            {
                {"limit", limit.ToString()},
                {"priority", priority.ToString()}
            };

			return _podio.GetAsync<CalendarSummary>(url, requestData);
		}

		/// <summary>
		/// Returns the calendar summary for personal tasks and personal spaces and sub-orgs.
		/// <para>Podio API Reference: https://developers.podio.com/doc/calendar/get-calendar-summary-for-personal-1657903 </para>
		/// </summary>
		/// <param name="limit">The maximum number of events to return in each group Default value: 5</param>
		/// <param name="priority">The minimum priority for the events to return Default value: 1</param>
		/// <returns>Task&lt;CalendarSummary&gt;.</returns>
		public Task<CalendarSummary> GetCalendarSummaryForPersonal(int limit = 5, int priority = 1)
		{
			string url = "/calendar/personal/summary";
			var requestData = new Dictionary<string, string>
            {
                {"limit", limit.ToString()},
                {"priority", priority.ToString()}
            };

			return _podio.GetAsync<CalendarSummary>(url, requestData);
		}

		/// <summary>
		/// Returns the calendar summary for the given space for the active user.
		/// <para>Podio API Reference: https://developers.podio.com/doc/calendar/get-calendar-summary-for-space-1609328 </para>
		/// </summary>
		/// <param name="spaceId">The space identifier.</param>
		/// <param name="limit">The maximum number of events to return in each group Default value: 5</param>
		/// <param name="priority">The minimum priority for the events to return Default value: 1</param>
		/// <returns>Task&lt;CalendarSummary&gt;.</returns>
		public Task<CalendarSummary> GetCalendarSummaryForSpace(int spaceId, int limit = 5, int priority = 1)
		{
			string url = string.Format("/calendar/space/{0}/summary", spaceId);
			var requestData = new Dictionary<string, string>
            {
                {"limit", limit.ToString()},
                {"priority", priority.ToString()}
            };

			return _podio.GetAsync<CalendarSummary>(url, requestData);
		}


		/// <summary>
		/// Updates the calendar event.
		/// </summary>
		/// <param name="uid">The uid.</param>
		/// <param name="startDateTime">The start date time.</param>
		/// <param name="endDateTime">The end date time.</param>
		/// <returns>Task.</returns>
		public Task UpdateCalendarEvent(int uid, DateTime startDateTime, DateTime endDateTime)
		{
			string url = string.Format("/calendar/event/{0}", uid);
			dynamic requestData = new
			{
				start_date = startDateTime.Date,
				start_time = startDateTime.TimeOfDay,
				end_date = endDateTime.Date,
				end_time = endDateTime.TimeOfDay
			};
			return _podio.PutAsync<dynamic>(url, requestData);
		}
	}
}
