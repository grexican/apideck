/*
 * Webhook API
 *
 * Welcome to the Webhook API.
 *
 * The version of the OpenAPI document: 8.11.0
 * Contact: hello@apideck.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = Apideck.Webhook.Client.OpenAPIDateConverter;

namespace Apideck.Webhook.Model
{
    /// <summary>
    /// NotImplementedResponse
    /// </summary>
    [DataContract(Name = "NotImplementedResponse")]
    public partial class NotImplementedResponse : IEquatable<NotImplementedResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotImplementedResponse" /> class.
        /// </summary>
        /// <param name="statusCode">HTTP status code.</param>
        /// <param name="error">Contains an explanation of the status_code as defined in HTTP/1.1 standard (RFC 7231).</param>
        /// <param name="typeName">The type of error returned.</param>
        /// <param name="message">A human-readable message providing more details about the error..</param>
        /// <param name="detail">Contains parameter or domain specific information related to the error and why it occurred..</param>
        /// <param name="_ref">Link to documentation of error type.</param>
        public NotImplementedResponse(decimal statusCode = default(decimal), string error = default(string), string typeName = default(string), string message = default(string), object detail = default(object), string _ref = default(string))
        {
            this.StatusCode = statusCode;
            this.Error = error;
            this.TypeName = typeName;
            this.Message = message;
            this.Detail = detail;
            this.Ref = _ref;
        }

        /// <summary>
        /// HTTP status code
        /// </summary>
        /// <value>HTTP status code</value>
        [DataMember(Name = "status_code", EmitDefaultValue = false)]
        public decimal StatusCode { get; set; }

        /// <summary>
        /// Contains an explanation of the status_code as defined in HTTP/1.1 standard (RFC 7231)
        /// </summary>
        /// <value>Contains an explanation of the status_code as defined in HTTP/1.1 standard (RFC 7231)</value>
        [DataMember(Name = "error", EmitDefaultValue = false)]
        public string Error { get; set; }

        /// <summary>
        /// The type of error returned
        /// </summary>
        /// <value>The type of error returned</value>
        [DataMember(Name = "type_name", EmitDefaultValue = false)]
        public string TypeName { get; set; }

        /// <summary>
        /// A human-readable message providing more details about the error.
        /// </summary>
        /// <value>A human-readable message providing more details about the error.</value>
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Contains parameter or domain specific information related to the error and why it occurred.
        /// </summary>
        /// <value>Contains parameter or domain specific information related to the error and why it occurred.</value>
        [DataMember(Name = "detail", EmitDefaultValue = true)]
        public object Detail { get; set; }

        /// <summary>
        /// Link to documentation of error type
        /// </summary>
        /// <value>Link to documentation of error type</value>
        [DataMember(Name = "ref", EmitDefaultValue = false)]
        public string Ref { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class NotImplementedResponse {\n");
            sb.Append("  StatusCode: ").Append(StatusCode).Append("\n");
            sb.Append("  Error: ").Append(Error).Append("\n");
            sb.Append("  TypeName: ").Append(TypeName).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  Detail: ").Append(Detail).Append("\n");
            sb.Append("  Ref: ").Append(Ref).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as NotImplementedResponse);
        }

        /// <summary>
        /// Returns true if NotImplementedResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of NotImplementedResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NotImplementedResponse input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.StatusCode == input.StatusCode ||
                    this.StatusCode.Equals(input.StatusCode)
                ) && 
                (
                    this.Error == input.Error ||
                    (this.Error != null &&
                    this.Error.Equals(input.Error))
                ) && 
                (
                    this.TypeName == input.TypeName ||
                    (this.TypeName != null &&
                    this.TypeName.Equals(input.TypeName))
                ) && 
                (
                    this.Message == input.Message ||
                    (this.Message != null &&
                    this.Message.Equals(input.Message))
                ) && 
                (
                    this.Detail == input.Detail ||
                    (this.Detail != null &&
                    this.Detail.Equals(input.Detail))
                ) && 
                (
                    this.Ref == input.Ref ||
                    (this.Ref != null &&
                    this.Ref.Equals(input.Ref))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                hashCode = (hashCode * 59) + this.StatusCode.GetHashCode();
                if (this.Error != null)
                {
                    hashCode = (hashCode * 59) + this.Error.GetHashCode();
                }
                if (this.TypeName != null)
                {
                    hashCode = (hashCode * 59) + this.TypeName.GetHashCode();
                }
                if (this.Message != null)
                {
                    hashCode = (hashCode * 59) + this.Message.GetHashCode();
                }
                if (this.Detail != null)
                {
                    hashCode = (hashCode * 59) + this.Detail.GetHashCode();
                }
                if (this.Ref != null)
                {
                    hashCode = (hashCode * 59) + this.Ref.GetHashCode();
                }
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
