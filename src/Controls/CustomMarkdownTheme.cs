using Drastic.Markdown;

namespace AutoGenMauiPlayground.Controls
{
    public class CustomMarkdownTheme : MarkdownTheme
    {
        public static readonly Color DefaultBackgroundColor = Color.FromArgb("#242424");

        public CustomMarkdownTheme()
        {
            BackgroundColor = DefaultBackgroundColor;
            Paragraph.ForegroundColor = DefaultTextColor;
            Heading1.ForegroundColor = DefaultTextColor;
            Heading1.BorderColor = DefaultSeparatorColor;
            Heading2.ForegroundColor = DefaultTextColor;
            Heading2.BorderColor = DefaultSeparatorColor;
            Heading3.ForegroundColor = DefaultTextColor;
            Heading4.ForegroundColor = DefaultTextColor;
            Heading5.ForegroundColor = DefaultTextColor;
            Heading6.ForegroundColor = DefaultTextColor;
            Link.ForegroundColor = DefaultAccentColor;
            Code.ForegroundColor = DefaultTextColor;
            Code.BackgroundColor = DefaultCodeBackground;
            Quote.ForegroundColor = DefaultQuoteTextColor;
            Quote.BorderColor = DefaultQuoteBorderColor;
            Separator.BorderColor = DefaultSeparatorColor;
        }

        public static readonly Color DefaultAccentColor = Color.FromArgb("#512BD4");

        public static readonly Color DefaultTextColor = Color.FromArgb("#FFFFFF");

        public static readonly Color DefaultCodeBackground = Color.FromArgb("#AC99EA");

        public static readonly Color DefaultSeparatorColor = Color.FromArgb("#E1E1E1");

        public static readonly Color DefaultQuoteTextColor = Color.FromArgb("#919191");

        public static readonly Color DefaultQuoteBorderColor = Color.FromArgb("#C8C8C8");
    }
}