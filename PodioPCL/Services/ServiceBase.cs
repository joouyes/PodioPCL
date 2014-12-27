using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodioPCL.Services
{
	/// <summary>
	/// A service to base all other services off of.
	/// </summary>
	/// <typeparam name="TModel">The type of model the Service deals with.</typeparam>
	public abstract class ServiceBase<TModel> where TModel : new()
	{
		/// <summary>
		/// The internal <see cref="T:PodioPCL.Podio"/> reference.
		/// </summary>
		protected Podio _Podio;

		/// <summary>
		/// Initializes a new instance of the Service.
		/// </summary>
		/// <param name="currentInstance">The current Podio instance.</param>
		internal ServiceBase(Podio currentInstance)
		{
			_Podio = currentInstance;
		}
	}
}
