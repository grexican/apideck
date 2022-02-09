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
    /// WebhookEvent
    /// </summary>
    [DataContract(Name = "WebhookEvent")]
    public partial class WebhookEvent : IEquatable<WebhookEvent>, IValidatableObject
    {

        /// <summary>
        /// Gets or Sets EventType
        /// </summary>
        [DataMember(Name = "event_type", EmitDefaultValue = false)]
        public WebhookEventType? EventType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="WebhookEvent" /> class.
        /// </summary>
        /// <param name="eventId">Unique reference to this request event.</param>
        /// <param name="serviceId">Service provider identifier.</param>
        /// <param name="eventType">eventType.</param>
        /// <param name="entityId">The service provider&#39;s ID of the entity that triggered this event.</param>
        /// <param name="entityType">The type entity that triggered this event.</param>
        /// <param name="entityUrl">The url to retrieve entity detail..</param>
        /// <param name="executionAttempt">The current count this request event has been attempted.</param>
        /// <param name="occurredAt">ISO Datetime for when the original event occurred.</param>
        public WebhookEvent(string eventId = default(string), string serviceId = default(string), WebhookEventType? eventType = default(WebhookEventType?), string entityId = default(string), string entityType = default(string), string entityUrl = default(string), decimal executionAttempt = default(decimal), DateTime occurredAt = default(DateTime))
        {
            this.EventId = eventId;
            this.ServiceId = serviceId;
            this.EventType = eventType;
            this.EntityId = entityId;
            this.EntityType = entityType;
            this.EntityUrl = entityUrl;
            this.ExecutionAttempt = executionAttempt;
            this.OccurredAt = occurredAt;
        }

        /// <summary>
        /// Unique reference to this request event
        /// </summary>
        /// <value>Unique reference to this request event</value>
        [DataMember(Name = "event_id", EmitDefaultValue = false)]
        public string EventId { get; set; }

        /// <summary>
        /// Service provider identifier
        /// </summary>
        /// <value>Service provider identifier</value>
        [DataMember(Name = "service_id", EmitDefaultValue = false)]
        public string ServiceId { get; set; }

        /// <summary>
        /// The service provider&#39;s ID of the entity that triggered this event
        /// </summary>
        /// <value>The service provider&#39;s ID of the entity that triggered this event</value>
        [DataMember(Name = "entity_id", EmitDefaultValue = false)]
        public string EntityId { get; set; }

        /// <summary>
        /// The type entity that triggered this event
        /// </summary>
        /// <value>The type entity that triggered this event</value>
        [DataMember(Name = "entity_type", EmitDefaultValue = false)]
        public string EntityType { get; set; }

        /// <summary>
        /// The url to retrieve entity detail.
        /// </summary>
        /// <value>The url to retrieve entity detail.</value>
        [DataMember(Name = "entity_url", EmitDefaultValue = false)]
        public string EntityUrl { get; set; }

        /// <summary>
        /// The current count this request event has been attempted
        /// </summary>
        /// <value>The current count this request event has been attempted</value>
        [DataMember(Name = "execution_attempt", EmitDefaultValue = false)]
        public decimal ExecutionAttempt { get; set; }

        /// <summary>
        /// ISO Datetime for when the original event occurred
        /// </summary>
        /// <value>ISO Datetime for when the original event occurred</value>
        [DataMember(Name = "occurred_at", EmitDefaultValue = false)]
        public DateTime OccurredAt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class WebhookEvent {\n");
            sb.Append("  EventId: ").Append(EventId).Append("\n");
            sb.Append("  ServiceId: ").Append(ServiceId).Append("\n");
            sb.Append("  EventType: ").Append(EventType).Append("\n");
            sb.Append("  EntityId: ").Append(EntityId).Append("\n");
            sb.Append("  EntityType: ").Append(EntityType).Append("\n");
            sb.Append("  EntityUrl: ").Append(EntityUrl).Append("\n");
            sb.Append("  ExecutionAttempt: ").Append(ExecutionAttempt).Append("\n");
            sb.Append("  OccurredAt: ").Append(OccurredAt).Append("\n");
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
            return this.Equals(input as WebhookEvent);
        }

        /// <summary>
        /// Returns true if WebhookEvent instances are equal
        /// </summary>
        /// <param name="input">Instance of WebhookEvent to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WebhookEvent input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.EventId == input.EventId ||
                    (this.EventId != null &&
                    this.EventId.Equals(input.EventId))
                ) && 
                (
                    this.ServiceId == input.ServiceId ||
                    (this.ServiceId != null &&
                    this.ServiceId.Equals(input.ServiceId))
                ) && 
                (
                    this.EventType == input.EventType ||
                    this.EventType.Equals(input.EventType)
                ) && 
                (
                    this.EntityId == input.EntityId ||
                    (this.EntityId != null &&
                    this.EntityId.Equals(input.EntityId))
                ) && 
                (
                    this.EntityType == input.EntityType ||
                    (this.EntityType != null &&
                    this.EntityType.Equals(input.EntityType))
                ) && 
                (
                    this.EntityUrl == input.EntityUrl ||
                    (this.EntityUrl != null &&
                    this.EntityUrl.Equals(input.EntityUrl))
                ) && 
                (
                    this.ExecutionAttempt == input.ExecutionAttempt ||
                    this.ExecutionAttempt.Equals(input.ExecutionAttempt)
                ) && 
                (
                    this.OccurredAt == input.OccurredAt ||
                    (this.OccurredAt != null &&
                    this.OccurredAt.Equals(input.OccurredAt))
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
                if (this.EventId != null)
                {
                    hashCode = (hashCode * 59) + this.EventId.GetHashCode();
                }
                if (this.ServiceId != null)
                {
                    hashCode = (hashCode * 59) + this.ServiceId.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.EventType.GetHashCode();
                if (this.EntityId != null)
                {
                    hashCode = (hashCode * 59) + this.EntityId.GetHashCode();
                }
                if (this.EntityType != null)
                {
                    hashCode = (hashCode * 59) + this.EntityType.GetHashCode();
                }
                if (this.EntityUrl != null)
                {
                    hashCode = (hashCode * 59) + this.EntityUrl.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ExecutionAttempt.GetHashCode();
                if (this.OccurredAt != null)
                {
                    hashCode = (hashCode * 59) + this.OccurredAt.GetHashCode();
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
