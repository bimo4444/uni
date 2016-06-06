using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using uni.Views;
using uni.ViewModels;
using UniEngine;
using System.Windows.Input;
using System.Windows.Threading;
using System.ComponentModel;
using DialogBase;
using System.Windows.Controls;
using MVPLight;
using Entities;

namespace uni
{
    class Presenter
    {
        public event EventHandler PropertyChanged;

        MainWindow mainWindow = new MainWindow();
        MainViewModel mainViewModel = new MainViewModel();

        PhoneBook phoneBook = new PhoneBook();
        PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();

        FirstView firstView = new FirstView();
        FirstViewModel firstViewModel = new FirstViewModel();

        ErrorView errorView = new ErrorView();
        ErrorViewModel errorViewModel = new ErrorViewModel();

        Engine engine = new Engine();

        public Presenter()
        {
            Bindings();
            SetViewModels();
            SetFirstView();
            ShowMainWindow();
            SubscribeVMChanges();
        }
        private void ShowPhoneBook()
        {
            mainViewModel.CursorState = Cursors.Wait;
            Task.Factory.StartNew(() => { phoneBookViewModel.Employees = engine.GetEmployees(); }).Wait();
            mainViewModel.CursorState = Cursors.Arrow;
            mainViewModel.CurrentView = phoneBook;
        }
        Dialog dialog;
        DialogView dv = new DialogView();
        private bool ShowDialog(string text)
        {
            if (dialog == null)
                dialog = new Dialog(dv);

            mainViewModel.CurrentView = dv;
            dialog.Show(text);

            return dialog.result ?? false;
        }

        private void SubscribeVMChanges()
        {
            firstViewModel.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "NewValue" || e.PropertyName == "OldValues")
            {
                EventHandler handler = PropertyChanged;
                if (handler != null)
                    handler(this, EventArgs.Empty);
            }
        }

        private void Bindings()
        {
            firstViewModel.Union = new RelayCommand(
                Union, ref PropertyChanged, (() => firstViewModel.OldValues != null && firstViewModel.NewValue != null && firstViewModel.OldValues != "" && firstViewModel.NewValue != ""));
            firstViewModel.Return = new RelayCommand(
                ReturnDeleted, ref PropertyChanged, (() => firstViewModel.OldValues != null && firstViewModel.OldValues != ""));
            firstViewModel.Ways = new RelayCommand(
                DeleteWays, ref PropertyChanged, (() => firstViewModel.OldValues != null && firstViewModel.OldValues != ""));
            errorViewModel.Back = new DelegateCommand(GoBack);
            firstViewModel.ShowPhoneBook = new DelegateCommand(() => ShowPhoneBook());
            phoneBookViewModel.Back = new DelegateCommand(() => mainViewModel.CurrentView = firstView);
            phoneBookViewModel.Copy = new DelegateCommand(() => Clipboard.SetText(phoneBook.gridControl.GetFocusedValue().ToString()));
        }
        private void GoBack()
        {
            mainViewModel.CurrentView = firstView;
        }

        private void SetViewModels()
        {
            mainWindow.DataContext = mainViewModel;
            firstView.DataContext = firstViewModel;
            phoneBook.DataContext = phoneBookViewModel;
            errorView.DataContext = errorViewModel;
        }

        private void SetFirstView()
        {
            mainViewModel.CurrentView = firstView;
        }

        private void ShowMainWindow()
        {
            mainWindow.Show();
        }
          
        private void Union()
        {
            firstViewModel.Status = "";
            string s = engine.CheckGuidsEthic(true, false, firstViewModel.OldValues, firstViewModel.NewValue);
            if (s != "")
            {
                if (ShowDialog("Объеденить:\n" + s))
                {
                    mainViewModel.CursorState = Cursors.Wait;
                    int i = engine.Union(firstViewModel.OldValues, firstViewModel.NewValue);
                    mainViewModel.CursorState = Cursors.Arrow;
                    firstViewModel.Status = "Обработано: " + i;
                    GoBack();
                }
                else
                    GoBack();
            }
            else
            {
                ShowErrorView("Не удалось найти:\n" + firstViewModel.OldValues);
            }
        }
        private void DeleteWays()
        {
            firstViewModel.Status = "";
            string s = engine.CheckWaysDocuments(firstViewModel.OldValues);
            if (s != "")
            {
                if (ShowDialog("Удалить 'впути' по документам:\n" + s))
                {
                    mainViewModel.CursorState = Cursors.Wait;
                    int i = engine.DeleteWays(firstViewModel.OldValues);
                    mainViewModel.CursorState = Cursors.Arrow;
                    firstViewModel.Status = "Обработано: " + i;
                    GoBack();
                }
                else
                    GoBack();
            }
            else
            {
                ShowErrorView("Не удалось найти:\n" + firstViewModel.OldValues);
            }
        }
        private void ShowErrorView(string text)
        {
            errorViewModel.Text = text;
            mainViewModel.CurrentView = errorView;
        }
        private void ReturnDeleted()
        {
            firstViewModel.Status = "";
            string s = engine.CheckGuidsEthic(false, true, firstViewModel.OldValues);
            if (s != "")
            {
                if (ShowDialog("Вернуть:\n" + s))
                {
                    mainViewModel.CursorState = Cursors.Wait;
                    int i = engine.ReturnDeleted(firstViewModel.OldValues);
                    mainViewModel.CursorState = Cursors.Arrow;
                    firstViewModel.Status = "Обработано: " + i;
                    GoBack();
                }
                else
                    GoBack();
            }
            else
            {
                ShowErrorView("Не удалось найти:\n" + firstViewModel.OldValues);
            }
        }
    }
}
