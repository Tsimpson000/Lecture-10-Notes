
//What does a DateTime object represent ( in terms of time )

//year, month, and day

//What does TimeSpan describe ( in terms of time )

//the difference between two dates

//How do you get the time RIGHT NOW with DateTime?

//DateTime.Now

//What kind of math do you have to do to get the result in years with TimeSpan?

//TimeSpan differenceInDays / 365.25

//If given a DateTime object of 01/01/2023 and another with 01/01/2023, get a TimeSpan and do the math to get a result of 13

//DateTime objectOne = now.AddDays(13);
//TimeSpan result = objectOne - objectTwo
//runDisplay.Text = result.Days.ToString();

//What is the key difference between the DatePicker and the Calander ( similar to the combo box and list box )

//DatePicker shows one date while Calendar shows a calendar and a range of dates

//DatePicker and Calander have two important properties, which are they
//Property 1: You use it to get the users selected value from the time picker

//.SelectedDate

//Property 2: You use this to make sure the time picker has a selected value

//.HasValue



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

namespace Lecture_10_Notes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int ageToDrive = 16;
        const int ageToVote = 18;
        const int ageToDrink = 21;
        public MainWindow()
        {
            InitializeComponent();
            BlogPost bp = new BlogPost("Header 1", "Body 1");
            runDisplay.Text = bp.ToString();

            //create new DateTime variable
            DateTime date = new DateTime();
            //create new DateTime variable of current time
            DateTime now = DateTime.Now;

            //Only displays current hours/minutes
            string shortTime = now.ToShortTimeString();
            //same as short time but with seconds
            string longTime = now.ToLongTimeString();

            
            string formatString = $"" +
                $"Short Time: {shortTime}\n" +
                 $"Long Time: {longTime}\n" +
                 $"Short Day: {now.ToShortDateString()}\n" +
                 $"Long Day: {now.ToLongDateString()}\n" +
                 $"Year: {now.Year}\n" +
                 $"Day of week: {now.DayOfWeek}";

            DateTime nowPlus7Months = now.AddMonths(7);

            TimeSpan differenceInDaysFor7Months = nowPlus7Months - now;


            //runDisplay.Text = formatString;
        }

        private void btnDisplayTime_Click(object sender, RoutedEventArgs e)
        {
            DateTime birthday = BirthdayObject();
            runDisplay.Text = $"Your birthday is {birthday}";
        }
        
        public DateTime BirthdayObject()
        {
            int day = int.Parse(txtDay.Text);
            int month = int.Parse(txtMonth.Text);
            int year = int.Parse(txtYear.Text);

            return new DateTime(year, month, day);
        }

        private void btnAgeCheck_Click(object sender, RoutedEventArgs e)
        {
            DateTime birthday = BirthdayObject();
            DateTime now = DateTime.Now;

            TimeSpan ageInDays = now - birthday;
            int age = (int)(ageInDays.Days / 365.25);

            runDisplay.Text = $"You are {age.ToString()} old.\n";

            if (age >= ageToDrive)
            {
                runDisplay.Text = $"You are old enough to drive\n";

            }

            if (age >= ageToVote)
            {
                runDisplay.Text = $"You are old enough to vote\n";

            }

            if (age >= ageToDrink)
            {
                runDisplay.Text = $"You are old enough to drink\n";

            }


        }

        private void btnResults_Click(object sender, RoutedEventArgs e)
        {
            bool calendarDateSelected = calDate.SelectedDate.HasValue;
            DateTime timeSelected = DateTime.Now;
            if (calendarDateSelected)
            {
                timeSelected = calDate.SelectedDate.Value;
            }
            runDisplay.Text = timeSelected.ToString();
        }
    }
}
