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
    /// The status of the webhook.
    /// </summary>
    /// <value>The status of the webhook.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Status
    {
        /// <summary>
        /// Enum Enabled for value: enabled
        /// </summary>
        [EnumMember(Value = "enabled")]
        Enabled = 1,

        /// <summary>
        /// Enum Disabled for value: disabled
        /// </summary>
        [EnumMember(Value = "disabled")]
        Disabled = 2

    }

}
