using Cvent.SchemaToPoco.Core.Types;
using NUnit.Framework;

namespace Cvent.SchemaToPoco.Core.UnitTests.FunctionalTests.DraftV4.JSONAttibutes
{
    [TestFixture]
    public class RequiredTestV4 : BaseTest
    {
        [Test]
        public void TestBasic()
        {
            const string schema = @"{
    '$schema': 'http://json-schema.org/draft-04/schema#',
    'type' : 'object',
    'properties' : {
        'foo' : {
            'type' : 'string'
        }
    },
    'required' : ['foo']
}";
            const string correctResult = @"namespace generated
{
    using System;
    using System.ComponentModel.DataAnnotations;


    public class DefaultClassName
    {

        private string _foo;

        [JsonProperty(Required=Required.Always)]
        public virtual string Foo
        {
            get
            {
                return _foo;
            }
            set
            {
                _foo = value;
            }
        }
    }
}";

            TestBasicEquals(correctResult, JsonSchemaToPoco.Generate(schema, "generated", AttributeType.JsonDotNet));
        }
    }
}
