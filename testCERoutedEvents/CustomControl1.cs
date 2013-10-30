using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace testCERoutedEvents
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:testCERoutedEvents"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:testCERoutedEvents;assembly=testCERoutedEvents"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    public class CustomControl1 : Control
    {
        //public static readonly RoutedEvent ColorChangedEvent;
        // Declare the event using EventHandler<T>
        public event EventHandler<EventArgs> RaiseCustomControlEvent;
        //public void OnMyRaiseEvent(object sender, EventArgs e);
        
        static CustomControl1()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomControl1) , new FrameworkPropertyMetadata(typeof(CustomControl1)));                                       
        }

        

        //public void DoSomething()
        //{
        //    // Write some code that does something useful here
        //    // then raise the event. You can also raise an event
        //    // before you execute a block of code.
        //    OnRaiseCustomControlEvent(new CustomControlEventArgs("Did something"));

        //}
        //private Storyboard theStoryboard;
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var theStoryboard = this.GetTemplateChild("mySB") as Storyboard;
            if(theStoryboard != null)
               theStoryboard.Completed += this.OnMyRaiseEvent;
            //Button theButton = GetTemplateChild("myButton") as Button;
            //if (theButton != null)
            //    MessageBox.Show(@"theButton is not null.");
            //theStoryboard.Completed += new EventHandler(OnMyRaiseEvent);
        }

        public void OnMyRaiseEvent(object sender,EventArgs e)
        {
            EventHandler<EventArgs> handler = RaiseCustomControlEvent;
            MessageBox.Show(@"I'm in Customer Control 1");
            // Event will be null if there are no subscribers
            if (handler != null)
            {
                // Format the string to send inside the CustomEventArgs parameter
                //e.Message += String.Format(" at {0}" , DateTime.Now.ToString());

                // Use the () operator to raise the event.
                MessageBox.Show(@"I'm in Customer Control");
                handler(sender, e);
            }
        }

        public void OnMyRaiseEvent1(object sender, EventArgs e)
        {
            MessageBox.Show(@"I'm in Customer Control 2");
        }

        // Wrap event invocations inside a protected virtual method
        // to allow derived classes to override the event invocation behavior
        //protected virtual EventHandler<EventArgs> OnRaiseCustomControlEvent(object sender , EventArgs e)
        //{
        //    // Make a temporary copy of the event to avoid possibility of
        //    // a race condition if the last subscriber unsubscribes
        //    // immediately after the null check and before the event is raised.
        //    EventHandler<EventArgs> handler = RaiseCustomControlEvent;

        //    // Event will be null if there are no subscribers
        //    if (handler != null)
        //    {
        //        // Format the string to send inside the CustomEventArgs parameter
        //        //e.Message += String.Format(" at {0}" , DateTime.Now.ToString());

        //        // Use the () operator to raise the event.
        //        handler(this , e);
        //    }

        //    return handler;
        //}

    }

    // Define a class to hold custom event info
    //public class CustomControlEventArgs : EventArgs
    //{
    //    public CustomControlEventArgs(string s)
    //    {
    //        message = s;
    //    }
    //    private string message;

    //    public string Message
    //    {
    //        get { return message; }
    //        set { message = value; }
    //    }
    //}
}
