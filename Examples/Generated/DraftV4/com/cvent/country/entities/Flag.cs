//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace com.cvent.country.entities
{
    using System;
    using System.Collections.Generic;
    
    
    // Used as the symbol or emblem of a country
    public class Flag
    {
        
        // Colors seen on the flag
        private List<string> _colors;
        
        // Colors seen on the flag
        public virtual List<string> Colors
        {
            get
            {
                return _colors;
            }
            set
            {
                _colors = value;
            }
        }
    }
}