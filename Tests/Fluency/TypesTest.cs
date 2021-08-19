﻿using System;
using System.Numerics;
using FluentAssertions;
using HonkSharp.Fluency;
using HonkSharp.Functional;
using Xunit;

namespace Tests
{
    public class TypesTest
    {
        [Fact] public void InvertTest1() => true.IsFalse().Should().Be(false);

        [Fact] public void ParseTest1()
            => Assert.Throws<WorstHappenedException>(
                () => "ss".Dangerous().Try<FormatException, int>(int.Parse).AssumeBest());
        
        [Fact] public void ParseTest2()
            => "55".Dangerous().Try<FormatException, int>(int.Parse).AssumeBest().Should().Be(55);
        
        [Fact] public void AssumeBest1()
            => new Either<int, Failure>(5).AssumeBest().Should().Be(5);
        
        [Fact] public void AssumeBest2()
            => new Either<Failure, int>(5).AssumeBest().Should().Be(5);
        
        [Fact] public void AssumeBest3()
            => new Either<int, Failure<string>>(5).AssumeBest().Should().Be(5);
        
        [Fact] public void AssumeBest4()
            => new Either<Failure<string>, int>(5).AssumeBest().Should().Be(5);
        
        [Fact] public void AssumeBest5()
            => ((int?)5).AssumeBest().Should().Be(5);
            
        [Fact] public void ParseTestByte() => "125".Parse<byte>().AssumeBest().Should().Be(125);
        [Fact] public void ParseTestSByte() => "125".Parse<sbyte>().AssumeBest().Should().Be(125);
        [Fact] public void ParseTestUshort() => "48000".Parse<ushort>().AssumeBest().Should().Be(48000);
        [Fact] public void ParseTestShort() => "10101".Parse<short>().AssumeBest().Should().Be(10101);
        [Fact] public void ParseTestInt() => "13919839".Parse<int>().AssumeBest().Should().Be(13919839);
        [Fact] public void ParseTestUInt() => "13919839".Parse<uint>().AssumeBest().Should().Be(13919839);
        [Fact] public void ParseTestLong() => "1391983913919".Parse<long>().AssumeBest().Should().Be(1391983913919);
        [Fact] public void ParseTestULong() => "1391983913919".Parse<ulong>().AssumeBest().Should().Be(1391983913919);
        [Fact] public void ParseTestFloat() => "1.3".Parse<float>().AssumeBest().Should().Be(1.3f);
        [Fact] public void ParseTestDouble() => "1.313131".Parse<double>().AssumeBest().Should().Be(1.313131);
        [Fact] public void ParseTestDecimal() => "1.313131".Parse<decimal>().AssumeBest().Should().Be(1.313131m);
        [Fact] public void ParseTestBigInteger() 
            => "2384982374538274982374823794872894".Parse<BigInteger>().AssumeBest()
                .Should().Be(BigInteger.Parse("2384982374538274982374823794872894"));
        
        [Fact] public void StringJoin1()
            => ",".Join(new[]{ 1, 2 }).Should().Be("1,2");
        [Fact] public void StringJoin2()
            => ",".Join(new[]{ 1, 2, 3 }).Should().Be("1,2,3");
        [Fact] public void StringJoin3()
            => ",".Join(new[]{ "1", "2", "3" }).Should().Be("1,2,3");
        [Fact] public void StringJoin4()
            => ", ".Join(new[]{ "1", "2", "3" }).Should().Be("1, 2, 3");
        [Fact] public void StringJoin5()
            => ";".Join(new[]{ "1" }).Should().Be("1");
        [Fact] public void StringJoin6()
            => ",".Join(new string[]{ }).Should().Be("");
        [Fact] public void StringJoin7()
            => "".Join(new[]{ "1", "2", "3", "4" }).Should().Be("1234");
        [Fact] public void StringJoin8()
            => "; ".Join("quack").Should().Be("q; u; a; c; k");
        
        
        [Fact] public void AsString1()
            => new[]{ 'a', 'b', 'c' }.AsString().Should().Be("abc");
        
        [Fact] public void AsString2()
            => new[]{ 'a' }.AsString().Should().Be("a");
        
        [Fact] public void AsString3()
            => new char[]{ }.AsString().Should().Be("");
    }
}