using System.Windows.Documents;
using System.Windows.Markup;

namespace ViewModel.Services;

public static class StringToFlowDocumentConverter
{
    public static FlowDocument ToFlowDocument(string xmlString)
    {
        var result = new FlowDocument();

        if (!string.IsNullOrEmpty(xmlString))
        {
            result.Blocks.Add((Section)XamlReader.Parse(xmlString));
        }

        return result;        
    }
}