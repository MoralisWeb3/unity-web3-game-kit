//using Moralis.Platform.Abstractions;
//using Moralis.Platform.Objects;
//using Moralis.Platform.Services.ClientServices;
//using Moralis.Platform.Utilities;
//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Text;

//namespace Moralis.Platform.Services.Infrastructure
//{
//    public abstract class DataEncoder<TUser> where TUser : MoralisUser
//    {
//        public static bool Validate(object value) => value is null || value.GetType().IsPrimitive || value is string || value is MoralisObject || value is MoralisAcl || value is MoralisFile || value is MoralisGeoPoint || value is ParseRelationBase || value is DateTime || value is byte[] || Conversion.As<IDictionary<string, object>>(value) is { } || Conversion.As<IList<object>>(value) is { };

//        // If this object has a special encoding, encode it and return the encoded object. Otherwise, just return the original object.

//        public object Encode(object value, IServiceHub<TUser> serviceHub) => value switch
//        {
//            DateTime { } date => new Dictionary<string, object>
//            {
//                ["iso"] = date.ToString(MoralisService<TUser>.DateFormatStrings.First(), CultureInfo.InvariantCulture),
//                ["__type"] = "Date"
//            },
//            byte[] { } bytes => new Dictionary<string, object>
//            {
//                ["__type"] = "Bytes",
//                ["base64"] = Convert.ToBase64String(bytes)
//            },
//            ParseObject { } entity => EncodeObject(entity),
//            IJsonConvertible { } jsonConvertible => jsonConvertible.ConvertToJSON(),
//            { } when Conversion.As<IDictionary<string, object>>(value) is { } dictionary => dictionary.ToDictionary(pair => pair.Key, pair => Encode(pair.Value, serviceHub)),
//            { } when Conversion.As<IList<object>>(value) is { } list => EncodeList(list, serviceHub),

//            // TODO (hallucinogen): convert IParseFieldOperation to IJsonConvertible

//            IParseFieldOperation { } fieldOperation => fieldOperation.Encode(serviceHub),
//            _ => value
//        };

//        protected abstract IDictionary<string, object> EncodeObject(ParseObject value);

//        object EncodeList(IList<object> list, IServiceHub serviceHub)
//        {
//            List<object> encoded = new List<object> { };

//            // We need to explicitly cast `list` to `List<object>` rather than `IList<object>` because IL2CPP is stricter than the usual Unity AOT compiler pipeline.

//            if (ParseClient.IL2CPPCompiled && list.GetType().IsArray)
//            {
//                list = new List<object>(list);
//            }

//            foreach (object item in list)
//            {
//                if (!Validate(item))
//                {
//                    throw new ArgumentException("Invalid type for value in an array");
//                }

//                encoded.Add(Encode(item, serviceHub));
//            }

//            return encoded;
//        }
//    }
//}
