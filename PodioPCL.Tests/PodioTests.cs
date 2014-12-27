using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PodioPCL.Utils.Authentication;
using System.Threading.Tasks;
using PodioPCL.Models;
using PodioPCL.Models.ItemFields;
using PodioPCL.Exceptions;

namespace PodioPCL.Tests
{
	[TestClass]
	public class PodioTests
	{
		[TestMethod, TestCategory(TestCategoryTypes.Constructor)]
		public void PodioConstructorTest()
		{
			Podio podio = TestUtility.GetPodio();
		}

		[TestMethod]
		public async Task AuthenticateWithPasswordTest()
		{
			Podio podio = await TestUtility.GetPodioAndUserLogin();
			Assert.IsNotNull(podio);
		}

		[TestMethod]
		public async Task AuthenticateWithAppTest()
		{
			Podio podio = await TestUtility.GetPodioAndAppLogin();
			Assert.IsNotNull(podio);
		}

		[TestMethod]
		public async Task RefreshAccessTokenAsyncTest()
		{
			Podio podio = await TestUtility.GetPodioAndUserLogin();
			Assert.IsNotNull(podio);
			PodioOAuth podioOAuth = await podio.RefreshAccessTokenAsync();
			Assert.IsNotNull(podioOAuth);
		}

		[TestMethod]
		public void GetAuthorizeUrlTest()
		{
			string testReturnUrl = "http://google.com";
			Podio podio = TestUtility.GetPodio();
			Assert.IsNotNull(podio);
			var url = podio.GetAuthorizeUrl(testReturnUrl);
			Assert.IsFalse(string.IsNullOrEmpty(url));
			Uri uri;
			Assert.IsTrue(Uri.TryCreate(url, UriKind.Absolute, out uri));
			var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
			Assert.AreEqual(TestUtility.LoginSettings.ClientId, query["client_id"]);
			var redirectUri = query["redirect_uri"];
			Assert.AreEqual(testReturnUrl, redirectUri);
		}

		[TestMethod]
		public async Task IsAuthenticatedTest()
		{
			Podio podio = TestUtility.GetPodio();
			Assert.IsFalse(podio.IsAuthenticated());
			await podio.AuthenticateWithPassword(TestUtility.LoginSettings.UserName, TestUtility.LoginSettings.Password);
			Assert.IsTrue(podio.IsAuthenticated());
		}
	}
}
