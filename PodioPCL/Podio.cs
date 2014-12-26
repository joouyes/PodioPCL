// ***********************************************************************
// Assembly         : PodioPCL
// Author           : OnsharpRyan
// Created          : 12-09-2014
//
// Last Modified By : OnsharpRyan
// Last Modified On : 12-26-2014
// ***********************************************************************
// <copyright file="Podio.cs" company="Onsharp">
//     Copyright (c) Onsharp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using PodioPCL.Exceptions;
using PodioPCL.Models.Request;
using PodioPCL.Models;
using PodioPCL.Services;
using PodioPCL.Utils;
using PodioPCL.Utils.Authentication;
using System.Threading.Tasks;

namespace PodioPCL
{
	/// <summary>
	/// The Podio client is used to Get and Set data with the Podio API.
	/// <para>
	/// Online Documentation <see href="http://podiopcl.playground.servers.onsharp.com/help/"/>
	/// </para>
	/// </summary>
	public class Podio
	{
		/// <summary>
		/// Gets or sets the client identifier.
		/// </summary>
		/// <value>The client identifier.</value>
		protected string ClientId { get; set; }
		/// <summary>
		/// Gets or sets the client secret.
		/// </summary>
		/// <value>The client secret.</value>
		protected string ClientSecret { get; set; }
		/// <summary>
		/// Gets or sets the o authentication.
		/// </summary>
		/// <value>The o authentication.</value>
		public PodioOAuth OAuth { get; set; }
		/// <summary>
		/// Gets or sets the authentication store.
		/// </summary>
		/// <value>The authentication store.</value>
		public IAuthStore AuthStore { get; set; }
		/// <summary>
		/// Gets the rate limit.
		/// </summary>
		/// <value>The rate limit.</value>
		public int RateLimit { get; private set; }
		/// <summary>
		/// Gets the rate limit remaining.
		/// </summary>
		/// <value>The rate limit remaining.</value>
		public int RateLimitRemaining { get; private set; }
		/// <summary>
		/// Gets or sets the API URL.
		/// </summary>
		/// <value>The API URL.</value>
		protected string ApiUrl { get; set; }

		/// <summary>
		/// Initialize the podio class with Client ID and Client Secret
		/// <para>You can get the Client ID and Client Secret from here: https://developers.podio.com/api-key </para>
		/// </summary>
		/// <param name="clientId">The client identifier.</param>
		/// <param name="clientSecret">The client secret.</param>
		/// <param name="authStore">The authentication store.</param>
		public Podio(string clientId, string clientSecret, IAuthStore authStore = null)
		{
			internalConstructor(clientId, clientSecret, authStore);
		}

		/// <summary>
		/// Internals the constructor.
		/// </summary>
		/// <param name="clientId">The client identifier.</param>
		/// <param name="clientSecret">The client secret.</param>
		/// <param name="authStore">The authentication store.</param>
		private void internalConstructor(string clientId, string clientSecret, IAuthStore authStore)
		{
			ClientId = clientId;
			ClientSecret = clientSecret;
			ApiUrl = "https://api.podio.com:443";

			if (authStore != null)
				AuthStore = authStore;
			else
				AuthStore = new NullAuthStore();

			OAuth = AuthStore.Get();
		}

		#region Request Helpers

		/// <summary>
		/// get as an asynchronous operation.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="url">The URL.</param>
		/// <param name="requestData">The request data.</param>
		/// <param name="options">The options.</param>
		/// <returns>System.Threading.Tasks.Task&lt;T&gt;.</returns>
		internal Task<T> GetAsync<T>(string url, dynamic requestData = null, dynamic options = null) where T : new()
		{
			return RequestAsync<T>(RequestMethod.GET, url, requestData, options);
		}

		/// <summary>
		/// post as an asynchronous operation.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="url">The URL.</param>
		/// <param name="requestData">The request data.</param>
		/// <param name="options">The options.</param>
		/// <returns>System.Threading.Tasks.Task&lt;T&gt;.</returns>
		internal Task<T> PostAsync<T>(string url, dynamic requestData = null, dynamic options = null) where T : new()
		{
			return RequestAsync<T>(RequestMethod.POST, url, requestData, options);
		}

