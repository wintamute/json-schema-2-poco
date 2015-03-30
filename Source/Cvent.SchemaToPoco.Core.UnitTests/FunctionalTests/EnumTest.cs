﻿using NUnit.Framework;

namespace Cvent.SchemaToPoco.Core.UnitTests.FunctionalTests
{
    [TestFixture]
    public class EnumTest : BaseTest
    {
        [Test]
        public void TestBasic()
        {
            const string schema = @"{
    '$schema': 'http://json-schema.org/draft-03/schema#',
    'type' : 'object',
    'properties' : {
        'foo' : {
            'type' : 'object',
            'enum' : ['one', '2two2', 'Three_ _third_']
        }
    }
}";
            const string correctResult = @"namespace generated
{
    using System;


    public enum Foo
    {

        One,

        _2two2,

        Three__third_,
    }

    public class DefaultClassName
    {
    }
}";

            TestBasicEquals(correctResult, JsonSchemaToPoco.Generate(schema));
        }
    }
}
