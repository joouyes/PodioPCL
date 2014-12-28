
namespace PodioPCL.Models
{
	internal enum ApplicationFieldTypes
	{
		Other,
		/// <summary>
		/// A short text field that can hold a text string.
		/// </summary>
		Text,
		/// <summary>
		/// A field that can hold a single number with decimals.
		/// </summary>
		Number,
		/// <summary>
		/// Holds an image.
		/// </summary>
		Image,
		/// <summary>
		/// An embedded media typically from youtube or similar.
		/// </summary>
		Media,
		/// <summary>
		/// A interval presented by a start and optional end date and optional time
		/// </summary>
		Date,
		/// <summary>
		/// A reference to another app item.
		/// </summary>
		App,
		/// <summary>
		/// A currency value
		/// </summary>
		Money,
		/// <summary>
		/// The progress of an app item.
		/// </summary>
		Progress,
		/// <summary>
		/// A location in f.ex. Google maps
		/// </summary>
		Location,
		/// <summary>
		/// Stores are duration in seconds, but normally presented in hours, minutes and seconds.
		/// </summary>
		Duration,
		/// <summary>
		/// Reference to a contact, which can be either a user or a space contact.
		/// </summary>
		Contact,
		/// <summary>
		/// A calculation based on fields in the same or related apps
		/// </summary>
		Calculation,
		/// <summary>
		/// A list of embeds (links).
		/// </summary>
		Embed,
		/// <summary>
		/// A list of options for the question
		/// </summary>
		Question,
		/// <summary>
		/// A list of files matching the configured mimetypes
		/// </summary>
		File,
		Category,
		State
	}
}
