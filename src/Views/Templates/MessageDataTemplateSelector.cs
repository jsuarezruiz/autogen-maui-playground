#nullable disable
using AutoGenMauiPlayground.Models;

namespace AutoGenMauiPlayground.Views.Templates
{
    internal class MessageDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate SenderMessageTemplate { get; set; }
        public DataTemplate ReceiverMessageTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var message = (Message)item;

            if (message.User is null)
                return SenderMessageTemplate;

            return ReceiverMessageTemplate;
        }
    }
}
