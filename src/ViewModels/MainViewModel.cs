#nullable disable
using AutoGen.Core;
using AutoGenMauiPlayground.AutoGen;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AutoGenMauiPlayground.ViewModels
{
    public class MainViewModel : BindableObject
    {
        string _prompt;
        ObservableCollection<Models.Message> _messages;
        bool _isLoading;

        public MainViewModel()
        {
            Messages = new ObservableCollection<Models.Message>();
        }

        public string Prompt
        {
            get => _prompt;
            set
            {
                _prompt = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Models.Message> Messages
        {
            get => _messages;
            set
            {
                _messages = value;
                OnPropertyChanged();
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public ICommand SendCommand => new Command(async () =>
        {
            if (string.IsNullOrWhiteSpace(Prompt))
                return;

            await AskForAppCodeAsync(Prompt);
        });

        public async Task AskForAppCodeAsync(string prompt)
        {
            try
            {
                IsLoading = true;

                Messages.Add(new Models.Message(prompt));

                var response = await AutoGenChatWorkflow.ExecuteAsync(prompt);

                Messages.Add(new Models.Message(response.GetContent(), response.From));
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}