		/// <summary>
		/// put as an asynchronous operation.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="url">The URL.</param>
		/// <param name="requestData">The request data.</param>
		/// <param name="options">The options.</param>
		/// <returns>System.Threading.Tasks.Task&lt;T&gt;.</returns>
		internal Task<T> PutAsync<T>(string url, dynamic requestData = null, dynamic options = null) where T : new()
		{
			return RequestAsync<T>(RequestMethod.PUT, url, requestData);
		}

		/// <summary>
		/// delete as an asynchronous operation.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="url">The URL.</param>
		/// <param name="requestData">The request data.</param>
		/// <param name="options">The options.</param>
		/// <returns>System.Threading.Tasks.Task&lt;T&gt;.</returns>
		internal Task<T> DeleteAsync<T>(string url, dynamic requestData = null, dynamic options = null) where T : new()
		{
			return RequestAsync<T>(RequestMethod.DELETE, url, requestData);
		}

		/// <summary>
		/// Requests the specified request method.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="requestMethod">The request method.</param>
		/// <param name="url">The URL.</param>
		/// <param name="requestData">The request data.</param>
		/// <param name="options">The options.</param>
		/// <returns>System.Threading.Tasks.Task&lt;T&gt;.</returns>
		/// <exception cref="System.Exception">ClientId and ClientSecret is not set</exception>
		/// <exception cref="PodioInvalidGrantException"></exception>
		/// <exception cref="PodioBadRequestException"></exception>
		/// <exception cref="PodioAuthorizationException"></exception>
		/// <exception cref="PodioForbiddenException"></exception>
		/// <exception cref="PodioNotFoundException"></exception>
		/// <exception cref="PodioConflictException"></exception>
		/// <exception cref="PodioGoneException"></exception>
		/// <exception cref="PodioRateLimitException"></exception>
		/// <exception cref="PodioServerException"></exception>
		/// <exception cref="PodioUnavailableException"></exception>
		/// <exception cref="PodioException"></exception>
		private async Task<T> RequestAsync<T>(RequestMethod requestMethod, string url, dynamic requestData, dynamic options = null) where T : new()
		{
			Dictionary<string, string> requestHeaders = new Dictionary<string, string>();
			var data = new List<string>();
			string httpMethod = string.Empty;
			string originalUrl = url;
			url = this.ApiUrl + url;

			//To use url other than api.podio.com, ex file download from files.podio.com
			if (options != null && options.ContainsKey("url"))
			{
				url = options["url"];
			}

			if (string.IsNullOrEmpty(ClientId) || string.IsNullOrEmpty(ClientSecret))
			{
				throw new Exception("ClientId and ClientSecret is not set");
			}

			switch (requestMethod.ToString())
			{
				case "GET":
					httpMethod = "GET";
					requestHeaders["Content-type"] = "application/x-www-form-urlencoded";
					if (requestData != null)
					{
						string query = EncodeAttributes(requestData);
						url = url + "?" + query;
					}
					requestHeaders["Content-length"] = "0";
					break;
				case "DELETE":
					httpMethod = "DELETE";
					requestHeaders["Content-type"] = "application/x-www-form-urlencoded";
					if (requestData != null)
					{
						string query = EncodeAttributes(requestData);
						url = url + "?" + query;
					}
					requestHeaders["Content-length"] = "0";
					break;
				case "POST":
					httpMethod = "POST";
					if (options != null && options.ContainsKey("upload") && options["upload"])
					{
						requestHeaders["Content-type"] = "multipart/form-data";
						data.Add("file");
					}
					else if (options != null && options.ContainsKey("oauth_request") && options["oauth_request"])
					{
						data.Add("oauth");
						requestHeaders["Content-type"] = "application/x-www-form-urlencoded";
					}
					else
					{
						requestHeaders["Content-type"] = "application/json";
						data.Add("post");
					}
					break;
				case "PUT":
					httpMethod = "PUT";
					requestHeaders["Content-type"] = "application/json";
					data.Add("put");
					break;
			}

			if (OAuth != null && !string.IsNullOrEmpty(OAuth.AccessToken))
			{
				requestHeaders["Authorization"] = "OAuth2 " + OAuth.AccessToken;
				if (options != null && options.ContainsKey("oauth_request") && options["oauth_request"])
				{
					requestHeaders.Remove("Authorization");
				}
			}
			else
			{
				requestHeaders.Remove("Authorization");
			}

			if (options != null && options.ContainsKey("file_download") && options["file_download"])
				requestHeaders["Accept"] = "*/*";
			else
				requestHeaders["Accept"] = "application/json";

			var request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = httpMethod;

			PodioResponse podioResponse = new PodioResponse();
			var responseHeaders = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
			var responseObject = new T();

			if (requestHeaders.Any())
			{
				if (requestHeaders.ContainsKey("Accept"))
					request.Accept = requestHeaders["Accept"];
				if (requestHeaders.ContainsKey("Content-type"))
					request.ContentType = requestHeaders["Content-type"];
				if (requestHeaders.ContainsKey("Authorization"))
					request.Headers["Authorization"] = requestHeaders["Authorization"];
			}
			if (data.Any())
			{
				foreach (string item in data)
				{
					if (item == "file")
						await AddFileToRequestStream(requestData.filePath, requestData.fileName, requestData.mimeType, request);
					else if (item == "oauth")
						await WriteToRequestStream(EncodeAttributes(requestData), request);
					else
						await WriteToRequestStream(requestData, request);
				}
			}

			try
			{
				WebResponse webResponse = await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, request);

				using (webResponse)
				{
					podioResponse.Status = (int)((HttpWebResponse)webResponse).StatusCode;
					foreach (string key in webResponse.Headers.AllKeys)
					{
						responseHeaders.Add(key, webResponse.Headers[key]);
					}

					if (options != null && options.ContainsKey("file_download"))
					{
						using (var memoryStream = new MemoryStream())
						{
							var fileResponse = new FileResponse();
							webResponse.GetResponseStream().CopyTo(memoryStream);
							fileResponse.FileContents = memoryStream.ToArray();
							fileResponse.ContentType = webResponse.ContentType;
							fileResponse.ContentLength = webResponse.ContentLength;
							return (T)fileResponse.ChangeType<T>();
						}
					}
					else if (options != null && options.ContainsKey("return_raw"))
					{
						using (StreamReader sr = new StreamReader(webResponse.GetResponseStream()))
						{
							podioResponse.Body = sr.ReadToEnd();
							return podioResponse.Body;
						}
					}
					else
					{
						using (StreamReader sr = new StreamReader(webResponse.GetResponseStream()))
						{
							podioResponse.Body = sr.ReadToEnd();
						}
					}
					podioResponse.Headers = responseHeaders;
				}
			}
			catch (WebException e)
			{
				using (WebResponse response = e.Response)
				{
					podioResponse.Status = (int)((HttpWebResponse)response).StatusCode;
					foreach (string key in response.Headers.AllKeys)
					{
						responseHeaders.Add(key, response.Headers[key]);
					}

					using (StreamReader sr = new StreamReader(response.GetResponseStream()))
					{
						podioResponse.Body = sr.ReadToEnd();
					}
					podioResponse.Headers = responseHeaders;
				}
			}


