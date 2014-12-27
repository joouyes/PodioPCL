using Microsoft.VisualStudio.TestTools.UnitTesting;
using PodioPCL.Utils.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodioPCL.Tests.Services
{
	[TestClass]
	public class ActionServiceTests
	{
		[TestMethod, TestCategory(TestCategoryTypes.Constructor)]
		public void ActionServiceConstructorTest()
		{
			Podio podio = TestUtility.GetPodio();
			Assert.IsNotNull(podio.ActionService);
		}

		[TestMethod]
		public async Task GetActionsTest()
		{
			Podio podio = await TestUtility.GetPodioAndUserLogin();

			//TODO: This service needs to be tested properly.
			//var actions = await podio.ActionService.GetAction(0);
		}
	}
}
