//using Moralis.Platform.Objects;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Moralis.Platform.Services.Infrastructure
//{
//    public class PointerOrLocalIdEncoder : DataEncoder
//    {
//        public static PointerOrLocalIdEncoder Instance { get; } = new PointerOrLocalIdEncoder { };

//        protected override IDictionary<string, object> EncodeObject(MoralisObject value)
//        {
//            if (value.objectId is null)
//            {
//                // TODO (hallucinogen): handle local id. For now we throw.

//                throw new InvalidOperationException("Cannot create a pointer to an object without an objectId.");
//            }

//            return new Dictionary<string, object>
//            {
//                ["__type"] = "Pointer",
//                ["className"] = value.ClassName,
//                ["objectId"] = value.objectId
//            };
//        }
//    }
//}
