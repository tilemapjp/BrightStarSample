using System;

using Xamarin.Forms;
using System.Reactive.Linq;

namespace BrightStarSample
{
    public class App : Application
    {
        static PersonDataBase database;

        public static PersonDataBase Database
        {
            get
            {
                if ( database == null )
                {
                    database = new PersonDataBase();
                }
                return database;
            }
        }

        public App()
        {
            var nameEntry  = new Entry { Placeholder = "名前を入力" };
            var ageEntry   = new Entry { Placeholder = "年齢を入力(数値のみ)" };
            var saveButton = new Button { Text = "保存" };
            var loadButton = new Button { Text = "読み出し" };

            saveButton.Clicked += (sender, e) => 
            {
                var person = new Person();
                person.Name = nameEntry.Text;
                person.Age  = Convert.ToInt16(ageEntry.Text);

                App.Database.SaveItem(person);
            };

            loadButton.Clicked += (sender, e) => 
            {
                var name = nameEntry.Text;
                var loaded = Database.GetItem(name);
                if (loaded == null) {
                    nameEntry.Text = "";
                    ageEntry.Text = "";
                } else {
                    ageEntry.Text = loaded.Age.ToString();
                }
            };
                
            // The root page of your application
            MainPage = new ContentPage
            {
                Padding = new Thickness(20),
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                        nameEntry,
                        ageEntry,
                        saveButton,
                        loadButton
                    }
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

