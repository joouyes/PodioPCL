using Microsoft.VisualStudio.TestTools.UnitTesting;
using PodioPCL.Exceptions;
using PodioPCL.Models;
using PodioPCL.Models.ItemFields;
using PodioPCL.Utils.ApplicationFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodioPCL.Tests.Services
{
	[TestClass]
	public class ApplicationServiceTests
	{

		[TestMethod]
		public async Task ActivateAppTest()
		{
			Podio podio = await TestUtility.GetPodioAndUserLogin();
			throw new NotImplementedException();
		}

		[TestMethod]
		public async Task AddNewAppTest()
		{
			Podio podio = await TestUtility.GetPodioAndUserLogin();
			var allOrganizations = await podio.OrganizationService.GetOrganizations();
			var organization = allOrganizations.FirstOrDefault();
			var space = organization.Spaces.Where(s => s.Name == "PodioPCL Tests").FirstOrDefault();
			ApplicationConfiguration config = new ApplicationConfiguration
			{
				Name = "PodioPCL Test App",
				ItemName = "PodioPCL Test Itme",
				Icon = "230.png"
			};
			var textField = new TextApplicationField();
			textField.Config.Label = "Sample Text Field";
			textField.Config.Label = "Sample Text Field Description";
			textField.Size = "small";

			var categoryField = new CategoryApplicationField();
			categoryField.Config.Label = "Sample Category Field";
			categoryField.Options = new List<CategoryItemField.Option>()
			{
			    new CategoryItemField.Option{ Text = "Option One "},
			    new CategoryItemField.Option{ Text = "Option Two "}
			};
			categoryField.Multiple = true;
			categoryField.Display = CategoryApplicationField.DisplayType.List;
			categoryField.Type = "category";
			int newAppID = await podio.ApplicationService.AddNewApp(space.SpaceId, config, new List<ApplicationField> { textField, categoryField });

			var newApplicationId = await podio.ApplicationService.AddNewApp(space.SpaceId, config);
			var newApplication = await podio.ApplicationService.GetApp(newAppID);
			try
			{
				await podio.ApplicationService.DeleteApp(newApplicationId);
			}
			catch (PodioForbiddenException)
			{
				//your API level doesn't allow the deletion of apps.
			}
		}

		[TestMethod]
		public async Task ActivateAppFieldTest()
		{
			Podio podio = await TestUtility.GetPodioAndUserLogin();
			throw new NotImplementedException();
		}

		[TestMethod]
		public async Task DeactivateAppTest()
		{
			Podio podio = await TestUtility.GetPodioAndUserLogin();
			throw new NotImplementedException();
		}

		[TestMethod]
		public async Task DeleteAppTest()
		{
			Podio podio = await TestUtility.GetPodioAndUserLogin();
			throw new NotImplementedException();
		}

		[TestMethod]
		public async Task DeleteAppFieldTest()
		{
			Podio podio = await TestUtility.GetPodioAndUserLogin();
			throw new NotImplementedException();
		}

		[TestMethod]
		public async Task GetAllAppsTest()
		{
			Podio podio = await TestUtility.GetPodioAndUserLogin();
			throw new NotImplementedException();
		}

		[TestMethod]
		public async Task GetAppByLabelTest()
		{
			//https://developers.podio.com/doc/applications/get-app-by-org-label-space-label-and-app-label-91708386
			Podio podio = await TestUtility.GetPodioAndUserLogin();
			throw new NotImplementedException();
		}

		[TestMethod]
		public async Task GetAppDependenciesTest()
		{
			Podio podio = await TestUtility.GetPodioAndUserLogin();
			throw new NotImplementedException();
		}

		[TestMethod]
		public async Task GetAppFieldTest()
		{
			Podio podio = await TestUtility.GetPodioAndUserLogin();
			throw new NotImplementedException();
		}

		[TestMethod]
		public async Task GetAppsBySpaceTest()
		{
			Podio podio = await TestUtility.GetPodioAndUserLogin();
			throw new NotImplementedException();
		}

		[TestMethod]
		public async Task GetFeaturesTest()
		{
			Podio podio = await TestUtility.GetPodioAndUserLogin();
			throw new NotImplementedException();
		}

		[TestMethod]
		public async Task GetIconSuggestionsTest()
		{
			Podio podio = await TestUtility.GetPodioAndUserLogin();
			throw new NotImplementedException();
		}

		[TestMethod]
		public async Task GetSpaceAppDependencies()
		{
			Podio podio = await TestUtility.GetPodioAndUserLogin();
			throw new NotImplementedException();
		}

		[TestMethod]
		public async Task GetTopAppsTest()
		{
			Podio podio = await TestUtility.GetPodioAndUserLogin();
			throw new NotImplementedException();
		}

		[TestMethod]
		public async Task GetTopAppsForOrgTest()
		{
			Podio podio = await TestUtility.GetPodioAndUserLogin();
			throw new NotImplementedException();
		}

		[TestMethod]
		public async Task InstallAppTest()
		{
			Podio podio = await TestUtility.GetPodioAndUserLogin();
			throw new NotImplementedException();
		}

	}
}