			if (podioResponse.Headers.ContainsKey("X-Rate-Limit-Remaining"))
				RateLimitRemaining = int.Parse(podioResponse.Headers["X-Rate-Limit-Remaining"]);
			if (podioResponse.Headers.ContainsKey("X-Rate-Limit-Limit"))
				RateLimit = int.Parse(podioResponse.Headers["X-Rate-Limit-Limit"]);

			PodioError podioError = new PodioError();
			if (podioResponse.Status >= 400)
				podioError = JSONSerializer.Deserilaize<PodioError>(podioResponse.Body);

			switch (podioResponse.Status)
			{
				case 200:
				case 201:
					responseObject = JSONSerializer.Deserilaize<T>(podioResponse.Body);
					break;
				case 204:
					responseObject = default(T);
					break;
				case 400:
					if (podioError.Error == "invalid_grant")
					{
						//Reset auth info
						OAuth = new PodioOAuth();
						throw new PodioInvalidGrantException(podioResponse.Status, podioError);
					}
					else
					{
						throw new PodioBadRequestException(podioResponse.Status, podioError);
					}
				case 401:
					if (podioError.ErrorDescription == "expired_token" || podioError.Error == "invalid_token")
					{
						if (!string.IsNullOrEmpty(OAuth.RefreshToken))
						{
							//Refresh access token
							var authInfo = await RefreshAccessTokenAsync();
							if (authInfo != null && !string.IsNullOrEmpty(authInfo.AccessToken))
								responseObject = await RequestAsync<T>(requestMethod, originalUrl, requestData, options);
						}
						else
						{
							throw new PodioAuthorizationException(podioResponse.Status, podioError);
						}
					}
					break;
				case 403:
					throw new PodioForbiddenException(podioResponse.Status, podioError);
				case 404:
					throw new PodioNotFoundException(podioResponse.Status, podioError);
				case 409:
					throw new PodioConflictException(podioResponse.Status, podioError);
				case 410:
					throw new PodioGoneException(podioResponse.Status, podioError);
				case 420:
					throw new PodioRateLimitException(podioResponse.Status, podioError);
				case 500:
					throw new PodioServerException(podioResponse.Status, podioError);
				case 502:
				case 503:
				case 504:
					throw new PodioUnavailableException(podioResponse.Status, podioError);
				default:
					throw new PodioException(podioResponse.Status, podioError);
			}

