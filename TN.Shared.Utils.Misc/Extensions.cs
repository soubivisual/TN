using System.Globalization;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace TN.Shared.Utils.Misc
{
    public static class Extensions
    {
        private static readonly JsonSerializerSettings defaultConfiguration;
        private static readonly JsonSerializerSettings snakeCaseConfiguration;
        private static readonly JsonSerializerSettings ignoreErrorConfiguration;

        static Extensions()
        {
            defaultConfiguration = new JsonSerializerSettings()
            {
                //PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            snakeCaseConfiguration = new JsonSerializerSettings()
            {
                //PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ContractResolver = new DefaultContractResolver() { NamingStrategy = new SnakeCaseNamingStrategy() }
            };

            ignoreErrorConfiguration = new JsonSerializerSettings()
            {
                Error = (se, ev) => { ev.ErrorContext.Handled = true; }
            };
        }

        public static string ToJson<T>(this T obj)
        {
            return JsonConvert.SerializeObject(obj, defaultConfiguration);
        }

        public static string ToSnakeCaseJson<T>(this T obj)
        {
            return JsonConvert.SerializeObject(obj, snakeCaseConfiguration);
        }

        public static T FromJson<T>(this string serialized, bool ignoreUnmatchProperties = false)
        {
            if (ignoreUnmatchProperties)
                return string.IsNullOrWhiteSpace(serialized) ? default(T) : JsonConvert.DeserializeObject<T>(serialized, ignoreErrorConfiguration);
            else
                return string.IsNullOrWhiteSpace(serialized) ? default(T) : JsonConvert.DeserializeObject<T>(serialized);
        }

        public static JObject ToJObject(this object obj)
        {
            var result = default(JObject);

            try
            {
                result = JObject.Parse(obj.ToString());
            }
            catch { }

            return result;
        }

        public static T GetValueFromJsonToken<T>(this JObject jObject, string path)
        {
            var result = default(T);

            try
            {
                result = jObject.SelectToken(path).Value<T>();
            }
            catch { }

            return result;
        }

        public static string RemoveJsonToken(this JObject jObject, string path)
        {
            var result = string.Empty;

            try
            {
                jObject.SelectToken(path).Parent.Remove();
            }
            catch { }
            finally
            {
                result = jObject.ToString();
            }

            return result;
        }

        public static T ConvertTo<T>(this object obj)
        {
            //return obj.ToJson().FromJson<T>();

            var result = (T)Activator.CreateInstance(typeof(T));

            if (obj != null)
                result = (T)Functions.Cast(obj, result);

            return result;
        }

        public static string ToXML(this string text)
        {
            var response = text;

            try
            {
                response = XElement.Parse(text).ToString();
            }
            catch { }

            return response;
        }

        public static string ToXml<T>(this T obj)
        {
            var serializer = new DataContractSerializer(obj.GetType());
            using var writer = new StringWriter();
            using var stm = new XmlTextWriter(writer);
            serializer.WriteObject(stm, obj);
            return writer.ToString();
        }

        public static T FromXml<T>(this string serialized)
        {
            var serializer = new DataContractSerializer(typeof(T));
            using var reader = new StringReader(serialized);
            using var stm = new XmlTextReader(reader);
            return (T)serializer.ReadObject(stm);
        }

        public static int ToValidTimeout(this int? nullableNumber)
        {
            return nullableNumber == null ? 100000 : Convert.ToInt32(nullableNumber) * 1000;
        }

        public static DateTime FromUnixTime(this long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

        public static long ToUnixTime(this DateTime dateUtc)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64(dateUtc.Subtract(epoch).TotalSeconds);
        }

        public static string LimitTo(this string data, int length)
        {
            return (data == null || data.Length < length)
              ? data
              : data.Substring(0, length);
        }

        public static string EmptyNull(this string str)
        {
            return str ?? "";
        }

        public static short ToShort(this string text)
        {
            _ = short.TryParse(text, out short result);
            return result;
        }

        public static int ToInt(this string text)
        {
            _ = int.TryParse(text, out int result);
            return result;
        }

        public static int ToInt(this DateTime? date)
        {
            return date.HasValue ? int.Parse(date.Value.ToString("yyyyMMdd")) : 0;
        }

        public static long ToLong(this string text)
        {
            _ = long.TryParse(text, out long result);
            return result;
        }

        public static decimal ToDecimal(this string text)
        {
            _ = decimal.TryParse(text, out decimal result);
            return result;
        }

        public static double ToDouble(this string text)
        {
            _ = double.TryParse(text, out double result);
            return result;
        }

        public static bool ToBool(this string text)
        {
            _ = bool.TryParse(text, out bool result);
            return result;
        }

        public static Guid ToGuid(this string text)
        {
            _ = Guid.TryParse(text, out Guid result);
            return result;
        }

        public static string ToCRCString(this decimal number)
        {
            return number.ToString("C2", CultureInfo.CreateSpecificCulture("es-CR"));
        }

        public static string To2DecimalString(this decimal number)
        {
            return number.ToString("#,0.00", CultureInfo.InvariantCulture);
        }

        public static string To8DecimalString(this decimal number)
        {
            return number.ToString("#,0.00######", CultureInfo.InvariantCulture);
        }

        public static string ToNoThousands2DecimalString(this decimal number)
        {
            return number.ToString("#.00", CultureInfo.InvariantCulture);
        }

        public static string ToNoDecimalString(this decimal number)
        {
            return Math.Floor(number).ToString();
        }

        public static decimal ToRoundUpNoDecimal(this decimal number)
        {
            return Math.Ceiling(number);
        }

        public static decimal ToRoundDown2Decimal(this decimal number)
        {
            return (Math.Floor(number * 100) / 100);
        }

        public static decimal ToRoundUp2Decimal(this decimal number)
        {
            return (Math.Ceiling(number * 100) / 100);
        }

        public static DateTime ToDateTime(this string date)
        {
            _ = DateTime.TryParse(date, out DateTime Date);

            return Date;
        }

        public static DateTime ToUniversalDateTime(this DateTime date)
        {
            return DateTime.SpecifyKind(date, DateTimeKind.Local).ToUniversalTime();
        }

        public static DateTime ToLocalDateTime(this DateTime date)
        {
            return DateTime.SpecifyKind(date, DateTimeKind.Utc).ToLocalTime();
        }

        public static string RemainingTimeInMinutes(this DateTimeOffset date)
        {
            var result = (decimal)(date - DateTime.Now).TotalMinutes;

            return result.ToRoundUpNoDecimal().ToString();
        }

        public static bool IsJson(this string text)
        {
            try
            {
                JToken.Parse(text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsXML(this string text)
        {
            try
            {
                XDocument.Parse(text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string FormatJson(this string text)
        {
            try
            {
                var obj = text.FromJson<dynamic>();
                return JsonConvert.SerializeObject(obj, defaultConfiguration);
            }
            catch (Exception)
            {
                return text;
            }
        }

        public static string FormatXML(this string text)
        {
            try
            {
                XDocument xml = XDocument.Parse(text);
                return xml.ToString();
            }
            catch (Exception)
            {
                return text;
            }
        }

        public static string ToCleanJson(this string text) => text.Replace(" ", "").Replace("\r\n", "").Replace("\n", "").Replace("\r", "");

        public static string ToSnakeCase(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }

            text = text.Trim();

            var length = text.Length;
            var addedByLower = false;
            var stringBuilder = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                var currentChar = text[i];

                if (char.IsWhiteSpace(currentChar))
                {
                    continue;
                }

                if (currentChar.Equals('_'))
                {
                    stringBuilder.Append('_');
                    continue;
                }

                bool isLastChar = i + 1 == length,
                        isFirstChar = i == 0,
                        nextIsUpper = false,
                        nextIsLower = false;

                if (!isLastChar)
                {
                    nextIsUpper = char.IsUpper(text[i + 1]);
                    nextIsLower = !nextIsUpper && !text[i + 1].Equals('_');
                }

                if (!char.IsUpper(currentChar))
                {
                    stringBuilder.Append(char.ToLowerInvariant(currentChar));

                    if (nextIsUpper)
                    {
                        stringBuilder.Append('_');
                        addedByLower = true;
                    }

                    continue;
                }

                if (nextIsLower && !addedByLower && !isFirstChar)
                {
                    stringBuilder.Append('_');
                }

                addedByLower = false;

                stringBuilder.Append(char.ToLowerInvariant(currentChar));
            }

            return stringBuilder.ToString();
        }

        public static string ToSnakeCaseV2(this string str)
        {
            return string.Concat(str.Select((character, index) =>
                    index > 0 && char.IsUpper(character)
                        ? "_" + character
                        : character.ToString()))
                .ToLower();
        }

        public static string ToFirstLetterUpper(this string text)
        {
            string result = string.Empty;
            string[] words = text.ToLower().Split(' ');

            foreach (var word in words)
                result += $"{word[0].ToString().ToUpper()}{word.Substring(1)} ";

            return result.TrimEnd();
        }

        public static string Mask(this string text, char character)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            var sb = new StringBuilder(text.Length);

            for (int i = 0; i < text.Length; i++)
                sb.Append(character);

            return sb.ToString();
        }

        public static string Underscore(this string input)
        {
            return Regex.Replace(
                Regex.Replace(
                    Regex.Replace(input, @"([\p{Lu}]+)([\p{Lu}][\p{Ll}])", "$1_$2"), @"([\p{Ll}\d])([\p{Lu}])", "$1_$2"), @"[-\s]", "_").ToLower();
        }

        public static string GetName(this object instance) => instance.GetType()?.Name;

        public static string RemoveWhiteSpaces(this string text) => Regex.Replace(text, @"\s+", "");

        public static string LookupValue(this string text, string regex)
        {
            var response = string.Empty;

            foreach (Match match in Regex.Matches(text, regex))
            {
                if (match.Success && match.Groups.Count > 0)
                    response += match.Groups[0].Value;
            }

            return response;
        }
    }
}