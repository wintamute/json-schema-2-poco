using NUnit.Framework;

namespace Cvent.SchemaToPoco.Core.UnitTests.FunctionalTests
{
    [TestFixture]
    public class ObjectTestV4 : BaseTest
    {
        [Test]
        public void TestBasic()
        {
            const string schema = @"{
    '$schema': 'http://json-schema.org/draft-04/schema#',
    'title': 'Product',
    'description': 'A product from Acmes catalog',
    'type': 'object',
    'properties': {
        'id': {
            'description': 'The unique identifier for a product',
            'type': 'integer'
        },
        'name': {
            'description': 'Name of the product',
            'type': 'string'
        },
        'price': {
            'type': 'number',
            'minimum': 0,
            'exclusiveMinimum': true
        },
        'tags': {
            'type': 'array',
            'items': {
                'type': 'string'
            },
            'minItems': 1,
            'uniqueItems': true
        },
        'dimensions': {
            'type': 'object',
            'properties': {
                'length': {'type': 'number'},
                'width': {'type': 'number'},
                'height': {'type': 'number'}
            },
            'required': ['length', 'width', 'height']
        }
    },
    'required': ['id', 'name', 'price']
}";
            const string correctResult = @"namespace generated
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Cvent.SchemaToPoco.Core.ValidationAttributes;
    using System.Collections.Generic;
    using generated;

    // A product from Acmes catalog
    public class Product
    {

        // The unique identifier for a product
        private int _id;

        // Name of the product
        private string _name;
        
        private double _price;
        
        private HashSet<string> _tags;

        private Dimensions _dimensions;
        
        // The unique identifier for a product
        [Required()]
        public virtual int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        
        // Name of the product
        [Required()]
        public virtual string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        [Required()]
        [MinValue(1)]
        public virtual double Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }
        
        [MinLength(1)]
        public virtual HashSet<string> Tags
        {
            get
            {
                return _tags;
            }
            set
            {
                _tags = value;
            }
        }

        public virtual Dimensions Dimensions
        {
            get
            {
                return _dimensions;
            }
            set
            {
                _dimensions = value;
            }
        }
    }
}";

            TestBasicEquals(correctResult, JsonSchemaToPoco.Generate(schema));
        }
    }
}
