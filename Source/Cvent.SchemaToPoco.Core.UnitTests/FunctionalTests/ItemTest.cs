﻿using NUnit.Framework;

namespace Cvent.SchemaToPoco.Core.UnitTests.FunctionalTests
{
    [TestFixture]
    public class ItemTest : BaseTest
    {
        [Test]
        public void TestBasic()
        {
            const string schema = @"{
    '$schema': 'http://json-schema.org/draft-03/schema#',
    'type' : 'object',
    'properties' : {
        'foo' : {
            'type' : 'array',
            'items' : {
                'type' : 'string'
            }
        }
    }
}";
            const string correctResult = @"namespace generated
{
    using System;
    using System.Collections.Generic;

    public class DefaultClassName
    {

        private List<string> _foo;

        public virtual List<string> Foo
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

            TestBasicEquals(correctResult, JsonSchemaToPoco.Generate(schema));
        }
    }
}
