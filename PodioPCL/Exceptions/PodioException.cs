// ***********************************************************************
// Assembly         : PodioPCL
// Author           : OnsharpRyan
// Created          : 12-09-2014
//
// Last Modified By : OnsharpRyan
// Last Modified On : 12-13-2014
// ***********************************************************************
// <copyright file="PodioException.cs" company="Onsharp">
//     Copyright (c) Onsharp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;

namespace PodioPCL.Exceptions
{
	/// <summary>
	/// The PodioException is the base for all PodioExceptions
	/// </summary>
    public class PodioException : Exception
    {
		/// <summary>
		/// Response from the API
		/// </summary>
		/// <value>The error.</value>
        public PodioError Error { get; internal set; }

		/// <summary>
		/// Status code of the response
		/// </summary>
		/// <value>The status.</value>
        public int Status { get; internal set; }
		/// <summary>
		/// Initializes a new instance of the <see cref="PodioException"/> class.
		/// </summary>
		/// <param name="status">The status.</param>
		/// <param name="error">The error.</param>
        public PodioException(int status, PodioError error)
        {
            this.Error = error;
            this.Status = status;
        }
    }

	/// <summary>
	/// Class PodioInvalidGrantException.
	/// </summary>
	public class PodioInvalidGrantException : PodioException
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="PodioInvalidGrantException"/> class.
		/// </summary>
		/// <param name="status">The status.</param>
		/// <param name="error">The error.</param>
        public PodioInvalidGrantException(int status, PodioError error)
            : base(status, error)
        {
        }
    }

	/// <summary>
	/// Class PodioBadRequestException.
	/// </summary>
	public class PodioBadRequestException : PodioException
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="PodioBadRequestException"/> class.
		/// </summary>
		/// <param name="status">The status.</param>
		/// <param name="error">The error.</param>
        public PodioBadRequestException(int status, PodioError error)
            : base(status, error)
        {
        }
    }

	/// <summary>
	/// Class PodioAuthorizationException.
	/// </summary>
	public class PodioAuthorizationException : PodioException
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="PodioAuthorizationException"/> class.
		/// </summary>
		/// <param name="status">The status.</param>
		/// <param name="error">The error.</param>
        public PodioAuthorizationException(int status, PodioError error)
            : base(status, error)
        {
        }
    }

	/// <summary>
	/// Class PodioForbiddenException.
	/// </summary>
	public class PodioForbiddenException : PodioException
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="PodioForbiddenException"/> class.
		/// </summary>
		/// <param name="status">The status.</param>
		/// <param name="error">The error.</param>
        public PodioForbiddenException(int status, PodioError error)
            : base(status, error)
        {
        }
    }

	/// <summary>
	/// Class PodioNotFoundException.
	/// </summary>
	public class PodioNotFoundException : PodioException
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="PodioNotFoundException"/> class.
		/// </summary>
		/// <param name="status">The status.</param>
		/// <param name="error">The error.</param>
        public PodioNotFoundException(int status, PodioError error)
            : base(status, error)
        {
        }
    }

	/// <summary>
	/// Class PodioConflictException.
	/// </summary>
	public class PodioConflictException : PodioException
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="PodioConflictException"/> class.
		/// </summary>
		/// <param name="status">The status.</param>
		/// <param name="error">The error.</param>
        public PodioConflictException(int status, PodioError error)
            : base(status, error)
        {
        }
    }

	/// <summary>
	/// Class PodioGoneException.
	/// </summary>
	public class PodioGoneException : PodioException
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="PodioGoneException"/> class.
		/// </summary>
		/// <param name="status">The status.</param>
		/// <param name="error">The error.</param>
        public PodioGoneException(int status, PodioError error)
            : base(status, error)
        {
        }
    }

	/// <summary>
	/// Class PodioRateLimitException.
	/// </summary>
	public class PodioRateLimitException : PodioException
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="PodioRateLimitException"/> class.
		/// </summary>
		/// <param name="status">The status.</param>
		/// <param name="error">The error.</param>
        public PodioRateLimitException(int status, PodioError error)
            : base(status, error)
        {
        }
    }

	/// <summary>
	/// Class PodioServerException.
	/// </summary>
	public class PodioServerException : PodioException
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="PodioServerException"/> class.
		/// </summary>
		/// <param name="status">The status.</param>
		/// <param name="error">The error.</param>
        public PodioServerException(int status, PodioError error)
            : base(status, error)
        {
        }
    }

	/// <summary>
	/// Class PodioUnavailableException.
	/// </summary>
	public class PodioUnavailableException : PodioException
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="PodioUnavailableException"/> class.
		/// </summary>
		/// <param name="status">The status.</param>
		/// <param name="error">The error.</param>
        public PodioUnavailableException(int status, PodioError error)
            : base(status, error)
        {
        }
    }

	/// <summary>
	/// Represent the error response from API
	/// </summary>
    public class PodioError
    {
		/// <summary>
		/// Gets or sets a value indicating whether [error propagate].
		/// </summary>
		/// <value><c>true</c> if [error propagate]; otherwise, <c>false</c>.</value>
        [JsonProperty(PropertyName = "error_propagate")]
        public bool ErrorPropagate { get; set; }

		/// <summary>
		/// Gets or sets the error.
		/// </summary>
		/// <value>The error.</value>
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

		/// <summary>
		/// Gets or sets the error description.
		/// </summary>
		/// <value>The error description.</value>
        [JsonProperty(PropertyName = "error_description")]
        public string ErrorDescription { get; set; }

		/// <summary>
		/// Gets or sets the error detail.
		/// </summary>
		/// <value>The error detail.</value>
        [JsonProperty(PropertyName = "error_detail")]
        public string ErrorDetail { get; set; }

		/// <summary>
		/// Gets or sets the request.
		/// </summary>
		/// <value>The request.</value>
        [JsonProperty(PropertyName = "request")]
        public Request Request { get; set; }
    }

	/// <summary>
	/// Class Request.
	/// </summary>
    public class Request
    {
		/// <summary>
		/// Gets or sets the URL.
		/// </summary>
		/// <value>The URL.</value>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

		/// <summary>
		/// Gets or sets the query string.
		/// </summary>
		/// <value>The query string.</value>
        [JsonProperty(PropertyName = "query_string")]
        public string QueryString { get; set; }

		/// <summary>
		/// Gets or sets the method.
		/// </summary>
		/// <value>The method.</value>
        [JsonProperty(PropertyName = "method")]
        public string Method { get; set; }
    }

}