			return responseObject;
		}

		/// <summary>
		/// Transform options object to query parameteres
		/// </summary>
		/// <param name="url">The URL.</param>
		/// <param name="options">The options.</param>
		/// <returns>System.String.</returns>
		internal string PrepareUrlWithOptions(string url, CreateUpdateOptions options)
		{
			string urlWithOptions = "";
			List<string> parameters = new List<string>();
			if (options.Silent)
				parameters.Add("silent=1");
			if (!options.Hook)
				parameters.Add("hook=false");
			if (options.Fields != null && options.Fields.Any())
				parameters.Add(string.Join(",", options.Fields.Select(s => s).ToArray()));

			urlWithOptions = parameters.Any() ? url + "?" + string.Join("&", parameters.ToArray()) : url;
			return urlWithOptions;
		}

		/// <summary>
		/// Write an object to request stream.
		/// </summary>
		/// <param name="obj">The object.</param>
		/// <param name="request">HttpWebRequest object of which request to write</param>
		internal async Task WriteToRequestStream(object obj, HttpWebRequest request)
		{
			if (obj != null)
			{
				try
				{
					Stream requestStream = await Task.Factory.FromAsync<Stream>(request.BeginGetRequestStream, request.EndGetRequestStream, request);

					using (var streamWriter = new StreamWriter(requestStream))
					{
						if (obj is string)
							streamWriter.Write(obj);
						else
							streamWriter.Write(JSONSerializer.Serilaize(obj));
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

		/// <summary>
		/// Convert dictionay to to query string
		/// </summary>
		/// <param name="attributes">The attributes.</param>
		/// <returns>System.String.</returns>
		internal static string EncodeAttributes(Dictionary<string, string> attributes)
		{
			var encodedString = string.Empty;
			if (attributes.Any())
			{
				var parameters = new List<string>();
				foreach (var item in attributes)
				{
					if (item.Key != string.Empty && !string.IsNullOrEmpty(item.Value))
					{
						parameters.Add(WebUtility.UrlEncode(item.Key) + "=" + (WebUtility.UrlEncode(item.Value)));
					}
				}
				if (parameters.Any())
					encodedString = string.Join("&", parameters.ToArray());
			}

			return encodedString;
		}



		/// <summary>
		/// Add a file to request stream
		/// </summary>
		/// <param name="file">The file.</param>
		/// <param name="fileName">File Name</param>
		/// <param name="mimeType">Type of the MIME.</param>
		/// <param name="request">HttpWebRequest object of which request stream file is added to</param>
		/// <exception cref="System.IO.FileNotFoundException">File not found in the specified path</exception>
		private async Task AddFileToRequestStream(byte[] file, string fileName, string mimeType, HttpWebRequest request)
		{
			byte[] inputData;
			string contentType = "";
			if (file != null && file.Length > 0)
			{
				string boundary = String.Format("----------{0:N}", Guid.NewGuid());
				contentType = "multipart/form-data; boundary=" + boundary;
				MemoryStream ms = new MemoryStream();

				ms.Write(Encoding.UTF8.GetBytes("\r\n"), 0, Encoding.UTF8.GetByteCount("\r\n"));

				string postData = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}",
					boundary,
					"filename",
					fileName);
				ms.Write(Encoding.UTF8.GetBytes(postData), 0, Encoding.UTF8.GetByteCount(postData));

				byte[] data = file;

				ms.Write(Encoding.UTF8.GetBytes("\r\n"), 0, Encoding.UTF8.GetByteCount("\r\n"));

				string header = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\";\r\nContent-Type: {3}\r\n\r\n",
				   boundary,
				   "source",
				   fileName,
				   mimeType);
				ms.Write(Encoding.UTF8.GetBytes(header), 0, Encoding.UTF8.GetByteCount(header));
				ms.Write(data, 0, data.Length);

				string footer = "\r\n--" + boundary + "--\r\n";

				ms.Write(Encoding.UTF8.GetBytes(footer), 0, Encoding.UTF8.GetByteCount(footer));
				inputData = ms.ToArray();

			}
			else
			{
				throw new FileNotFoundException("File not found in the specified path");
			}

			request.ContentType = contentType;

			var result = await Task.Factory.FromAsync<Stream>(request.BeginGetRequestStream, request.EndGetRequestStream, request);

			using (var requestStream = result)
			{
				requestStream.Write(inputData, 0, inputData.Length);
			}

		}

		#endregion

		#region Authentication

		/// <summary>
		/// Authenticate as an App (with AppId and AppSecret)
		/// <para>Podio API Reference: https://developers.podio.com/authentication/app_auth </para>
		/// </summary>
		/// <param name="appId">AppId</param>
		/// <param name="appToken">AppToken</param>
		/// <returns>PodioOAuth object with OAuth data</returns>
		public Task<PodioOAuth> AuthenticateWithApp(int appId, string appToken)
		{
			var authRequest = new Dictionary<string, string>(){
                   {"app_id", appId.ToString()},
                   {"app_token", appToken},
                   {"grant_type", "app"}
                };
			return AuthenticateAsync("app", authRequest);
		}

		/// <summary>
		/// Authenticate with username and password
		/// <para>Podio API Reference: https://developers.podio.com/authentication/username_password </para>
		/// </summary>
		/// <param name="username">The username.</param>
		/// <param name="password">The password.</param>
		/// <returns>PodioOAuth object with OAuth data</returns>
		public Task<PodioOAuth> AuthenticateWithPassword(string username, string password)
		{
			var authRequest = new Dictionary<string, string>(){
                   {"username", username},
                   {"password", password},
                   {"grant_type", "password"}
                };
			return AuthenticateAsync("password", authRequest);
		}

		/// <summary>
		/// Authenticate with an authorization code
		/// <para>Podio API Reference: https://developers.podio.com/authentication/server_side </para>
		/// </summary>
		/// <param name="authorizationCode">The authorization code.</param>
		/// <param name="redirectUri">The redirect URI.</param>
		/// <returns>PodioOAuth object with OAuth data</returns>

		public Task<PodioOAuth> AuthenticateWithAuthorizationCode(string authorizationCode, string redirectUri)
		{
			var authRequest = new Dictionary<string, string>(){
                   {"code", authorizationCode},
                   {"redirect_uri", redirectUri},
                   {"grant_type", "authorization_code"}
                };
			return AuthenticateAsync("authorization_code", authRequest);
		}

		/// <summary>
		/// Remove the Authenticate.
		/// </summary>
		public void DeAuthenticate()
		{
			AuthStore.Set(null);
		}

		/// <summary>
		/// Refresh the Access Token.
		/// <para>When the access token expires, you can use this method to refresh your access, and gain another access_token</para><para>Podio API Reference: https://developers.podio.com/authentication </para>
		/// </summary>
		/// <returns>PodioOAuth object with OAuth data</returns>
		public Task<PodioOAuth> RefreshAccessTokenAsync()
		{
			var authRequest = new Dictionary<string, string>(){
                   {"refresh_token", OAuth.RefreshToken},
                   {"grant_type", "refresh_token"}
                };
			return AuthenticateAsync("refresh_token", authRequest);
		}

		/// <summary>
		/// Authenticates the specified grant type.
		/// </summary>
		/// <param name="grantType">Type of the grant.</param>
		/// <param name="attributes">The attributes.</param>
		/// <returns>PodioOAuth.</returns>
		private async Task<PodioOAuth> AuthenticateAsync(string grantType, Dictionary<string, string> attributes)
		{
			attributes["client_id"] = ClientId;
			attributes["client_secret"] = ClientSecret;

			var options = new Dictionary<string, object>(){
                {"oauth_request",true}
            };

			PodioOAuth podioOAuth = await PostAsync<PodioOAuth>("/oauth/token", attributes, options);
			this.OAuth = podioOAuth;
			AuthStore.Set(podioOAuth);

			return podioOAuth;
		}

		/// <summary>
		/// Constructs the full url to Podio's authorization endpoint (To get AuthorizationCode in server-side flow)
		/// </summary>
		/// <param name="redirectUri">The redirectUri must be on the same domain as the domain you specified when you applied for your API Key</param>
		/// <returns>System.String.</returns>
		public string GetAuthorizeUrl(string redirectUri)
		{
			string authorizeUrl = "https://podio.com/oauth/authorize?response_type=code&client_id={0}&redirect_uri={1}";
			return String.Format(authorizeUrl, this.ClientId, WebUtility.UrlEncode(redirectUri));
		}

		/// <summary>
		/// Check if there is a stored access token already present.
		/// </summary>
		/// <returns><c>true</c> if this instance is authenticated; otherwise, <c>false</c>.</returns>
		public bool IsAuthenticated()
		{
			return (this.OAuth != null && !string.IsNullOrEmpty(this.OAuth.AccessToken));
		}

		#endregion

		#region Services

		/// <summary>
		/// Provies all API methods in Item Area
		/// <para>Podio API Reference: https://developers.podio.com/doc/items </para>
		/// </summary>
		/// <value>The item service.</value>
		public ItemService ItemService
		{
			get { return new ItemService(this); }
		}

		/// <summary>
		/// Provies all API methods in Files Area
		/// <para>Podio API Reference: https://developers.podio.com/doc/files </para>
		/// </summary>
		/// <value>The file service.</value>
		public FileService FileService
		{
			get { return new FileService(this); }
		}

		/// <summary>
		/// Provies all API methods in Embed Area
		/// <para>https://developers.podio.com/doc/embeds</para>
		/// </summary>
		/// <value>The embed service.</value>
		public EmbedService EmbedService
		{
			get { return new EmbedService(this); }
		}

		/// <summary>
		/// Provies all API methods in Embed Area
		/// <para>https://developers.podio.com/doc/applications</para>
		/// </summary>
		/// <value>The application service.</value>
		public ApplicationService ApplicationService
		{
			get { return new ApplicationService(this); }
		}

		/// <summary>
		/// Provies all API methods in Tasks Area
		/// <para>https://developers.podio.com/doc/tasks</para>
		/// </summary>
		/// <value>The task service.</value>
		public PodioTaskService TaskService
		{
			get { return new PodioTaskService(this); }
		}

		/// <summary>
		/// Provies all API methods in Status Area
		/// <para>https://developers.podio.com/doc/status</para>
		/// </summary>
		/// <value>The status service.</value>
		public StatusService StatusService
		{
			get { return new StatusService(this); }
		}

		/// <summary>
		/// Provies all API methods in Contact Area
		/// <para>https://developers.podio.com/doc/contacts</para>
		/// </summary>
		/// <value>The contact service.</value>
		public ContactService ContactService
		{
			get { return new ContactService(this); }
		}

		/// <summary>
		/// Provies all API methods in Hook Area
		/// <para> https://developers.podio.com/doc/hooks </para>
		/// </summary>
		/// <value>The hook service.</value>
		public HookService HookService
		{
			get { return new HookService(this); }
		}

		/// <summary>
		/// Provies all API methods in Hook Area
		/// <para> https://developers.podio.com/doc/hooks </para>
		/// </summary>
		/// <value>The comment service.</value>
		public CommentService CommentService
		{
			get { return new CommentService(this); }
		}

		/// <summary>
		/// Provies all API methods in Organization Area
		/// <para> https://developers.podio.com/doc/organizations </para>
		/// </summary>
		/// <value>The organization service.</value>
		public OrganizationService OrganizationService
		{
			get { return new OrganizationService(this); }
		}

		/// <summary>
		/// Provies all API methods in Space Area
		/// <para> https://developers.podio.com/doc/spaces </para>
		/// </summary>
		/// <value>The space service.</value>
		public SpaceService SpaceService
		{
			get { return new SpaceService(this); }
		}

		/// <summary>
		/// Provies all API methods in SpaceMember Area
		/// <para> https://developers.podio.com/doc/space-members </para>
		/// </summary>
		/// <value>The space members service.</value>
		public SpaceMembersService SpaceMembersService
		{
			get { return new SpaceMembersService(this); }
		}

		/// <summary>
		/// Provies all API methods in  Widgets Area
		/// <para> https://developers.podio.com/doc/widgets </para>
		/// </summary>
		/// <value>The widget service.</value>
		public WidgetService WidgetService
		{
			get { return new WidgetService(this); }
		}

		/// <summary>
		/// Provies API methods in Stream Area
		/// <para> https://developers.podio.com/doc/stream </para>
		/// </summary>
		/// <value>The stream service.</value>
		public StreamService StreamService
		{
			get { return new StreamService(this); }
		}

		/// <summary>
		/// Provies all API methods in  Reference Area
		/// <para> https://developers.podio.com/doc/reference </para>
		/// </summary>
		/// <value>The reference service.</value>
		public ReferenceService ReferenceService
		{
			get { return new ReferenceService(this); }
		}

		/// <summary>
		/// Gets the grant service.
		/// </summary>
		/// <value>The grant service.</value>
		public GrantService GrantService
		{
			get { return new GrantService(this); }
		}

		/// <summary>
		/// Provies all API methods in Search area
		/// <para> https://developers.podio.com/doc/search </para>
		/// </summary>
		/// <value>The search service.</value>
		public SearchService SearchService
		{
			get { return new SearchService(this); }
		}

		/// <summary>
		/// Provies all API methods in Rating Area
		/// <para> https://developers.podio.com/doc/ratings </para>
		/// </summary>
		/// <value>The rating service.</value>
		public RatingService RatingService
		{
			get { return new RatingService(this); }
		}

		/// <summary>
		/// Provies all API methods in Tag Area
		/// <para> https://developers.podio.com/doc/tags </para>
		/// </summary>
		/// <value>The tag service.</value>
		public TagService TagService
		{
			get { return new TagService(this); }
		}

		/// <summary>
		/// Gets the batch service.
		/// </summary>
		/// <value>The batch service.</value>
		public BatchService BatchService
		{
			get { return new BatchService(this); }
		}

		/// <summary>
		/// Provies all API methods in Actions area
		/// <para> https://developers.podio.com/doc/actions </para>
		/// </summary>
		/// <value>The action service.</value>
		public ActionService ActionService
		{
			get { return new ActionService(this); }
		}

		/// <summary>
		/// Provies all API methods in Calendar Area
		/// <para> https://developers.podio.com/doc/calendar </para>
		/// </summary>
		/// <value>The calendar service.</value>
		public CalendarService CalendarService
		{
			get { return new CalendarService(this); }
		}

		/// <summary>
		/// Provies all API methods in Conversations area
		/// <para> https://developers.podio.com/doc/conversations </para>
		/// </summary>
		/// <value>The conversation service.</value>
		public ConversationService ConversationService
		{
			get { return new ConversationService(this); }
		}

		/// <summary>
		/// Provies all API methods in Notifications area
		/// <para> https://developers.podio.com/doc/notifications </para>
		/// </summary>
		/// <value>The notification service.</value>
		public NotificationService NotificationService
		{
			get { return new NotificationService(this); }
		}

		/// <summary>
		/// Gets the reminder service.
		/// </summary>
		/// <value>The reminder service.</value>
		public ReminderService ReminderService
		{
			get { return new ReminderService(this); }
		}

		/// <summary>
		/// Provies all API methods in Recurrence Area
		/// <para> https://developers.podio.com/doc/recurrence </para>
		/// </summary>
		/// <value>The recurrence service.</value>
		public RecurrenceService RecurrenceService
		{
			get { return new RecurrenceService(this); }
		}

		/// <summary>
		/// Provies all API methods in Importer area
		/// <para> https://developers.podio.com/doc/importer </para>
		/// </summary>
		/// <value>The importer service.</value>
		public ImporterService ImporterService
		{
			get { return new ImporterService(this); }
		}

		/// <summary>
		/// Provies all API methods in Question Area
		/// <para> https://developers.podio.com/doc/questions </para>
		/// </summary>
		/// <value>The question service.</value>
		public QuestionService QuestionService
		{
			get { return new QuestionService(this); }
		}

		/// <summary>
		/// Provies all API methods in Subscriptions area
		/// <para> https://developers.podio.com/doc/subscriptions </para>
		/// </summary>
		/// <value>The subscription service.</value>
		public SubscriptionService SubscriptionService
		{
			get { return new SubscriptionService(this); }
		}

		/// <summary>
		/// Provies API methods in User Area
		/// <para> https://developers.podio.com/doc/users </para>
		/// </summary>
		/// <value>The user service.</value>
		public UserService UserService
		{
			get { return new UserService(this); }
		}

		/// <summary>
		/// Provies API methods in Forms area
		/// <para> https://developers.podio.com/doc/forms </para>
		/// </summary>
		/// <value>The form service.</value>
		public FormService FormService
		{
			get { return new FormService(this); }
		}

		/// <summary>
		/// Provies all API methods in  AppMarket Area
		/// <para> https://developers.podio.com/doc/app-store </para>
		/// </summary>
		/// <value>The application market service.</value>
		public AppMarketService AppMarketService
		{
			get { return new AppMarketService(this); }
		}

		/// <summary>
		/// Gets the view service.
		/// </summary>
		/// <value>The view service.</value>
		public ViewService ViewService
		{
			get { return new ViewService(this); }
		}

		/// <summary>
		/// Provies API methods in Integrations area
		/// <para> https://developers.podio.com/doc/integrations </para>
		/// </summary>
		/// <value>The integration service.</value>
		public IntegrationService IntegrationService
		{
			get { return new IntegrationService(this); }
		}

		/// <summary>
		/// Provies API methods in Flow area
		/// <para> https://developers.podio.com/doc/flows </para>
		/// </summary>
		/// <value>The flow service.</value>
		public FlowService FlowService
		{
			get { return new FlowService(this); }
		}
		#endregion
	}
	/// <summary>
	/// Enum RequestMethod
	/// </summary>
	public enum RequestMethod
	{
		/// <summary>
		/// The get
		/// </summary>
		GET,
		/// <summary>
		/// The post
		/// </summary>
		POST,
		/// <summary>
		/// The put
		/// </summary>
		PUT,
		/// <summary>
		/// The delete
		/// </summary>
		DELETE
	}
}