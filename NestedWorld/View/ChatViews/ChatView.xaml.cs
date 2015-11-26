using NestedWorld.Classes.Chat;
using NestedWorld.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace NestedWorld.View.ChatViews
{
    public sealed partial class ChatView : UserControl
    {

        public static readonly DependencyProperty ChatNameProperty = DependencyProperty.Register("ChatName", typeof(string), typeof(ChatView), null);
        public static readonly DependencyProperty ChannelProperty = DependencyProperty.Register("Channel", typeof(ObservableCollection<Message>), typeof(ChatView), null);

        private Channel _channel;
        public Channel channel
        {
            get { return _channel; }
            set
            {
                _channel = value;
                SetValue(ChannelProperty, new ObservableCollection<Message>(value.messageList));
                SetValue(ChatNameProperty, value.chatName);
            }
        }

        public ChatView()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        private void TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter && (sender as TextBox).Text != "")
            {
                Debug.WriteLine((sender as TextBox).Text);
                channel?.Add(new Message((sender as TextBox).Text, DateTime.Now, eWho.ME));
                channel?.Add(new Message((sender as TextBox).Text, DateTime.Now, eWho.YOU));
                (sender as TextBox).Text = "";
                if (channel != null)
                    SetValue(ChannelProperty, new ObservableCollection<Message>(channel?.messageList));

            }
        }
    }
}
