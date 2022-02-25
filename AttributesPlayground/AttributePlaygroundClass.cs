using System;
using System.Collections.Generic;
using System.Text;

namespace AttributesPlayground
{
    
    internal class AttributePlaygroundClass
    {
    }

    sealed class TestAttribute:Attribute
    {
        
    }
    [TestAttribute]
    public class MyTestAttribute
    {

    }

}
