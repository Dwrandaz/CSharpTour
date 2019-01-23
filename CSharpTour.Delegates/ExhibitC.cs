using System;
using System.Threading;
using System.Timers;

namespace CSharpTour.Delegates
{
    public class ExhibitC
    {
        public static void Run()
        {
            var chef = new Chef();
            chef.ItsTimeForFood += Celebrate;
            chef.StartDay();

            // Wait for the events
            Thread.Sleep(Timeout.Infinite);
        }

        public static void Celebrate(object sender, FoodTimeEventArgs e)
        {
            Console.WriteLine($"Its time for {e.Meal}!");
        }

        public class FoodTimeEventArgs : EventArgs
        {
            public FoodTimeEventArgs(string meal)
            {
                Meal = meal;
            }

            public string Meal { get; }
        }

        public class Chef
        {
            private string[] _meals = { "Breakfast", "Lunch", "Dinner" };
            private int _currentMeal = 0;
            private System.Timers.Timer _timer;

            public Chef()
            {
                _timer = new System.Timers.Timer(1000);
                _timer.Elapsed += RaiseEvent;
            }

            public void StartDay()
            {
                _timer.Start();
            }

            public event EventHandler<FoodTimeEventArgs> ItsTimeForFood;

            public void RaiseEvent(object s, ElapsedEventArgs elapsed)
            {
                if (_currentMeal >= _meals.Length)
                {
                    _timer.Stop();
                }

                ItsTimeForFood?.Invoke(this, new FoodTimeEventArgs(_meals[_currentMeal]));

                _currentMeal++;
            }
        }
    }
}