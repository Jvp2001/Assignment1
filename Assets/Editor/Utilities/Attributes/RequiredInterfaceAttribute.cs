using System;
using UnityEngine;

namespace Utilities.Attributes
{
    public class RequiredInterfaceAttribute : PropertyAttribute
    {
        public Type RequiredType { get; private set; }

        public RequiredInterfaceAttribute(Type requiredType)
        {
            RequiredType = requiredType;
        }
        
        
    }
}