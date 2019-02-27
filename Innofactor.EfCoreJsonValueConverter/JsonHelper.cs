using System;
using Newtonsoft.Json;

namespace Innofactor.EfCoreJsonValueConverter {

  /// <summary>
  /// Container for JSON settings used for value conversion.
  /// </summary>
  public static class JsonHelper {

    /// <summary>
    /// Specifies the <see cref="JsonSerializerSettings" /> used for value conversion.
    /// </summary>
    public static JsonSerializerSettings SerializerSettings { get; } = new JsonSerializerSettings();

    internal static object Deserialize(string json, Type type)
    {
      return string.IsNullOrWhiteSpace(json) ? null : JsonConvert.DeserializeObject(json, type, SerializerSettings);
    }

    internal static T Deserialize<T>(string json) where T : class {
      return string.IsNullOrWhiteSpace(json) ? null : JsonConvert.DeserializeObject<T>(json, SerializerSettings);
    }

    internal static string Serialize(object obj) {
      return obj == null ? null : JsonConvert.SerializeObject(obj, SerializerSettings);
    }

  }

}
