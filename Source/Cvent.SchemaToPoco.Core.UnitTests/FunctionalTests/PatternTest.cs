﻿using NUnit.Framework;

namespace Cvent.SchemaToPoco.Core.UnitTests.FunctionalTests
{
    [TestFixture]
    public class PatternTest : BaseTest
    {
        [Test]
        public void TestBasic()
        {
            const string schema = @"{
    '$schema': 'http://json-schema.org/draft-03/schema#',
    'type' : 'object',
    'properties' : {
        'foo' : {
            'type' : 'string',
            'description' : 'Match the regex \\\""dev\""\'[a-c] ',
            'pattern' : '^\\\""dev\""\'[a-c]\\s$'
        }
    }
}";
            const string correctResult = @"namespace generated
{
    using System;
    using System.ComponentModel.DataAnnotations;


    public class DefaultClassName
    {

        // Match the regex ""dev""'[a-c]
        private string _foo;

        // Match the regex ""dev""'[a-c]
        [RegularExpression(@""^\\\""""dev\""""\'[a-c]\s$"")]
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

            TestBasicEquals(correctResult, JsonSchemaToPoco.Generate(schema));
        }
    }
}
