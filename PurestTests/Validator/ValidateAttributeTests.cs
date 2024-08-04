using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purest;
using Purest.Validate;

namespace Purest.Tests;

[TestClass]
public class ValidateAttributeTests
{
    TestClass? target;

    [TestInitialize]
    public void SetUp()
    {
        target = new TestClass();
    }

    [TestMethod()]
    public void ValidateTest()
    {
        var result = Validator.Validate(target!).ToArray();

        Assert.IsTrue((result?.Length ?? 0) == 2);
    }
}

public class TestClass
{
    [NotNull]
    public int? Result { get; set; }

    [Range(10, 200)]
    public int? Value { get; set; } = 100;
}
