// ***********************************************************************
// Assembly         : PodioPCL
// Author           : OnsharpRyan
// Created          : 12-13-2014
//
// Last Modified By : OnsharpRyan
// Last Modified On : 12-13-2014
// ***********************************************************************
// <copyright file="DateItemField.cs" company="Onsharp">
//     Copyright (c) Onsharp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;

namespace PodioPCL.Models.ItemFields
{
	/// <summary>
	/// A interval presented by a start and optional end date and optional time.
	/// <br />
	/// <a href="https://developers.podio.com/doc/applications">Application API Documentation</a>
	/// </summary>
    public class DateItemField : ItemField
    {

		/// <summary>
		/// Gets or sets the start.
		/// </summary>
		/// <value>The start.</value>
        public DateTime? Start {
            get
            {
                if (this.HasValue("start"))
                {
                    return DateTime.Parse((string)this.Values.First()["start"]);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                setDateTime(value, "start");
            }
        }

		/// <summary>
		/// Gets or sets the end.
		/// </summary>
		/// <value>The end.</value>
        public DateTime? End
        {
            get
            {
                if (this.HasValue("end"))
                {
                    return DateTime.Parse((string)this.Values.First()["end"]);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                setDateTime(value, "end");
            }
        }

		/// <summary>
		/// Gets the start date.
		/// </summary>
		/// <value>The start date.</value>
        public DateTime? StartDate
        {
            get
            {
                if (this.HasValue("start_date"))
                {
                    return DateTime.Parse((string)this.Values.First()["start_date"]);
                }
                else
                {
                    return null;
                }
            }
        }

		/// <summary>
		/// Gets the end date.
		/// </summary>
		/// <value>The end date.</value>
        public DateTime? EndDate
        {
            get
            {
                if (this.HasValue("end_date"))
                {
                    return DateTime.Parse((string)this.Values.First()["end_date"]);
                }
                else
                {
                    return null;
                }
            }
        }

		/// <summary>
		/// Gets the start time.
		/// </summary>
		/// <value>The start time.</value>
        public string StartTime {
            get {
                if (this.HasValue("start_time"))
                {
                    return (string)this.Values.First()["start_time"];
                }
                else
                {
                    return null;
                }
            }
        }

		/// <summary>
		/// Gets the end time.
		/// </summary>
		/// <value>The end time.</value>
        public string EndTime
        {
            get
            {
                if (this.HasValue("end_time"))
                {
                    return (string)this.Values.First()["end_time"];
                }
                else
                {
                    return null;
                }
            }
        }

		/// <summary>
		/// Sets the date time.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="attribute">The attribute.</param>
        protected void setDateTime(DateTime? value, string attribute) {
            ensureValuesInitialized(true);
            string stringValue = null;
            if (value != null)
            {
                stringValue = String.Format("{0:yyyy-MM-dd HH:mm:ss}", value);
            }
            this.Values.First()[attribute] = stringValue;        
        }
    }

}
