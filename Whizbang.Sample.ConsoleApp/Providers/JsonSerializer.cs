using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Whizbang.Core;
using Whizbang.Core.Serializer;

namespace Whizbang.Sample.ConsoleApp.Providers
{
    public class JsonSerializer : IObjectSerializer<string>
    {
        private readonly ITypeResolver _typeResolver;

        public JsonSerializer()
        {
            _typeResolver = App.Container.Resolve<ITypeResolver>();
        }

        public object Deserialize(string val, string typeName)
        {
            var type = _typeResolver.Resolve(typeName);

            return JsonConvert.DeserializeObject(val, type);
        }

        public string Serialize(object obj, out string typeName)
        {
            typeName = _typeResolver.NameFor(obj.GetType());

            return JsonConvert.SerializeObject(obj);
        }
    }
}
