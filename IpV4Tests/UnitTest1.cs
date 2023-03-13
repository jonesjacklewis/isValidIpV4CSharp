namespace IpV4Tests;

using IsValidIpV4;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    /*
     * All 0s --> True
     * All 255 --> True
     * Valid IP Address --> True
     * Length < 4 --> False
     * Length > 4 --> False
     * Alphanumeric --> False
     * Alphabetic --> False
     * Contains Padding --> False
     * Octet Starts With Leading 0 --> False
     */

    [Test]
    public void Given_FourOctetsOfAllZero_ShouldBeTrue()
    {
        Assert.That(Program.IsValidIpV4("0.0.0.0"), Is.True);
    }

    [Test]
    public void Given_FourOctetsOfAll255_ShouldBeTrue()
    {
        Assert.That(Program.IsValidIpV4("255.255.255.255"), Is.True);
    }

    [Test]
    public void Given_ValidIpV4_ShouldBeTrue()
    {
        Assert.That(Program.IsValidIpV4("128.55.25.255"), Is.True);
    }

    [Test]
    public void Given_LessThanFourOctets_ShouldBeFalse()
    {
        Assert.That(Program.IsValidIpV4("55.25.255"), Is.False);
    }

    [Test]
    public void Given_MoreThanFourOctets_ShouldBeFalse()
    {
        Assert.That(Program.IsValidIpV4("55.25.255.127.128"), Is.False);
    }

    [Test]
    public void Given_AlphanumericOctets_ShouldBeFalse()
    {
        Assert.That(Program.IsValidIpV4("55.25.255.abc"), Is.False);
    }

    [Test]
    public void Given_AlphabeticOctets_ShouldBeFalse()
    {
        Assert.That(Program.IsValidIpV4("abc.def.ghi.jkl"), Is.False);
    }

    [Test]
    public void Given_OctetContainsPadding_ShouldBeFalse()
    {
        Assert.That(Program.IsValidIpV4("128.0.0. 0"), Is.False);
    }

    [Test]
    public void Given_OctetHadLeadingZero_ShouldBeFalse()
    {
        Assert.That(Program.IsValidIpV4("128.0.0.015"), Is.False);
    }
}
