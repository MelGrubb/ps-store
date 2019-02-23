using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace Store.Common.Validation
{
    [Serializable]
    public class ValidationException : Exception
    {
        /// <summary>Initializes a new instance of the <see cref="ValidationException" /> class.</summary>
        public ValidationException()
        {
        }

        public ValidationException(IEnumerable<ValidationError> errors)
        {
            StatusCode = HttpStatusCode.BadRequest;
            Errors = errors;
        }

        /// <summary>Initializes a new instance of the <see cref="ValidationException" /> class.</summary>
        /// <param name="message">The message that describes the error.</param>
        public ValidationException(string message) : base(message)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ValidationException" /> class.</summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public ValidationException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ValidationException" /> class.</summary>
        /// <param name="message">The message.</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="refLink">The reference link.</param>
        public ValidationException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError, IEnumerable<ValidationError> errors = null, string errorCode = "", string refLink = "") : base(message)
        {
            StatusCode = statusCode;
            Errors = errors;
            ReferenceErrorCode = errorCode;
            ReferenceDocumentLink = refLink;
        }

        /// <summary>Initializes a new instance of the <see cref="ValidationException" /> class.</summary>
        /// <param name="ex">The ex.</param>
        /// <param name="statusCode">The status code.</param>
        public ValidationException(Exception ex, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : base(ex.Message)
        {
            StatusCode = statusCode;
        }

        /// <summary>Initializes a new instance of the <see cref="ValidationException" /> class.</summary>
        /// <param name="info">
        ///     The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized
        ///     object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual
        ///     information about the source or destination.
        /// </param>
        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>Gets or sets the errors.</summary>
        /// <value>The errors.</value>
        public IEnumerable<ValidationError> Errors { get; set; }

        /// <summary>Gets or sets the reference document link.</summary>
        /// <value>The reference document link.</value>
        public string ReferenceDocumentLink { get; set; }

        /// <summary>Gets or sets the reference error code.</summary>
        /// <value>The reference error code.</value>
        public string ReferenceErrorCode { get; set; }

        /// <summary>Gets or sets the status code. Default is InternalServerError.</summary>
        /// <value>The status code.</value>
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;
    }
}
