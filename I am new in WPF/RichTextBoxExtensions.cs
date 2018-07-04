using System;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace I_am_new_in_WPF
{
    public static class RichTextBoxExtensions
    {
        public static void InsertIntoCaretPosition(this RichTextBox box, string text, string color)
        {
            BrushConverter converter = new BrushConverter();
            TextRange range = new TextRange(box.CaretPosition, box.CaretPosition);
            range.Text = text;
            try
            {
                range.ApplyPropertyValue(TextElement.ForegroundProperty,
                    converter.ConvertFromString(color));
            }
            catch (FormatException) {/*Nothing. If error, just set property to default (solid black brush)*/ }

            box.RunNextPosition(LogicalDirection.Forward, text.Length);
        }

        public static void AppendText(this RichTextBox box, string text, string color)
        {
            BrushConverter converter = new BrushConverter();
            TextRange range = new TextRange(box.Document.ContentEnd, box.Document.ContentEnd);
            range.Text = text;
            try
            {
                range.ApplyPropertyValue(TextElement.ForegroundProperty,
                    converter.ConvertFromString(color));
            }
            catch (FormatException) {/*Nothing. If error, just set property to default (solid black brush)*/ }
            
            box.RunNextPosition(LogicalDirection.Forward, text.Length);
        }

        public static void Clear(this RichTextBox box)
        {
            box.Document.Blocks.Clear();
        }

        public static void PerformBackspace(this RichTextBox box)
        {
            var range = box.CaretPosition.GetPositionAtOffset(1,LogicalDirection.Backward);
            range.DeleteTextInRun(1);
            
            box.RunNextPosition(LogicalDirection.Backward);
        }

        public static void RunNextPosition(this RichTextBox box, LogicalDirection direction = LogicalDirection.Forward, int count = 1)
        {
            box.CaretPosition = box.CaretPosition.GetPositionAtOffset(count, direction);
        }


    }
}
