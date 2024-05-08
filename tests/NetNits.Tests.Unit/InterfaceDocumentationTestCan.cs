using System.Xml;
using FluentAssertions;
using TestProject1;
using TestProject1.CompleteInterfaces;
using TestProject1.IncompleteInterfaces;

namespace NetNits.Tests.Unit;

public static class InterfaceDocumentationTestCan
{

    public static bool ContainSummaryDocumentation(this Type interfaceToCheck)
    {
        try
        {
            //get methods for interface
            var methods = interfaceToCheck.GetMethods();
            var xmlPath = Path.ChangeExtension(methods[0].Module.FullyQualifiedName, "xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);
        
            foreach (var method in methods)
            {

                var docElement = doc.DocumentElement;
                docElement.Should().NotBeNull();
                var parameters = method.GetParameters();
                var paramTypes = string.Join(",", parameters.Select(x => x.ParameterType.ToString()).ToArray());
                var methodName = $"M:{interfaceToCheck.FullName}.{method.Name}({paramTypes})";
                XmlNode node = docElement?.SelectSingleNode($"/doc/members/member[@name='{methodName}']")!;
                var summary = node.SelectSingleNode("summary");
                summary.Should().NotBeNull();
                summary.InnerText.Should().NotBeNullOrWhiteSpace();
                
            }

            return true;
        }
        catch (Exception)
        {
            //expect this exception to be thrown
            return false;
        }
    }
    
    public static bool ContainParameterDocumentation(this Type interfaceToCheck)
    {
        try
        {
            //get methods for interface
            var methods = interfaceToCheck.GetMethods();
            var xmlPath = Path.ChangeExtension(methods[0].Module.FullyQualifiedName, "xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);
        
            foreach (var method in methods)
            {

                var docElement = doc.DocumentElement;
                docElement.Should().NotBeNull();
                var parameters = method.GetParameters();
                var paramTypes = string.Join(",", parameters.Select(x => x.ParameterType.ToString()).ToArray());
                var methodName = $"M:{interfaceToCheck.FullName}.{method.Name}({paramTypes})";
                XmlNode node = docElement?.SelectSingleNode($"/doc/members/member[@name='{methodName}']")!;

                foreach (var parameter in parameters)
                {
                    var parameterDocumentation = node.SelectSingleNode($"param[@name='{parameter.Name}']");
                    parameterDocumentation.Should().NotBeNull();
                    parameterDocumentation.InnerText.Should().NotBeNullOrWhiteSpace();
                }
            }

            return true;
        }
        catch (Exception)
        {
            //expect this exception to be thrown
            return false;
        }
    }
    public static bool ContainReturnDocumentation(this Type interfaceToCheck)
    {
        try
        {
            //get methods for interface
            var methods = interfaceToCheck.GetMethods();
            var xmlPath = Path.ChangeExtension(methods[0].Module.FullyQualifiedName, "xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);
        
            foreach (var method in methods)
            {

                var docElement = doc.DocumentElement;
                docElement.Should().NotBeNull();
                var parameters = method.GetParameters();
                var paramTypes = string.Join(",", parameters.Select(x => x.ParameterType.ToString()).ToArray());
                var methodName = $"M:{interfaceToCheck.FullName}.{method.Name}({paramTypes})";
                XmlNode node = docElement?.SelectSingleNode($"/doc/members/member[@name='{methodName}']")!;
                var returnDoc = node.SelectSingleNode("returns");
                var text = returnDoc.InnerText;
                returnDoc.Should().NotBeNull();
                returnDoc.InnerText.Should().NotBeNullOrWhiteSpace();
                
            }

            return true;
        }
        catch (Exception)
        {
            //expect this exception to be thrown
            return false;
        }
    }
    
    
    [Fact]
    public static void Detect_Missing_Summary_Documentation()
    {
        typeof(ICalculator).ContainSummaryDocumentation().Should().BeTrue();
        typeof(ICalculator1).ContainSummaryDocumentation().Should().BeTrue();
        typeof(ICalculator2).ContainSummaryDocumentation().Should().BeFalse();
        typeof(ICalculator3).ContainSummaryDocumentation().Should().BeTrue();
    }
    
    [Fact]
    public static void Detect_Missing_Parameter_Documentation()
    {
        typeof(ICalculator).ContainParameterDocumentation().Should().BeTrue();
        typeof(ICalculator1).ContainParameterDocumentation().Should().BeFalse();
        typeof(ICalculator2).ContainParameterDocumentation().Should().BeFalse();
        typeof(ICalculator3).ContainParameterDocumentation().Should().BeTrue();
        typeof(ICalculator4).ContainParameterDocumentation().Should().BeFalse();
        typeof(ICalculator5).ContainParameterDocumentation().Should().BeFalse();
    }
    [Fact]
    public static void Detect_Missing_Return_Documentation()
    {
        typeof(ICalculator).ContainReturnDocumentation().Should().BeTrue();
        // typeof(ICalculator1).ContainReturnDocumentation().Should().BeFalse();
        // typeof(ICalculator2).ContainReturnDocumentation().Should().BeFalse();
        // typeof(ICalculator3).ContainReturnDocumentation().Should().BeFalse();
        // typeof(ICalculator4).ContainReturnDocumentation().Should().BeFalse();
        // typeof(ICalculator5).ContainReturnDocumentation().Should().BeFalse();
        // typeof(ICalculator6).ContainReturnDocumentation().Should().BeFalse();
        // typeof(ICalculator7).ContainReturnDocumentation().Should().BeFalse();
    }
}